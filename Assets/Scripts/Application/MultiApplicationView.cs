using System.Collections.Generic;

namespace AzurSimpleRunner
{
    public class MultiApplicationView : ApplicationView
    {
        public List<ApplicationView> children = new List<ApplicationView>();

        public override void Initialize(IApplicationModel model, ApplicationController controller)
        {
            foreach (var child in children)
            {
                child.Initialize(model, controller);
            }
        }
    }    
}
