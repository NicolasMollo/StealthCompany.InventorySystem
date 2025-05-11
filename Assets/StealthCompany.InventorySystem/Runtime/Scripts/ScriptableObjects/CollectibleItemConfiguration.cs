using InventorySystem.ScriptableObjects.Commands;
using Sirenix.OdinInspector.Editor.Validation;
using System.Data;
using UnityEngine;
using UnityEngine.UI;


namespace InventorySystem.Systems.Controllers.Items.Collectibles
{

    [CreateAssetMenu(fileName = "CollectibleItemConfiguration", menuName = "ScriptableObjects/CollectibleItemConfiguration")]
    public class CollectibleItemConfiguration : ScriptableObject
    {

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

        [SerializeField]
        private CommandBehaviour _collectibleItemBehaviour = null;
        public CommandBehaviour CollectibleItemBehaviour
        {
            get => _collectibleItemBehaviour;
        }

    }

}