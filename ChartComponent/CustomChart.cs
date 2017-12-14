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
                //foreach (var value in serie.PointsList)
                //{
                //    var p = new DataPoint();
                //    p.SetValueXY(value.Key, value.Value);
                //    p.ToolTip = $"x - {value.Key}\ny - {value.Value}";
                //    newSerie.Points.Add(p);
                //}
                Series.Add(newSerie);
            }
            ChartAreas[0].AxisX.Minimum = 0;
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var gr = CreateGraphics();

            Refresh();

            var dp = new DataPoint(0, 0);
            gr.DrawLine(new Pen(Color.Red), (float)ChartAreas[0].AxisX.ValueToPixelPosition(0), e.Y, e.X, e.Y);
            gr.DrawLine(new Pen(Color.Red), e.X, (float)ChartAreas[0].AxisY.ValueToPixelPosition(0), e.X, e.Y);


        }

    }
}
