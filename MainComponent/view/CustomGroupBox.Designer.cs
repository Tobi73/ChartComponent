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
            components = new System.ComponentModel.Container();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();

            btnSave = new System.Windows.Forms.Button();
            btnLoad = new System.Windows.Forms.Button();
            btnConvert = new System.Windows.Forms.Button();
            btnTable = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();

            chartTree = new TreeComponent.ChartTree(this.components);
            customChart = new ChartComponent.CustomChart(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customChart)).BeginInit();
            SuspendLayout();
            // 
            // this
            // 
            this.ColumnCount = 4;
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.Controls.Add(this.btnSave, 0, 1);
            this.Controls.Add(this.btnConvert, 2, 1);
            this.Controls.Add(this.btnLoad, 1, 1);
            this.Controls.Add(this.btnTable, 3, 1);
            this.Controls.Add(this.chartTree, 0, 0);
            this.Controls.Add(this.customChart, 2, 0);
            this.Location = new System.Drawing.Point(66, 60);
            this.Name = "tableLayoutPanelMain";
            this.RowCount = 2;
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.4878F));
            this.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.Size = new System.Drawing.Size(499, 174);
            this.TabIndex = 8;

            // 
            // btnSave
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnSave.Location = new System.Drawing.Point(87, 218);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnLoad.Location = new System.Drawing.Point(6, 218);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(75, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnConvert
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnConvert.Location = new System.Drawing.Point(314, 218);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(75, 23);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "convert";
            btnConvert.UseVisualStyleBackColor = true;
            btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnTable
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.None;
            btnTable.Location = new System.Drawing.Point(400, 218);
            btnTable.Name = "btnTable";
            btnTable.Size = new System.Drawing.Size(75, 23);
            btnTable.TabIndex = 0;
            btnTable.Text = "table";
            btnTable.UseVisualStyleBackColor = true;
            btnTable.Click += new System.EventHandler(this.btnTable_Click);
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // chartTree1
            // 
            SetColumnSpan(chartTree, 2);
            chartTree.Location = new System.Drawing.Point(3, 3);
            chartTree.Name = "chartTree";
            chartTree.RootName = "Chart Tree";
            chartTree.Size = new System.Drawing.Size(242, 134);
            chartTree.TabIndex = 8;
            chartTree.Text = "chartTree";
            // 
            // customchart
            // 
            customChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            customChart.ChartAreas.Add(chartArea1);
            SetColumnSpan(this.customChart, 2);
            legend1.Name = "Legend1";
            customChart.Legends.Add(legend1);
            customChart.Location = new System.Drawing.Point(251, 3);
            customChart.Name = "customChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            customChart.Series.Add(series1);
            customChart.Size = new System.Drawing.Size(245, 134);
            customChart.TabIndex = 9;
            customChart.Text = "customChart";



            ClientSize = new System.Drawing.Size(480,250);
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnTable;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private TreeComponent.ChartTree chartTree;
        private ChartComponent.CustomChart customChart;



    }
}
