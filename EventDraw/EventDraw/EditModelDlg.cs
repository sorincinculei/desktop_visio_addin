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

namespace EventDraw
{
    public partial class EditModelDlg : Form
    {
        private string _baseId;
        private ShapeInfo _modelInfo;

        private ShapeManager sManager;

        public EditModelDlg(ShapeManager sM, ShapeInDoc info)
        {
            InitializeComponent();

            this.sManager = sM;
            this._baseId = info.BaseID;
            this._modelInfo = sManager.getShapeInfo(this._baseId);

            // Init Component
            this.lbl_model_type.Text = info.getName();

            this._modelInfo.baseId = this._baseId;

            // Set Rotation
            this.ipt_rotation_x.Value = (decimal) this._modelInfo.modelParams.angle.x;
            this.ipt_rotation_y.Value = (decimal)this._modelInfo.modelParams.angle.y;
            this.ipt_rotation_z.Value = (decimal)this._modelInfo.modelParams.angle.z;
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
            //GL.Viewport(0, 0, this.render_panel.ClientSize.Width, this.render_panel.ClientSize.Height);
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //GL.Ortho(0, 50.0, 0, 50.0, -1.0, 1.0);
            //GL.MatrixMode(MatrixMode.Modelview);

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

        private void btn_save_Click(object sender, EventArgs e)
        {
            this.sManager.saveShape(this._modelInfo);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Rotation
        private void ipt_rotation_x_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.x = (float) ipt_rotation_x.Value;
        }

        private void ipt_rotation_y_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.y = (float)ipt_rotation_y.Value;
        }

        private void ipt_rotation_z_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.angle.z = (float)ipt_rotation_z.Value;
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
        }

        private void ipt_scale_y_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.scale.y = (float) ipt_scale_y.Value;
        }

        private void ipt_scale_z_ValueChanged(object sender, EventArgs e)
        {
            _modelInfo.modelParams.scale.z = (float) ipt_scale_z.Value;
        }

    }
}
