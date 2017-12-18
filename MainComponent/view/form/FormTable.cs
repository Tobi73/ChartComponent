using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartComponent;

namespace MainComponent.view.form
{
    public partial class FormTable : Form
    {
        public FormTable(ChartModel _chart)
        {
            InitializeComponent();

            this.chart = _chart;
        }

        private ChartModel chart;
        public bool save = false;
        public ChartModel Chart
        {
            get { return chart; }
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            writeTable();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save = true;
            changeChart();
            Close();
        }

        private void writeTable()
        {
            List<string> xList = new List<string>();

            dataGridView1.Columns.Add("c0", "");


            int j = 1;
            string[] row;
            foreach (Serie s in chart.SeriesList)
            {
                foreach (var point in s.PointsList)
                {
                    if (!xList.Contains(point.Key))
                    {
                        xList.Add(point.Key);
                        dataGridView1.Columns.Add("c" + j, "");
                        j++;
                    }
                }
            }
            xList.Insert(0, "");
            dataGridView1.Rows.Add(xList.ToArray());
            xList.RemoveAt(0);

            bool isFirstRow = true;
            string[] firtsRow = new string[xList.Count + 1];
            foreach (Serie s in chart.SeriesList)
            {
                row = new string[xList.Count + 1];
                row[0] = s.SerieName;
                j = 1;
                foreach (var x in xList)
                {
                    if (isFirstRow)
                    {

                    }
                    if (s.PointsList.ContainsKey(x))
                    {
                        row[j] = s.PointsList[x].ToString();
                    }
                    j++;
                }
                dataGridView1.Rows.Add(row);

            }
        }

        private void changeChart()
        {
            chart = new ChartModel(chart.ChartName);
            for(int j = 1; j < dataGridView1.Rows.Count-1; j++)
            {
                chart.AddSerie(new Serie(dataGridView1[0, j].Value.ToString()));

                for(int i = 1; i < dataGridView1.Columns.Count; i++)
                {
                    if(dataGridView1[i, j].Value != null)
                    {
                        double y;
                        string s = dataGridView1[i, j].Value.ToString();
                        double.TryParse(s,out y);
                        chart.AddValue(j - 1, dataGridView1[i, 0].Value.ToString(), y);
                    }
                }
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("c" + dataGridView1.Columns.Count, "");
        }

        private void btnDeleteColumn_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove(dataGridView1.SelectedCells[0].OwningColumn);

        }
    }
}
