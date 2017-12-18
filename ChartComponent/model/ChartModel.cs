using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartComponent
{
    [DataContract]
    public class Serie
    {
        public Serie() { }

        public Serie(string name, Color c)
        {
            pointsList = new Dictionary<string, double>();
            serieName = name;
            color = c;
        }

        public Serie(string name)
        {
            Random r = new Random(255);
            pointsList = new Dictionary<string, double>();
            serieName = name;
            color = Color.FromArgb(r.Next());
        }

        private Color color;
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

        public Color Color
        {
            get { return color; }
            set { color = value; }
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
        public List<string> AxisX;


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
            AxisX = new List<string>();
        }

        public ChartModel() : base()
        {
            seriesList = new List<Serie>();
            AxisX = new List<string>();
        }

        public void AddValue(int indexSerie, string xValue, double yValue)
        {
            if (indexSerie < seriesList.Count)
            {
                Serie s = seriesList[indexSerie];
                s.PointsList[xValue] = yValue;
                if (!AxisX.Contains(xValue))
                {
                    AxisX.Add(xValue);
                }
            }
        }

        public void AddSerie(Serie s)
        {
            seriesList.Add(s);
        }

    }
}
