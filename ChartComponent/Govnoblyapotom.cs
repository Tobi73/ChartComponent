﻿using System.ComponentModel;
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
            Series.RemoveAt(0);
            foreach (var serie in chartModel.Series)
            {
                var s = new Series();
                s.ChartType = chartModel.ChartType;
                s.Name = "test";
                for (var i = 0; i < serie.X.Count; i++)
                {
                    s.Points.AddXY(serie.X[i], serie.Y[i]);
                }
                Series.Add(s);
            }
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
