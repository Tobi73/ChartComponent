using ChartComponent;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TreeComponent
{
    public partial class ChartTree : Control
    {
        public delegate void ChartTreeEditEventHandler(object sender, ChartEditEventArgs a);
        public delegate ChartModel ChartTreeAddEventHandler(object sender, ChartAddEventArgs a);
        event EventHandler onChartNodeSelect;
        event EventHandler onChartNodeDelete;
        event ChartTreeAddEventHandler onChartAdd;
        event ChartTreeEditEventHandler onChartEdit;
        Func<string, ChartModel> fileLoad;

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
            get
            {
                return rootNode as RootModel;
            }
            set
            {
                rootNode = value;
                rootNode.ContextMenuStrip = rootNodeMenu;
                validateNodes(rootNode.Nodes);
                tree.Nodes.Clear();
                tree.Nodes.Add(rootNode);
                Invalidate();
            }
        }

        public void SetFileLoadFunc(Func<string, ChartModel> func)
        {
            fileLoad = func;
        }

        public TreeView ChartTreeView
        {
            get
            {
                return tree;
            }
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

        public event EventHandler OnChartNodeDelete
        {
            add
            {
                onChartNodeDelete += value;
            }
            remove
            {
                onChartNodeDelete -= value;
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

        public void AddNode(RootModel parent, ChartModel child)
        {
            child.ContextMenuStrip = chartNodeMenu;
            parent.Nodes.Add(child);
        }

        private void validateNodes(TreeNodeCollection charts)
        {
            foreach(TreeNode chart in charts)
            {
                chart.ContextMenuStrip = chartNodeMenu;
                validateNodes(chart.Nodes);
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
                    if (onChartNodeDelete != null)
                    {
                        onChartNodeDelete(this, new EventArgs());
                    }
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
                    chartNode = OpenChartAddForm(fileLoad);
                }
                if (chartNode == null) return;
                AddNode(tree.SelectedNode as RootModel, chartNode);
                onChartNodeSelect(this, new EventArgs());
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
                onChartNodeSelect(this, new EventArgs());
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

        private ChartModel OpenChartAddForm(Func<string, ChartModel> func)
        {
            var addForm = new ChartEditForm(func);
            addForm.ShowDialog();
            return addForm.ChartModel;
        }
    }
}
