using UnityEngine;
using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace InventorySystem.Systems.Controllers
{

    [DisallowMultipleComponent]
    public class InventorySystem_EnvironmentRootController : BaseSceneController
    {

        [SerializeField]
        [Tooltip("Floor collider that defines the size of the map")]
        private Collider floorCollider = null;

        #region Map properties

        public Vector3 MapPosition
        {
            get => floorCollider.transform.position;
        }

        public Vector3 MapSize
        {
            get => floorCollider.bounds.size;
        }

        public Vector3 HalfMapSize
        {
            get => floorCollider.bounds.size * 0.5f;
        }

        #endregion

    }

}