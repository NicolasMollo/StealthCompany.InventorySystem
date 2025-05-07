using UnityEngine;
using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace InventorySystem.Systems.Controllers
{

    public class InventorySystem_CameraController : BaseSceneController
    {

        [SerializeField]
        [Tooltip("Camera")]
        private Camera _camera;
        public Camera Camera
        {
            get => _camera;
        }

        [SerializeField]
        [Tooltip("Camera target")]
        private Transform cameraTarget;

        [SerializeField]
        [Tooltip("Camera position offset")]
        private Vector3 positionOffset = new Vector3(0, 2, -5);

        [SerializeField]
        [Tooltip("Camera sensitivity")]
        private float sensitivity = 100.0f;

        [SerializeField]
        [Tooltip("Minimum pitch")]
        private float minPitch = -40f;

        [SerializeField]
        [Tooltip("Maximum pitch")]
        private float maxPitch = 70f;

        private float yaw = 0f;
        private float pitch = 0f;


        #region API

        public override void UpdateController()
        {

            CameraMovement();

        }

        public void SetSensitivity(float sensitivity)
        {

            this.sensitivity = sensitivity;

        }

        #endregion

        #region Private methods

        private void CameraMovement()
        {

            Vector2 calculatedInput = GetAxes() * sensitivity * Time.deltaTime;
            yaw += calculatedInput.x;
            pitch -= calculatedInput.y;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 desiredPosition = cameraTarget.position + rotation * positionOffset;

            _camera.transform.position = desiredPosition;
            _camera.transform.LookAt(cameraTarget);

        }

        private Vector2 GetAxes()
        {

            Vector2 inputAxes = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
            return inputAxes;

        }

        #endregion

    }

}