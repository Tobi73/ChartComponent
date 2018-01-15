using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void customGroupBox1_OnChartNodeDelete(object sender, EventArgs e)
        {
            var text = textBox1.Text + "\n удаление узла";
            textBox1.Text = text;
        }

        private void customGroupBox1_OnChartNodeSelect(object sender, EventArgs e)
        {
            var text = textBox1.Text + "\n выделение узла узла";
            textBox1.Text = text;
        }
    }
}
