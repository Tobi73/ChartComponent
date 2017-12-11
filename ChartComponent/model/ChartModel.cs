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

    public class Serie
    {
        private List<double> x = new List<double>();
        private List<double?> y = new List<double?>();
        private string serieName;

        [DataMember]
        public string SerieName
        {
            get
            {
                return SerieName;
            }
            set
            {
                serieName = value;
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

       

    }
    public class ChartModel : RootModel
    {
        public List<Serie> Series;
        private SeriesChartType chartType;
        private string nameX;
        private string nameY;

        [DataMember]
        public string NameX
        {
            get { return nameX; }
            set { nameX = value; }
        }

        [DataMember]
        public string NameY
        {
            get { return nameY; }
            set { nameY = value; }
        }

        public ChartModel(string chartName) : base()
        {
            Name = chartName;
            Series = new List<Serie>();
        }

        public ChartModel() : base()
        {
            Series = new List<Serie>();
        }

        public void AddValue(int index, double xValue, double? yValue = null)
        {
            Series[index].X.Add(xValue);
            Series[index].Y.Add(yValue);
        }

        public void AddSerie(Serie serie)
        {
            Series.Add(serie);
        }

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
    }
}
