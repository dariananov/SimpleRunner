using System;
using UnityEngine;
using UnityEngine.UI;

namespace AzurSimpleRunner
{
    public class GameTimer : MonoBehaviour
    {
        public event Action OnGameStarted;
        public event Action OnGameEnded;
        public event Action OnMainTimePassed;
        
        public float gameTime = 15f;
        public float finishDelay = 3f;
        public Slider progressBar;

        private float timer = -1;
        private bool isMainTime = true;

        public void Initialize()
        {
            timer = 0f;
            UpdateProgressBar();
            OnGameStarted?.Invoke();
        }

        private void Update()
        {
            if (timer < 0)
                return;
            
            if (!Input.GetMouseButton(0))
                return;

            timer += Time.deltaTime;
            UpdateProgressBar();

            if (isMainTime && timer > gameTime)
            {
                OnMainTimePassed?.Invoke();
                isMainTime = false;
            }
                
            if (timer > gameTime + finishDelay)
                OnGameEnded?.Invoke();
        }

        private void UpdateProgressBar()
        {
            progressBar.value = timer / (gameTime + finishDelay);
        }
    }
}
