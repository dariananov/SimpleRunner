using System;

namespace AzurSimpleRunner
{
    public class ApplicationModel : IApplicationModel
    {
        private AppState state = AppState.FINISH;
        public AppState State => state;

        public event Action OnWaiting;
        public event Action OnPlaying;
        public event Action OnFinish;
        
        public void SetPlaying()
        {
            if (state != AppState.WAITING)
                return;
            
            state = AppState.PLAYING;
            OnPlaying?.Invoke();
        }

        public void SetWaiting()
        {
            if (state == AppState.WAITING)
                return;
            
            state = AppState.WAITING;
            OnWaiting?.Invoke();
        }

        public void SetFinish()
        {
            if (state == AppState.FINISH)
                return;
            
            state = AppState.FINISH;
            OnFinish?.Invoke();
        }
    }
}
