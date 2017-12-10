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


            btnSave = new System.Windows.Forms.Button();
            btnLoad = new System.Windows.Forms.Button();
            btnConvert = new System.Windows.Forms.Button();
            btnTable = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // groupBox1
            // 
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnTable);

            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(87, 218);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 3;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new System.Drawing.Point(6, 218);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new System.Drawing.Size(75, 23);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "load";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            btnConvert.Location = new System.Drawing.Point(314, 218);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new System.Drawing.Size(75, 23);
            btnConvert.TabIndex = 1;
            btnConvert.Text = "convert";
            btnConvert.UseVisualStyleBackColor = true;
            // 
            // btnTable
            // 
            btnTable.Location = new System.Drawing.Point(400, 218);
            btnTable.Name = "btnTable";
            btnTable.Size = new System.Drawing.Size(75, 23);
            btnTable.TabIndex = 0;
            btnTable.Text = "table";
            btnTable.UseVisualStyleBackColor = true;
            btnTable.Click += new System.EventHandler(this.btnTable_Click);

            ClientSize = new System.Drawing.Size(480,250);
            MinimumSize = new System.Drawing.Size(480, 250);
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnTable;



    }
}
