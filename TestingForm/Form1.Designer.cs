namespace TestingForm
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.govnoblyapotom1 = new ChartComponent.Govnoblyapotom(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.govnoblyapotom1)).BeginInit();
            this.SuspendLayout();
            // 
            // govnoblyapotom1
            // 
            chartArea1.Name = "ChartArea1";
            this.govnoblyapotom1.ChartAreas.Add(chartArea1);
            this.govnoblyapotom1.Childs = null;
            legend1.Name = "Legend1";
            this.govnoblyapotom1.Legends.Add(legend1);
            this.govnoblyapotom1.Location = new System.Drawing.Point(22, 34);
            this.govnoblyapotom1.Name = "govnoblyapotom1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.govnoblyapotom1.Series.Add(series1);
            this.govnoblyapotom1.Size = new System.Drawing.Size(533, 298);
            this.govnoblyapotom1.TabIndex = 0;
            this.govnoblyapotom1.Text = "govnoblyapotom1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 392);
            this.Controls.Add(this.govnoblyapotom1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.govnoblyapotom1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ChartComponent.Govnoblyapotom govnoblyapotom1;
    }
}

