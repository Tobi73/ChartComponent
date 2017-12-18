using System;
using System.Windows.Forms;

namespace MainComponent
{
    partial class CustomGroupBox
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chartTree = new TreeComponent.ChartTree(this.components);
            this.customChart = new ChartComponent.CustomChart(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customChart)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chartTree
            // 
            this.SetColumnSpan(this.chartTree, 1);
            this.chartTree.Location = new System.Drawing.Point(3, 3);
            this.chartTree.Name = "chartTree";
            this.chartTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTree.RootName = "Chart Tree";
            this.chartTree.Size = new System.Drawing.Size(242, 172);
            this.chartTree.TabIndex = 8;
            this.chartTree.Text = "chartTree";
            // this.chartTree.tree.NodeMouseClick += new TreeNodeMouseClickEventHandler(takeChartFromTree);
            this.chartTree.OnChartNodeSelect += new EventHandler(takeChartFromTree);
            // 
            // customChart
            // 
            this.customChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.customChart.ChartAreas.Add(chartArea2);
            this.SetColumnSpan(this.customChart, 1);
            legend2.Name = "Legend1";
            this.customChart.Legends.Add(legend2);
            this.customChart.Location = new System.Drawing.Point(251, 3);
            this.customChart.Name = "customChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.customChart.Series.Add(series2);
            this.customChart.Size = new System.Drawing.Size(245, 172);
            this.customChart.TabIndex = 9;
            this.customChart.Text = "customChart";
            // 
            // CustomGroupBox
            // 
            this.ColumnCount = 2;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Controls.Add(this.chartTree, 0, 0);
            this.Controls.Add(this.customChart, 1, 0);
            this.Location = new System.Drawing.Point(66, 60);
            this.RowCount = 1;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            this.Size = new System.Drawing.Size(499, 174);
            this.TabIndex = 8;
            ((System.ComponentModel.ISupportInitialize)(this.customChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private TreeComponent.ChartTree chartTree;
        private ChartComponent.CustomChart customChart;



    }
}
