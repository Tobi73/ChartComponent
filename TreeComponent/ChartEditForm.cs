using ChartComponent;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TreeComponent
{
    public partial class ChartEditForm : Form
    {
        ChartModel model;
        Func<string, ChartModel> loadFileFunction;

        public ChartEditForm(ChartModel model, Func<string, ChartModel> func = null)
        {
            InitializeComponent();
            this.model = model;
            chartNameTextBox.Text = model.Text;
            loadFileFunction = func ?? LoadFromCsv;
        }

        public ChartEditForm(Func<string, ChartModel> func = null)
        {
            InitializeComponent();
            loadFileFunction = func ?? LoadFromCsv;
        }

        public ChartEditForm()
        {
            InitializeComponent();
            loadFileFunction = LoadFromCsv;
        }

        public ChartModel ChartModel
        {
            get
            {
                return model;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(chartNameTextBox.Text.Length != 0)
            {
                if(model == null)
                {
                    model = new ChartModel()
                    {
                        Text = chartNameTextBox.Text
                    };
                } else
                {
                    model.Text = chartNameTextBox.Text;
                }
                Close();
            } else
            {
                MessageBox.Show("Введите название графика!");
            }
        }

        private void buttonOpenTable_Click(object sender, EventArgs e)
        {
            FormTable ft = new FormTable(model);
            ft.ShowDialog();
            
                model = ft.Chart;
            
        }

        public virtual ChartModel LoadChart(string fname)
        {
            return loadFileFunction(fname);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    model = loadFileFunction(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка:{ex.ToString()}");
                }

            }
        }

        private ChartModel LoadFromCsv(string fname)
        {
            var chartModel = new ChartModel();
            var lines = File.ReadAllLines(fname, Encoding.UTF8);
            var names = lines[0]?.Split(';');
            chartModel.Name = names.GetValue(0)?.ToString() ?? "Chart";
            chartModel.NameX = names.GetValue(1)?.ToString() ?? "X";
            chartModel.NameY = names.GetValue(2)?.ToString() ?? "Y";

            foreach (var xValue in lines[1]?.Split(';'))
            {
                chartModel.AxisX.Add(xValue);
            }

            for (var i = 2; i < lines.Length; i++)
            {
                var serieElements = lines[i]?.Split(';');
                var serie = new Serie(serieElements[0]);
                for (var k = 1; k < serieElements.Length; k++)
                {
                    serie.PointsList.Add(chartModel.AxisX[k - 1], double.Parse(serieElements[k]));
                }
                chartModel.SeriesList.Add(serie);
            }
            return chartModel;
        }

        private void ChartEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
