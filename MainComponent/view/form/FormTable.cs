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
        public FormTable(/* График */)
        {
            InitializeComponent();


        }

        Govnoblyapotom chart;

        private void FormTable_Load(object sender, EventArgs e)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
            row.Cells[0].Value = "XYZ";
            row.Cells[1].Value = 50.2;
            dataGridView1.Rows.Add(row);
        }
    }
}
