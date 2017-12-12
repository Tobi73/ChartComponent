using ChartComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestingForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cm = new ChartModel
            {
                ChartName = "test",
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
                Children = null,
            };
            cm.AddSerie("MySerie");
            cm.AddValue(0, 23, 32);
            govnoblyapotom1.Draw(cm);
        }
    }
}
