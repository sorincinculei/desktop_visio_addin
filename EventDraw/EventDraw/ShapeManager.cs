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

        public ShapeManager()
        {
            LoadXml();
        }
        
        public void LoadXml()
        {
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + xmlFileName;
            //XmlDocument xDoc = new XmlDocument();
            //xDoc.LoadXml(path);

            //XmlElement xRoot = xDoc.DocumentElement;

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + xmlFileName;
            XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
            FileStream fs = new FileStream(path, FileMode.Open);
            ShapeTypes shapetype;
            shapetype = (ShapeTypes)serializer.Deserialize(fs);
            fs.Close();
        }

        public void saveXml()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + xmlFileName;
            XmlSerializer serializer = new XmlSerializer(typeof(ShapeTypes));
            TextWriter writer = new StreamWriter(path);
            ShapeTypes shapetype = new ShapeTypes();

            serializer.Serialize(writer, shapetype);
            writer.Close();
        }
    }
}
