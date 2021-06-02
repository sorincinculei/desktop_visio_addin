using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Visio = Microsoft.Office.Interop.Visio;

namespace EventDraw
{
    public partial class HeightDlg : Form
    {
        private string elevationProp = "Prop.BaseElevation";
        private string heightProp = "Prop.Height3D";

        private Visio.Shape SelectedShape { get; set; }
        private Visio.Application App { get; }
        public HeightDlg(Visio.Application app, Visio.Shape shape)
        {
            InitializeComponent();

            App = app;
            SelectedShape = shape;

            InitValue();
        }

        private void InitValue()
        {
           double elevation = SelectedShape.Cells[elevationProp].Result[Visio.VisUnitCodes.visNumber];
           double height = SelectedShape.Cells[heightProp].Result[Visio.VisUnitCodes.visNumber];

            ipt_base_elevation.Value = (decimal) elevation;
            ipt_height_m.Value = (decimal) height;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string elevation = ipt_base_elevation.Value.ToString();
            string height = ipt_height_m.Value.ToString();

            SelectedShape.Cells[elevationProp].Formula = elevation;
            SelectedShape.Cells[heightProp].Formula = height;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_PutTop_Click(object sender, EventArgs e)
        {
            var intTolerance = 0.25;
            var intFlag = Visio.VisSpatialRelationFlags.visSpatialFrontToBack;

            Visio.Page ActivePage = App.ActivePage;

            double sx = SelectedShape.Cells["PinX"].Result[Visio.VisUnitCodes.visMeters];
            double sy = SelectedShape.Cells["PinY"].Result[Visio.VisUnitCodes.visMeters];

            /*
            Visio.Selection overlapedShapes = ActivePage.SpatialSearch[sx, sy, (short) Visio.VisSpatialRelationCodes.visSpatialTouching, intTolerance, (short) intFlag];
            int count = overlapedShapes.Count;
            */
            Visio.Selection overlapedShapes = SelectedShape.SpatialNeighbors[(short)Visio.VisSpatialRelationCodes.visSpatialOverlap, intTolerance, 0];

            foreach (Visio.Shape overlapedShape in overlapedShapes)
            {
                if (overlapedShape.Master != null)
                {
                    
                }
            }

            var Count = overlapedShapes.Count;

            /*
            List<Visio.Shape> overlapedShapes = new List<Visio.Shape>();


            List<Visio.Shape> lists = AnalyzePage(ActivePage.Shapes);

            var count = ActivePage.Shapes.Count;
            var shapecount = lists.Count;

            foreach (Visio.Shape vsoShapeOnPage in lists)
            {
                short intReturnValue = SelectedShape.SpatialRelation[vsoShapeOnPage, intTolerance, (short) intFlag];

                switch (intReturnValue)
                {
                    case (short) Visio.VisSpatialRelationCodes.visSpatialOverlap:
                        overlapedShapes.Add(vsoShapeOnPage);
                        break;
                }
            }

            string message = overlapedShapes.Count.ToString();
            const string caption = "Information";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            */
        }

        private List<Visio.Shape> AnalyzePage(Visio.Shapes shapes)
        {
            List<Visio.Shape> result = new List<Visio.Shape>();
            foreach (Visio.Shape shape in shapes)
            {
                AnalyzePage(shape, ref result);
            }
            return result;
        }

        private void AnalyzePage(Visio.Shape shape, ref List<Visio.Shape> result)
        {
            double sx = shape.Cells["PinX"].Result[Visio.VisUnitCodes.visCentimeters];
            double sy = shape.Cells["PinY"].Result[Visio.VisUnitCodes.visCentimeters];
            double sangle = shape.Cells["Angle"].Result[Visio.VisUnitCodes.visAngleUnits];
            double width = shape.Cells["Width"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];
            double height = shape.Cells["Height"].Result[Microsoft.Office.Interop.Visio.VisUnitCodes.visCentimeters];

            if (shape.Master != null)
            {
                result.Add(shape);
            }
            else
            {
                int shapeCount = shape.Shapes.Count;
                if (shapeCount > 0)
                {
                    for (int i = 1; i <= shapeCount; i++)
                    {
                        AnalyzePage(shape.Shapes[i], ref result);
                    }
                }
            }
        }
    }
}
