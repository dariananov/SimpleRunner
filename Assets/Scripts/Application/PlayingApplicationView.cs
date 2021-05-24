using UnityEngine;
using UnityEngine.UI;

namespace AzurSimpleRunner
{
    public class PlayingApplicationView : ApplicationView
    {
        public GameObject playingPrefab;
        public GameTimer gameTimer;

        protected override void SetWaiting()
        {
            playingPrefab.SetActive(false);
        }

        protected override void SetPlaying()
        {
            playingPrefab.SetActive(true);
            gameTimer.Initialize();
            gameTimer.OnGameEnded += () => controller.EndGame();
        }
        protected override void SetFinish()
        {
            playingPrefab.SetActive(false);
        }
    }
}