using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Visio = Microsoft.Office.Interop.Visio;
using EventDraw._3d;

namespace EventDraw
{
    public partial class ThisAddIn
    {
        public string RootPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\EventDraw";
        public string defaultExtension = "X";
        private Engine _engine;

        private ShapeManager sManager;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, int hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        /// <summary>
        /// A simple command
        /// </summary>
        /// 
        public void Render()
        {
            Visio.Window window = this.Application.ActiveWindow.Windows.Add("EventDraw 3D Viewer", Visio.VisWindowStates.visWSVisible | Visio.VisWindowStates.visWSDockedRight, Visio.VisWinTypes.visAnchorBarAddon, 0, 0, 600);
            RenderDlg dlg = new RenderDlg(this.Application, this.sManager);
            dlg.Show();
            IntPtr ParenthWnd = new IntPtr(0);
            ParenthWnd = FindWindow(null, "3D Rendering");
            if (ParenthWnd.Equals(IntPtr.Zero))
            {
                
            }
            else
            {
                SetWindowLong(ParenthWnd, -16, 0x40000000 | 0x10000000);
                SetParent(ParenthWnd, window.WindowHandle32);
            }

            _engine = dlg.RenderEngine;
        }
        
        public void Setting()
        {
            SettingDlg d = new SettingDlg();
            d.ShowDialog();
        }

        public void Shapemanager()
        {
            ShapeManagerDlg dlg = new ShapeManagerDlg(this.Application, this.sManager);
            dlg.ShowDialog();
        }

        public void Help()
        {
            
        }

        public void ImportModel()
        {
            ImportDlg dlg = new ImportDlg();
            dlg.ShowDialog();
        }

        public void OpenSample()
        {
            if (this.Application.ActivePage != null)
                this.Application.ActiveDocument.Close();

            string sampleFileName = @"\\QT Ballroom_Plan_3D3.vsd";
            string samplefilePath = RootPath + @"\Samples" + sampleFileName;

            if (System.IO.File.Exists(samplefilePath))
            {
                Visio.Documents visioDocs = this.Application.Documents;
                visioDocs.Open(samplefilePath);
            }
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            LoadVSS();
            sManager = new ShapeManager();

            //System.IO.Directory.CreateDirectory(RootPath);
            //this.Application.SetCustomMenus(vsoUIObject);

            var commands = Application.CommandBars;
            foreach (var command in commands)
            {
                var name = command.Name;
            }
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {

        }

        private void LoadVSS()
        {
            try
            {
                string stencilFileName = @"\\Waypoint.vss";
                string fileName = @"\\pd-m-0001_1.11.vdw";

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + stencilFileName;
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + fileName;

                Visio.Documents visioDocs = this.Application.Documents;

                /*
                if (System.IO.File.Exists(path))
                {
                    Visio.Documents visioDocs = this.Application.Documents;
                    var targetDoc = this.Application.Documents.Add("");
                    
                    var sourceDoc = visioDocs.OpenEx(path, (short)Visio.VisOpenSaveArgs.visAddHidden);
                    var sourceMasters = sourceDoc.Masters;

                    for (var i = 1; i <= sourceMasters.Count; ++i)
                    {
                        targetDoc.Drop(sourceMasters[i], 10, 10);
                    }
                    sourceDoc.Close();
                    

                    //isio.Document visioStencil = visioDocs.OpenEx(path, (short)Visio.VisOpenSaveArgs.visOpenDocked);
                    
                    //var visioDocument = this.Application.Documents.OpenEx(filePath, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDontList);
                    //var visioPage = visioDocument.Application.ActivePage;
                    //visioPage.Application.Documents.OpenEx(path, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visOpenDocked);
                    //visioDocument.SaveAsEx(filePath, (short)Microsoft.Office.Interop.Visio.VisOpenSaveArgs.visSaveAsWS);
                }
                */
            }
            catch (Exception e)
            {
                
            }
            //Visio.Document visioStencil = visioDocs.OpenEx("3D Master Shapes.vss", (short)Visio.VisOpenSaveArgs.visOpenDocked);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;

            CustomMenu();

            this.Application.DocumentOpened += new Visio.EApplication_DocumentOpenedEventHandler(Document_Opened);
            this.Application.SelectionAdded += new Visio.EApplication_SelectionAddedEventHandler(Shape_Selected);

            this.Application.MarkerEvent += new Visio.EApplication_MarkerEventEventHandler(Marker_Event);

            this.Application.SelectionChanged += new Visio.EApplication_SelectionChangedEventHandler(Selection_Changed);
            //this.Application.CommandBars.Add("ContextMenu", Microsoft.Office.Core.MsoBarPosition.msoBarBottom, missing, true);
            //Microsoft.Office.Core.CommandBarButton bt = (Microsoft.Office.Core.CommandBarButton) commandBar.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, commandBar.Controls.Count + 1, true);
            // bt.Visible = true;
            //bt.Caption = "Test Context Menu on Store";
        }

        private void Document_Opened(Visio.Document doc)
        {

        }

        private void Shape_Selected(Visio.Selection selction)
        {

        }

        private void Marker_Event(Visio.Application app, int SequenceNum, string ContextString)
        {
            if (ContextString == "3D_Height")
            {
                var selection = app.ActiveWindow.Selection;
                if (selection.Count > 0)
                {
                    HeightDlg dlg = new HeightDlg(app, selection.PrimaryItem, _engine);
                    dlg.Show();
                }
            }
        }

        private void Selection_Changed(Visio.Window window)
        {
            /*
            var commandBars = (Microsoft.Office.Core.CommandBars)this.Application.CommandBars;
            var commandBar = commandBars[1];

            var commandBar1 = commandBars.ActionControl;

            Microsoft.Office.Core.CommandBar _ContextMenu = this.Application.CommandBars.Add("ContextMenu", Microsoft.Office.Core.MsoBarPosition.msoBarPopup, missing, true);
            Microsoft.Office.Core.CommandBarButton bt = (Microsoft.Office.Core.CommandBarButton)_ContextMenu.Controls.Add(Microsoft.Office.Core.MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, _ContextMenu.Controls.Count + 1, true);
            bt.Visible = true;
            bt.Caption = "Test Context Menu on Store";
            */
        }

        private void CustomMenu()
        {
            var vsoUIObject = this.Application.BuiltInMenus;
            var vsoMenuSets = vsoUIObject.MenuSets;

            var vsoMenuSet = vsoMenuSets.ItemAtID[(short)Visio.VisUIObjSets.visUIObjSetCntx_DrawObjSel];

            for (int i = 0; i < vsoMenuSet.Menus.Count; i ++)
            {
                var menu = vsoMenuSet.Menus[i];
                menu.Caption = "Menubar";

                for (int j = 0; j < menu.MenuItems.Count; j++)
                {
                    var text = menu.MenuItems[j].Caption;
                }

                var vsoMenuItems = menu.MenuItems;
                var vsoMenuItem = vsoMenuItems.Add();
                vsoMenuItem.Caption = "&3D Height";
                vsoMenuItem.AddOnName = "QUEUEMARKEREVENT";
                vsoMenuItem.AddOnArgs = "3D_Height";
            }

            this.Application.SetCustomMenus(vsoUIObject);

            /*
            Microsoft.Office.Core.CommandBar menubar = this.Application.CommandBars["Menu Bar"];

            var subButton = (Microsoft.Office.Core.CommandBarButton)menubar.Controls.Add();
            subButton.Caption = "Subscribe";
            subButton.BeginGroup = false;
            subButton.Tag = "subButton";
            */
            var p = 0;
        }
    }
}
