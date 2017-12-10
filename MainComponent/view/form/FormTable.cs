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

        ChartModel chart;

        private void FormTable_Load(object sender, EventArgs e)
        {

        }
    }
}
