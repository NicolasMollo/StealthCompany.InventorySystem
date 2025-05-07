using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Modules;


namespace InventorySystem.Systems.Controllers.PlayerModules
{

    public class InventorySystem_MovementModule : BaseMovementModule
    {

        [TitleGroup("INVENTORYSYSTEM_MOVEMENTMODULE", null, TitleAlignments.Centered)]

        [SerializeField]
        [Tooltip("Transform target to move")]
        private Transform _targetTransform = null;
        public Transform TargetTransform
        {
            get => _targetTransform;
        }

        [SerializeField]
        [Range(1.0f, 1000.0f)]
        [Tooltip("Scalar that will be multiplied by the vector relating to the direction of movement")]
        private float movementSpeed = 1.0f;


        public void Movement(Transform targetCamera)
        {

            Vector3 direction = targetCamera.forward * GetAxes().z + targetCamera.right * GetAxes().x;
            Vector3 directionNormalized = direction.normalized;
            float calculatedMovementSpeed = movementSpeed * Time.deltaTime;
            Vector3 velocity = directionNormalized * calculatedMovementSpeed;

            _targetTransform.Translate(velocity, Space.World);
            _targetTransform.rotation = targetCamera.rotation;

        }

        private Vector3 GetAxes()
        {

            Vector3 inputAxes = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            return inputAxes;

        }

    }

}