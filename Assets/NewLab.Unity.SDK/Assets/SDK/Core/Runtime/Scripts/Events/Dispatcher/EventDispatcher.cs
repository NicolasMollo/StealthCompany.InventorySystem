using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Events
{

    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public class EventDispatcher : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("List of scene events")]
        private List<BaseEvent> _events = null;


        #region API

        /// <summary>
        /// Method that allows you to take the event of the specified type.
        /// The method accepts a parameter of type 'T'(generic) which must be a "BaseEvent".
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns></returns>
        public T GetEvent<T>() where T : BaseEvent
        {
            return _events.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// Method that removes all listeners from all events.
        /// </summary>
        public void RemoveAllListenersFromAllEvents()
        {

            foreach (BaseEvent m_event in _events)
            {
                m_event.RemoveAllListeners();
            }

        }

        #endregion

    }

}