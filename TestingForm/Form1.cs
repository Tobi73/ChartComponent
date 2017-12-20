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
            //var cm = new ChartModel
            //{
            //    ChartName = "test",
            //    ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column,
            //    Children = null,
            //};
            //cm.AddSerie("MySerie");
            //cm.AddValue(0, 23, 32);
            //cm.AddValue(0, 25, 37);
            //cm.AddValue(0, 28, 40);
            //cm.AddValue(0, 30, 23);
            //cm.AddValue(0, 50, 32);

            //govnoblyapotom1.Draw(cm);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            customGroupBox1.testAddData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customGroupBox1.convertToExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customGroupBox1.serializeXml();
        }
    }
}
