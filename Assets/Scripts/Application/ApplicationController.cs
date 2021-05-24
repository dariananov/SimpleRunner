using UnityEngine;
using UnityEngine.SceneManagement;

namespace AzurSimpleRunner
{
    public class ApplicationController : MonoBehaviour
    {
        public ApplicationView view;
        public GameTimer gameTimer;
        
        private IApplicationModel model;

        private void Start()
        {
            model = new ApplicationModel();
            view.Initialize(model, this);
            model.SetWaiting();
        }

        public void StartGame()
        {
            model.SetPlaying();
        }

        public void EndGame()
        {
            model.SetFinish();
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}