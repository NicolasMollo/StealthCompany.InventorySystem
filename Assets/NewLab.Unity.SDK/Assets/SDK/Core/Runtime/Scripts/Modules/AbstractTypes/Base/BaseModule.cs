using Sirenix.OdinInspector;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Modules
{

    /// <summary>
    /// Implementation of the <seealso cref="IModule"/> interface.
    /// This class serves as the basis for all classes that want to define themselves as a "Module".
    /// </summary>
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseModule : MonoBehaviour, IModule
    {

        #region Data

        [TitleGroup("BASE MODULE", null, TitleAlignments.Centered)]

        [SerializeField]
        [Tooltip("Module's name")]
        private string _moduleName = string.Empty;
        private const string DEFAULTMODULE_NAME = "Default Module";

        [SerializeField]
        [Tooltip("Module's id")]
        private int _moduleID = -1;

        public string ModuleName
        {
            get
            {
                if (string.IsNullOrEmpty(_moduleName))
                {
                    _moduleName = DEFAULTMODULE_NAME;
                    Debug.LogWarning($"== {this.name.ToUpper()} == The module name is not a valid name.\r\nit was assigned the name by default:\"{_moduleName}\"");
                }
                return _moduleName;
            }
            protected set
            {
                _moduleName = value;
            }

        }

        public int ModuleID
        {
            get
            {
                if (_moduleID <= -1)
                {
                    _moduleID = -1;
                    Debug.LogWarning($"== {this.name.ToUpper()} == The module id is not a valid ID.\r\nit was assigned the ID by default:\"{_moduleID}\"");
                }
                return _moduleID;
            }
            protected set
            {
                _moduleID = value;
            }
        }

        #endregion
        #region API

        /// <summary>
        /// Method that takes care of setting the module.
        /// This method can be overridden.
        /// </summary>
        public virtual void SetUp() { }

        /// <summary>
        /// Method that takes care of updating the module.
        /// This method can be overridden.
        /// </summary>
        public virtual void UpdateModule() { }

        /// <summary>
        /// Method that takes care of updating (fixed mode) the module.
        /// This method can be overridden.
        /// </summary>
        public virtual void FixedUpdateModule() { }

        /// <summary>
        /// Method that takes care of cleaning the module.
        /// This method can be overridden.
        /// </summary>
        public virtual void CleanUp() { }

        #endregion

    }

}