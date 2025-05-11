using NewLab.Unity.SDK.Core.Modules;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem.Systems.UI.LifeBar
{

    public class UI_LifeBarController : BaseController
    {

        [SerializeField]
        private Image bar = null;

        private float originalScaleX = 0.0f;


        public void SetUp(Std_HealthModule healthModule)
        {

            originalScaleX = bar.transform.localScale.x;
            SetLifeBar(healthModule);

        }

        public void SetLifeBar(Std_HealthModule healthModule)
        {

            // float scaleX = bar.transform.localScale.x + originalScaleX * (healthModule.CurrentHealth / healthModule.MaxHealth);
            float scaleX = /*originalScaleX * */(healthModule.CurrentHealth / healthModule.MaxHealth);
            Vector3 scaleToReach = new Vector3(scaleX, bar.transform.localScale.y, bar.transform.localScale.z);
            bar.transform.localScale = Vector3.Lerp(bar.transform.localScale, scaleToReach, Time.deltaTime);

        }

    }

}