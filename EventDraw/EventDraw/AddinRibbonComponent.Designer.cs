namespace EventDraw
{
    partial class AddinRibbonComponent : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public AddinRibbonComponent()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.group5 = this.Factory.CreateRibbonGroup();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.group6 = this.Factory.CreateRibbonGroup();
            this.btn_render = this.Factory.CreateRibbonButton();
            this.btn_shapeM = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.btn_settings = this.Factory.CreateRibbonButton();
            this.btn_sample = this.Factory.CreateRibbonButton();
            this.btn_about = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.group1.SuspendLayout();
            this.group4.SuspendLayout();
            this.group3.SuspendLayout();
            this.group5.SuspendLayout();
            this.group2.SuspendLayout();
            this.group6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.Groups.Add(this.group1);
            this.tab1.Groups.Add(this.group4);
            this.tab1.Groups.Add(this.group6);
            this.tab1.Groups.Add(this.group3);
            this.tab1.Groups.Add(this.group5);
            this.tab1.Groups.Add(this.group2);
            this.tab1.Label = "EventDraw";
            this.tab1.Name = "tab1";
            // 
            // group1
            // 
            this.group1.Items.Add(this.btn_render);
            this.group1.Name = "group1";
            // 
            // group4
            // 
            this.group4.Items.Add(this.btn_shapeM);
            this.group4.Name = "group4";
            // 
            // group3
            // 
            this.group3.Items.Add(this.btn_settings);
            this.group3.Name = "group3";
            // 
            // group5
            // 
            this.group5.Items.Add(this.btn_sample);
            this.group5.Name = "group5";
            // 
            // group2
            // 
            this.group2.Items.Add(this.btn_about);
            this.group2.Name = "group2";
            // 
            // group6
            // 
            this.group6.Items.Add(this.button1);
            this.group6.Name = "group6";
            // 
            // btn_render
            // 
            this.btn_render.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_render.Image = global::EventDraw.Properties.Resources._3d_icon_12;
            this.btn_render.Label = "Build active Drawing";
            this.btn_render.Name = "btn_render";
            this.btn_render.ShowImage = true;
            this.btn_render.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_render_Click);
            // 
            // btn_shapeM
            // 
            this.btn_shapeM.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_shapeM.Image = global::EventDraw.Properties.Resources.objects_icon;
            this.btn_shapeM.Label = "Shape Manager";
            this.btn_shapeM.Name = "btn_shapeM";
            this.btn_shapeM.ShowImage = true;
            this.btn_shapeM.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_shapeM_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Image = global::EventDraw.Properties.Resources.NicePng_transportation_png_3349636;
            this.button1.Label = "Import Model";
            this.button1.Name = "button1";
            this.button1.ShowImage = true;
            this.button1.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.button1_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_settings.Image = global::EventDraw.Properties.Resources.Settings_icon;
            this.btn_settings.Label = "Settings";
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.ShowImage = true;
            this.btn_settings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_settings_Click);
            // 
            // btn_sample
            // 
            this.btn_sample.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_sample.Image = global::EventDraw.Properties.Resources.clipart3511429;
            this.btn_sample.Label = "Sample";
            this.btn_sample.Name = "btn_sample";
            this.btn_sample.ShowImage = true;
            this.btn_sample.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_sample_Click);
            // 
            // btn_about
            // 
            this.btn_about.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btn_about.Image = global::EventDraw.Properties.Resources.about;
            this.btn_about.Label = "About";
            this.btn_about.Name = "btn_about";
            this.btn_about.ShowImage = true;
            this.btn_about.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btn_about_Click);
            // 
            // AddinRibbonComponent
            // 
            this.Name = "AddinRibbonComponent";
            this.RibbonType = "Microsoft.Visio.Drawing";
            this.Tabs.Add(this.tab1);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group5.ResumeLayout(false);
            this.group5.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group6.ResumeLayout(false);
            this.group6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_render;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_about;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_settings;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_shapeM;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group5;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btn_sample;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group6;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
    }

    partial class ThisRibbonCollection
    {
        internal AddinRibbonComponent Ribbon
        {
            get { return this.GetRibbon<AddinRibbonComponent>(); }
        }
    }
}
