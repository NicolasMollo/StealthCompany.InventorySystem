using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using NewLab.Unity.SDK.Core.Modules;
using NewLab.Unity.SDK.Core.Systems.Controllers;


namespace InventorySystem.Systems.UI.HealthBar
{

    #region HealthBarColors public struct

    [Serializable]
    public struct HealthBarColors
    {

        [SerializeField]
        private Color _fullHpColor;
        public Color FullHpColor
        {
            get => _fullHpColor;
        }

        [SerializeField]
        private Color _averageHpColor;
        public Color AverageHpColor
        {
            get => _averageHpColor;
        }

        [SerializeField]
        private Color _quarterHpColor;
        public Color QuarterHpColor
        {
            get => _quarterHpColor;
        }

    }

    #endregion

    public class UI_HealthBarController : BaseController
    {

        [SerializeField]
        [Tooltip("Object that will be updated on the X-axis")]
        private RectTransform healthBarTransform = null;

        [SerializeField]
        [Tooltip("Image component of healt bar object")]
        private Image healthBarImage = null;

        [SerializeField]
        [Tooltip("Healrh bar colors")]
        private HealthBarColors healthBarColors = default;

        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float smoothTime = 0.2f;

        private Vector3 startScale = Vector3.zero;


        #region API

        /// <summary>
        /// Method that sets the health bar controller.
        /// </summary>
        public override void SetUp()
        {

            startScale = healthBarTransform.localScale;

        }

        /// <summary>
        /// Method that updates the health bar.
        /// </summary>
        /// <param name="healthModule"></param>
        public void UpdateHealthBar(Std_HealthModule healthModule)
        {

            float scaleX = healthModule.CurrentHealth / healthModule.MaxHealth;
            StartCoroutine(SetHealthBarScaleX(scaleX));

        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method that sets the health bar X scale smoothly.
        /// </summary>
        /// <param name="targetScaleX"></param>
        /// <returns></returns>
        private IEnumerator SetHealthBarScaleX(float targetScaleX)
        {

            Vector3 initialScale = healthBarTransform.localScale;
            Vector3 targetScale = new Vector3(targetScaleX, initialScale.y, initialScale.z);
            float elapsedTime = 0f;

            while (elapsedTime < smoothTime)
            {
                elapsedTime += Time.deltaTime;
                healthBarTransform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / smoothTime);
                SetHealthBarColor(healthBarTransform.localScale.x, healthBarColors);
                yield return null;
            }

            healthBarTransform.localScale = targetScale;
            SetHealthBarColor(healthBarTransform.localScale.x, healthBarColors);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentScaleX"></param>
        /// <param name="healthBarColors"></param>
        private void SetHealthBarColor(float currentScaleX, HealthBarColors healthBarColors)
        {

            float averageHealthOffset = startScale.x * 0.5f;
            float quarterLifeOffset = startScale.x * 0.25f;

            if (currentScaleX > averageHealthOffset)
                healthBarImage.color = healthBarColors.FullHpColor;
            else if (currentScaleX <= averageHealthOffset && currentScaleX >= quarterLifeOffset)
                healthBarImage.color = healthBarColors.AverageHpColor;
            else
                healthBarImage.color = healthBarColors.QuarterHpColor;

        }

        #endregion

    }

}