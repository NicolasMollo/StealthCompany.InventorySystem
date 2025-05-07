using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace NewLab.Unity.SDK.Core.Systems.Input.Unity
{

    public class Unity_InputController : BaseInputController
    {

        [SerializeField]
        [Tooltip("Container's input action reference")]
        private InputActionReference _inputActionReference = null;

        [SerializeField]
        [Tooltip("Input name")]
        private string _inputName = string.Empty;
        public string InputName
        {
            get => _inputName;
        }

        [SerializeField]
        [Tooltip("Input id")]
        private int _inputID = -1;
        public int InputID
        {
            get => _inputID;
        }

        public bool IsEnable
        {
            get => _inputActionReference.action.enabled;
        }

        public bool IsPressed
        {
            get;
            set;
        } = false;

        #region Actions

        public Action<Unity_InputController> OnEnableInput = null;
        public Action<Unity_InputController> OnDisableInput = null;

        /// <summary>
        /// Action invoked when the input started.
        /// </summary>
        public Action<Unity_InputController> OnInputStarted = null;
        /// <summary>
        /// Action invoked when the input it's finished (button released for example).
        /// </summary>
        public Action<Unity_InputController> OnInputEnded = null;
        /// <summary>
        /// Action invoked when the input it's considered completed.
        /// </summary>
        public Action<Unity_InputController> OnInputCompleted = null;

        #endregion

        #region API

        public override void SetUp()
        {

            _inputActionReference.action.started += CallOnInputStarted;
            _inputActionReference.action.canceled += CallOnInputEnded;
            _inputActionReference.action.performed += CallOnInputCompleted;

        }

        public override void CleanUp()
        {

            _inputActionReference.action.started -= CallOnInputStarted;
            _inputActionReference.action.canceled -= CallOnInputEnded;
            _inputActionReference.action.performed -= CallOnInputCompleted;

        }

        public override void EnableInput()
        {

            _inputActionReference.action.Enable();
            OnEnableInput?.Invoke(this);

        }

        public override void DisableInput()
        {

            _inputActionReference.action.Disable();
            OnDisableInput?.Invoke(this);

        }

        #endregion
        #region Internal methods

        private void CallOnInputStarted(InputAction.CallbackContext callbackContext)
        {

            OnInputStarted?.Invoke(this);

        }

        private void CallOnInputEnded(InputAction.CallbackContext callbackContext)
        {

            OnInputEnded?.Invoke(this);

        }

        private void CallOnInputCompleted(InputAction.CallbackContext callbackContext)
        {

            OnInputCompleted?.Invoke(this);

        }

        #endregion
    }

}