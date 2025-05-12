using UnityEngine;
using System.Collections;
using NewLab.Unity.SDK.Core.Modules;
using NewLab.Unity.SDK.Core.Systems.Controllers;
using Sirenix.OdinInspector;
using UnityEngine.UI;
using System;


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

        [Range(0.0f, 1.0f)]
        public float smoothTime = 0.2f;

        [SerializeField]
        private Image image = null;

        private Vector3 startScale = Vector3.zero;

        [SerializeField]
        private HealthBarColors healthBarColors = default;



        public override void SetUp()
        {

            startScale = healthBarTransform.localScale;

        }

        public void UpdateHealthBar(Std_HealthModule healthModule)
        {

            float scaleX = healthModule.CurrentHealth / healthModule.MaxHealth;
            StartCoroutine(SetHealthBarScaleX(scaleX));

        }

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

        private void SetHealthBarColor(float currentScaleX, HealthBarColors healthBarColors)
        {

            float averageHealthOffset = startScale.x * 0.5f;
            float quarterLifeOffset = startScale.x * 0.25f;

            if (currentScaleX > averageHealthOffset)
                image.color = healthBarColors.FullHpColor;
            else if (currentScaleX <= averageHealthOffset && currentScaleX >= quarterLifeOffset)
                image.color = healthBarColors.AverageHpColor;
            else
                image.color = healthBarColors.QuarterHpColor;

        }

    }

}