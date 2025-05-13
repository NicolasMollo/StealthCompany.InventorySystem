using InventorySystem.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using InventorySystem.Systems.Controllers.Player;
using InventorySystem.Systems.UI.Inventory;
using InventorySystem.Systems.UI.HealthBar;
using InventorySystem.Systems.UI.Settings;
using NewLab.Unity.SDK.Core.Modules;
using NewLab.Unity.SDK.Core.Systems;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using UnityEngine;
using InventorySystem.Systems.UI.EffectViewers;

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
        private UI_EffectsViewersController _effectsViewersController = null;
        public UI_EffectsViewersController EffectsViewersController
        {
            get => _effectsViewersController;
        }

        [SerializeField]
        private UI_HealthBarController _healthBarController = null;
        public UI_HealthBarController HealthBarController
        {
            get => _healthBarController;
        }

        #endregion


        #region API

        public void RegisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            _inventoryController.OnCreateInventoryItem += OnCreateInventoryItem;

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
            _healthBarController.SetUp();
            _healthBarController.UpdateHealthBar(playerController.HealthModule);
            playerController.HealthModule.OnTakeHealth += OnPlayerTakeHealth;
            playerController.HealthModule.OnTakeDamage += OnPlayerTakeDamage;
            // Effects viewer management
            _effectsViewersController.SetUp();
            _effectsViewersController.SetPlayerSpeedText(playerController.MovementModule.MovementSpeed);
            playerController.MovementModule.OnChangeMovementSpeed += OnChangePlayerMovementSpeed;



        }

        public void UnregisteringEventOnMainSceneRootController(BaseSceneRootController sceneRootController)
        {

            _inventoryController.OnCreateInventoryItem -= OnCreateInventoryItem;

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
            // Effects viewer management
            playerController.MovementModule.OnChangeMovementSpeed -= OnChangePlayerMovementSpeed;


        }

        #endregion

        private void OnCreateInventoryItem(UI_InventoryItem inventoryItem)
        {

            inventoryItem.OnClickButton += OnClickInventoryItem;
        }

        private void OnClickInventoryItem(UI_InventoryItem inventoryItem)
        {

            _effectsViewersController.SetEffectTimeViewImage(inventoryItem.Configuration);

        }

        private void OnChangePlayerMovementSpeed(float movementSpeed)
        {

            _effectsViewersController.SetPlayerSpeedText(movementSpeed);

        }

        private void OnPlayerTakeHealth(Std_HealthModule healthModule)
        {

            _healthBarController.UpdateHealthBar(healthModule);

        }

        private void OnPlayerTakeDamage(Std_HealthModule healthModule)
        {

            _healthBarController.UpdateHealthBar(healthModule);

        }

        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            _inventoryController.SetUpInventoryItem(configuration);

        }


    }

}