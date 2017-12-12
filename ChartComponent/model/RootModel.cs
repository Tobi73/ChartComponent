using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;

namespace ChartComponent
{
    public class RootModel : TreeNode
    {

        protected List<ChartModel> children;
        protected string name;

        public RootModel()
        {
            Name = "root";
            Children = new List<ChartModel>();
        }

        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        [DataMember]
        public List<ChartModel> Children
        {
            set
            {
                children = value;
            }
            get
            {
                return children;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
