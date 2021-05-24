using UnityEngine;

namespace AzurSimpleRunner
{
    public class DestroyTrigger : MonoBehaviour
    {
        public string destroyTag = "Coin";

        public void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(destroyTag))
                return;

            Destroy(other.gameObject);
        }
    }
}
