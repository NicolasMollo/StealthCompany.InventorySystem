using UnityEngine;
using InventorySystem.ScriptableObjects.Commands;


namespace InventorySystem.Systems.Controllers.Items.Collectibles
{

    [CreateAssetMenu(fileName = "CollectibleItemConfiguration", menuName = "ScriptableObjects/CollectibleItemConfiguration")]
    public class CollectibleItemConfiguration : ScriptableObject
    {

        [SerializeField]
        private string _itemName = string.Empty;
        public string ItemName
        {
            get => _itemName;
        }

        [SerializeField]
        private int _itemID = -1;
        public int ItemID
        {
            get => _itemID;
        }

        [SerializeField]
        private Sprite _itemUIImage = null;
        public Sprite ItemUIImage
        {
            get => _itemUIImage;
        }

        [SerializeField]
        private Material _itemUIImageMaterial = null;
        public Material ItemUIImageMaterial
        {
            get => _itemUIImageMaterial;
        }

        [SerializeField]
        private CommandBehaviour _itemCommandBehaviour = null;
        public CommandBehaviour ItemCommandBehaviour
        {
            get => _itemCommandBehaviour;
        }

    }

}