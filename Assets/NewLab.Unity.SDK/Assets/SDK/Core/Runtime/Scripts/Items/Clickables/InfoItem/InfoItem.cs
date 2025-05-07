using UnityEngine;
using Sirenix.OdinInspector;
using NewLab.Unity.SDK.Core.Systems.Controllers.ClickableElements;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.InfoElements
{

    public class InfoItem : BaseClickableItem<InfoItemData>
    {

        [TitleGroup("INFO ITEM DATA", null, TitleAlignments.Left)]

        [SerializeField]
        private InfoItemData _infoItemData = null;

        public InfoItemData InfoItemData
        {
            get => _infoItemData;
            protected set => _infoItemData = value;
        }

        protected override InfoItemData GetEventsData()
        {
            return _infoItemData;
        }

    }

}