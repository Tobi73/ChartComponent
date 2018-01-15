namespace MainComponent
{
    partial class ShitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.customGroupBox1 = new MainComponent.CustomGroupBox(this.components);
            this.SuspendLayout();
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.BackColorChart = System.Drawing.Color.White;
            this.customGroupBox1.BackColorTree = System.Drawing.SystemColors.Control;
            this.customGroupBox1.BorderlineColorChart = System.Drawing.Color.White;
            this.customGroupBox1.BorderlineDashStyleChart = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            this.customGroupBox1.BorderlineWidthChart = 1;
            this.customGroupBox1.BorderStyleTree = System.Windows.Forms.BorderStyle.None;
            this.customGroupBox1.ColumnCount = 2;
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.customGroupBox1.FontTree = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.customGroupBox1.Location = new System.Drawing.Point(52, 28);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.RowCount = 1;
            this.customGroupBox1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.customGroupBox1.Size = new System.Drawing.Size(499, 174);
            this.customGroupBox1.TabIndex = 8;
            this.customGroupBox1.TypeOfChart = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            this.customGroupBox1.WidthChart = 50F;
            // 
            // ShitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 316);
            this.Controls.Add(this.customGroupBox1);
            this.Name = "ShitForm";
            this.Text = "ShitForm";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGroupBox customGroupBox1;
    }
}