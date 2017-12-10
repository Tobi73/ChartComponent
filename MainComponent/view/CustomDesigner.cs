using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.ComponentModel;

namespace MainComponent
{
    public class CustomDesigner : ControlDesigner
    {
        
            public override void Initialize(IComponent component)
            {
                base.Initialize(component);
                var c = component as CustomGroupBox;
            }


        private DesignerActionListCollection actionListCollection;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (actionListCollection == null)
                {
                    actionListCollection = new DesignerActionListCollection();




                }
                return actionListCollection;
            }
        }

    }
}
