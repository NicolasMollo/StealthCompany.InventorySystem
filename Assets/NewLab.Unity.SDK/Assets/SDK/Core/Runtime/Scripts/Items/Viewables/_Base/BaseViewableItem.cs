using System;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.ViewableElements
{

    [DisallowMultipleComponent]
    public abstract class BaseViewableItem : MonoBehaviour
    {

        public Action OnViewing = null;

        /// <summary>
        /// Method that manages the visualization of the item.
        /// The method can be overridden!
        /// </summary>
        public virtual void Visualize()
        {

            OnViewing?.Invoke();

        }

    }

}