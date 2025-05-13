using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Modules;
using NewLab.Unity.SDK.Core.Systems;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.UI.Inventory;
using InventorySystem.Systems.UI.HealthBar;
using InventorySystem.Systems.UI.EffectViewers;
using InventorySystem.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using InventorySystem.Systems.Controllers.Player;


namespace InventorySystem.Systems.UI
{

    public class InventorySystem_SystemUI : BaseSystem
    {

        #region UI Controllers

        [TitleGroup("UI CONTROLLERS", null, TitleAlignments.Left)]

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

        /// <summary>
        /// Method that takes care of registering system UI methods to scene controller events.
        /// </summary>
        /// <param name="sceneRootController"></param>
        public void RegisterSceneEvents(BaseSceneRootController sceneRootController)
        {

            // _inventoryController
            _inventoryController.OnCreateInventoryItem += OnCreateInventoryItem;
            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();
            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer += OnPlayerCollisionWithCollectibleItem;
            }
            // _healthBarController
            InventorySystem_PlayerController playerController =
                sceneRootController.GetController<InventorySystem_PlayerController>();
            _healthBarController.SetUp();
            _healthBarController.UpdateHealthBar(playerController.HealthModule);
            playerController.HealthModule.OnTakeHealth += OnPlayerTakeHealth;
            playerController.HealthModule.OnTakeDamage += OnPlayerTakeDamage;
            // _effectsVieversController
            _effectsViewersController.SetPlayerSpeedText(playerController.MovementModule.MovementSpeed);
            playerController.MovementModule.OnChangeMovementSpeed += OnChangePlayerMovementSpeed;

        }

        /// <summary>
        /// Method that takes care of unregistering system UI methods to scene controller events.
        /// </summary>
        /// <param name="sceneRootController"></param>
        public void UnregisterSceneEvents(BaseSceneRootController sceneRootController)
        {

            // _inventoryController
            _inventoryController.OnCreateInventoryItem -= OnCreateInventoryItem;
            InventorySystem_CollectibleItemsController collectibleItemsController =
                sceneRootController.GetController<InventorySystem_CollectibleItemsController>();
            foreach (CollectibleItem item in collectibleItemsController.CollectibleItems)
            {
                item.OnCollideWithPlayer -= OnPlayerCollisionWithCollectibleItem;
            }
            // _healthBarController
            InventorySystem_PlayerController playerController =
               sceneRootController.GetController<InventorySystem_PlayerController>();
            playerController.HealthModule.OnTakeHealth -= OnPlayerTakeHealth;
            playerController.HealthModule.OnTakeDamage -= OnPlayerTakeDamage;
            // _effectsVieversController
            playerController.MovementModule.OnChangeMovementSpeed -= OnChangePlayerMovementSpeed;

        }

        #endregion

        #region Events methods

        private void OnCreateInventoryItem(UI_InventoryItem inventoryItem)
        {

            inventoryItem.OnClickButton += OnClickInventoryItem;
        }
        private void OnClickInventoryItem(UI_InventoryItem inventoryItem)
        {

            _effectsViewersController.SetEffectTimeViewImage(inventoryItem.Configuration);

        }

        private void OnPlayerCollisionWithCollectibleItem(CollectibleItemConfiguration configuration)
        {

            _inventoryController.SetUpInventoryItem(configuration);

        }

        private void OnPlayerTakeHealth(Std_HealthModule healthModule)
        {

            _healthBarController.UpdateHealthBar(healthModule);

        }
        private void OnPlayerTakeDamage(Std_HealthModule healthModule)
        {

            _healthBarController.UpdateHealthBar(healthModule);

        }

        private void OnChangePlayerMovementSpeed(float movementSpeed)
        {

            _effectsViewersController.SetPlayerSpeedText(movementSpeed);

        }

        #endregion

    }

}