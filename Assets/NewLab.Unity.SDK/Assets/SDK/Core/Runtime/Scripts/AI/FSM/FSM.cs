using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.AI
{

    [DisallowMultipleComponent]
    public class FSM : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("List of FSM states")]
        private List<BaseState> _states = null;

        private BaseState _currentState = null;
        public BaseState CurrentState
        {
            get => _currentState;
        }


        #region API

        /// <summary>
        /// Method that returns the "State" of the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// The method accepts a parameter of type 'T'(generic) which must be a "State".
        /// <returns></returns>
        public T GetState<T>() where T : BaseState
        {
            return _states.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Method to change the current state of the FSM.
        /// The method accepts as an argument a parameter of type "State" which represents the new current state of the FSM.
        /// </summary>
        /// <param name="nextState"></param>
        public void ChangeState(BaseState nextState)
        {

            if (_currentState != null)
            {
                _currentState.OnStateExit();
            }

            _currentState = nextState;
            _currentState.OnStateEnter();
            // Debug.Log($"== {this.name.ToUpper()} == The current state is: {_currentState.name}");

        }

        /// <summary>
        /// Method that updates the current state.
        /// </summary>
        public void UpdateCurrentState()
        {
            if (_currentState != null)
            {
                _currentState.OnStateUpdate();
            }
        }

        #endregion

    }

}