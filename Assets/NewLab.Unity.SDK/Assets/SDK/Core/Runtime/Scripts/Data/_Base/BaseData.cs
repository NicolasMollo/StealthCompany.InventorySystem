using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Systems.Controllers
{

    /// <summary>
    /// Abstract scriptable object that will serve as the basis for all the "Data" structures of the application.
    /// This class is not instantiable!
    /// </summary>
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseData : ScriptableObject
    {

        #region Data

        [SerializeField]
        [Tooltip("Data name")]
        private string _dataName = string.Empty;
        private const string DEFAULTDATA_NAME = "Default Data";

        [SerializeField]
        [Tooltip("Data id")]
        private int _dataID = -1;

        public string DataName
        {
            get
            {
                if (string.IsNullOrEmpty(_dataName))
                {
                    _dataName = DEFAULTDATA_NAME;
                    Debug.LogWarning($"== {this.name.ToUpper()} == The data name is not a valid name.\r\nit was assigned the name by default:\"{_dataName}\"");
                }
                return _dataName;
            }
            protected set
            {
                _dataName = value;
            }

        }

        public int DataID
        {
            get
            {
                if (_dataID <= -1)
                {
                    _dataID = -1;
                    Debug.LogWarning($"== {this.name.ToUpper()} == The module id is not a valid ID.\r\nit was assigned the ID by default:\"{_dataID}\"");
                }
                return _dataID;
            }
            protected set
            {
                _dataID = value;
            }
        }

        #endregion

    }

}