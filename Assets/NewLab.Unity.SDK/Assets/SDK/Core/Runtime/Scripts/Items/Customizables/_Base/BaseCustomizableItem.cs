using System;
using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.CustomizableElements
{

    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    public abstract class BaseCustomizableItem<T> : MonoBehaviour where T : BaseCustomizableItemData
    {

        public Action<T> OnCustomize = null;

        #region API

        public virtual void Customize(T customizableItemData)
        {

            OnCustomize?.Invoke(customizableItemData);

        }

        #endregion

    }

}