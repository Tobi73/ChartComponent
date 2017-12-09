using System.ComponentModel;

namespace ChartComponent
{
    public partial class Govnoblyapotom : Component
    {
        public Govnoblyapotom()
        {
            InitializeComponent();
        }

        public Govnoblyapotom(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
