namespace NewLab.Unity.SDK.Core.Systems.Controllers
{

    public abstract class BaseSceneController : BaseController
    {

        #region API

        /// <summary>
        /// Method that sets the scene controller.
        /// This method accepts as an argument a parameter of type "SceneRootController" which represents the entity 
        /// responsible for managing all the SceneControllers present in the scene.
        /// </summary>
        /// <param name="sceneRootController"></param>
        public virtual void SetUp(BaseSceneRootController sceneRootController) { }

        /// <summary>
        /// Method that cleans the scene controller.
        /// This method accepts as an argument a parameter of type "SceneRootController" which represents the entity 
        /// responsible for managing all the SceneControllers present in the scene.
        /// </summary>
        /// <param name="sceneRootController"></param>
        public virtual void CleanUp(BaseSceneRootController sceneRootController) { }

        #endregion

    }

}