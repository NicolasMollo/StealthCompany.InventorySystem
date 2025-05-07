using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.InfoElements
{

    [CreateAssetMenu(menuName = "ScriptableObjects/Data/InfoItemData")]
    public class InfoItemData : BaseData
    {

        [SerializeField]
        private float infoItemHeight = 0.0f;

        [SerializeField]
        private float infoItemWidth = 0.0f;

        [SerializeField]
        private float infoItemSize = 0.0f;


        public float InfoItemHeight
        {
            get => infoItemHeight;
        }

        public float InfoItemWidth
        {
            get => infoItemWidth;
        }

        public float InfoItemWidthSize
        {
            get => infoItemSize;
        }

    }

}