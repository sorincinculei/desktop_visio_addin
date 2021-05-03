﻿using System;
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

        public ShapeManagerDlg(Visio.Application app, ShapeManager sM)
        {
            InitializeComponent();
            this.appliction = app;
            this.sManager = sM;
            this.sManager.saveXml();
            LoadShapeFromActive();
        }

        private void btn_edit_model_Click(object sender, EventArgs e)
        {
            EditModelDlg dlg = new EditModelDlg(this.sManager);
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

                    this.lbx_shapelist.Items.Add(s);
                }
            }
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

            GL.Begin(BeginMode.Quads);

            GL.Color4(Color4.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.End();

            this.render_panel.SwapBuffers();
        }

        private void lbx_shapelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShapeInDoc value = (ShapeInDoc) this.lbx_shapelist.SelectedItem;
            this.tbx_baseID.Text = value.getBaseID();
        }
    }
}
