using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using System.Linq;
using System;


namespace InventorySystem.Systems.UI.Inventory
{

    [DisallowMultipleComponent]
    public class UI_InventoryController : BaseController
    {

        #region Slots

        [TitleGroup("SLOTS", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Inventory slot prefab")]
        private GameObject prefabInventorySlot = null;

        [SerializeField]
        private Transform slotsParent = null;

        [SerializeField]
        [Tooltip("List of inventory slots")]
        private List<UI_InventorySlot> slots = null;

        private UI_InventorySlot FreeSlot
        {
            get
            {
                UI_InventorySlot inventorySlot = null;
                foreach (UI_InventorySlot slot in slots)
                {
                    if (slot.transform.childCount == 0)
                    {
                        inventorySlot = slot;
                        break;
                    }
                }
                return inventorySlot;
            }
            set => FreeSlot = value;
        }

        #endregion
        #region Items

        [TitleGroup("ITEMS", null, TitleAlignments.Left)]

        [SerializeField]
        [Tooltip("Inventory item prefab")]
        private GameObject prefabInventoryItem = null;

        [SerializeField]
        [Tooltip("Inventory items parent on drag")]
        private Transform itemsParentOnDrag = null;

        [Tooltip("List of inventory items")]
        private List<UI_InventoryItem> items = new List<UI_InventoryItem>();
        public List<UI_InventoryItem> Items
        {
            get => items;
        }

        #endregion

        public Action<UI_InventoryItem> OnCreateInventoryItem = null;

        #region API

        public void SetUpInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            UI_InventoryItem inventoryItem = items.FirstOrDefault(item => 
                item.Configuration.CollectibleItemID == collectibleItemConfiguration.CollectibleItemID
                    && !item.ReachedMaxNumberOfUnits
                        );

            if (inventoryItem == null)
                inventoryItem = CreateInventoryItem(collectibleItemConfiguration);

            inventoryItem.IncreaseUnitsOfItemCount();

        }

        #endregion


        private UI_InventoryItem CreateInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            UI_InventorySlot slot = FreeSlot == null ? CreateInventorySlot() : FreeSlot;
            GameObject inventoryItemObject = Instantiate(prefabInventoryItem, slot.transform);
            UI_InventoryItem inventoryItem = inventoryItemObject.GetComponent<UI_InventoryItem>();
            inventoryItem.SetUp(slot.transform, itemsParentOnDrag, collectibleItemConfiguration);
            inventoryItem.OnDestroyMe += OnDestroyInventoryItem;
            items.Add(inventoryItem);
            OnCreateInventoryItem?.Invoke(inventoryItem);
            return inventoryItem;

        }

        private UI_InventorySlot CreateInventorySlot()
        {

            GameObject inventorySlotObject = Instantiate(prefabInventorySlot, slotsParent);
            UI_InventorySlot inventorySlot = inventorySlotObject.GetComponent<UI_InventorySlot>();
            slots.Add(inventorySlot);
            return inventorySlot;

        }


        private void OnDestroy()
        {

            foreach (UI_InventoryItem inventoryItem in items)
            {
                inventoryItem.OnDestroyMe -= OnDestroyInventoryItem;
            }

        }
        private void OnDestroyInventoryItem(UI_InventoryItem inventoryItem)
        {

            items.Remove(inventoryItem);

        }

    }

}