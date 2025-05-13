using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using TMPro;


namespace InventorySystem.Systems.UI.Inventory
{

    [DisallowMultipleComponent]
    public class UI_InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        #region UI components references

        [SerializeField]
        [Tooltip("Graphic of UI inventory item")]
        private Image image = null;

        [SerializeField]
        [Tooltip("Button component")]
        private Button _button = null;

        [SerializeField]
        [Tooltip("Item units text")]
        private TextMeshProUGUI itemUnitsText = null;

        #endregion
        #region Item units

        [SerializeField]
        [Tooltip("Max number of inventory item's units")]
        private int maxUnitsCount = 10;

        private int unitsOfItemCount = 0;

        public bool ReachedMaxNumberOfUnits
        {
            get => unitsOfItemCount == maxUnitsCount;
        }

        #endregion
        #region Parents

        [Tooltip("Inventory item parent on drag")]
        private Transform dragParent = null;

        [HideInInspector]
        [Tooltip("Inventory item parent")]
        public Transform parent = null;

        #endregion

        [Tooltip("Data that define a type of inventory item")]
        private CollectibleItemConfiguration _configuration = null;
        public CollectibleItemConfiguration Configuration
        {
            get => _configuration;
        }

        public Action<UI_InventoryItem> OnClickButton = null;
        public Action<UI_InventoryItem> OnDestroyMe = null;


        #region API

        /// <summary>
        /// Method that deals with setting the inventory item.
        /// </summary>
        /// <param name="itemParent"></param>
        /// <param name="itemParentOnDrag"></param>
        /// <param name="itemConfiguration"></param>
        public void SetUp(Transform itemParent, Transform itemParentOnDrag, CollectibleItemConfiguration itemConfiguration)
        {

            parent = itemParent;
            dragParent = itemParentOnDrag;
            _configuration = itemConfiguration;
            image.material = _configuration.ItemUIImageMaterial;
            image.sprite = _configuration.ItemUIImage;
            AddListeners();

        }

        /// <summary>
        /// Method that enables the button's interaction
        /// </summary>
        public void EnableButton()
        {

            _button.interactable = true;

        }

        /// <summary>
        /// Method that disables the button's interaction
        /// </summary>
        public void DisableButton()
        {

            _button.interactable = false;

        }

        /// <summary>
        /// Method that deals with increasing the number of units of the item.
        /// </summary>
        /// <returns></returns>
        public int IncreaseUnitsOfItemCount()
        {

            unitsOfItemCount++;
            SetItemUnitsText();
            return unitsOfItemCount;

        }

        #endregion

        #region Life cycle

        private void OnDestroy()
        {

            RemoveListeners();
            OnDestroyMe?.Invoke(this);

        }

        #endregion

        #region Event methods

        private void AddListeners()
        {

            _configuration.CollectibleItemBehaviour.OnStartCommand += OnStartCommand;
            _configuration.CollectibleItemBehaviour.OnEndCommand += OnEndCommand;
            _button.onClick.AddListener(OnButtonClick);

        }
        private void RemoveListeners()
        {

            _button.onClick.RemoveListener(OnButtonClick);
            _configuration.CollectibleItemBehaviour.OnStartCommand -= OnStartCommand;
            _configuration.CollectibleItemBehaviour.OnEndCommand -= OnEndCommand;

        }

        private void OnButtonClick()
        {

            OnClickButton?.Invoke(this);
            DecreaseUnitsOfItemCount();

        }
        private void OnStartCommand()
        {

            DisableButton();

        }
        private void OnEndCommand()
        {

            EnableButton();

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method that decreases the units of the item.
        /// If the number of units is equal to zero the item is deleted.
        /// </summary>
        private void DecreaseUnitsOfItemCount()
        {

            unitsOfItemCount--;
            SetItemUnitsText();
            if (unitsOfItemCount == 0)
                Destroy(this.gameObject);

        }

        private void SetItemUnitsText()
        {

            itemUnitsText.text = unitsOfItemCount < 2 ? string.Empty : unitsOfItemCount.ToString();

        }

        #endregion

        #region DragHandler events

        public void OnBeginDrag(PointerEventData eventData)
        {

            image.raycastTarget = false;
            parent = transform.parent;
            transform.SetParent(dragParent);

        }

        public void OnDrag(PointerEventData eventData)
        {

            transform.position = Input.mousePosition;

        }

        public void OnEndDrag(PointerEventData eventData)
        {

            image.raycastTarget = true;
            transform.SetParent(parent);

        }

        #endregion

    }

}