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
            try { 
                string path = Globals.ThisAddIn.RootPath + xmlFileName;
                XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
                if (System.IO.File.Exists(path))
                { 
                    FileStream fs = new FileStream(path, FileMode.Open);
                    this._shapetype = (ShapeTypes)serializer.Deserialize(fs);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                this._shapetype = new ShapeTypes();
            }
        }

        public void saveXml()
        {
            try { 
                string path = Globals.ThisAddIn.RootPath + xmlFileName;
                XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
                TextWriter writer = new StreamWriter(path);

                serializer.Serialize(writer, this._shapetype);
                writer.Close();
            }
            catch (Exception e)
            {

            }
        }

        public ShapeInfo getShapeInfo(string baseId)
        {
            char[] charsToTrim = { '{', '}' };

            List<ShapeInfo> shapeInfos = this._shapetype._shapeInfos;
            foreach (ShapeInfo s in shapeInfos)
            {
                string sbaseId = s.baseId;

                if (sbaseId == baseId)
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
