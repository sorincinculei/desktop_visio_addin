﻿using System;
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

namespace EventDraw
{
    
    public partial class RenderDlg : Form
    {
        private Engine _engine;
        private EventDraw._3d.InputHandler inputHandler;

        private bool mouseLeftDown = false;
        private int mouseLastX = -1;
        private int mouseLastY = -1;

        private readonly float _sensitivity = 0.2f;

        public RenderDlg()
        {
            InitializeComponent();
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
            string sampleFileName = @"\\1.8m x 1.6m Round Table.obj";
            string samplefilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + sampleFileName;

            float[] mesh1 = ObjLoader.Load(samplefilePath);

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

            GL.Enable(EnableCap.DepthTest);
            _engine.Render3DObjects();
            GL.Disable(EnableCap.DepthTest);

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
}
