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

        public Serie(string name)
        {
            y = new Dictionary<double, double>();
            serieName = name;
        }

        private Dictionary<double, double> y;
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
        public Dictionary<double, double> Y
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
        private List<Serie> seriesList;
        private SeriesChartType chartType;
        private string nameX;
        private string nameY;
        private List<double> x = new List<double>();

        [DataMember]
        public List<Serie> SeriesList
        {
            get
            {
                return seriesList;
            }
            set
            {
                seriesList = value;
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
            seriesList = new List<Serie>();
        }

        public ChartModel() : base()
        {
            seriesList = new List<Serie>();
        }

        public void AddValue(int indexSerie, double xValue, double yValue)
        {
            if (indexSerie <= seriesList.Count)
            {
                Serie s = seriesList[indexSerie];

                if (s.Y.ContainsKey(xValue))
                {
                    s.Y[xValue] = yValue;
                }
                else
                {
                    this.x.Add(xValue);
                    s.Y.Add(xValue, yValue);
                }
            }
        }





        public void AddSerie(string name)
        {
            Serie serie = new Serie(name);
            seriesList.Add(serie);
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
