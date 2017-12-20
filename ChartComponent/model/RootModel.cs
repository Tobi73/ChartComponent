using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ChartComponent
{
    [JsonObject]
    public class RootModel : TreeNode
    {

        protected List<ChartModel> children;
        protected string chartName;
        public RootModel()
        {
            ChartName = "root";
            Children = new List<ChartModel>();
        }

        [DataMember]
        public string ChartName
        {
            get
            {
                return chartName;
            }
            set
            {
                chartName = value;
                Text = value;
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
            return ChartName;
        }
    }
}
