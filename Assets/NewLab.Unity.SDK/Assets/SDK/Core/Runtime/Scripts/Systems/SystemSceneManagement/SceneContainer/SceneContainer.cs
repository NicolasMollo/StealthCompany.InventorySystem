using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.SceneManagement
{

    public class SceneContainer : MonoBehaviour
    {

        [SerializeField]
        private SceneData _sceneData = null;
        public SceneData SceneData
        {
            get => _sceneData;
        }

        #region Container data

        private bool _isLoaded = false;
        public bool IsLoaded
        {
            get => _isLoaded;
            protected set => _isLoaded = value;
        }

        #endregion


        #region API

        public virtual void SetUp()
        {

            bool loadingState = true;
            _isLoaded = loadingState;

        }

        public virtual void CleanUp()
        {

            bool loadingState = false;
            _isLoaded = loadingState;

        }

        #endregion

    }

}