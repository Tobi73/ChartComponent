using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainComponent
{
    [DesignerAttribute(typeof(CustomDesigner))]
    public partial class CustomGroupBox : GroupBox
    {
        public CustomGroupBox()
        {
            InitializeComponent();
        }

        public CustomGroupBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private bool useTable = true;

        [Category("New"), Description("Can user's work with table?")]
        public bool UseTable
        {
            set {
                useTable = value;
                Invalidate();
            }
            get { return useTable; }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e) 
        {
            base.OnPaint(e);
            if (!useTable)
            {
                btnTable.Visible = false;
            }

        }
    }
}
