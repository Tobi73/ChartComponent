using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChartComponent;

namespace TreeComponent
{
    class TreeModel
    {
        private List<ChartModel> children;
        private string name = "root";


        public string Name
        {
            get { return name; }
        } 

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
