using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace InventorySystem.Systems.Controllers
{

    public class InventorySystem_MainSceneRootController : BaseSceneRootController
    {

        /* Inherited members:
           - Controllers
           - SystemsManager
           - Event Dispatcher
        */

        protected override void InternalSetUp()
        {

            base.InternalSetUp(); // get SystemsManager

            foreach (BaseSceneController controller in Controllers)
            {
                controller.SetUp();
            }

        }

        protected override void InternalCleanUp()
        {

            foreach (BaseSceneController controller in Controllers)
            {
                controller.CleanUp();
            }

        }

    }

}