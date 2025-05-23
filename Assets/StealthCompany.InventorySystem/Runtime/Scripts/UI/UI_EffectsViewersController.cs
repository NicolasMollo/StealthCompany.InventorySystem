using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using InventorySystem.ScriptableObjects.Commands;
using InventorySystem.Systems.Controllers.Items.Collectibles;


namespace InventorySystem.Systems.UI.EffectViewers
{

    [DisallowMultipleComponent]
    public class UI_EffectsViewersController : BaseController
    {

        [SerializeField]
        [Tooltip("Effect time view image")]
        private Image effectTimeViewImage = null;

        [SerializeField]
        [Tooltip("Player speed text")]
        private TextMeshProUGUI playerSpeedText = null;

        private const float IMAGE_SHOW_VALUE = 1.0f;
        private const float IMAGE_HIDE_VALUE = 0.0f;


        #region API

        /// <summary>
        /// Method that sets the effect time view image.
        /// </summary>
        /// <param name="collectibleItemConfiguration"></param>
        public void SetEffectTimeViewImage(CollectibleItemConfiguration collectibleItemConfiguration)
        {

            if (collectibleItemConfiguration.ItemCommandBehaviour is ITimedCommand timedCommand)
                StartCoroutine(DrainEffectTimeViewImage(timedCommand.Duration, collectibleItemConfiguration.ItemUIImageMaterial));
            else
                StartCoroutine(ShowEffectTimeViewImage(IMAGE_SHOW_VALUE, collectibleItemConfiguration.ItemUIImageMaterial));

        }

        /// <summary>
        /// Method that sets the player speed text.
        /// </summary>
        /// <param name="playerSpeed"></param>
        public void SetPlayerSpeedText(float playerSpeed)
        {

            playerSpeedText.text = playerSpeed.ToString();

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method that gradually decreases the "fillAmount" value of the image.
        /// </summary>
        /// <param name="drainDuration"></param>
        /// <returns></returns>
        private IEnumerator DrainEffectTimeViewImage(float drainDuration, Material material)
        {

            effectTimeViewImage.material = material;
            effectTimeViewImage.fillAmount = IMAGE_SHOW_VALUE;
            float initialFillAmount = effectTimeViewImage.fillAmount;
            float elapsedTime = 0f;

            while (elapsedTime < drainDuration)
            {
                elapsedTime += Time.deltaTime;
                float time = Mathf.Clamp01(elapsedTime / drainDuration);
                effectTimeViewImage.fillAmount = Mathf.Lerp(initialFillAmount, 0, time);
                yield return null;
            }

            effectTimeViewImage.fillAmount = IMAGE_HIDE_VALUE;

        }

        /// <summary>
        /// Method that temporarily displays the image.
        /// </summary>
        /// <param name="duration"></param>
        /// <returns></returns>
        private IEnumerator ShowEffectTimeViewImage(float duration, Material material)
        {

            Material previousMaterial = effectTimeViewImage.material;
            effectTimeViewImage.material = material;
            effectTimeViewImage.fillAmount = IMAGE_SHOW_VALUE;
            yield return new WaitForSeconds(duration);
            effectTimeViewImage.fillAmount = IMAGE_HIDE_VALUE;
            effectTimeViewImage.material = previousMaterial;

        }

        #endregion

    }

}