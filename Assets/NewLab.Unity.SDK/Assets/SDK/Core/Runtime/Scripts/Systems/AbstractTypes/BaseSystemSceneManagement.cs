using UnityEngine.SceneManagement;


namespace NewLab.Unity.SDK.Core.Systems.SceneManagement
{

    public abstract class BaseSystemSceneManagement : BaseSystem
    {

        #region API

        // READ ME:
        // "ChangeScene" method with stering is abstract because the name of the scene is more secure than scene ID:
        // the scene ID change when the scene build order is changed, while the scene name it's always the same.

        /// <summary>
        /// Method for changing scene.
        /// This method accepts as arguments a "string" type parameter which indicates 
        /// the name of the new scene to which you want to pass and a "LoadSceneMode" type parameter 
        /// which represents the mode in which the loading of the new scene will be managed.
        /// The method must be overridden!
        /// </summary>
        /// <param name="sceneName"></param>
        /// <param name="loadSceneMode"></param>
        public abstract void ChangeScene(string sceneName, LoadSceneMode loadSceneMode);

        /// <summary>
        /// Method for changing scene.
        /// This method accepts as arguments a "int" type parameter which indicates 
        /// the ID of the new scene to which you want to pass and a "LoadSceneMode" type parameter 
        /// which represents the mode in which the loading of the new scene will be managed.
        /// The method can be overridden.
        /// </summary>
        /// <param name="sceneID"></param>
        /// <param name="loadSceneMode"></param>
        public virtual void ChangeScene(int sceneID, LoadSceneMode loadSceneMode) { }

        #endregion

    }

}