using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ChartComponent
{
    public abstract class TreeNodeModel
    {
        protected List<ChartModel> children;
        protected string name;

        [DataMember]
        public string Name
        {
            get { return name; }
        }

        [DataMember]
        public List<ChartModel> Children
        {
            set { children = value; }
            get { return children; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
