using System;
using System.Drawing;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.IO;

using EventDraw._3d;

namespace EventDraw
{
    public partial class EditModelDlg : Form
    {
        private string _baseId;

        private ShapeInfo _modelInfo;
        private ShapeManager sManager;

        // 3D variables
        private Engine _engine;

        private EventDraw._3d.InputHandler inputHandler;
        private bool mouseLeftDown = false;
        private int mouseLastX = -1;
        private int mouseLastY = -1;
        private readonly float _sensitivity = 0.2f;

        private int _modelIndex;
        private ShapeInDoc _info;

        public EditModelDlg(ShapeManager sM, ShapeInDoc info)
        {
            InitializeComponent();

            sManager = sM;
            _baseId = info.BaseID;
            _modelInfo = sManager.getShapeInfo(this._baseId);

            _modelInfo.baseId = this._baseId;
            _info = info;

            cbx_model_path.Items.Add(new Store("Building Plan", @"Building Plan\Shapes", false));
            cbx_model_path.Items.Add(new Store("Custom", @"Custom\Shapes", false));
            cbx_model_path.Items.Add(new Store("Network", @"Network\Shapes", true));
            cbx_model_path.Items.Add(new Store("3DVG", @"3DVG", true));

            cbx_model_path.SelectedIndex = 0;

            btn_add_model.Enabled = false;
            btn_remove_model.Enabled = false;

        }

        private void InitialValues(ShapeInDoc info)
        {
            // Init Component
            this.lbl_model_type.Text = info.getName();

            // Width And Height
            this.lbl_width.Text = info.width.ToString();
            this.lbl_height.Text = info.height.ToString();
            this.lbl_aspect.Text = (info.width / info.height).ToString();


            // Set Scale Value
            this.ipt_scale_x.Value = (decimal)this._modelInfo.modelParams.scale.x;
            this.ipt_scale_y.Value = (decimal)this._modelInfo.modelParams.scale.y;
            this.ipt_scale_z.Value = (decimal)this._modelInfo.modelParams.scale.z;

            // Set Rotation
            this.ipt_rotation_x.Value = (decimal)this._modelInfo.modelParams.angle.x;
            this.ipt_rotation_y.Value = (decimal)this._modelInfo.modelParams.angle.y;
            this.ipt_rotation_z.Value = (decimal)this._modelInfo.modelParams.angle.z;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _engine = new Engine();

            this.render_panel.Load += Render_panel_Load;
            this.render_panel.Resize += Render_panel_Resize;
            this.render_panel.Paint += Render_panel_Paint;


            Render_panel_Resize(this.render_panel, EventArgs.Empty);


            inputHandler = new EventDraw._3d.InputHandler(render_panel);

            inputHandler.mouseDownListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = true);
            inputHandler.mouseUpListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = false);

            inputHandler.mouseMoved += (int x, int y) =>
            {
                if (mouseLastX != -1 && mouseLastY != -1)
                {
                    if (mouseLeftDown)
                    {
                        int deltaX = x - mouseLastX;
                        int deltaY = y - mouseLastY;

                        _engine._camera.Yaw += deltaX * _sensitivity;
                        _engine._camera.Pitch -= deltaY * _sensitivity;
                    }
                }

                mouseLastX = x;
                mouseLastY = y;

                this.render_panel.Invalidate();
            };

            inputHandler.mouseWheelMoved += (int delta) =>
            {
                _engine._camera.Zoom(delta);

                this.render_panel.Invalidate();
            };

            inputHandler.keyDownListeners.Add(Keys.W, (modifiy) => {
                _engine._camera.Forward();

                this.render_panel.Invalidate();
            });

            inputHandler.keyDownListeners.Add(Keys.S, (modifiy) => {
                _engine._camera.Backwards();

                this.render_panel.Invalidate();
            });

            inputHandler.keyDownListeners.Add(Keys.A, (modifiy) => {
                _engine._camera.LeftMove();

                this.render_panel.Invalidate();
            });

            inputHandler.keyDownListeners.Add(Keys.D, (modifiy) => {
                _engine._camera.RightMove();

                this.render_panel.Invalidate();
            });


            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);

            // Create Floor
            int floorHandle = _engine.CreateCube(new Color4(1.0f, 1.0f, 1.0f, 1.0f), (float)_info.width, (float)_info.height, 1);
            _engine.setRotate((float)Math.PI / 2, 0.0f, 0.0f, floorHandle);

            //Load Model
            var modelPath = _modelInfo.model.fileName;
            if (modelPath != "")
            {
                var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, modelPath);
                _modelIndex = _engine.OpenTexturedObj(
                    filePath + "." + Globals.ThisAddIn.defaultExtension,
                    filePath + "." + Globals.ThisAddIn.defaultExtension
                );
            }

            InitialValues(_info);
        }

        private void Render_panel_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color.CornflowerBlue);
        }

        private void Render_panel_Resize(object sender, EventArgs e)
        {
            this.render_panel.MakeCurrent();

            this.render_panel.MakeCurrent();

            if (this.render_panel.ClientSize.Height == 0)
                this.render_panel.ClientSize = new System.Drawing.Size(this.render_panel.ClientSize.Width, 1);
            GL.Viewport(0, 0, this.render_panel.ClientSize.Width, this.render_panel.ClientSize.Height);
        }

        private void Render_panel_Paint(object sender, PaintEventArgs e)
        {
            this.render_panel.MakeCurrent();
            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Enable(EnableCap.DepthTest);
            _engine.Render3DObjects();
            GL.Disable(EnableCap.DepthTest);

            this.render_panel.SwapBuffers();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            FileStore selectedModel = (FileStore)lbx_model.SelectedItem;
            if (selectedModel != null)
            {
                _modelInfo.model.fileName = selectedModel.path.Replace(Globals.ThisAddIn.RootPath + @"\", "");
                _modelInfo.model.displayName = selectedModel.name;
            }
            sManager.saveShape(this._modelInfo);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Rotation
        private void ipt_rotation_x_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.x = (float) ipt_rotation_x.Value;

            float rotX = _modelInfo.modelParams.angle.x;
            float rotY = _modelInfo.modelParams.angle.y;
            float rotZ = _modelInfo.modelParams.angle.z;

            if (_engine != null) _engine.setRotate(rotX, rotY, rotZ, _modelIndex);
        }

        private void ipt_rotation_y_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.y = (float)ipt_rotation_y.Value;

            float rotX = _modelInfo.modelParams.angle.x;
            float rotY = _modelInfo.modelParams.angle.y;
            float rotZ = _modelInfo.modelParams.angle.z;

            if (_engine != null) _engine.setRotate(rotX, rotY, rotZ, _modelIndex);
        }

        private void ipt_rotation_z_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.z = (float)ipt_rotation_z.Value;

            float rotX = _modelInfo.modelParams.angle.x;
            float rotY = _modelInfo.modelParams.angle.y;
            float rotZ = _modelInfo.modelParams.angle.z;

            if (_engine != null) _engine.setRotate(rotX, rotY, rotZ, _modelIndex);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            float multiple = (float) ipt_multipler.Value;
            ipt_scale_x.Value = (decimal)(_modelInfo.modelParams.scale.x * multiple);
            ipt_scale_y.Value = (decimal)(_modelInfo.modelParams.scale.y * multiple);
            ipt_scale_z.Value = (decimal)(_modelInfo.modelParams.scale.z * multiple);
        }

        private void ipt_scale_x_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.scale.x = (float) ipt_scale_x.Value;

            _engine.setScale(_modelInfo.modelParams.scale.x, _modelInfo.modelParams.scale.y, _modelInfo.modelParams.scale.z, _modelIndex);
        }

        private void ipt_scale_y_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.scale.y = (float) ipt_scale_y.Value;

            _engine.setScale(_modelInfo.modelParams.scale.x, _modelInfo.modelParams.scale.y, _modelInfo.modelParams.scale.z, _modelIndex);
        }

        private void ipt_scale_z_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.scale.z = (float) ipt_scale_z.Value;

            _engine.setScale(_modelInfo.modelParams.scale.x, _modelInfo.modelParams.scale.y, _modelInfo.modelParams.scale.z, _modelIndex);
        }

        private void btn_add_model_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "model files (*.obj)|*.obj";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
        }

        private void cbx_model_path_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            Store s = (Store) comboBox.SelectedItem;

            string path = s.path;
            bool canImport = s.canImport;

            string targetPath = Globals.ThisAddIn.RootPath;
            string destFile = System.IO.Path.Combine(targetPath, path);

            System.IO.Directory.CreateDirectory(destFile);

            lbx_model.Items.Clear();

            string[] files = System.IO.Directory.GetFiles(destFile);
            foreach(string sf in files)
            {
                lbx_model.Items.Add(new FileStore(System.IO.Path.GetFileNameWithoutExtension(sf), sf, System.IO.Path.GetExtension(sf)));
            }

            btn_add_model.Enabled = canImport;
            btn_remove_model.Enabled = canImport;
        }

        private void lbx_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileStore selectedModel = (FileStore)lbx_model.SelectedItem;

            string filePath = selectedModel.path;
            _engine.Clear();
            _modelIndex = _engine.OpenTexturedObj(
                filePath + "." + Globals.ThisAddIn.defaultExtension, 
                filePath + "." + Globals.ThisAddIn.defaultExtension
            );
        }

        private void btn_scale_reset_Click(object sender, EventArgs e)
        {
            Vector3 bounding = _engine.getBoundingBox(_modelIndex);

            ipt_scale_x.Value = (decimal)(_info.width / bounding.X);
            ipt_scale_z.Value = (decimal)(_info.height / bounding.Z);

            ipt_scale_y.Value = (decimal) Math.Min(_info.width / bounding.X, _info.height / bounding.Z);
        }
    }

    public class FileStore : IEquatable<FileStore>
    {
        public string name;
        public string path;
        public string extension;

        public FileStore(string pName, string pPath, string pExtension)
        {
            name = pName;
            path = pPath;
            extension = pExtension;
        }

        public override string ToString()
        {
            return this.name;
        }

        public bool Equals(FileStore other)
        {
            if (other == null) return false;
            return true;
        }
    }

    public class Store : IEquatable<Store>
    {
        public string name;
        public string path;
        public bool canImport;

        public Store(string pName, string pPath, bool pCanImport)
        {
            name = pName;
            path = pPath;
            canImport = pCanImport;
        }

        public override string ToString()
        {
            return this.name;
        }

        public bool Equals(Store other)
        {
            if (other == null) return false;
            if (name != other.name) return false;
            if (path != other.path) return false;
            return true;
        }
    }
}
