using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems
{

    /// <summary>
    /// Monobehavior which manages the systems of the entire application.
    /// </summary>
    [DisallowMultipleComponent]
    public class SystemsManager : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("List of application's systems")]
        private List<BaseSystem> _systems = null;

        [Tooltip("Systems manager singleton")]
        public static SystemsManager Instance
        {
            get;
            private set;
        } = null;


        #region Life cycle

        private void Awake()
        {

            SetUp();

        }

        private void SetUp()
        {

            // Set singleton
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }

            // Add to permanent objects
            DontDestroyOnLoad(this.gameObject);

            // Systems set up
            foreach (BaseSystem system in _systems)
            {
                system.SetUp();
            }

        }


        private void OnDestroy()
        {

            CleanUp();

        }

        private void CleanUp()
        {

            // Systems clean up
            foreach (BaseSystem system in _systems)
            {
                system.CleanUp();
            }

        }

        #endregion
        #region API

        /// <summary>
        /// Method that returns the "BaseSystem" of the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// The method accepts a parameter of type 'T'(generic) which must be a "BaseSystem".
        /// <returns></returns>
        public T GetSystem<T>() where T : BaseSystem
        {
            return _systems.OfType<T>().FirstOrDefault();
        }

        #endregion

    }

}