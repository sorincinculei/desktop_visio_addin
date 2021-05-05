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

using Visio = Microsoft.Office.Interop.Visio;

namespace EventDraw
{
    public partial class ShapeManagerDlg : Form
    {
        private Visio.Application appliction;
        private ShapeManager sManager;
        private List<ShapeInDoc> _usedShape = new List<ShapeInDoc>();
        private InputHandler inputHandler;

        Mesh _mesh = null;
        private bool mouseLeftDown = false;

        private int mouseLastX = -1;
        private int mouseLastY = -1;
        private float scale = 1f;

        private List<Rotation> rotations;

        public ShapeManagerDlg(Visio.Application app, ShapeManager sM)
        {
            InitializeComponent();
            this.axViewer1.CreateControl();

            this.appliction = app;
            this.sManager = sM;

            sM.saveXml();
            LoadShapeFromActive();

            inputHandler = new InputHandler(render_panel);
            inputHandler.mouseDownListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = true);
            inputHandler.mouseUpListeners.Add(MouseButtons.Left, (x, y) => mouseLeftDown = false);

            inputHandler.mouseMoved += (int x, int y) =>
            {
                if (mouseLastX != -1 && mouseLastY != -1)
                {
                    if(mouseLeftDown)
                    {
                        int moveX = x - mouseLastX;
                        int moveY = y - mouseLastY;

                        float mag = (float)Math.Sqrt(moveX * moveX + moveY * moveY) / 2f;

                        // vector (x, y) perpendicular to another vector is (y, x)
                        rotations.Add(new Rotation(-mag, -moveY, -moveX, 0));

                        render_panel.Invalidate();
                    }
                }

                mouseLastX = x;
                mouseLastY = y;
            };

            inputHandler.mouseWheelMoved += (int delta) =>
            {
                scale += delta / SystemInformation.MouseWheelScrollDelta * 0.01f;

                // keep scale between 0.1 - 10
                scale = Math.Min(10f, Math.Max(0.01f, scale));

                render_panel.Invalidate();
            };

            rotations = new List<Rotation>();
        }

        private void btn_edit_model_Click(object sender, EventArgs e)
        {
            ShapeInDoc selectedModel = (ShapeInDoc)this.lbx_shapelist.SelectedItem;

            EditModelDlg dlg = new EditModelDlg(this.sManager, selectedModel);
            dlg.ShowDialog();
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

                    if (!this._usedShape.Contains(s))
                        this._usedShape.Add(s);
                }
            }

            this.lbx_shapelist.DataSource = this._usedShape;
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.render_panel.Load += Render_panel_Load;
            this.render_panel.Resize += Render_panel_Resize;
            this.render_panel.Paint += Render_panel_Paint;

            Render_panel_Resize(this.render_panel, EventArgs.Empty);
        }

        private void Render_panel_Load(object sender, EventArgs e)
        {
            //GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.ClearColor(Color.CornflowerBlue);
        }

        private void Render_panel_Resize(object sender, EventArgs e)
        {
            this.render_panel.MakeCurrent();

            if (this.render_panel.ClientSize.Height == 0)
                this.render_panel.ClientSize = new System.Drawing.Size(this.render_panel.ClientSize.Width, 1);
            GL.Viewport(0, 0, this.render_panel.ClientSize.Width, this.render_panel.ClientSize.Height);

            float aspect_ratio = Math.Max(this.render_panel.ClientSize.Width, 1) / (float)Math.Max(this.render_panel.ClientSize.Height, 1);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        private void Render_panel_Paint(object sender, PaintEventArgs e)
        {
            this.render_panel.MakeCurrent();

            GL.ClearColor(Color.CornflowerBlue);

            GL.Enable(EnableCap.DepthTest);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Scale(scale, scale, 1);
            GL.Translate(0, 0, scale);

            foreach (Rotation rot in rotations)
            {
                GL.Rotate(rot.angle, rot.axis);
            }

            GL.EnableClientState(ArrayCap.VertexArray);

            // GL.Color4(Color4.Silver);
            // GL.Vertex3(-1.0f, -1.0f, -1.0f);
            // GL.Vertex3(-1.0f, 1.0f, -1.0f);
            // GL.Vertex3(1.0f, 1.0f, -1.0f);
            // GL.Vertex3(1.0f, -1.0f, -1.0f);
            if (_mesh != null)
            {
                var meshVertices = _mesh.vertices.ToArray();
                GL.VertexPointer(3, VertexPointerType.Float, 0, meshVertices);
                GL.Color4(0.5f, 0.5f, 0.5f, 0.5f);

                var meshVertexIndices = _mesh.vertexIndices.ToArray();
                GL.DrawElements(PrimitiveType.Triangles, _mesh.vertexIndices.Count, DrawElementsType.UnsignedInt, meshVertexIndices);

                var bbVertices = _mesh.boundingBox.vertices.ToArray();
                GL.VertexPointer(3, VertexPointerType.Float, 0, bbVertices);
                GL.Color4(BoundingBox.drawColor);

                var bbVertexIndices = _mesh.vertexIndices.ToArray();
                GL.DrawElements(PrimitiveType.Lines, _mesh.boundingBox.indices.Count, DrawElementsType.UnsignedInt, bbVertexIndices);

                GL.DisableClientState(ArrayCap.VertexArray);

                /*
                  GL.Begin(BeginMode.Quads);
                 GL.Color4(Color4.Silver);
                 GL.Vertex3(-1.0f, -1.0f, -1.0f);
                 GL.Vertex3(-1.0f, 1.0f, -1.0f);
                 GL.Vertex3(1.0f, 1.0f, -1.0f);
                 GL.Vertex3(1.0f, -1.0f, -1.0f);
                 GL.End();
                 */
            }

            this.render_panel.SwapBuffers();
        }

        private void lbx_shapelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShapeInDoc value = (ShapeInDoc) this.lbx_shapelist.SelectedItem;
            this.tbx_baseID.Text = value.getBaseID();
            this.DrawMaster();
            this.Draw3DModel();
        }

        private void DrawMaster()
        {

            //string sampleFileName = @"\\test\_temp.vsd";
            //string samplefilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + sampleFileName;

            //this.appliction.Documents.AddEx(samplefilePath);
            
            //this.appliction.Documents.
            //this.axViewer1.Load(samplefilePath);
        }

        private void Draw3DModel()
        {
            string sampleFileName = @"\\cube.obj";
            string samplefilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + sampleFileName;

            float[] mesh1 = ObjLoader.Load(samplefilePath);
        }
    }
}
