using System;
using UnityEngine;
using Sirenix.OdinInspector;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.ClickableElements
{

    [DisallowMultipleComponent]
    [InlineEditor(InlineEditorModes.FullEditor)]
    [RequireComponent(typeof(Collider))]
    public abstract class BaseClickableItem<T> : MonoBehaviour where T : UnityEngine.Object
    {

        [TitleGroup("CLICKABLE ITEM DATA", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Number of clicks for the object to be in the \"Clicked\" state")]
        private int clickAmount = 0;
        private int clickCount = 0;
        protected bool isInteractable = true;

        public bool IsClickAmountReached
        {
            get => clickCount == clickAmount;
        }

        public Action<T> OnEachClick = null;
        public Action<T> OnClickAmountReached = null;


        #region Life cycle

        private void OnMouseDown()
        {

            OnPointerClick();

        }

        /// <summary>
        /// Method that detects the click on the clickable item.
        /// </summary>
        protected virtual void OnPointerClick()
        {

            if (!isInteractable)
            {
                return;
            }

            clickCount++;
            Debug.Log($"== {this.name.ToUpper()} == Item is clicked");
            T data = GetEventsData();
            OnEachClick?.Invoke(data);

            if (IsClickAmountReached)
            {
                Debug.Log($"== {this.name.ToUpper()} == Item click amount is reached");
                OnClickAmountReached?.Invoke(data);
                clickCount = 0;
            }

        }

        /// <summary>
        /// Method that returns to the base the type that will replace the "T" type 
        /// to allow events to have the right type inside the Invoke.
        /// </summary>
        /// <returns></returns>
        protected abstract T GetEventsData();

        #endregion

        #region API

        /// <summary>
        /// Method that enable clickable item interaction.
        /// This method is overridable.
        /// </summary>
        /// <returns></returns>
        public virtual bool EnableInteraction()
        {

            bool interactableState = true;
            isInteractable = interactableState;
            return isInteractable;

        }

        /// <summary>
        /// Method that disable clickable item interaction.
        /// This method is overridable.
        /// </summary>
        /// <returns></returns>
        public virtual bool DisableInteraction()
        {

            bool interactableState = false;
            isInteractable = interactableState;
            return isInteractable;

        }

        #endregion

    }

}