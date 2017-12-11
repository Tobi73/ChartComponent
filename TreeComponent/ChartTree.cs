using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeComponent.Model;

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
        }        private void NodeClickedEvent(object sender, TreeNodeMouseClickEventArgs e)
        {
            selectedNode = e.Node;
        }        private void AddButtonClicked(object sender, EventArgs e)
        {
            if (selectedNode != null)
            {
                selectedNode.Nodes.Add(new ChartTreeNode
                {
                    Text = chartNameTextBox.Text
                });
            }
        }
    }
}
