using ChartComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeComponent
{
    public class ChartEditEventArgs: EventArgs
    {
        public ChartEditEventArgs(ChartModel model)
        {
            this.model = model;
        }

        ChartModel model;

        public ChartModel ChartModel
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

    }
}
