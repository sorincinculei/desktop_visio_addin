using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EventDraw
{
    public partial class ImportDlg : Form
    {
        private string _sourceFileName;
        private string _sourcePath;

        private string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EventDraw/Custom";

        public ImportDlg()
        {
            InitializeComponent();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Obj file (*.obj, *.mtl)|*.obj; *.mtl|fbx files (*.fbx)|*.fbx|CAD files (*.dae)|*.dae";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _sourceFileName = openFileDialog.SafeFileName;
                    _sourcePath = openFileDialog.InitialDirectory;

                    var filePath = openFileDialog.FileName;
                    tbx_filepath.Text = filePath;
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var fPath = tbx_filepath.Text;

            if (System.IO.File.Exists(fPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

                string destFile = System.IO.Path.Combine(targetPath, _sourceFileName);

                System.IO.File.Copy(fPath, destFile, true);

                const string message = "Model has been Saved!";
                const string caption = "Information";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
