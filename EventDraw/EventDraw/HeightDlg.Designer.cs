namespace EventDraw
{
    partial class HeightDlg
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipt_height_p = new System.Windows.Forms.NumericUpDown();
            this.ipt_height_m = new System.Windows.Forms.NumericUpDown();
            this.ipt_base_elevation = new System.Windows.Forms.NumericUpDown();
            this.chb_height_lock = new System.Windows.Forms.CheckBox();
            this.btn_PutTop = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_height_p)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_height_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_base_elevation)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height 3D";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height 3D Lock";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "3D Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Base Elevation";
            // 
            // ipt_height_p
            // 
            this.ipt_height_p.Location = new System.Drawing.Point(137, 11);
            this.ipt_height_p.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ipt_height_p.Name = "ipt_height_p";
            this.ipt_height_p.Size = new System.Drawing.Size(120, 20);
            this.ipt_height_p.TabIndex = 4;
            // 
            // ipt_height_m
            // 
            this.ipt_height_m.Location = new System.Drawing.Point(137, 38);
            this.ipt_height_m.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ipt_height_m.Name = "ipt_height_m";
            this.ipt_height_m.Size = new System.Drawing.Size(120, 20);
            this.ipt_height_m.TabIndex = 5;
            // 
            // ipt_base_elevation
            // 
            this.ipt_base_elevation.Location = new System.Drawing.Point(137, 84);
            this.ipt_base_elevation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ipt_base_elevation.Name = "ipt_base_elevation";
            this.ipt_base_elevation.Size = new System.Drawing.Size(120, 20);
            this.ipt_base_elevation.TabIndex = 6;
            // 
            // chb_height_lock
            // 
            this.chb_height_lock.AutoSize = true;
            this.chb_height_lock.Location = new System.Drawing.Point(137, 64);
            this.chb_height_lock.Name = "chb_height_lock";
            this.chb_height_lock.Size = new System.Drawing.Size(15, 14);
            this.chb_height_lock.TabIndex = 7;
            this.chb_height_lock.UseVisualStyleBackColor = true;
            // 
            // btn_PutTop
            // 
            this.btn_PutTop.Location = new System.Drawing.Point(182, 110);
            this.btn_PutTop.Name = "btn_PutTop";
            this.btn_PutTop.Size = new System.Drawing.Size(75, 23);
            this.btn_PutTop.TabIndex = 8;
            this.btn_PutTop.Text = "Put on Top";
            this.btn_PutTop.UseVisualStyleBackColor = true;
            this.btn_PutTop.Click += new System.EventHandler(this.btn_PutTop_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(182, 166);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(16, 166);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // HeightDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 201);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_PutTop);
            this.Controls.Add(this.chb_height_lock);
            this.Controls.Add(this.ipt_base_elevation);
            this.Controls.Add(this.ipt_height_m);
            this.Controls.Add(this.ipt_height_p);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HeightDlg";
            this.ShowInTaskbar = false;
            this.Text = "3D Height and Tilt";
            ((System.ComponentModel.ISupportInitialize)(this.ipt_height_p)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_height_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_base_elevation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ipt_height_p;
        private System.Windows.Forms.NumericUpDown ipt_height_m;
        private System.Windows.Forms.NumericUpDown ipt_base_elevation;
        private System.Windows.Forms.CheckBox chb_height_lock;
        private System.Windows.Forms.Button btn_PutTop;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}