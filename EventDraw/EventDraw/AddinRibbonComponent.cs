using System;
using System.Collections.Generic;
using Microsoft.Office.Tools.Ribbon;

namespace EventDraw
{
    public partial class AddinRibbonComponent
    {
        private void btn_render_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Render();
        }

        private void btn_settings_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Setting();
        }

        private void btn_about_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Help();
        }

        private void btn_shapeM_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Shapemanager();
        }

        private void btn_sample_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.OpenSample();
        }
    }
}
