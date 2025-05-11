using InventorySystem.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using InventorySystem.Systems.UI.Inventory;
using InventorySystem.Systems.UI.Settings;
using NewLab.Unity.SDK.Core.Systems;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using UnityEngine;

namespace InventorySystem.Systems.UI
{

    public class InventorySystem_SystemUI : BaseSystem
    {

        [SerializeField]
        [Tooltip("UI object at the top of the UI hierarchy")]
        private GameObject UIObject = null;

        #region UI Controllers

        [SerializeField]
        private UI_InventoryController _inventoryController = null;
        public UI_InventoryController InventoryController
        {
            get => _inventoryController;
        }

        [SerializeField]
        private UI_SettingsController _settingsController = null;
        public UI_SettingsController SettingsController
        {
            get => _settingsController;
        }

        #endregion


        #region API

        public void RegisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();

            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer += OnPlayerCollisionWithCollectibleItem;
            }


        }

        public void UnregisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();

            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer -= OnPlayerCollisionWithCollectibleItem;
            }

        }

        #endregion

        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            // Debug.Log($"== {this.name} == {configuration.CollectibleType.ToString()}");
            _inventoryController.SetUpInventoryItem(configuration);

        }


    }

}