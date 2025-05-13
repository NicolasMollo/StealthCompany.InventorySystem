using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Player;
using InventorySystem.Systems.Controllers.CameraManagement;
using InventorySystem.Systems.UI;


namespace InventorySystem.Systems.Controllers
{

    /// <summary>
    /// Root scene controller that handles all scene controllers.
    /// It is the logical object with the highest level of abstraction within the scene-specific objects
    /// and is also the head of the scene-specific objects hierarchy.
    /// </summary>
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
            systemUI.RegisterSceneEvents(this);

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

            systemUI.UnregisterSceneEvents(this);

        }

    }

}