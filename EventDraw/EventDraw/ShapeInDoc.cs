using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventDraw
{
    public class ShapeInDoc
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
    }
}
