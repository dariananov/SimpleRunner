using UnityEngine;

namespace AzurSimpleRunner
{
    public class ApplicationView : MonoBehaviour
    {
        protected ApplicationController controller;
        
        public virtual void Initialize(IApplicationModel model, ApplicationController controller)
        {
            this.controller = controller;
            model.OnWaiting += SetWaiting;
            model.OnPlaying += SetPlaying;
            model.OnFinish += SetFinish;
        }

        protected virtual void SetWaiting() { }
        protected virtual void SetPlaying() { }
        protected virtual void SetFinish() { }
    }
}
