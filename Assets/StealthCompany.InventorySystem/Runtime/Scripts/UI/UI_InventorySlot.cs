using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.Systems.UI.Inventory
{

    [DisallowMultipleComponent]
    public class UI_InventorySlot : MonoBehaviour, IDropHandler
    {

        private bool _isSlotFree = true;
        public bool IsSlotFree
        {
            get => _isSlotFree;
        }

        public void OnDrop(PointerEventData eventData)
        {

            if (this.transform.childCount == 0)
            {
                UI_InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<UI_InventoryItem>();
                inventoryItem.Parent = this.transform;
                _isSlotFree = false;
            }

        }


    }

}