namespace MainComponent
{
    partial class FormForTesting
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
            this.customGroupBox1.ColumnCount = 4;
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customGroupBox1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.customGroupBox1.Location = new System.Drawing.Point(32, 21);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.RowCount = 2;
            this.customGroupBox1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.4878F));
            this.customGroupBox1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.5122F));
            this.customGroupBox1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.customGroupBox1.Size = new System.Drawing.Size(514, 224);
            this.customGroupBox1.TabIndex = 8;
            this.customGroupBox1.UseTable = true;
            // 
            // FormForTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 299);
            this.Controls.Add(this.customGroupBox1);
            this.Name = "FormForTesting";
            this.Text = "FormForTesting";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomGroupBox customGroupBox1;
    }
}