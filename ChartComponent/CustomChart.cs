using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ChartComponent
{
    public partial class CustomChart : Chart
    {
        public CustomChart()
        {
            InitializeComponent();
        }

        public CustomChart(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private SeriesChartType typeOfChart;

        public SeriesChartType TypeOfChart
        {
            set
            {
                typeOfChart = value;
            }
            get
            {
                return typeOfChart;
            }
        }

        /// <summary>
        /// Creating chart by chart model
        /// </summary>
        /// <param name="chartModel"></param>
        public void Draw(ChartModel chartModel)
        {
            if(Series.Count > 0)
            {
                Series.Clear();
            }
            
            foreach (var serie in chartModel.SeriesList)
            {
                var newSerie = new Series();
                newSerie.Name = serie.SerieName;
                newSerie.ChartType = typeOfChart;
                foreach (var x in chartModel.AxisX)
                {
                    var p = new DataPoint();
                    double yValue;
                    if(serie.PointsList.TryGetValue(x, out yValue))
                    {
                        p.SetValueXY(x, yValue);
                        p.ToolTip = $"x - {x}\ny - {yValue}";
                    }
                    newSerie.Points.Add(p);
                }
                if (serie.Color != null)
                    newSerie.Color = serie.Color;
                Series.Add(newSerie);
            }
            ChartAreas[0].AxisX.Minimum = 0;
            foreach(var legend in Legends)
            {
                legend.Docking = Docking.Bottom;
            }
            Refresh();
        }

    }
}
