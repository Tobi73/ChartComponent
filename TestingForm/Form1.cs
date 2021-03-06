﻿using ChartComponent;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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
            //customGroupBox1.SetFileLoadFunction(lalal);
            foreach (var a in Enum.GetValues(typeof(SeriesChartType)))
            {
                comboBox1.Items.Add(a);
            }

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customGroupBox1.testAddData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customGroupBox1.ConvertToExcel();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customGroupBox1.SerializeJson();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customGroupBox1.DeserializeJson();
            //customGroupBox1.chartTree.ba
        }

        public ChartModel lalal(string filepath)
        {
            MessageBox.Show(filepath);
            return new ChartModel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            customGroupBox1.TypeOfChart = (SeriesChartType)comboBox1.SelectedItem;
            customGroupBox1.Invalidate();
        }
    }
}
