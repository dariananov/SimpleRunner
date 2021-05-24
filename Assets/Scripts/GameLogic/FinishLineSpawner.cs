using UnityEngine;

namespace AzurSimpleRunner
{
    public class FinishLineSpawner : MonoBehaviour
    {
        public GameTimer gameTimer;
        public GameObject prefab;
        public Transform parent;
        public Transform place;

        void Start()
        {
            gameTimer.OnMainTimePassed += SpawnPrefab;
        }

        private void SpawnPrefab()
        {
            var spawned = Instantiate(prefab, place.position, place.rotation, place);
            spawned.transform.SetParent(parent);
        }
    }
}
