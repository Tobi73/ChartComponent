using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ChartComponent
{
    public partial class Govnoblyapotom : Chart
    {
        public Govnoblyapotom()
        {
            InitializeComponent();
        }

        public Govnoblyapotom(IContainer container)
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
            Series[0].Name = chartModel.Name;
            Series[0].ChartType = chartModel.ChartType;

            for (var i = 0; i < chartModel.X.Count; i++)
            {
                Series[0].Points.AddXY(chartModel.X[i], chartModel.Y[i]);
            }

            var s2 = new Series();
            s2.Points.AddXY(20, 50);
            Series.Add(s2);
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            var gr = CreateGraphics();
            Refresh();
            gr.DrawLine(new Pen(Color.Red), ChartAreas[0].Position.X, ChartAreas[0].Position.Y, e.X, e.Y);
        }

    }
}
