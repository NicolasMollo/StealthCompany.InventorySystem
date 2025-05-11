using UnityEngine;
using NewLab.Unity.SDK.Core.Systems.Controllers.Player;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using NewLab.Unity.SDK.Core.Modules;
using InventorySystem.Systems.Controllers.CameraManagement;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using InventorySystem.Systems.UI;
using InventorySystem.Systems.UI.Inventory;
using InventorySystem.ScriptableObjects.Commands;


namespace InventorySystem.Systems.Controllers.Player
{

    public class InventorySystem_PlayerController : BasePlayerController
    {

        /* Inherited members:
           - playerModules
        */

        #region Modules

        private InventorySystem_MovementModule _movementModule = null;
        public InventorySystem_MovementModule MovementModule
        {
            get => _movementModule;
        }

        private Std_HealthModule _healthModule = null;
        public Std_HealthModule HealthModule
        {
            get => _healthModule;
        }

        #endregion

        private CommandBehaviour playerBehaviour = null;

        private Transform cameraTransform = null;


        public override void SetUp(BaseSceneRootController sceneRootController)
        {

            foreach (BaseModule module in playerModules)
            {
                module.SetUp();
            }

            // Get module references
            _movementModule = GetModule<InventorySystem_MovementModule>();
            _healthModule = GetModule<Std_HealthModule>();

            // Get camera transform
            InventorySystem_CameraController cameraController = 
                sceneRootController.GetController<InventorySystem_CameraController>();
            cameraTransform = cameraController.Camera.transform;

            #region Test

            InventorySystem_SystemUI systemUI =
                sceneRootController.SystemsManager.GetSystem<InventorySystem_SystemUI>();
            systemUI.InventoryController.OnCreateInventoryItem += OnCreateInventoryItem;

            #endregion

        }

        public override void UpdateController()
        {

            _movementModule.Movement(cameraTransform);

        }

        public override void CleanUp(BaseSceneRootController sceneRootController)
        {

            foreach (BaseModule module in playerModules)
            {
                module.CleanUp();
            }

            #region Test

            InventorySystem_SystemUI systemUI =
               sceneRootController.SystemsManager.GetSystem<InventorySystem_SystemUI>();
            systemUI.InventoryController.OnCreateInventoryItem -= OnCreateInventoryItem;

            #endregion

            if (playerBehaviour != null)
                playerBehaviour.CleanUp();

        }


        #region Test

        private void OnCreateInventoryItem(UI_InventoryItem inventoryItem)
        {

            inventoryItem.OnClickButton += OnClickInventoryItemButton;

        }

        private void OnClickInventoryItemButton(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            // collectibleItemConfiguration.CollectibleItemBehaviour.DoCommand(this.gameObject);
            playerBehaviour = collectibleItemConfiguration.CollectibleItemBehaviour;
            if (playerBehaviour.IsCurrentlyCast)
                return;
            playerBehaviour.DoCommand(this.gameObject);

        }


        //private void PrintCollectibleItemInfo(CollectibleItemConfiguration collectibleItemConfiguration)
        //{

        //    Debug.Log($"== {this.name} == {collectibleItemConfiguration.name}" +
        //        $"\n{collectibleItemConfiguration.CollectibleType.ToString()}" +
        //        $"\n{collectibleItemConfiguration.CollectibleItemID.ToString()}");

        //}

        #endregion

    }

}