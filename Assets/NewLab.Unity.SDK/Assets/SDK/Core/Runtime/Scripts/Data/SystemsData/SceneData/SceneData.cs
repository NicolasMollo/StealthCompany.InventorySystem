using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace NewLab.Unity.SDK.Core.Systems.SceneManagement
{

    [CreateAssetMenu(menuName = "ScriptableObjects/Core/Data/SceneData")]
    public class SceneData : BaseData
    {

        [TitleGroup("SCENE DATA", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Scene name")]
        private string _sceneName = string.Empty;
        public string SceneName
        {
            get
            {
                if (string.IsNullOrEmpty(_sceneName))
                {
                    Debug.LogError($"== {this.name.ToUpper()} == SCENE_NAME it's not correctly filled!");
                }
                return _sceneName;
            }
        }

        [SerializeField]
        [Tooltip("Scene ID")]
        private int _sceneID = -1;
        public int SceneID
        {
            get
            {
                if (_sceneID < 0)
                {
                    Debug.LogError($"== {this.name.ToUpper()} == SCENE_ID It's not corretctly filled!");
                }
                return _sceneID;
            }
        }

    }

}