using Sirenix.OdinInspector;
using System;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.SelectableElements
{

    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public class SelectableItem : MonoBehaviour
    {

        /*For testing*/[SerializeField]
        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            protected set => _isSelected = value;
        }

        public Action<SelectableItem> OnSelect = null;
        public Action<SelectableItem> OnDeselect = null;


        #region API

        public virtual void Select()
        {

            bool selectedState = true;
            _isSelected = selectedState;
            OnSelect?.Invoke(this);

        }

        public virtual void Deselect()
        {

            bool selectedState = false;
            _isSelected = selectedState;
            OnDeselect?.Invoke(this);

        }

        #endregion

    }

}