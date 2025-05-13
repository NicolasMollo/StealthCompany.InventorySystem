using System;
using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Modules;


namespace InventorySystem.Systems.Controllers.Player
{

    public class InventorySystem_MovementModule : BaseMovementModule
    {

        [TitleGroup("INVENTORYSYSTEM_MOVEMENTMODULE", null, TitleAlignments.Centered)]

        [SerializeField]
        [Tooltip("CharacterController target")]
        private CharacterController _targetCharacterController = null;
        public CharacterController TargetCharacterController
        {
            get => _targetCharacterController;
        }

        #region Speeds

        [SerializeField]
        [Range(1.0f, 1000.0f)]
        [Tooltip("Scalar that will be multiplied by the vector relating to the direction of movement")]
        private float _movementSpeed = 1.0f;
        public float MovementSpeed
        {
            get => _movementSpeed;
            set
            {
                _movementSpeed = value > 1000.0f ? 1000.0f : value < 1.0f ? 1.0f : value;
                OnChangeMovementSpeed?.Invoke(_movementSpeed);
            }
        }
        public Action<float> OnChangeMovementSpeed = null;

        [SerializeField]
        [Tooltip("Rotation speed multiplier")]
        [Range(1.0f, 25.0f)]
        private float rotationSpeedMultiplier = 10.0f;

        #endregion

        /// <summary>
        /// Method that deals with moving the target.
        /// </summary>
        /// <param name="targetCamera"></param>
        public void Movement(Transform targetCamera)
        {

            Vector3 input = GetAxes();
            Vector3 cameraForward = Vector3.ProjectOnPlane(targetCamera.forward, Vector3.up).normalized;
            Vector3 cameraRight = Vector3.ProjectOnPlane(targetCamera.right, Vector3.up).normalized;
            Vector3 directionNormalized = (cameraForward * input.z + cameraRight * input.x).normalized;
            float calculatedMovementSpeed = _movementSpeed * Time.deltaTime;
            float calculatedRotationSpeed = rotationSpeedMultiplier * Time.deltaTime;

            if (directionNormalized.magnitude > 0.1f)
            {
                Quaternion targetRot = Quaternion.LookRotation(directionNormalized);
                _targetCharacterController.transform.rotation = Quaternion.Slerp(
                    _targetCharacterController.transform.rotation,
                    targetRot,
                    calculatedRotationSpeed
                    );
            }

            _targetCharacterController.Move(directionNormalized * calculatedMovementSpeed);

        }

        /// <summary>
        /// Method that get mouse input axes.
        /// </summary>
        /// <returns></returns>
        private Vector3 GetAxes()
        {

            Vector3 inputAxes = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            return inputAxes;

        }


    }

}