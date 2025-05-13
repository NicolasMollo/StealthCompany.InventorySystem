using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;


namespace InventorySystem.Systems.Controllers
{

    public class InventorySystem_CollectibleItemsController : BaseSceneController
    {

        [SerializeField]
        [Tooltip("Number of collecticle items to spawn")]
        private int numberOfCollectibleItemsToSpawn = 10;

        [SerializeField]
        [Tooltip("Collectible items target parent")]
        private Transform collectibleItemsParent = null;

        [SerializeField]
        [Tooltip("List of collectible items prefab")]
        private List<GameObject> collectiblesPrefabs = null;

        [SerializeField]
        [Tooltip("Reactivate objects delay")]
        private float reactivationDelay = 1.0f;

        private List<CollectibleItem> _collectibleItems = null;
        public List<CollectibleItem> CollectibleItems
        {
            get => _collectibleItems;
        }

        public Vector3 mapPosition = Vector3.zero;
        private Vector3 halfMapSize = Vector3.zero;
        private Vector3 lastItemPosition = Vector3.zero;
        private int deactivatedCollectibleItems = 0;


        #region API

        public override void SetUp(BaseSceneRootController sceneRootController)
        {

            InventorySystem_EnvironmentRootController environmentRootController = 
                sceneRootController.GetController<InventorySystem_EnvironmentRootController>();
            mapPosition = environmentRootController.MapPosition;
            halfMapSize = environmentRootController.HalfMapSize;

            _collectibleItems = new List<CollectibleItem>();
            for (int i = 0; i < numberOfCollectibleItemsToSpawn; i++)
            {
                CollectibleItem collectibleItem = CreateRandomCollectibleItem();
                collectibleItem.OnCollideWithPlayer += OnPlayerCollisionWithCollectibleItem;
                _collectibleItems.Add(collectibleItem);
            }

        }

        public override void CleanUp()
        {

            foreach (CollectibleItem collectibleItem in _collectibleItems)
            {
                collectibleItem.OnCollideWithPlayer -= OnPlayerCollisionWithCollectibleItem;
            }

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method that deals with creating a random interactable object.
        /// </summary>
        /// <returns></returns>
        private CollectibleItem CreateRandomCollectibleItem()
        {

            int randomIndex = Random.Range(0, collectiblesPrefabs.Count);
            Vector3 randomPosition = GetNewRandomPosition();
            GameObject collectibleItemObject = Instantiate(
                collectiblesPrefabs[randomIndex], 
                randomPosition, 
                Quaternion.identity, 
                collectibleItemsParent
                );
            lastItemPosition = randomPosition;
            CollectibleItem collectibleItem = collectibleItemObject.GetComponent<CollectibleItem>();
            return collectibleItem;

        }

        /// <summary>
        /// Method that returns a random position different from the previous one.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetNewRandomPosition()
        {

            float positionY = 1;
            Vector3 randomPosition = new Vector3(
                Random.Range(mapPosition.x - halfMapSize.x, mapPosition.x + halfMapSize.x),
                positionY,
                Random.Range(mapPosition.z - halfMapSize.z, mapPosition.z + halfMapSize.z)
                );

            while (randomPosition == lastItemPosition)
            {
                randomPosition = new Vector3(
                Random.Range(mapPosition.x - halfMapSize.x, mapPosition.x + halfMapSize.x),
                positionY,
                Random.Range(mapPosition.z - halfMapSize.z, mapPosition.z + halfMapSize.z)
                );
            }

            return randomPosition;

        }

        /// <summary>
        /// Method that counts deactivated objects.
        /// Once deactivated objects reach the number of objects in the list it proceeds to the delayed reactivation of collectibles.
        /// </summary>
        /// <param name="configuration"></param>
        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            deactivatedCollectibleItems++;
            if (deactivatedCollectibleItems == _collectibleItems.Count)
            {
                StartCoroutine(ReactivatesCollectibleItems(reactivationDelay));
                deactivatedCollectibleItems = 0;
            }

        }

        /// <summary>
        /// Reactivates all collectibles after delay has passed.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        private IEnumerator ReactivatesCollectibleItems(float delay)
        {

            yield return new WaitForSeconds(delay);
            bool gameobjectActiveness = true;
            foreach (CollectibleItem item in _collectibleItems)
            {
                item.gameObject.SetActive(gameobjectActiveness);
            }

        }

        #endregion

    }

}