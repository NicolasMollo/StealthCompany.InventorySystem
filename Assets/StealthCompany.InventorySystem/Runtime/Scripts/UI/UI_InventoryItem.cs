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

        [SerializeField]
        [Tooltip("Graphic of UI inventory item")]
        private Image image = null;

        [SerializeField]
        [Tooltip("Button component")]
        private Button _button = null;
        public Button Button
        {
            get => _button;
        }

        [SerializeField]
        [Tooltip("Item units text")]
        private TextMeshProUGUI itemUnitsText = null;

        [Tooltip("Data that define a tyoe of invenotry item")]
        private CollectibleItemConfiguration _configuration = null;
        public CollectibleItemConfiguration Configuration
        {
            get => _configuration;
        }

        [Tooltip("Inventory item parent on drag")]
        private Transform dragParent = null;

        [Tooltip("Inventory item parent")]
        private Transform _parent = null;
        public Transform Parent
        {
            get => _parent;
            set => _parent = value;
        }

        [SerializeField]
        private int maxUnitsCount = 10;

        private int unitsOfItemCount = 0;
        public bool ReachedMaxNumberOfUnits
        {
            get => unitsOfItemCount == maxUnitsCount;
        }

        public Action OnItemBeginDrag = null;
        public Action OnItemDrag = null;
        public Action OnItemEndDrag = null;

        public Action<CollectibleItemConfiguration> OnClickButton = null;
        public Action<UI_InventoryItem> OnDestroyMe = null;


        public void SetUp(Transform inventoryItemParent, Transform inventoryItemParentOnDrag, CollectibleItemConfiguration itemConfiguration)
        {

            _parent = inventoryItemParent;
            dragParent = inventoryItemParentOnDrag;
            _configuration = itemConfiguration;
            image.material = _configuration.ItemUIImageMaterial;
            image.sprite = _configuration.ItemUIImage;
            _button.onClick.AddListener(OnButtonClick);

        }

        private void OnDestroy()
        {

            _button.onClick.RemoveListener(OnButtonClick);
            OnDestroyMe?.Invoke(this);

        }


        private void OnButtonClick()
        {

            if (_configuration.CollectibleItemBehaviour.IsCurrentlyCast) 
                return;
            OnClickButton?.Invoke(_configuration);
            DecreaseUnitsOfItemCount();

        }

        private void DecreaseUnitsOfItemCount()
        {

            unitsOfItemCount--;
            itemUnitsText.text = unitsOfItemCount < 2 ? string.Empty : unitsOfItemCount.ToString();
            if (unitsOfItemCount == 0)
                Destroy(this.gameObject);

        }

        public int IncreaseUnitsOfItemCount()
        {

            if (unitsOfItemCount == maxUnitsCount)
                unitsOfItemCount = 0;
            unitsOfItemCount++;
            itemUnitsText.text = unitsOfItemCount < 2 ? string.Empty : unitsOfItemCount.ToString();
            return unitsOfItemCount;

        }

        public void OnBeginDrag(PointerEventData eventData)
        {

            image.raycastTarget = false;
            _parent = transform.parent;
            transform.SetParent(dragParent);
            OnItemBeginDrag?.Invoke();

        }

        public void OnDrag(PointerEventData eventData)
        {

            transform.position = Input.mousePosition;
            OnItemDrag?.Invoke();

        }

        public void OnEndDrag(PointerEventData eventData)
        {

            image.raycastTarget = true;
            transform.SetParent(_parent);
            OnItemEndDrag?.Invoke();

        }

    }

}