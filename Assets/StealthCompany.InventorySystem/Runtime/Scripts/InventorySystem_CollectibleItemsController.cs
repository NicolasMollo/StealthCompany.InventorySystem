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

        private List<CollectibleItem> collectibleItems = null;
        private Vector3 halfMapSize = Vector3.zero;
        private Vector3 lastItemPosition = Vector3.zero;
        private int deactivatedCollectibleItems = 0;


        #region API

        public override void SetUp(BaseSceneRootController sceneRootController)
        {

            InventorySystem_EnvironmentRootController environmentRootController = 
                sceneRootController.GetController<InventorySystem_EnvironmentRootController>();
            halfMapSize = environmentRootController.HalfMapSize;

            collectibleItems = new List<CollectibleItem>();
            for (int i = 0; i < numberOfCollectibleItemsToSpawn; i++)
            {
                CollectibleItem collectibleItem = CreateRandomCollectibleItem();
                collectibleItem.OnCollideWithPlayer += OnPlayerCollisionWithCollectibleItem;
                collectibleItems.Add(collectibleItem);
            }

        }

        public override void CleanUp()
        {

            foreach (CollectibleItem collectibleItem in collectibleItems)
            {
                collectibleItem.OnCollideWithPlayer -= OnPlayerCollisionWithCollectibleItem;
            }

        }

        #endregion

        #region Private methods

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

        private Vector3 GetNewRandomPosition()
        {

            float positionY = 1;
            Vector3 randomPosition = new Vector3(
                Random.Range(-halfMapSize.x, halfMapSize.x),
                positionY,
                Random.Range(-halfMapSize.z, halfMapSize.z)
                );

            while (randomPosition == lastItemPosition)
            {
                randomPosition = new Vector3(
                Random.Range(-halfMapSize.x, halfMapSize.x),
                positionY,
                Random.Range(-halfMapSize.z, halfMapSize.z)
                );
            }

            return randomPosition;

        }

        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            deactivatedCollectibleItems++;
            if (deactivatedCollectibleItems == collectibleItems.Count)
            {
                StartCoroutine(ReactivatesCollectibleItems(reactivationDelay));
                deactivatedCollectibleItems = 0;
            }

        }

        private IEnumerator ReactivatesCollectibleItems(float delay)
        {

            yield return new WaitForSeconds(delay);

            bool gameobjectActiveness = true;
            foreach (CollectibleItem item in collectibleItems)
            {
                item.gameObject.SetActive(gameobjectActiveness);
            }

        }

        #endregion

    }

}