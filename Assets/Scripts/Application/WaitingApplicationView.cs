using UnityEngine;

namespace AzurSimpleRunner
{
    public class WaitingApplicationView : ApplicationView
    {
        public GameObject waitingPrefab;

        protected override void SetWaiting()
        {
            waitingPrefab.SetActive(true);
        }

        protected override void SetPlaying()
        {
            waitingPrefab.SetActive(false);
        }
        
        private void Interact()
        {
            controller.StartGame();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }
}
