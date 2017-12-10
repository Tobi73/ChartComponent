using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainComponent.view.form;

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

        private void btnTable_Click(object sender, EventArgs e)
        {
            FormTable ft = new FormTable(/* Передать выбранный график */);
            ft.ShowDialog();
            
        }
    }
}
