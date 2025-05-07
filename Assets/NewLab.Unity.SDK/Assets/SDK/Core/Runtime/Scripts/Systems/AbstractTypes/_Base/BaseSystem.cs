using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Systems
{

    /// <summary>
    /// Implementation of the <seealso cref="ISystem"/> interface.
    /// This class serves as the basis for all classes that want to define themselves as a "System".
    /// </summary>
    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseSystem : MonoBehaviour, ISystem
    {

        #region API

        /// <summary>
        /// Method that takes care of setting the system.
        /// This method can be overridden.
        /// </summary>
        public virtual void SetUp() { }

        /// <summary>
        /// Method that takes care of cleaning the system.
        /// This method can be overridden.
        /// </summary>
        public virtual void CleanUp() { }

        #endregion

    }

}