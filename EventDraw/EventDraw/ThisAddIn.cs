using System;
using System.Windows.Forms;
using Visio = Microsoft.Office.Interop.Visio;

namespace EventDraw
{
    public partial class ThisAddIn
    {
        private ShapeManager sManager;

        /// <summary>
        /// A simple command
        /// </summary>
        public void Render()
        {
            RenderDlg dlg = new RenderDlg();
            dlg.ShowDialog();
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
            this.Application.ActiveDocument.Close();

            string sampleFileName = @"\\3D Marquee.vsd";
            string samplefilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + sampleFileName;
            Visio.Documents visioDocs = this.Application.Documents;
            visioDocs.Open(samplefilePath);
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            LoadVSS();
            sManager = new ShapeManager();
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
        }

    }
}
