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

        public void Draw(ChartModel chartModel)
        {
            Series.RemoveAt(0);
            foreach (var serie in chartModel.SeriesList)
            {
                var newSerie = new Series();
                newSerie.Name = serie.SerieName;
                foreach (var value in serie.Y)
                {
                    newSerie.Points.AddXY(value.Key, value.Value);
                }
                Series.Add(newSerie);
            }
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var gr = CreateGraphics();
            Refresh();
            gr.DrawLine(new Pen(Color.Red), 50, 50, e.X, e.Y);
        }

    }
}
