using InventorySystem.ScriptableObjects.Commands;
using InventorySystem.Systems.Controllers.Items.Collectibles;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using System.Collections;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace InventorySystem.Systems.UI.EffectViewers
{

    [DisallowMultipleComponent]
    public class UI_EffectsViewersController : BaseController
    {

        [SerializeField]
        private Image effectTimeViewImage = null;

        private const float IMAGE_SHOW_VALUE = 1.0f;
        private const float IMAGE_HIDE_VALUE = 0.0f;

        [SerializeField]
        private TextMeshProUGUI playerSpeedText = null;


        public override void SetUp()
        {

            effectTimeViewImage.fillAmount = IMAGE_HIDE_VALUE;

        }


        public void SetEffectTimeViewImage(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            effectTimeViewImage.fillAmount = IMAGE_SHOW_VALUE;
            effectTimeViewImage.material = collectibleItemConfiguration.ItemUIImageMaterial;
            if (collectibleItemConfiguration.CollectibleItemBehaviour is ITimedCommand timedCommand)
                StartCoroutine(DrainEffectTimeViewImage(timedCommand.Duration));
            else
                StartCoroutine(ShowEffectTimeViewImage(1.0f));

        }

        public void SetPlayerSpeedText(float playerSpeed)
        {

            playerSpeedText.text = playerSpeed.ToString();

        }



        private IEnumerator DrainEffectTimeViewImage(float fillDuration)
        {

            effectTimeViewImage.fillAmount = IMAGE_SHOW_VALUE;
            float initialFillAmount = effectTimeViewImage.fillAmount;
            float elapsedTime = 0f;

            while (elapsedTime < fillDuration)
            {
                elapsedTime += Time.deltaTime;
                float time = Mathf.Clamp01(elapsedTime / fillDuration);
                effectTimeViewImage.fillAmount = Mathf.Lerp(initialFillAmount, 0, time);
                yield return null;
            }

            effectTimeViewImage.fillAmount = IMAGE_HIDE_VALUE;

        }

        private IEnumerator ShowEffectTimeViewImage(float duration)
        {

            effectTimeViewImage.fillAmount = IMAGE_SHOW_VALUE;
            yield return new WaitForSeconds(duration);
            effectTimeViewImage.fillAmount = IMAGE_HIDE_VALUE;

        }


    }

}