using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartComponent
{
    public enum ChartType
    {
        Column = 1,
        Pie = 2
    }

    public class ChartModel : RootModel
    {
        private List<double> x = new List<double>();
        private List<double?> y = new List<double?>();

        private SeriesChartType chartType;

        [DataMember]
        public SeriesChartType ChartType
        {
            get
            {
                return chartType;
            }
            set
            {
                chartType = value;
            }
        }

        [DataMember]
        public List<double> X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        [DataMember]
        public List<double?> Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public ChartModel(string chartName) : base()
        {
            Name = chartName;
        }
        public ChartModel() : base() { }

        public void AddValue(double xValue, double? yValue = null)
        {
            X.Add(xValue);
            Y.Add(yValue);
        }
    }
}
