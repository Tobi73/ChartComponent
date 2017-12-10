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
            this.customGroupBox1.Location = new System.Drawing.Point(23, 26);
            this.customGroupBox1.MinimumSize = new System.Drawing.Size(480, 250);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(480, 250);
            this.customGroupBox1.TabIndex = 0;
            this.customGroupBox1.TabStop = false;
            this.customGroupBox1.Text = "customGroupBox1";
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