using UnityEngine;
using Random = UnityEngine.Random;

namespace AzurSimpleRunner
{
    public class CoinsSpawner : MonoBehaviour
    {
        public GameTimer gameTimer;
        public GameObject prefab;
        public Transform parent;
        public Transform place;
        public Vector2 timeRange = new Vector2(0.5f, 1.5f);
        public Vector2 xPosRange = new Vector2(-2.5f, 2.5f);

        private bool isPlaying;
        private float timer;
        private float currentPeriod;

        void Start()
        {
            isPlaying = false;
            gameTimer.OnGameStarted += () => isPlaying = true;
            gameTimer.OnMainTimePassed += () => isPlaying = false;
            timer = 0f;
            currentPeriod = 0f;
        }

        private void Update()
        {
            if (!isPlaying)
                return;
            
            if (!Input.GetMouseButton(0))
                return;

            timer += Time.deltaTime;
            if (timer > currentPeriod)
            {
                UpdatePeriod();
                SpawnPrefab();
            }
        }

        private void UpdatePeriod()
        {
            timer = 0f;
            currentPeriod = Random.Range(timeRange.x, timeRange.y);
        }

        private void SpawnPrefab()
        {
            var shift = new Vector3(Random.Range(xPosRange.x, xPosRange.y), 0, 0);
            var spawned = Instantiate(prefab, place.position + shift, place.rotation, place);
            spawned.transform.SetParent(parent);
        }
    }
}
