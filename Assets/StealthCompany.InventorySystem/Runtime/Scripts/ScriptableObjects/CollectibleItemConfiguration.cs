using UnityEngine;
using UnityEngine.UI;


namespace InventorySystem.Systems.Controllers.Items.Collectibles
{

    [CreateAssetMenu(fileName = "CollectibleItemConfiguration", menuName = "ScriptableObjects/CollectibleItemConfiguration")]
    public class CollectibleItemConfiguration : ScriptableObject
    {

        #region CollectibleItemType public enum

        public enum CollectibleItemType : byte
        {
            Poison,
            Potion,
            Invincibility,
            Last
        }

        #endregion

        [SerializeField]
        private CollectibleItemType _collectibleType = CollectibleItemType.Poison;
        public CollectibleItemType CollectibleType
        {
            get => _collectibleType;
        }

        [SerializeField]
        private string _collectibleItemName = string.Empty;
        public string CollectibleItemName
        {
            get => _collectibleItemName;
        }

        [SerializeField]
        private int _collectibleItemID = -1;
        public int CollectibleItemID
        {
            get => _collectibleItemID;
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

    }

}