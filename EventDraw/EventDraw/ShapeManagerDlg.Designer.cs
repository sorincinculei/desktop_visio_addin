namespace EventDraw
{
    partial class ShapeManagerDlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShapeManagerDlg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbx_shapelist = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_edit_model = new System.Windows.Forms.Button();
            this.render_panel = new OpenTK.GLControl();
            this.axViewer1 = new AxVisioViewer.AxViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbx_baseID = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axViewer1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbx_shapelist);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 441);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Active drawing shapes";
            // 
            // lbx_shapelist
            // 
            this.lbx_shapelist.BackColor = System.Drawing.Color.White;
            this.lbx_shapelist.DisplayMember = "Name";
            this.lbx_shapelist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbx_shapelist.FormattingEnabled = true;
            this.lbx_shapelist.Location = new System.Drawing.Point(3, 16);
            this.lbx_shapelist.Name = "lbx_shapelist";
            this.lbx_shapelist.Size = new System.Drawing.Size(386, 422);
            this.lbx_shapelist.TabIndex = 0;
            this.lbx_shapelist.ValueMember = "BaseID";
            this.lbx_shapelist.SelectedIndexChanged += new System.EventHandler(this.lbx_shapelist_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.render_panel);
            this.flowLayoutPanel1.Controls.Add(this.axViewer1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(410, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(291, 441);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btn_edit_model);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 32);
            this.panel2.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(210, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_edit_model
            // 
            this.btn_edit_model.Location = new System.Drawing.Point(97, 4);
            this.btn_edit_model.Name = "btn_edit_model";
            this.btn_edit_model.Size = new System.Drawing.Size(107, 23);
            this.btn_edit_model.TabIndex = 0;
            this.btn_edit_model.Text = "Edit or assign";
            this.btn_edit_model.UseVisualStyleBackColor = true;
            this.btn_edit_model.Click += new System.EventHandler(this.btn_edit_model_Click);
            // 
            // render_panel
            // 
            this.render_panel.BackColor = System.Drawing.Color.Black;
            this.render_panel.Location = new System.Drawing.Point(3, 41);
            this.render_panel.Name = "render_panel";
            this.render_panel.Size = new System.Drawing.Size(288, 186);
            this.render_panel.TabIndex = 1;
            this.render_panel.VSync = false;
            // 
            // axViewer1
            // 
            this.axViewer1.Enabled = true;
            this.axViewer1.Location = new System.Drawing.Point(3, 233);
            this.axViewer1.Name = "axViewer1";
            this.axViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axViewer1.OcxState")));
            this.axViewer1.Size = new System.Drawing.Size(285, 205);
            this.axViewer1.TabIndex = 2;
            this.axViewer1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbx_baseID);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 460);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 36);
            this.panel1.TabIndex = 2;
            // 
            // tbx_baseID
            // 
            this.tbx_baseID.Location = new System.Drawing.Point(44, 10);
            this.tbx_baseID.Name = "tbx_baseID";
            this.tbx_baseID.Size = new System.Drawing.Size(366, 20);
            this.tbx_baseID.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(590, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "BaseID";
            // 
            // ShapeManagerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 508);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShapeManagerDlg";
            this.Text = "Shape Manager";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axViewer1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox lbx_shapelist;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_edit_model;
        //private System.Windows.Forms.Panel render_panel;
        private OpenTK.GLControl render_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbx_baseID;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private AxVisioViewer.AxViewer axViewer1;
    }
}