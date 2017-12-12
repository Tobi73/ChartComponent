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

        public ChartTree()
        {
            InitializeComponent();
        }

        public ChartTree(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [Category("Tree Info"), Description("Specifies the name of the root node.")]
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
            get { return tree.SelectedNode; }
        }

        private void NodeClickedEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            // selectedNode = e.Node;
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                tree.SelectedNode.Nodes.Add(new ChartModel
                {
                    Text = chartNameTextBox.Text
                });
            }
        }

        private void ChartNodeNameChanged(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node is ChartModel)
            {
                (e.Node as ChartModel).ChartName = e.Label;
                e.CancelEdit = false;
            } else
            {
                e.CancelEdit = true;
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


    }
}
