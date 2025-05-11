using InventorySystem.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using InventorySystem.Systems.Controllers.Player;
using InventorySystem.Systems.UI.Inventory;
using InventorySystem.Systems.UI.LifeBar;
using InventorySystem.Systems.UI.Settings;
using NewLab.Unity.SDK.Core.Modules;
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

        [SerializeField]
        private UI_LifeBarController _lifeBarController = null;
        public UI_LifeBarController LifeBarController
        {
            get => _lifeBarController;
        }

        #endregion


        #region API

        public void RegisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            // Inventory management
            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();

            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer += OnPlayerCollisionWithCollectibleItem;
            }

            // Life bar management
            InventorySystem_PlayerController playerController =
                sceneRootController.GetController<InventorySystem_PlayerController>();
            _lifeBarController.SetUp(playerController.HealthModule);
            playerController.HealthModule.OnTakeHealth += OnPlayerTakeHealth;
            playerController.HealthModule.OnTakeDamage += OnPlayerTakeDamage;


        }

        public void UnregisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            // Inventory management
            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();

            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer -= OnPlayerCollisionWithCollectibleItem;
            }

            // Life bar management
            InventorySystem_PlayerController playerController =
               sceneRootController.GetController<InventorySystem_PlayerController>();
            playerController.HealthModule.OnTakeHealth -= OnPlayerTakeHealth;
            playerController.HealthModule.OnTakeDamage -= OnPlayerTakeDamage;

        }

        #endregion

        private void OnPlayerTakeHealth(Std_HealthModule healthModule)
        {

            _lifeBarController.SetLifeBar(healthModule);

        }

        private void OnPlayerTakeDamage(Std_HealthModule healthModule)
        {

            _lifeBarController.SetLifeBar(healthModule);

        }

        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            _inventoryController.SetUpInventoryItem(configuration);

        }


    }

}