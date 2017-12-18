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
                        ChartName = chartNameTextBox.Text
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
    }
}
