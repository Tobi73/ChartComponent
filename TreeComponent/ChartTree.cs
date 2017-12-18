using ChartComponent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeComponent
{
    public partial class ChartTree : Control
    {
        public delegate void ChartTreeEditEventHandler(object sender, ChartEditEventArgs a);
        public delegate ChartModel ChartTreeAddEventHandler(object sender, ChartAddEventArgs a);
        event EventHandler onChartNodeSelect;
        event ChartTreeAddEventHandler onChartAdd;
        event ChartTreeEditEventHandler onChartEdit;

        public ChartTree()
        {
            InitializeComponent();
        }

        public ChartTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public RootModel RootNode
        {
            get { return rootNode as RootModel; }
        }

        public TreeView ChartTreeView
        {
            get { return tree; }
        }
        
        public event EventHandler OnChartNodeSelect
        {
            add
            {
                onChartNodeSelect += value;
            }
            remove
            {
                onChartNodeSelect -= value;
            }
        }

        public event ChartTreeAddEventHandler OnChartAdd
        {
            add
            {
                onChartAdd += value;
            }
            remove
            {
                onChartAdd -= value;
            }
        }

        public event ChartTreeEditEventHandler OnChartEdit
        {
            add
            {
                onChartEdit += value;
            }
            remove
            {
                onChartEdit -= value;
            }
        }

        public string RootName
        {
            get
            {
                return rootNode.Text;
            }
            set
            {
                rootNode.Text = value;
                Invalidate();
            }
        }

        public TreeNode SelectedChartNode
        {
            get
            {
                return tree.SelectedNode;
            }
        }

        private void NodeClickedEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            tree.SelectedNode = e.Node;
            if (onChartNodeSelect != null)
            {
                onChartNodeSelect(this, new EventArgs());
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tree.SelectedNode != null && tree.SelectedNode is ChartModel)
                {
                    var parent = tree.SelectedNode.Parent;
                    tree.SelectedNode.Remove();
                    tree.SelectedNode = parent;
                    tree.Invalidate();
                }
            }
        }

        private void AddChartButtonClick(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                ChartModel chartNode;
                if (onChartAdd != null)
                {
                    chartNode = onChartAdd(this, new ChartAddEventArgs());
                }
                else
                {
                    chartNode = OpenChartAddForm();
                }
                if (chartNode == null) return;
                chartNode.ContextMenuStrip = chartNodeMenu;
                tree.SelectedNode.Nodes.Add(chartNode);
            }
        }

        private void EditChartButtonClick(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                if (onChartAdd != null)
                {
                    onChartEdit(this, new ChartEditEventArgs(tree.SelectedNode as ChartModel));
                }
                else
                {
                    OpenChartEditForm();
                }
            }
        }

        private void OpenChartEditForm()
        {
            var editForm = new ChartEditForm(tree.SelectedNode as ChartModel);
            editForm.ShowDialog();
        }

        private ChartModel OpenChartAddForm()
        {
            var addForm = new ChartEditForm();
            addForm.ShowDialog();
            return addForm.ChartModel;
        }
    }
}
