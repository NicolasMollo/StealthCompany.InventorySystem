using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using System.Linq;


namespace InventorySystem.Systems.UI.Inventory
{

    [DisallowMultipleComponent]
    public class UI_InventoryController : BaseController
    {

        #region Slots

        [TitleGroup("SLOTS", null, TitleAlignments.Left)]

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

        #region API

        public void SetUpInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            UI_InventoryItem inventoryItem = items.FirstOrDefault(item => 
                item.Configuration.CollectibleItemID == collectibleItemConfiguration.CollectibleItemID
                    );

            if (inventoryItem == null)
                inventoryItem = CreateInventoryItem(collectibleItemConfiguration);

            inventoryItem.IncreaseUnitsOfItemCount();

        }

        #endregion

        private UI_InventoryItem CreateInventoryItem(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            GameObject inventoryItemObject = Instantiate(prefabInventoryItem, FreeSlot.transform);
            UI_InventoryItem inventoryItem = inventoryItemObject.GetComponent<UI_InventoryItem>();
            inventoryItem.SetUp(FreeSlot.transform, itemsParentOnDrag, collectibleItemConfiguration);
            items.Add(inventoryItem);
            return inventoryItem;

        }

    }

}