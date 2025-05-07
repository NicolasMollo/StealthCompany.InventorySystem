using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Events
{

    /// <summary>
    /// This class serves as the basis for all classes that want to define themselves as a "Event".
    /// </summary>
    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseEvent : MonoBehaviour
    {

        #region API

        /// <summary>
        /// Method that removes all listeners from the event.
        /// </summary>
        public abstract void RemoveAllListeners();

        #endregion

    }

}