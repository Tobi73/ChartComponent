using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartComponent;
using System.Runtime.Serialization;
using System.IO;

namespace TreeComponent
{
    public class TreeModel
    {
        private List<ChartModel> children;
        private string name = "root";

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

        public TreeModel()
        {
            children = new List<ChartModel>();
        }
    }
}
