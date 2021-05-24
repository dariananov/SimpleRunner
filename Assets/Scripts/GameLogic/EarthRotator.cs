using UnityEngine;

namespace AzurSimpleRunner
{
    public class EarthRotator : MonoBehaviour
    {
        public GameTimer gameTimer;
        public Transform rotatable;
        public float rotateSpeed = 1f;
        public Vector3 globalRotateAxis = new Vector3(1, 0, 0);

        private bool isPlaying;

        void Start()
        {
            isPlaying = false;
            gameTimer.OnGameStarted += () => isPlaying = true;
            gameTimer.OnGameEnded += () => isPlaying = false;
        }

        void Update()
        {
            if (!isPlaying)
                return;

            if (Input.GetMouseButton(0))
            {
                rotatable.Rotate(globalRotateAxis, rotateSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
