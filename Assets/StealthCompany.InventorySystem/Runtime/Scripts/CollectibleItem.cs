using System;
using UnityEngine;


namespace InventorySystem.Systems.Controllers.Items.Collectibles
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Collider))]
    public class CollectibleItem : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Collectible item data thats define a type of collectible item")]
        private CollectibleItemConfiguration configuration = null;

        private const string TAG_PLAYER = "Player";
        public Action<CollectibleItemConfiguration> OnCollideWithPlayer = null;


        private void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag(TAG_PLAYER))
            {
                OnCollideWithPlayer?.Invoke(configuration);
                Deactivation();
            }

        }

        private void Deactivation()
        {

            bool activeness = false;
            gameObject.SetActive(activeness);

        }

    }

}