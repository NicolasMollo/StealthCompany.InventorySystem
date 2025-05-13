using UnityEngine;
using NewLab.Unity.SDK.Core.Systems.Controllers.Player;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using NewLab.Unity.SDK.Core.Modules;
using InventorySystem.Systems.Controllers.CameraManagement;
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

        private CommandBehaviour lastCommandBehaviour = null;
        public CommandBehaviour LastCommandBehaviour
        {
            get => lastCommandBehaviour;
        }

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
            // System UI
            InventorySystem_SystemUI systemUI =
                sceneRootController.SystemsManager.GetSystem<InventorySystem_SystemUI>();
            systemUI.InventoryController.OnCreateInventoryItem += OnCreateInventoryItem;

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
            // System UI
            InventorySystem_SystemUI systemUI =
               sceneRootController.SystemsManager.GetSystem<InventorySystem_SystemUI>();
            systemUI.InventoryController.OnCreateInventoryItem -= OnCreateInventoryItem;

        }


        #region Events methods

        private void OnCreateInventoryItem(UI_InventoryItem inventoryItem)
        {

            inventoryItem.OnClickButton += OnClickInventoryItemButton;

        }

        private void OnClickInventoryItemButton(UI_InventoryItem inventoryItem)
        {

            lastCommandBehaviour = inventoryItem.Configuration.ItemCommandBehaviour;
            lastCommandBehaviour.DoCommand(this.gameObject);

        }

        #endregion

    }

}