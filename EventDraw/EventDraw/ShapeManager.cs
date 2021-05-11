using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace EventDraw
{
    public class ShapeManager
    {
        private string xmlFileName = @"\\shapes.xml";

        //private ShapeInDoc[] useShapes;
        private ShapeTypes _shapetype;

        public ShapeManager()
        {
            LoadXml();
        }
        
        public void LoadXml()
        {
            string path = Globals.ThisAddIn.RootPath + xmlFileName;
            XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
            FileStream fs = new FileStream(path, FileMode.Open);
            this._shapetype = (ShapeTypes)serializer.Deserialize(fs);
            fs.Close();
        }

        public void saveXml()
        {
            string path = Globals.ThisAddIn.RootPath + xmlFileName;
            XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
            TextWriter writer = new StreamWriter(path);

            serializer.Serialize(writer, this._shapetype);
            writer.Close();
        }

        public ShapeInfo getShapeInfo(string baseId)
        {
            List<ShapeInfo> shapeInfos = this._shapetype._shapeInfos;
            foreach (ShapeInfo s in shapeInfos)
            {
                if (s.baseId == baseId)
                {
                    return s;
                }
            }

            return new ShapeInfo();
        }

        public void saveShape(ShapeInfo newS)
        {
            this._shapetype.addShapeInfo(newS);
            this.saveXml();
        }
    }
}
