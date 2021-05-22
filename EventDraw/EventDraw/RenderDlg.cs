using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using EventDraw._3d;

using Visio = Microsoft.Office.Interop.Visio;

namespace EventDraw
{
    
    public partial class RenderDlg : Form
    {
        private Engine _engine;
        private ShapeManager sManager;

        private EventDraw._3d.InputHandler inputHandler;

        private bool mouseLeftDown = false;
        private int mouseLastX = -1;
        private int mouseLastY = -1;

        private readonly float _sensitivity = 0.2f;

        private Visio.Application appliction;
        
        public RenderDlg(Visio.Application app, ShapeManager sM)
        {
            InitializeComponent();

            appliction = app;
            this.sManager = sM;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            _engine.Destory();
            base.OnHandleDestroyed(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            _engine = new Engine();

            this.render_panel.Load += Render_panel_Load;
            this.render_panel.Resize += Render_panel_Resize;
            this.render_panel.Paint += Render_panel_Paint;

            Render_panel_Resize(this.render_panel, EventArgs.Empty);

            loadScene();

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
            };

            inputHandler.mouseWheelMoved += (int delta) =>
            {
                _engine._camera.Zoom(delta);
            };

            inputHandler.keyDownListeners.Add(Keys.W, (modifiy) => {
                _engine._camera.Forward();
            });

            inputHandler.keyDownListeners.Add(Keys.S, (modifiy) => {
                _engine._camera.Backwards();
            });

            inputHandler.keyDownListeners.Add(Keys.A, (modifiy) => {
                _engine._camera.LeftMove();
            });

            inputHandler.keyDownListeners.Add(Keys.D, (modifiy) => {
                _engine._camera.RightMove();
            });


            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.Blend);
        }

        private void loadScene()
        {
            Visio.Documents visioDocs = this.appliction.Documents;
            var page = visioDocs.Application.ActivePage;

            double tx = page.PageSheet.Cells["PageWidth"].Result[Visio.VisUnitCodes.visCentimeters];
            double ty = page.PageSheet.Cells["PageHeight"].Result[Visio.VisUnitCodes.visCentimeters];

            //pageSheet.Cells["PrintPageOrientation"].FormulaU = "2";

            _engine._camera.Front = new Vector3((float) tx / 2.0f, 0.0f, (float)ty / 2.0f);
            _engine._camera.Distance = (float)Math.Max(tx / 2, ty / 2);

            // Create Floor
            int floorHandle = _engine.CreateFloor(new Color4(0.8f, 0.8f, 0.8f, 0.8f), (float) tx, (float) ty);
            _engine.setPostiion((float)tx / 2, 0.0f, (float)ty / 2, floorHandle);
            //_engine.setRotate((float)Math.PI / 2, 0.0f, 0.0f, floorHandle);

            var shapes = page.Shapes;

            /** Import Shape **/

            List<RenderModel> lists = AnalyzePage(shapes, tx);
            var usersGroupedByCountry = lists.GroupBy(list => list.baseId);

            foreach (var grouplist in usersGroupedByCountry)
            {
                ShapeInfo modelInfo = sManager.getShapeInfo(grouplist.Key);
                var modelPath = modelInfo.model.fileName;

                int handle = -1;

                if (modelPath != "")
                {
                    var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, modelPath);
                    handle = _engine.OpenTexturedObj(filePath + "." + Globals.ThisAddIn.defaultExtension,
                            filePath + "." + Globals.ThisAddIn.defaultExtension);

                    foreach (var ss in grouplist)
                    {
                        int modelIndex = _engine.cloneTextureObj(handle);

                        float scaleX = modelInfo.modelParams.scale.x;
                        float scaleY = modelInfo.modelParams.scale.y;
                        float scaleZ = modelInfo.modelParams.scale.z;

                        float rotX = modelInfo.modelParams.angle.x;
                        float rotY = modelInfo.modelParams.angle.y - (float)Math.PI * (float)ss.angle / 180f;
                        float rotZ = modelInfo.modelParams.angle.z;

                        _engine.setRotate(rotX, rotY, rotZ, modelIndex);
                        _engine.setScale(scaleX, scaleY, scaleZ, modelIndex);
                        _engine.setPostiion((float)ss.x, 0.0f, (float)ss.y, modelIndex);
                    }
                }
                else
                {
                    RenderModel g = grouplist.First();
                    var text = g.text;
                    if (text == "Wall" || text == "Pilaster")
                    {
                        foreach (var ss in grouplist)
                        {
                            int wallHandle = _engine.CreateWall(new Color4(0.7f, 0.7f, 0.7f, 1.0f), (float)ss.width, (float)ss.height);

                            float rotX = 0;
                            float rotY = -(float)Math.PI * (float)ss.angle / 180f;
                            float rotZ = 0;

                            _engine.setRotate(rotX, rotY, rotZ, wallHandle);
                            _engine.setPostiion((float)ss.x, 0, (float)ss.y, wallHandle);
                        }
                    }
                    else if (text == "Opening")
                    {
                        foreach (var ss in grouplist)
                        {
                            int wallHandle = _engine.CreateWall(new Color4(1.0f, 0.0f, 0.0f, 1.0f), (float)ss.width, (float)ss.height);

                            float rotX = 0;
                            float rotY = -(float)Math.PI * (float)ss.angle / 180f;
                            float rotZ = 0;

                            _engine.setRotate(rotX, rotY, rotZ, wallHandle);
                            _engine.setPostiion((float)ss.x, 0, (float)ss.y, wallHandle);
                        }
                    }
                    else if (text == "Dynamic Double")
                    {
                        foreach (var ss in grouplist)
                        {
                            var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, "Custom/gap/doubledoor.obj");
                            int wallHandle = _engine.OpenTexturedObj(filePath, filePath + "." + Globals.ThisAddIn.defaultExtension);
                            //int wallHandle = _engine.CreateWall(new Color4(0.0f, 1.0f, 0.0f, 1.0f), (float)ss.width, (float)ss.height);

                            float rotX = (float) Math.PI / 2;
                            float rotY = -(float)Math.PI * (float)ss.angle / 180f;
                            float rotZ = 0;

                            _engine.setRotate(rotX, rotY, rotZ, wallHandle);
                            _engine.setScale(2.411862f, 2.411862f, 3.258033f, wallHandle);
                            _engine.setPostiion((float)ss.x, 0, (float)ss.y, wallHandle);
                        }
                    }
                }
            }
                /*
                foreach(RenderModel list in lists)
                {
                    ShapeInfo modelInfo = sManager.getShapeInfo(list.baseId);
                    var modelPath = modelInfo.model.fileName;

                    if (modelPath != "")
                    {
                        var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, modelPath);

                        int handle = _engine.OpenTexturedObj(filePath + "." + Globals.ThisAddIn.defaultExtension,
                            filePath + "." + Globals.ThisAddIn.defaultExtension);

                        float scaleX = modelInfo.modelParams.scale.x;
                        float scaleY = modelInfo.modelParams.scale.y;
                        float scaleZ = modelInfo.modelParams.scale.z;

                        float rotX = modelInfo.modelParams.angle.x;
                        float rotY = modelInfo.modelParams.angle.y - (float)Math.PI * (float)list.angle / 180f;
                        float rotZ = modelInfo.modelParams.angle.z;

                        _engine.setRotate(rotX, rotY, rotZ, handle);
                        _engine.setScale(scaleX, scaleY, scaleZ, handle);
                        _engine.setPostiion((float)list.x, 0.0f, (float)list.y, handle);
                    }
                    else
                    {

                    }
                }
                */

                /*
                foreach (Visio.Shape shape in shapes)
                {
                    if (shape.Master != null)
                    {
                        double width = shape.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                        double height = shape.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                        double x = shape.Cells["PinX"].Result[Visio.VisUnitCodes.visCentimeters];
                        double y = shape.Cells["PinY"].Result[Visio.VisUnitCodes.visCentimeters];
                        double angle = shape.Cells["Angle"].Result[Visio.VisUnitCodes.visAngleUnits];

                        string baseId = shape.Master.BaseID;
                        ShapeInfo modelInfo = sManager.getShapeInfo(baseId);

                        var modelPath = modelInfo.model.fileName;

                        if (modelPath != "")
                        {
                            var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, modelPath);

                            int handle = _engine.OpenTexturedObj(filePath + "." + Globals.ThisAddIn.defaultExtension,
                                filePath + "." + Globals.ThisAddIn.defaultExtension);

                            float scaleX = modelInfo.modelParams.scale.x;
                            float scaleY = modelInfo.modelParams.scale.y;
                            float scaleZ = modelInfo.modelParams.scale.z;

                            float rotX = modelInfo.modelParams.angle.x;
                            float rotY = modelInfo.modelParams.angle.y - (float)Math.PI * (float) angle / 180f;
                            float rotZ = modelInfo.modelParams.angle.z;

                            _engine.setRotate(rotX, rotY, rotZ, handle);
                            _engine.setScale(scaleX, scaleY, scaleZ, handle);
                            _engine.setPostiion((float)x, 0.0f, (float)y, handle);
                        }
                    }
                    else
                    {
                        int shapeCount = shape.Shapes.Count;
                        if (shapeCount > 0)
                        {

                            double width = shape.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                            double height = shape.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                            double x = shape.Cells["PinX"].Result[Visio.VisUnitCodes.visCentimeters];
                            double y = shape.Cells["PinY"].Result[Visio.VisUnitCodes.visCentimeters];
                            double angle = shape.Cells["Angle"].Result[Visio.VisUnitCodes.visAngleUnits];


                            for (int i = 1; i <= shapeCount; i++)
                            {
                                var s = shape.Shapes[i];

                                double swidth = s.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                                double sheight = s.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
                                double sx = s.Cells["PinX"].Result[Visio.VisUnitCodes.visCentimeters];
                                double sy = s.Cells["PinY"].Result[Visio.VisUnitCodes.visCentimeters];
                                double sangle = s.Cells["Angle"].Result[Visio.VisUnitCodes.visAngleUnits];

                                if (s.Master != null)
                                {
                                    string baseId = s.Master.BaseID;

                                    ShapeInfo modelInfo = sManager.getShapeInfo(baseId);
                                    var modelPath = modelInfo.model.fileName;

                                    if (modelPath != "")
                                    {
                                        var filePath = System.IO.Path.Combine(Globals.ThisAddIn.RootPath, modelPath);

                                        int handle = _engine.OpenTexturedObj(filePath + "." + Globals.ThisAddIn.defaultExtension,
                                            filePath + "." + Globals.ThisAddIn.defaultExtension);

                                        float scaleX = modelInfo.modelParams.scale.x;
                                        float scaleY = modelInfo.modelParams.scale.y;
                                        float scaleZ = modelInfo.modelParams.scale.z;

                                        float rotX = modelInfo.modelParams.angle.x;
                                        float rotY = modelInfo.modelParams.angle.y - (float)Math.PI * (float)(angle + sangle) / 180f;
                                        float rotZ = modelInfo.modelParams.angle.z;

                                        _engine.setRotate(rotX, rotY, rotZ, handle);
                                        _engine.setScale(scaleX / 2, scaleY, scaleZ, handle);
                                        _engine.setPostiion((float)(x + sx), 0.0f, (float)(y + sy), handle);
                                    }
                                }
                            }
                        }
                    }
                }

                */
            }

        private List<RenderModel> AnalyzePage(Visio.Shapes shapes, double pageWidth)
        {
            List<RenderModel> result = new List<RenderModel>();

            foreach (Visio.Shape shape in shapes)
            {
                AnalyzePage(shape, 0, 0, 0, ref result, pageWidth);
            }

            return result;
        }

        private void AnalyzePage(Visio.Shape shape, double x, double y, double angle, ref List<RenderModel> result, double pageWidth)
        {
            double sx = shape.Cells["PinX"].Result[Visio.VisUnitCodes.visCentimeters];
            double sy = shape.Cells["PinY"].Result[Visio.VisUnitCodes.visCentimeters];
            double sangle = shape.Cells["Angle"].Result[Visio.VisUnitCodes.visAngleUnits];
            double width = shape.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
            double height = shape.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];

            if (shape.Master != null)
            {
                RenderModel model = new RenderModel();
                model.baseId = shape.Master.BaseID;
                model.x = (float) pageWidth - (float) (x + sx);
                model.y = (float) (y + sy);
                model.width = (float) (width);
                model.height = (float) (height);
                model.angle = (float)( angle + sangle);
                model.text = shape.Master.Name;
                result.Add(model);
                
                int shapeCount = shape.Master.Shapes.Count;
                if (shapeCount > 0)
                {
                    for (int i = 1; i <= shapeCount; i++)
                    {
                        var k = 0;
                    }
                }
            }
            else
            {
                int shapeCount = shape.Shapes.Count;
                if (shapeCount > 0)
                {
                    for (int i = 1; i <= shapeCount; i++)
                    {
                        AnalyzePage(shape.Shapes[i], x - sx, y + sy, angle + sangle, ref result, pageWidth);
                    }
                }
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

            if (this.render_panel.ClientSize.Height == 0)
                this.render_panel.ClientSize = new System.Drawing.Size(this.render_panel.ClientSize.Width, 1);
            GL.Viewport(0, 0, this.render_panel.ClientSize.Width, this.render_panel.ClientSize.Height);
        }

        private void Render_panel_Paint(object sender, PaintEventArgs e)
        {
            this.render_panel.MakeCurrent();

            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearDepth(1);

            //GL.Enable(EnableCap.Blend);
           // GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            //GL.DepthMask(false);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            //GL.Enable(EnableCap.CullFace);
            //GL.Disable(EnableCap.Multisample);

            //GL.DepthMask(true);
            //GL.BlendEquation(BlendEquationMode.FuncAdd);

            _engine.Render3DObjects();

            GL.Disable(EnableCap.DepthTest);
            //GL.Disable(EnableCap.Blend);
            //GL.DepthMask(true);

            this.render_panel.SwapBuffers();

            this.render_panel.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Obj file (*.obj, *.mtl)|*.obj; *.mtl|fbx files (*.fbx)|*.fbx|CAD files (*.dae)|*.dae";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    _engine.OpenTexturedObj(filePath, filePath);
                }
            }
        }
    }

    class RenderModel
    {
        public string baseId;
        public string text;
        public float x;
        public float y;
        public float angle;
        public float width;
        public float height;
    }
}
