﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChartComponent;
using MainComponent.controller;
using TreeComponent;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

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

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private ChartModel thisChart;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private RootModel tree;

        public void SetFileLoadFunction(Func<string, ChartModel> func)
        {
            chartTree.SetFileLoadFunc(func);
        }
        [Category("General"), Description("Tree/Chart Component Ratio (%)")]
        public float WidthChart
        {
            set
            {
                ColumnStyles[1].Width = value;
                ColumnStyles[0].Width = 100-value;
            }
            get
            {
                return ColumnStyles[1].Width;
            }
        }

        [Category("General"), Description("Default chart type")]
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

        [Category("Chart"), Description("Border color")]
        public Color BorderlineColorChart
        {
            set
            {
                customChart.BorderlineColor = value;
            }
            get
            {
                return customChart.BorderlineColor;
            }
        }

        [Category("Chart"), Description("Border width")]
        public int BorderlineWidthChart
        {
            set
            {
                customChart.BorderlineWidth = value;
            }
            get
            {
                return customChart.BorderlineWidth;
            }
        }

        [Category("Chart"), Description("Background color")]
        public Color BackColorChart
        {
            set
            {
                customChart.BackColor = value;
            }
            get
            {
                return customChart.BackColor;
            }
        }

        [Category("Chart"), Description("Border dash style")]
        public ChartDashStyle BorderlineDashStyleChart
        {
            set
            {
                customChart.BorderlineDashStyle = value;
            }
            get
            {
                return customChart.BorderlineDashStyle;
            }
        }

        [Category("Tree"), Description("Background color")]
        public Color BackColorTree
        {
            set
            {
                chartTree.tree.BackColor = value;
                
            }
            get
            {
                return chartTree.BackColor;
            }
        }

        [Category("Tree"), Description("Border style")]
        public BorderStyle BorderStyleTree
        {
            set
            {
                chartTree.tree.BorderStyle = value;
            }
            get
            {
                return chartTree.tree.BorderStyle;
            }
        }

        [Category("Tree"), Description("Font")]
        public Font FontTree
        {
            set
            {
                chartTree.Font = value;
                
            }
            get
            {
                return chartTree.Font;
            }
        }

        [Category("Tree"), Description("Chart node selection handler")]
        public event EventHandler OnChartNodeSelect
        {
            add
            {
                chartTree.OnChartNodeSelect += value;
            }
            remove
            {
                chartTree.OnChartNodeSelect -= value;
            }
        }

        [Category("Tree"), Description("Chart node removal handler")]
        public event EventHandler OnChartNodeDelete
        {
            add
            {
                chartTree.OnChartNodeDelete += value;
            }
            remove
            {
                chartTree.OnChartNodeDelete -= value;
            }
        }

        [Category("Tree"), Description("Chart node add handler")]
        public event ChartTreeAddEventHandler OnChartAdd
        {
            add
            {
                chartTree.OnChartAdd += value;
            }
            remove
            {
                chartTree.OnChartAdd -= value;
            }
        }

        [Category("Tree"), Description("Chart node edit handler")]
        public event ChartTreeEditEventHandler OnChartEdit
        {
            add
            {
                chartTree.OnChartEdit += value;
            }
            remove
            {
                chartTree.OnChartEdit -= value;
            }
        }

        [Category("Tree"), Description("Name of the root node")]
        public string RootName
        {
            get
            {
                return chartTree.RootName;
            }
            set
            {
                chartTree.RootName = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RootModel RootNode
        {
            get
            {
                return chartTree.RootNode;
            }
            set
            {
                chartTree.RootNode = value;
            }
        }

        public Func<string, ChartModel> FileLoadFunc
        {
            set
            {
                chartTree.SetFileLoadFunc(value);
            }
        }

        public TreeView ChartTreeView
        {
            get
            {
                return chartTree.ChartTreeView;
            }
        }

        public TreeNode SelectedChartNode
        {
            get
            {
                return chartTree.SelectedChartNode;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            customChart.Invalidate();
            if (thisChart != null)
            {
                customChart.Draw(thisChart);
            }
        }

        /// <summary>
        /// обработчик события получения выделенного chartModel из chartTree
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void takeChartFromTree(object sender, EventArgs e)
        {
            takeTree();
            takeChartFromTreeMeth();

        }

        public void deleteChartNodeEvent(object sender, EventArgs e)
        {
            takeTree();
            takeChartFromTreeMeth();
        }

        public void takeTree()
        {
            tree = chartTree.RootNode;
        }

        public void takeChartFromTreeMeth()
        {
            if (chartTree.SelectedChartNode is ChartModel)
            {
                thisChart = chartTree.SelectedChartNode as ChartModel;
                customChart.Draw(thisChart);
            }
        }

        

        /// <summary>
        /// примерные действия программиста для заполнения ChartModel
        /// </summary>
        public void testAddData()
        {
            thisChart.SeriesList.Clear();
            thisChart.AddSerie(new Serie("пешеход", Color.Blue));
            thisChart.AddSerie(new Serie("велосипедист", Color.Brown));
            thisChart.AddSerie(new Serie("мотоциклист", Color.Red));
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

        public void SerializeJson()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Serializer.Serialize(tree, saveFileDialog1.FileName);
                }
                catch(Exception e)
                {
                    MessageBox.Show($"Ошибка:{e.ToString()}");
                }
            }
        }

        public void DeserializeJson()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var deserialised = Serializer.Deserialize(openFileDialog1.FileName);
                    tree = deserialised;
                    chartTree.RootNode = deserialised;
                } catch(Exception e)
                {
                    MessageBox.Show($"Ошибка:{e.ToString()}");
                }
               
            }
        }

        public void ConvertToExcel()
        {
            saveFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if(thisChart == null)
            {
                MessageBox.Show("график не выбран");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                XlsxExporter converter = new XlsxExporter();
                converter.export(saveFileDialog1.FileName, thisChart);
                MessageBox.Show("Сохранено");
            }
            saveFileDialog1.Filter = null;
        }

        public void ShowTable()
        {
            FormTable ft = new FormTable(thisChart);
            ft.ShowDialog();
            
                thisChart = ft.Chart;
            

            if (chartTree.SelectedChartNode is ChartModel)
            {
                customChart.Draw(thisChart);
            }
        }
    }
}
