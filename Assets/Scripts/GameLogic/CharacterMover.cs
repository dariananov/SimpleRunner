using UnityEngine;

namespace AzurSimpleRunner
{
    public class CharacterMover : MonoBehaviour
    {
        public GameTimer gameTimer;
        public Animator animator;
        public float speed = 1f;
        public float cameraDepth = 1f;
        public Vector2 xMoveRange = new Vector2(-3, 3);
        
        private bool isPlaying;

        void Start()
        {
            isPlaying = false;
            
            gameTimer.OnGameStarted += () => isPlaying = true;
            gameTimer.OnGameEnded += () => isPlaying = false;
        }

        void Update()
        {
            var isMoving = Input.GetMouseButton(0);
            animator.SetBool("Moving", isMoving && isPlaying);
            if (!isMoving || !isPlaying)
                return;
            
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, cameraDepth));
            var targetPosition = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
            var newPosition = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

            if (newPosition.x < xMoveRange.x || newPosition.x > xMoveRange.y)
                return;

            transform.position = newPosition;
        }
    }
}
