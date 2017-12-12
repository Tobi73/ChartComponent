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
        TreeNode selectedNode;

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

        public TreeNode SelectedNode
        {
            get { return selectedNode; }
        }

        private void NodeClickedEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedNode = e.Node;
        }

        private void AddButtonClicked(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                selectedNode.Nodes.Add(new ChartModel
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
                if (selectedNode != null && selectedNode is ChartModel)
                {
                    var parent = selectedNode.Parent;
                    selectedNode.Remove();
                    selectedNode = parent;
                    tree.SelectedNode = selectedNode;
                    tree.Invalidate();
                }
            }
        }


    }
}
