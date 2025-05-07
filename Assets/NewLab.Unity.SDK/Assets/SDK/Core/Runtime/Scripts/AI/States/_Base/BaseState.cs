using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.AI
{

    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseState : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("FSM that manages this state")]
        protected FSM fsm = null;


        #region API

        /// <summary>
        /// Method that is called when entering the state.
        /// </summary>
        public virtual void OnStateEnter() { }

        /// <summary>
        /// Method that is called when updating state.
        /// </summary>
        public virtual void OnStateUpdate() { }

        /// <summary>
        /// Method that is called when leaving the state.
        /// </summary>
        public virtual void OnStateExit() { }

        #endregion

    }

}