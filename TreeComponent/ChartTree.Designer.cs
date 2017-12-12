using ChartComponent;
using System.Windows.Forms;


namespace TreeComponent
{
    partial class ChartTree
    {
        public TreeView tree;
        private TreeNode rootNode;
        private TableLayoutPanel mainPanel;
        private TableLayoutPanel controlPanel;
        private Button addButton;
        private Label chartNameLabel;
        private TextBox chartNameTextBox;


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
            mainPanel = new TableLayoutPanel();
            controlPanel = new TableLayoutPanel();
            tree = new TreeView();
            rootNode = new RootModel();
            addButton = new Button();
            chartNameLabel = new Label();

            chartNameTextBox = new TextBox();
            chartNameTextBox.Multiline = true;
            chartNameTextBox.Dock = DockStyle.Fill;

            mainPanel.SuspendLayout();
            controlPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.Controls.Add(this.tree, 0, 0);
            mainPanel.Controls.Add(this.controlPanel, 0, 1);
            mainPanel.Location = new System.Drawing.Point(87, 38);
            mainPanel.Name = "mainPanel";
            mainPanel.RowCount = 2;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 41.01123F));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            mainPanel.Size = new System.Drawing.Size(422, 243);
            mainPanel.TabIndex = 0;
            // 
            // tree
            // 
            tree.Dock = DockStyle.Fill;
            tree.Location = new System.Drawing.Point(3, 3);
            tree.Name = "tree";
            tree.Size = new System.Drawing.Size(389, 182);
            tree.TabIndex = 0;
            tree.LabelEdit = true;
            rootNode.Name = "root";
            rootNode.Text = "Chart Tree";
            tree.Nodes.Add(rootNode);
            tree.NodeMouseClick += new TreeNodeMouseClickEventHandler(NodeClickedEvent);
            tree.AfterLabelEdit += new NodeLabelEditEventHandler(ChartNodeNameChanged);
            tree.KeyUp += new KeyEventHandler(OnKeyUp);
            // 
            // controlPanel
            // 
            controlPanel.ColumnCount = 3;
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            controlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            controlPanel.Controls.Add(addButton, 0, 0);
            controlPanel.Controls.Add(chartNameLabel, 1, 0);
            controlPanel.Controls.Add(chartNameTextBox, 2, 0);
            controlPanel.Dock = DockStyle.Fill;
            controlPanel.Location = new System.Drawing.Point(3, 205);
            controlPanel.Name = "controlPanel";
            controlPanel.RowCount = 1;
            controlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlPanel.Size = new System.Drawing.Size(416, 35);
            controlPanel.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Fill;
            addButton.Location = new System.Drawing.Point(3, 3);
            addButton.Name = "addButton";
            addButton.Size = new System.Drawing.Size(73, 29);
            addButton.TabIndex = 0;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += new System.EventHandler(AddButtonClicked);
            // 
            // chartNameLabel
            // 
            chartNameLabel.Dock = DockStyle.Fill;
            chartNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            chartNameLabel.Location = new System.Drawing.Point(82, 3);
            chartNameLabel.Name = "chartNameLabel";
            chartNameLabel.Size = new System.Drawing.Size(67, 29);
            chartNameLabel.TabIndex = 1;
            chartNameLabel.Text = "Название:";
            // 
            // component
            // 
            ClientSize = new System.Drawing.Size(600, 310);
            Controls.Add(mainPanel);
            Name = "chartTreeView";
            Text = "chartTreeView";
            mainPanel.ResumeLayout(false);
            controlPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
