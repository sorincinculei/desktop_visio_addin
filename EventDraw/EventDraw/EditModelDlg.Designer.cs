namespace EventDraw
{
    partial class EditModelDlg
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.render_panel = new OpenTK.GLControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_aspect = new System.Windows.Forms.Label();
            this.lbl_height = new System.Windows.Forms.Label();
            this.lbl_width = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_remove_model = new System.Windows.Forms.Button();
            this.btn_add_model = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_model_type = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ipt_rotation_z = new System.Windows.Forms.NumericUpDown();
            this.ipt_rotation_y = new System.Windows.Forms.NumericUpDown();
            this.ipt_rotation_x = new System.Windows.Forms.NumericUpDown();
            this.btn_rotation_reset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ipt_offset_y = new System.Windows.Forms.NumericUpDown();
            this.ipt_offset_x = new System.Windows.Forms.NumericUpDown();
            this.btn_offset_reset = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ipt_scale_z = new System.Windows.Forms.NumericUpDown();
            this.ipt_scale_y = new System.Windows.Forms.NumericUpDown();
            this.ipt_scale_x = new System.Windows.Forms.NumericUpDown();
            this.ipt_multipler = new System.Windows.Forms.NumericUpDown();
            this.btn_scale_reset = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_x)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_offset_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_offset_x)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_x)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_multipler)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(914, 542);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.render_panel);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Location = new System.Drawing.Point(275, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(433, 535);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected 3D Model";
            // 
            // render_panel
            // 
            this.render_panel.BackColor = System.Drawing.Color.Black;
            this.render_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.render_panel.Location = new System.Drawing.Point(3, 51);
            this.render_panel.Name = "render_panel";
            this.render_panel.Size = new System.Drawing.Size(427, 481);
            this.render_panel.TabIndex = 1;
            this.render_panel.VSync = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.comboBox2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 16);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(427, 35);
            this.panel5.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 8);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_aspect);
            this.panel2.Controls.Add(this.lbl_height);
            this.panel2.Controls.Add(this.lbl_width);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.lbl_model_type);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 542);
            this.panel2.TabIndex = 1;
            // 
            // lbl_aspect
            // 
            this.lbl_aspect.AutoSize = true;
            this.lbl_aspect.Location = new System.Drawing.Point(203, 85);
            this.lbl_aspect.Name = "lbl_aspect";
            this.lbl_aspect.Size = new System.Drawing.Size(28, 13);
            this.lbl_aspect.TabIndex = 8;
            this.lbl_aspect.Text = "0.00";
            // 
            // lbl_height
            // 
            this.lbl_height.AutoSize = true;
            this.lbl_height.Location = new System.Drawing.Point(203, 53);
            this.lbl_height.Name = "lbl_height";
            this.lbl_height.Size = new System.Drawing.Size(28, 13);
            this.lbl_height.TabIndex = 7;
            this.lbl_height.Text = "0.00";
            // 
            // lbl_width
            // 
            this.lbl_width.AutoSize = true;
            this.lbl_width.Location = new System.Drawing.Point(203, 36);
            this.lbl_width.Name = "lbl_width";
            this.lbl_width.Size = new System.Drawing.Size(28, 13);
            this.lbl_width.TabIndex = 6;
            this.lbl_width.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Aspect (W/H)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(128, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Height";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.btn_remove_model);
            this.groupBox1.Controls.Add(this.btn_add_model);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(3, 147);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 383);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D Models";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 356);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(242, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // btn_remove_model
            // 
            this.btn_remove_model.Location = new System.Drawing.Point(177, 328);
            this.btn_remove_model.Name = "btn_remove_model";
            this.btn_remove_model.Size = new System.Drawing.Size(75, 23);
            this.btn_remove_model.TabIndex = 2;
            this.btn_remove_model.Text = "Delete";
            this.btn_remove_model.UseVisualStyleBackColor = true;
            // 
            // btn_add_model
            // 
            this.btn_add_model.Location = new System.Drawing.Point(10, 329);
            this.btn_add_model.Name = "btn_add_model";
            this.btn_add_model.Size = new System.Drawing.Size(75, 23);
            this.btn_add_model.TabIndex = 1;
            this.btn_add_model.Text = "Add";
            this.btn_add_model.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(246, 303);
            this.listBox1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(3, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(118, 116);
            this.panel4.TabIndex = 1;
            // 
            // lbl_model_type
            // 
            this.lbl_model_type.AutoSize = true;
            this.lbl_model_type.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_model_type.Location = new System.Drawing.Point(3, 4);
            this.lbl_model_type.Name = "lbl_model_type";
            this.lbl_model_type.Size = new System.Drawing.Size(63, 24);
            this.lbl_model_type.TabIndex = 0;
            this.lbl_model_type.Text = "Table";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_cancel);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.groupBox6);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(714, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 542);
            this.panel3.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(117, 513);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(4, 513);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "OK";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(4, 389);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(193, 120);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Options";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ipt_rotation_z);
            this.groupBox5.Controls.Add(this.ipt_rotation_y);
            this.groupBox5.Controls.Add(this.ipt_rotation_x);
            this.groupBox5.Controls.Add(this.btn_rotation_reset);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(4, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(194, 128);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Rotation (degrees)";
            // 
            // ipt_rotation_z
            // 
            this.ipt_rotation_z.DecimalPlaces = 4;
            this.ipt_rotation_z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_rotation_z.Location = new System.Drawing.Point(61, 74);
            this.ipt_rotation_z.Name = "ipt_rotation_z";
            this.ipt_rotation_z.Size = new System.Drawing.Size(120, 20);
            this.ipt_rotation_z.TabIndex = 6;
            this.ipt_rotation_z.ValueChanged += new System.EventHandler(this.ipt_rotation_z_ValueChanged);
            // 
            // ipt_rotation_y
            // 
            this.ipt_rotation_y.DecimalPlaces = 4;
            this.ipt_rotation_y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_rotation_y.Location = new System.Drawing.Point(62, 47);
            this.ipt_rotation_y.Name = "ipt_rotation_y";
            this.ipt_rotation_y.Size = new System.Drawing.Size(120, 20);
            this.ipt_rotation_y.TabIndex = 5;
            this.ipt_rotation_y.ValueChanged += new System.EventHandler(this.ipt_rotation_y_ValueChanged);
            // 
            // ipt_rotation_x
            // 
            this.ipt_rotation_x.DecimalPlaces = 4;
            this.ipt_rotation_x.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_rotation_x.Location = new System.Drawing.Point(63, 20);
            this.ipt_rotation_x.Name = "ipt_rotation_x";
            this.ipt_rotation_x.Size = new System.Drawing.Size(120, 20);
            this.ipt_rotation_x.TabIndex = 4;
            this.ipt_rotation_x.ValueChanged += new System.EventHandler(this.ipt_rotation_x_ValueChanged);
            // 
            // btn_rotation_reset
            // 
            this.btn_rotation_reset.Location = new System.Drawing.Point(10, 99);
            this.btn_rotation_reset.Name = "btn_rotation_reset";
            this.btn_rotation_reset.Size = new System.Drawing.Size(178, 23);
            this.btn_rotation_reset.TabIndex = 3;
            this.btn_rotation_reset.Text = "Reset to 0";
            this.btn_rotation_reset.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Z:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "X:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ipt_offset_y);
            this.groupBox4.Controls.Add(this.ipt_offset_x);
            this.groupBox4.Controls.Add(this.btn_offset_reset);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(4, 148);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 101);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Offset";
            // 
            // ipt_offset_y
            // 
            this.ipt_offset_y.DecimalPlaces = 4;
            this.ipt_offset_y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_offset_y.Location = new System.Drawing.Point(59, 42);
            this.ipt_offset_y.Name = "ipt_offset_y";
            this.ipt_offset_y.Size = new System.Drawing.Size(120, 20);
            this.ipt_offset_y.TabIndex = 4;
            // 
            // ipt_offset_x
            // 
            this.ipt_offset_x.DecimalPlaces = 4;
            this.ipt_offset_x.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_offset_x.Location = new System.Drawing.Point(60, 18);
            this.ipt_offset_x.Name = "ipt_offset_x";
            this.ipt_offset_x.Size = new System.Drawing.Size(120, 20);
            this.ipt_offset_x.TabIndex = 3;
            // 
            // btn_offset_reset
            // 
            this.btn_offset_reset.Location = new System.Drawing.Point(12, 68);
            this.btn_offset_reset.Name = "btn_offset_reset";
            this.btn_offset_reset.Size = new System.Drawing.Size(175, 23);
            this.btn_offset_reset.TabIndex = 2;
            this.btn_offset_reset.Text = "Reset to 0";
            this.btn_offset_reset.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "X:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ipt_scale_z);
            this.groupBox3.Controls.Add(this.ipt_scale_y);
            this.groupBox3.Controls.Add(this.ipt_scale_x);
            this.groupBox3.Controls.Add(this.ipt_multipler);
            this.groupBox3.Controls.Add(this.btn_scale_reset);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(194, 137);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Scale";
            // 
            // ipt_scale_z
            // 
            this.ipt_scale_z.DecimalPlaces = 4;
            this.ipt_scale_z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_scale_z.Location = new System.Drawing.Point(65, 82);
            this.ipt_scale_z.Name = "ipt_scale_z";
            this.ipt_scale_z.Size = new System.Drawing.Size(120, 20);
            this.ipt_scale_z.TabIndex = 8;
            this.ipt_scale_z.ValueChanged += new System.EventHandler(this.ipt_scale_z_ValueChanged);
            // 
            // ipt_scale_y
            // 
            this.ipt_scale_y.DecimalPlaces = 4;
            this.ipt_scale_y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_scale_y.Location = new System.Drawing.Point(65, 60);
            this.ipt_scale_y.Name = "ipt_scale_y";
            this.ipt_scale_y.Size = new System.Drawing.Size(120, 20);
            this.ipt_scale_y.TabIndex = 7;
            this.ipt_scale_y.ValueChanged += new System.EventHandler(this.ipt_scale_y_ValueChanged);
            // 
            // ipt_scale_x
            // 
            this.ipt_scale_x.DecimalPlaces = 4;
            this.ipt_scale_x.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ipt_scale_x.Location = new System.Drawing.Point(65, 38);
            this.ipt_scale_x.Name = "ipt_scale_x";
            this.ipt_scale_x.Size = new System.Drawing.Size(120, 20);
            this.ipt_scale_x.TabIndex = 6;
            this.ipt_scale_x.ValueChanged += new System.EventHandler(this.ipt_scale_x_ValueChanged);
            // 
            // ipt_multipler
            // 
            this.ipt_multipler.DecimalPlaces = 1;
            this.ipt_multipler.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ipt_multipler.Location = new System.Drawing.Point(84, 16);
            this.ipt_multipler.Name = "ipt_multipler";
            this.ipt_multipler.Size = new System.Drawing.Size(100, 20);
            this.ipt_multipler.TabIndex = 5;
            this.ipt_multipler.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.ipt_multipler.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btn_scale_reset
            // 
            this.btn_scale_reset.Location = new System.Drawing.Point(10, 108);
            this.btn_scale_reset.Name = "btn_scale_reset";
            this.btn_scale_reset.Size = new System.Drawing.Size(175, 23);
            this.btn_scale_reset.TabIndex = 4;
            this.btn_scale_reset.Text = "Scale to the size of shape";
            this.btn_scale_reset.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Multiplier";
            // 
            // EditModelDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 542);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EditModelDlg";
            this.Text = "Edit 3D Model";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_rotation_x)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_offset_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_offset_x)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_scale_x)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipt_multipler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btn_remove_model;
        private System.Windows.Forms.Button btn_add_model;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_model_type;
        private System.Windows.Forms.GroupBox groupBox2;
        private OpenTK.GLControl render_panel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown ipt_rotation_z;
        private System.Windows.Forms.NumericUpDown ipt_rotation_y;
        private System.Windows.Forms.NumericUpDown ipt_rotation_x;
        private System.Windows.Forms.Button btn_rotation_reset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown ipt_offset_y;
        private System.Windows.Forms.NumericUpDown ipt_offset_x;
        private System.Windows.Forms.Button btn_offset_reset;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown ipt_scale_z;
        private System.Windows.Forms.NumericUpDown ipt_scale_y;
        private System.Windows.Forms.NumericUpDown ipt_scale_x;
        private System.Windows.Forms.NumericUpDown ipt_multipler;
        private System.Windows.Forms.Button btn_scale_reset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbl_aspect;
        private System.Windows.Forms.Label lbl_height;
        private System.Windows.Forms.Label lbl_width;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
    }
}