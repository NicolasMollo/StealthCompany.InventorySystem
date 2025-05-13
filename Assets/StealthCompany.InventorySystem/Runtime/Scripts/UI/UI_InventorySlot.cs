using UnityEngine;
using UnityEngine.EventSystems;


namespace InventorySystem.Systems.UI.Inventory
{

    [DisallowMultipleComponent]
    public class UI_InventorySlot : MonoBehaviour, IDropHandler
    {

        public bool IsFree
        {
            get => transform.childCount == 0;
        }

        public void OnDrop(PointerEventData eventData)
        {

            if (IsFree)
            {
                UI_InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<UI_InventoryItem>();
                inventoryItem.parent = transform;
            }

        }

    }

}