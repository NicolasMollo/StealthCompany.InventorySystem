using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using NewLab.Unity.SDK.Core.Events;


namespace NewLab.Unity.SDK.Core.Systems.Controllers
{

    /// <summary>
    /// Monobehaviour which deals with scene management.
    /// "SceneRootController" is/should be the highest abstraction within the scene.
    /// This Monobehaviour must be overridden by those who want to define themselves as scene controllers.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class BaseSceneRootController : BaseController
    {

        [SerializeField]
        [Tooltip("List of scene controllers")]
        private List<BaseSceneController> _controllers = null;
        public List<BaseSceneController> Controllers
        {
            get => _controllers;
        }

        [Tooltip("Systems manager")]
        private SystemsManager _systemsManager = null;
        public SystemsManager SystemsManager
        {
            get => _systemsManager;
        }

        [SerializeField]
        [Tooltip("Event dispatcher")]
        private EventDispatcher _eventDispatcher = null;
        public EventDispatcher EventDispatcher
        {
            get => _eventDispatcher;
        }


        #region Life cycle

        private void Start()
        {

            InternalSetUp();

        }

        /// <summary>
        /// Method that sets the SceneRootController.
        /// This method is called in the "Start" method of SceneRootController class.
        /// When override this method don't forget to call: "base.SetUp()" inside which the base class is set up.
        /// </summary>
        protected virtual void InternalSetUp()
        {

            _systemsManager = SystemsManager.Instance;

        }


        private void OnDestroy()
        {

            InternalCleanUp();

        }

        /// <summary>
        /// Method that cleans the ScenRootController.
        /// This method is called in the "OnDestroy" method of SceneRootController class.
        /// </summary>
        protected virtual void InternalCleanUp() { }

        #endregion
        #region API

        /// <summary>
        /// Method that returns the controller of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetController<T>() where T : BaseSceneController
        {
            return _controllers.OfType<T>().FirstOrDefault();
        }

        #endregion

    }

}