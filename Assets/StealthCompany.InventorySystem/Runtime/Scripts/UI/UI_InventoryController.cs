using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;


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
        [Tooltip("Inventory slots parent")]
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
                    if (slot.IsFree)
                    {
                        inventorySlot = slot;
                        break;
                    }
                }
                return inventorySlot;
            }
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

        #endregion

        public Action<UI_InventoryItem> OnCreateInventoryItem = null;

        #region API

        /// <summary>
        /// Method that deals with the Set Up of an inventory item.
        /// If the inventory Item exists and has not reached the maximum quantity of units then it 
        /// adds a unit to the item, otherwise it creates and returns a new one
        /// </summary>
        /// <param name="collectibleItemConfiguration"></param>
        public void SetUpInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            UI_InventoryItem inventoryItem = items.FirstOrDefault(item => 
                item.Configuration.ItemID == collectibleItemConfiguration.ItemID
                    && !item.ReachedMaxNumberOfUnits
                        );

            if (inventoryItem == null)
                inventoryItem = CreateInventoryItem(collectibleItemConfiguration);

            inventoryItem.IncreaseUnitsOfItemCount();

        }

        #endregion

        #region Life cycle

        private void OnDestroy()
        {

            foreach (UI_InventoryItem inventoryItem in items)
            {
                inventoryItem.OnDestroyMe -= OnDestroyInventoryItem;
            }

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method that creates and return an inventory item.
        /// If a free slot(parent of the item) is not found, one is created and the item is then added to it.
        /// </summary>
        /// <param name="collectibleItemConfiguration"></param>
        /// <returns></returns>
        private UI_InventoryItem CreateInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            UI_InventorySlot inventorySlot = FreeSlot == null ? CreateInventorySlot() : FreeSlot;
            GameObject inventoryItemObject = Instantiate(prefabInventoryItem, inventorySlot.transform);
            UI_InventoryItem inventoryItem = inventoryItemObject.GetComponent<UI_InventoryItem>();
            inventoryItem.SetUp(inventorySlot.transform, itemsParentOnDrag, collectibleItemConfiguration);
            inventoryItem.OnDestroyMe += OnDestroyInventoryItem;
            items.Add(inventoryItem);
            OnCreateInventoryItem?.Invoke(inventoryItem);
            return inventoryItem;

        }

        /// <summary>
        /// Method that creates and returns an inventory slot.
        /// </summary>
        /// <returns></returns>
        private UI_InventorySlot CreateInventorySlot()
        {

            GameObject inventorySlotObject = Instantiate(prefabInventorySlot, slotsParent);
            UI_InventorySlot inventorySlot = inventorySlotObject.GetComponent<UI_InventorySlot>();
            slots.Add(inventorySlot);
            return inventorySlot;

        }

        /// <summary>
        /// Method that removes the inventory item passed as parameter from the "items" list once it is destroyed.
        /// </summary>
        /// <param name="inventoryItem"></param>
        private void OnDestroyInventoryItem(UI_InventoryItem inventoryItem)
        {

            items.Remove(inventoryItem);

        }

        #endregion

    }

}