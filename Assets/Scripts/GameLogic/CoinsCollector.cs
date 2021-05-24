using UnityEngine;
using UnityEngine.UI;

namespace AzurSimpleRunner
{
    public class CoinsCollector : MonoBehaviour
    {
        public Text coinsInfo;
        public string coinTag = "Coin";
        public GameObject particles;

        private int coinsCounter;
        
        private void Start()
        {
            coinsCounter = 0;
            UpdateCoinsInfo();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(coinTag))
                return;

            coinsCounter += 1;
            UpdateCoinsInfo();
            
            var coin = other.transform;
            Instantiate(particles, coin.position, coin.rotation, coin.parent);
            Destroy(other.gameObject);
        }

        private void UpdateCoinsInfo()
        {
            coinsInfo.text = coinsCounter + "";
        }
    }
}
