using System;
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

        private ChartModel thisChart;
        private RootModel tree;

        public void SetFileLoadFunction(Func<string, ChartModel> func)
        {
            chartTree.SetFileLoadFunc(func);
        }
        [Category("New"), Description("Select width CustomChart (%)")]
        public float widthChart
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

        [Category("CustomChart"), Description("Select type of chart")]
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

        [Category("CustomChart"), Description("Select borders color")]
        public Color BorderColorChart
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

        [Category("CustomChart"), Description("Select borders width")]
        public int BorderWidthChart
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

        [Category("CustomChart"), Description("Select back color")]
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

        //[Category("CustomChart"), Description("Select BackImage")]
        //public string BackImageChart
        //{
        //    set
        //    {
        //        customChart.BackImage = value;
        //        customChart.Invalidate();
        //    }
        //    get
        //    {
        //        return customChart.BackImage;
        //    }
        //}

        [Category("CustomTree"), Description("Select back color")]
        public Color BackColorTree
        {
            set
            {
                chartTree.BackColor = value;
                
            }
            get
            {
                return chartTree.BackColor;
            }
        }

        [Category("CustomTree"), Description("Select BackgroundImage")]
        public Image BackgroundImageTree
        {
            set
            {
                chartTree.BackgroundImage = value;
            }
            get
            {
                return chartTree.BackgroundImage;
            }
        }

        [Category("CustomTree"), Description("Select Font")]
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

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
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
