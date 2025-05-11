using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Player;
using InventorySystem.Systems.Controllers.CameraManagement;
using InventorySystem.Systems.UI;
using UnityEngine.Rendering.VirtualTexturing;


namespace InventorySystem.Systems.Controllers
{

    public class InventorySystem_MainSceneRootController : BaseSceneRootController
    {

        /* Inherited members:
           - Controllers
           - SystemsManager
           - Event Dispatcher
        */

        // Scene controllers
        private InventorySystem_CameraController cameraController = null;
        private InventorySystem_PlayerController playerController = null;
        // Systems
        private InventorySystem_SystemUI systemUI = null;


        protected override void InternalSetUp()
        {

            base.InternalSetUp(); // get SystemsManager

            foreach (BaseSceneController controller in Controllers)
            {
                controller.SetUp(this);
            }

            // Get controllers references
            cameraController = GetController<InventorySystem_CameraController>();
            playerController = GetController<InventorySystem_PlayerController>();
            // Get systems reference
            systemUI = SystemsManager.GetSystem<InventorySystem_SystemUI>();
            systemUI.RegisteringEventOnMainSceneRootController(this);

        }

        public void Update()
        {

            playerController.UpdateController();

        }

        public void LateUpdate()
        {

            cameraController.UpdateController();

        }

        protected override void InternalCleanUp()
        {

            foreach (BaseSceneController controller in Controllers)
            {
                controller.CleanUp(this);
            }

            systemUI.UnregisteringEventOnMainSceneRootController(this);

        }

    }

}