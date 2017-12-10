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
        private List<Chart> childs;

        public List<Chart> Childs
        {
            get
            {
                return childs;
            }
            set
            {
                childs = value;
            }
        }

        public Chart GetChild(int index)
        {
            return childs.ElementAtOrDefault(index);
        }

        public Chart AddChild(Chart chart)
        {
            childs.Add(chart);
            return chart;
        }

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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            MessageBox.Show(e.X.ToString());
            var pp = ChartAreas[0].AxisX.PixelPositionToValue(e.X);
            MessageBox.Show(ChartAreas[0].Position.X.ToString());
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            MessageBox.Show(e.X.ToString());
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
