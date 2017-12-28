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

namespace TreeComponent
{
    public partial class ChartEditForm : Form
    {
        ChartModel model;

        public ChartEditForm(ChartModel model)
        {
            InitializeComponent();
            this.model = model;
            chartNameTextBox.Text = model.Text;
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
            FormTable ft = new FormTable(new ChartModel(chartNameTextBox.Text));
            ft.ShowDialog();
            if (ft.save)
            {
                model = ft.Chart;
            }
        }

        public virtual ChartModel LoadChart(string fname)
        {
            return new ChartModel();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    model = LoadChart(openFileDialog1.FileName);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка:{ex.ToString()}");
                }

            }
        }
    }
}
