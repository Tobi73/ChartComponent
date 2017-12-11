using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace ChartComponent
{
    public class RootModel : TreeNodeModel
    {

        public RootModel()
        {
            children = new List<ChartModel>();
            name = "root";
        }
    }
}
