using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace EventDraw
{
    public class ShapeInfo : IEquatable<ShapeInfo>
    {
        [XmlElement("Id")]
        public string id;

        [XmlElement("BaseId")]
        public string baseId;

        public string Id3D;
        public string Class;
        public MasterSize MasterSize;
        public bool IsCustom;
        public bool PutOnTable;
        public bool HangOnTable;
        public bool LinksToCenter;

        [XmlElement("Model")]
        public Model model;

        [XmlElement("ModelParams")]
        public ModelParams modelParams;

        public ShapeInfo()
        {
            this.id = "";
            this.baseId = "";
            this.Id3D = "";
            this.Class = "";
            this.IsCustom = false;
            this.PutOnTable = false;
            this.HangOnTable = false;
            this.LinksToCenter = false;
            this.MasterSize = new MasterSize();
            this.model = new Model();
            this.modelParams = new ModelParams();
        }

        public bool Equals(ShapeInfo other)
        {
            if (baseId != other.baseId) return false;
            return true;
        }
    }

    public class MasterSize
    {
        public float width;
        public float height;

        public MasterSize()
        {
            this.width = 0;
            this.height = 0;
        }
    }

    public class Model
    {
        public string fileName;
        public string displayName;
        public bool IsCustomer;

        public Model()
        {
            this.fileName = "";
            this.displayName = "";
            this.IsCustomer = false;
        }
    }

    public class ModelParams
    {
        [XmlElement("Localtion")]
        public Location localtion;

        [XmlElement("Angle")]
        public Angle angle;

        [XmlElement("Scale")]
        public Scale scale;

        public float Height;
        public bool FlipXY;
        public bool ScaleHeight;

        public ModelParams()
        {
            this.localtion = new Location();
            this.angle = new Angle();
            this.scale = new Scale();
            this.Height = 0;
            this.FlipXY = false;
            this.ScaleHeight = false;
        }
    }

    public class Location
    {
        [XmlElement("X")]
        public float x;

        [XmlElement("Y")]
        public float y;

        [XmlElement("Z")]
        public float z;

        public Location()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
    }

    public class Angle
    {
        [XmlElement("X")]
        public float x;

        [XmlElement("Y")]
        public float y;

        [XmlElement("Z")]
        public float z;

        public Angle()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
    }

    public class Scale
    {
        [XmlElement("X")]
        public float x;

        [XmlElement("Y")]
        public float y;

        [XmlElement("Z")]
        public float z;

        public Scale()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
    }
}
