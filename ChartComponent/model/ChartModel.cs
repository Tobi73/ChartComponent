using System.Collections.Generic;
using System.Runtime.Serialization;


namespace ChartComponent
{

    public class ChartModel : TreeNodeModel
    {
        private List<double> x = new List<double>();
        private List<double> y = new List<double>();

        [DataMember]
        public List<double> X {
            get { return x; }
            set { x = value; }
        }

        [DataMember]
        public List<double> Y
        {
            get { return y; }
            set { y = value; }
        }


        public ChartModel()
        {
            children = new List<ChartModel>();
            name = "root";
        }

    }
}
