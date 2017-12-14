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
using System.Windows.Forms.DataVisualization.Charting;

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

        [Category("New"), Description("Select type of chart")]
        public SeriesChartType TypeOfChart
        {
            set
            {
                customChart.TypeOfChart = value;
            }
            get
            {
                return customChart.TypeOfChart;
            }
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

            base.OnPaint(e);
            
            if (useTable)
            {
                btnTable.Visible = true;
            }
            else
            {
                btnTable.Visible = false;

            }

        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            FormTable ft = new FormTable(thisChart);
            ft.ShowDialog();
            if (ft.save)
            {
                thisChart = ft.Chart;
            }

            if (chartTree.SelectedChartNode is ChartModel)
            {
                customChart.Draw(thisChart);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            testAddData();
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
            tree = chartTree.RootNode;
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
            thisChart.AddValue(0, 1.ToString(), 5);
            thisChart.AddValue(0, 2.ToString(), 10);
            thisChart.AddValue(0, 3.ToString(), 15);
            thisChart.AddValue(0, 4.ToString(), 20);

            thisChart.AddValue(1, 1.ToString(), 20);
            thisChart.AddValue(1, 2.ToString(), 40);
            thisChart.AddValue(1, 3.ToString(), 60);
            thisChart.AddValue(1, 4.ToString(), 80);

            thisChart.AddValue(2, 1.ToString(), 50);
            thisChart.AddValue(2, 2.ToString(), 100);
            thisChart.AddValue(2, 3.ToString(), 150);
            thisChart.AddValue(2, 4.ToString(), 200);


            if (chartTree.SelectedChartNode is ChartModel)
            {
                customChart.Draw(thisChart);
            }
        }




    }
}
