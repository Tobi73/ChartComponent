using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainComponent.view.form;
using ChartComponent;
using MainComponent.controller;
using TreeComponent;

namespace MainComponent
{
    [DesignerAttribute(typeof(CustomDesigner))]
    public partial class CustomGroupBox : GroupBox
    {
        public CustomGroupBox()
        {
            InitializeComponent();
        }

        public CustomGroupBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool useTable = true;
        private ChartModel chart;
        private TreeModel tree;

        [Category("New"), Description("Can user's work with table?")]
        public bool UseTable
        {
            set {
                useTable = value;
                Invalidate();
            }
            get { return useTable; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) 
        {
            base.OnPaint(e);
            if (!useTable)
            {
                btnTable.Visible = false;
            }

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            FormTable ft = new FormTable(chart);
            ft.ShowDialog();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                String mes = Serializer.Serialize(tree, saveFileDialog1.FileName);
                MessageBox.Show(mes);
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tree = new TreeModel();
                tree = Serializer.Deserialize(openFileDialog1.FileName);
                if(tree.Children.Count == 0)
                {
                    MessageBox.Show("не удалось загрузить дерево");
                }
            }
        }

    }
}
