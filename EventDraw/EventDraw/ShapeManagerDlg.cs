using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using EventDraw._3d;

using Visio = Microsoft.Office.Interop.Visio;

namespace EventDraw
{
    public partial class ShapeManagerDlg : Form
    {
        private Visio.Application appliction;
        private ShapeManager sManager;
        private List<ShapeInDoc> _usedShape = new List<ShapeInDoc>();
        private EventDraw._3d.InputHandler inputHandler;
        private Engine _engine;

        private bool mouseLeftDown = false;
        private int mouseLastX = -1;
        private int mouseLastY = -1;

        private readonly float _sensitivity = 0.2f;

        public ShapeManagerDlg(Visio.Application app, ShapeManager sM)
        {
            InitializeComponent();
            this.axViewer1.CreateControl();

            this.appliction = app;
            this.sManager = sM;

            sM.saveXml();
            LoadShapeFromActive();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            _engine.Destory();
            base.OnHandleDestroyed(e);
        }

        private void LoadShapeFromActive()
        {
            Visio.Documents visioDocs = this.appliction.Documents;
            var page = visioDocs.Application.ActivePage;

            var shapes = page.Shapes;
            foreach (Visio.Shape shape in shapes)
            {
                if (shape.Master != null)
                {
                    ShapeInDoc s = new ShapeInDoc();
                    s.setBaseID(shape.Master.BaseID);
                    s.setName(shape.Master.Name);

                    /*
                    double Left = 0.0;
                    double Right = 0.0;
                    double Bottom = 0.0;
                    double Top = 0.0;
                    shape.Master.VisualBoundingBox((short) Visio.VisBoundingBoxArgs.visBBoxDrawingCoords, out Left, out Right, out Bottom, out Top);

                    s.width = Right - Left;
                    s.height = Bottom - Top;
                    */

                    s.width = shape.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                    s.height = shape.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];

                    if (!this._usedShape.Contains(s))
                        this._usedShape.Add(s);
                }
            }

            this.lbx_shapelist.DataSource = this._usedShape;

            if (_usedShape.Count == 0) { btn_edit_model.Enabled = false; }
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
        }

        private void btn_edit_model_Click(object sender, EventArgs e)
        {
            ShapeInDoc selectedModel = (ShapeInDoc)this.lbx_shapelist.SelectedItem;

            if (selectedModel != null)
            {
                EditModelDlg dlg = new EditModelDlg(this.sManager, selectedModel);
                dlg.ShowDialog();
            }
        }

        private void Render_panel_Load(object sender, EventArgs e)
        {
            //GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
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

        private void lbx_shapelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShapeInDoc value = (ShapeInDoc) this.lbx_shapelist.SelectedItem;

            var selectedShapeBaseId = value.getBaseID();
            ShapeInfo modelInfo = sManager.getShapeInfo(selectedShapeBaseId);

            var modelPath = modelInfo.model.fileName;

            // Display BaseId of Master
            this.tbx_baseID.Text = selectedShapeBaseId;
            this.DrawMaster();

            // Remove Previous 3D Model
            _engine?.Clear();

            // Load 3D Model
            if (modelPath != "") Draw3DModel(modelPath + "." + Globals.ThisAddIn.defaultExtension);
        }

        private void DrawMaster()
        {

        }

        private void Draw3DModel(string path)
        {
            var model_path = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, path);
            var _modelIndex = _engine.OpenTexturedObj(model_path, model_path);

            Vector3 bounding = _engine.getBoundingBox(_modelIndex);
            _engine._camera.Distance = bounding.Length;
        }
    }
}
