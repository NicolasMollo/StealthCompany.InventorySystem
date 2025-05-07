namespace NewLab.Unity.SDK.Core.Systems.Controllers.CustomizableElements
{

    public abstract class BaseCustomizableItemsController : BaseSceneController
    {

        /// <summary>
        /// Method that saves the last changes made during the last time the application was used.
        /// </summary>
        protected virtual void SaveLatestChanges(BaseSceneRootController sceneRootController = null) { }

        /// <summary>
        /// Method that takes care of updating the customizable objects with the latest changes made during the last use of the application.
        /// </summary>
        protected virtual void LoadLatestChanges(BaseSceneRootController sceneRootController = null) { }

    }

}