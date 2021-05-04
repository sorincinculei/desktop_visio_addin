using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw
{
    public class ShapeInDoc : IEquatable<ShapeInDoc>
    {
        public string Name;
        public string BaseID;
        
        public void setName(string name)
        {
            this.Name = name;
        }

        public void setBaseID(string baseID)
        {
            this.BaseID = baseID;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getBaseID()
        {
            return this.BaseID;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public bool Equals(ShapeInDoc other)
        {
            if (other == null) return false;
            if (Name != other.Name) return false;
            if (BaseID != other.BaseID) return false;
            return true;
        }
    }
}
