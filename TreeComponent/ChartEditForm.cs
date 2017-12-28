using ChartComponent;
using System;
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
            loadFileFunction = func;
        }

        public ChartEditForm(Func<string, ChartModel> func = null)
        {
            InitializeComponent();
            loadFileFunction = func;
        }

        public ChartEditForm()
        {
            InitializeComponent();
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

        private void ChartEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
