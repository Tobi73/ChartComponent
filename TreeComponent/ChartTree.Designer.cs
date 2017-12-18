using ChartComponent;
using System.Windows.Forms;


namespace TreeComponent
{
    partial class ChartTree
    {
        public TreeView tree;
        private TreeNode rootNode;
        private TableLayoutPanel mainPanel;
        private ContextMenuStrip chartNodeMenu;
        private ContextMenuStrip rootNodeMenu;
        private ToolStripMenuItem addMenuItem;
        private ToolStripMenuItem editMenuItem;
        private ToolStripMenuItem rootAddMenuItem;


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
            tree = new TreeView();
            rootNode = new RootModel();
            chartNodeMenu = new ContextMenuStrip();
            rootNodeMenu = new ContextMenuStrip();
            editMenuItem = new ToolStripMenuItem();
            addMenuItem = new ToolStripMenuItem();
            rootAddMenuItem = new ToolStripMenuItem();

            mainPanel.SuspendLayout();
            chartNodeMenu.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.ColumnCount = 1;
            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            mainPanel.Controls.Add(this.tree, 0, 0);
            mainPanel.Location = new System.Drawing.Point(87, 38);
            mainPanel.Name = "mainPanel";
            mainPanel.RowCount = 1;
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 41.01123F));
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
            rootNode.Name = "root";
            rootNode.Text = "Chart Tree";
            rootNode.ContextMenuStrip = rootNodeMenu;
            tree.Nodes.Add(rootNode);
            tree.NodeMouseClick += new TreeNodeMouseClickEventHandler(NodeClickedEvent);
            tree.KeyUp += new KeyEventHandler(OnKeyUp);
            // 
            // chartNodeMenu
            // 
            chartNodeMenu.Items.AddRange(new ToolStripItem[] { editMenuItem, addMenuItem });
            chartNodeMenu.Name = "chartNodeMenu";
            chartNodeMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // rootNodeMenu
            // 
            rootNodeMenu.Items.AddRange(new ToolStripItem[] { rootAddMenuItem });
            rootNodeMenu.Name = "rootNodeMenu";
            rootNodeMenu.Size = new System.Drawing.Size(155, 70);
            // 
            // editMenuItem
            // 
            this.editMenuItem.Name = "editMenuItem";
            this.editMenuItem.Size = new System.Drawing.Size(154, 22);
            this.editMenuItem.Text = "Редактировать";
            this.editMenuItem.Click += new System.EventHandler(EditChartButtonClick);
            // 
            // rootAddMenuItem
            // 
            this.rootAddMenuItem.Name = "rootAddMenuItem";
            this.rootAddMenuItem.Size = new System.Drawing.Size(154, 22);
            this.rootAddMenuItem.Text = "Добавить";
            this.rootAddMenuItem.Click += new System.EventHandler(AddChartButtonClick);
            // 
            // addMenuItem
            // 
            addMenuItem.Name = "addMenuItem";
            addMenuItem.Size = new System.Drawing.Size(154, 22);
            addMenuItem.Text = "Добавить";
            addMenuItem.Click += new System.EventHandler(AddChartButtonClick);
            // 
            // component
            // 
            ClientSize = new System.Drawing.Size(600, 310);
            Controls.Add(mainPanel);
            Name = "chartTreeView";
            Text = "chartTreeView";
            mainPanel.ResumeLayout(false);
            chartNodeMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}
