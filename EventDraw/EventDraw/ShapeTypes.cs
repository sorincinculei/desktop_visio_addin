using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EventDraw
{
    [XmlRoot("ShapeTypes")]
    [XmlInclude(typeof(ShapeInfo))]
    public class ShapeTypes
    {
        [XmlArray("ShapeInfos")]
        public List<ShapeInfo> _shapeInfos = new List<ShapeInfo>();

        public ShapeTypes()
        {

        }

        public void addShapeInfo(ShapeInfo newS)
        {
            if (this._shapeInfos.Contains(newS))
            {
                this._shapeInfos.Remove(newS);
                this._shapeInfos.Add(newS);
            }
            else
            {
                this._shapeInfos.Add(newS);
            }
        }

        private void removeShapeInfo()
        {

        }
    }
}
