using System;

namespace AzurSimpleRunner
{
    public enum AppState
    {
        WAITING,
        PLAYING,
        FINISH
    }
    
    public interface IApplicationModel
    {
        AppState State
        {
            get;
        }
        
        event Action OnWaiting;
        event Action OnPlaying;
        event Action OnFinish;
        
        void SetPlaying();
        void SetWaiting();
        
        void SetFinish();
    }
}
