using UnityEngine;
using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace InventorySystem.Systems.Controllers
{

    public class InventorySystem_CameraController : BaseSceneController
    {

        [SerializeField]
        [Tooltip("Camera target")]
        private Camera _targetCamera = null;
        public Camera TargetCamera
        {
            get => _targetCamera;
        }

        private Transform rotationTarget = null;

        [SerializeField]
        [Range(1.0f, 1000.0f)]
        [Tooltip("Mouse sensitivity")]
        private float sensitivity = 1.0f;

        private float xRotation = 0.0f;

        [SerializeField]
        [Range(0.0f, 360.0f)]
        private float minRotationX = 0.0f;
        [SerializeField]
        [Range(0.0f, 360.0f)]
        private float maxRotationX = 0.0f;

        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float zPositionOffset = 5.0f;

        private float yRotation = 0.0f;


        [SerializeField]
        [Range(1.0f, 10.0f)]
        private float yPositionOffset = 1.0f;


        #region API

        public override void SetUp(BaseSceneRootController sceneRootController)
        {

            InventorySystem_PlayerController playerController = 
                sceneRootController.GetController<InventorySystem_PlayerController>();
            rotationTarget = playerController.MovementModule.TargetTransform;

        }

        public override void UpdateController()
        {

            SetPosition();
            SetRotation();

        }

        public void SetSensitivity(float sensitivity)
        {

            this.sensitivity = sensitivity;

        }

        #endregion

        #region Private methods

        private void SetPosition()
        {

            Vector3 distanceOffset = Vector3.back * zPositionOffset + Vector3.up * yPositionOffset;
            Vector3 distanceToTarget = _targetCamera.transform.localRotation * distanceOffset;

            _targetCamera.transform.position = rotationTarget.position + distanceToTarget;
            // _targetCamera.transform.position = Vector3.Lerp(_targetCamera.transform.position, rotationTarget.position + distanceToTarget, 2f);
        }

        private void SetRotation()
        {

            Vector2 mouseInput = GetAxes();
            float calculatedSensitivity = sensitivity * Time.deltaTime;
            mouseInput *= calculatedSensitivity;
            xRotation -= mouseInput.y;
            xRotation = Mathf.Clamp(xRotation, minRotationX, maxRotationX);
            yRotation -= mouseInput.x;
            Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0f);

            _targetCamera.transform.localRotation = rotation;

        }

        private Vector2 GetAxes()
        {

            Vector2 inputAxes = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            return inputAxes;

        }

        #endregion

    }

}