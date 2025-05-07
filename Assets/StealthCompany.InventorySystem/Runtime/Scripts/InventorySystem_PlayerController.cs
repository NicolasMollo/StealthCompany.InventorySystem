using NewLab.Unity.SDK.Core.Systems.Controllers.Player;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using NewLab.Unity.SDK.Core.Modules;
using InventorySystem.Systems.Controllers.PlayerModules;
using UnityEngine;


namespace InventorySystem.Systems.Controllers
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

        }

    }

}