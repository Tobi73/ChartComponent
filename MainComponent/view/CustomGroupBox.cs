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
    public partial class CustomGroupBox : TableLayoutPanel
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
        private ChartModel thisChart;
        private RootModel tree;

        [Category("New"), Description("Can user's work with table?")]
        public bool UseTable
        {
            set {
                useTable = value;
                Invalidate();
            }
            get { return useTable; }
        }

        private void test()
        {
            tree = new RootModel();
            tree.Children.Add(new ChartModel());
            tree.Children.Add(new ChartModel());
            tree.Children.Add(new ChartModel());
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) 
        {
            test();

            base.OnPaint(e);
            
            if (!useTable)
            {
                btnTable.Visible = false;
            }

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            thisChart = new ChartModel("график движения ребят");
            testAddData();
            //FormTable ft = new FormTable(thisChart);
            //ft.ShowDialog();
            
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
                tree = new RootModel();
                tree = Serializer.Deserialize(openFileDialog1.FileName);
                if(tree.Children.Count == 0)
                {
                    MessageBox.Show("не удалось загрузить дерево");
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            Converter conv;
            saveFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                conv = new Converter(saveFileDialog1.FileName, thisChart);

                conv.buildTableExcel(); // ew - ExcelWorker, работа с отчетами
                conv.closeFile();
                MessageBox.Show("Сохранено");

            }

            
        }

        /// <summary>
        /// обработчик события получения выделенного chartModel из chartTree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void takeChartFromTree(object sender, EventArgs e)
        {
            if(chartTree.SelectedChartNode is ChartModel)
            {
                thisChart = chartTree.SelectedChartNode as ChartModel;
                customChart.Draw(thisChart);
            }

        }

        /// <summary>
        /// примерные действия программиста для заполнения ChartModel
        /// </summary>
        private void testAddData()
        {
            thisChart.AddSerie("пешеход");
            thisChart.AddSerie("велосипедист");
            thisChart.AddSerie("мотоциклист");
            thisChart.NameX = "T(час)";
            thisChart.NameY = "S(км)";
            thisChart.AddValue(0, 1, 5);
            thisChart.AddValue(0, 2, 10);
            thisChart.AddValue(0, 3, 15);
            thisChart.AddValue(0, 4, 20);

            thisChart.AddValue(1, 1, 20);
            thisChart.AddValue(1, 2, 40);
            thisChart.AddValue(1, 3, 60);
            thisChart.AddValue(1, 4, 80);

            thisChart.AddValue(2, 1, 50);
            thisChart.AddValue(2, 2, 100);
            thisChart.AddValue(2, 3, 150);
            thisChart.AddValue(2, 4, 200);

            customChart.Draw(thisChart);
        }




    }
}
