using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartComponent
{
    [DataContract]
    public class Serie
    {
        public Serie() { }

        public Serie(string name)
        {
            pointsList = new Dictionary<string, double>();
            serieName = name;
        }

        private Dictionary<string, double> pointsList;
        private string serieName;

        [DataMember]
        public string SerieName
        {
            get
            {
                return serieName;
            }
            set
            {
                serieName = value;
            }
        }

        [DataMember]
        public Dictionary<string, double> PointsList
        {
            get
            {
                return pointsList;
            }
            set
            {
                pointsList = value;
            }
        }
    }

    [DataContract]
    public class ChartModel : RootModel
    {
        private List<Serie> seriesList;
        private string nameX;
        private string nameY;



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
            ChartName = chartName;
            Text = chartName;
            seriesList = new List<Serie>();
        }

        public ChartModel() : base()
        {
            seriesList = new List<Serie>();
        }

        public void AddValue(int indexSerie, string xValue, double yValue)
        {
            if (indexSerie < seriesList.Count)
            {
                Serie s = seriesList[indexSerie];
                s.PointsList[xValue] = yValue;
            }
        }


        public void AddSerie(string name)
        {
            Serie serie = new Serie(name);
            seriesList.Add(serie);
        }

    }
}
