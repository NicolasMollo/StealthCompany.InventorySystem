using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewLab.Unity.SDK.Core.Systems.Controllers.FadeableElements
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(Renderer))]
    public class FadeableItem : MonoBehaviour
    {

        [SerializeField]
        private Renderer m_renderer = null;

        [SerializeField]
        [Range(0.0f, 10.0f)]
        private float fadeInDelay = 0.0f;

        [SerializeField]
        [Range(0.0f, 10.0f)]
        private float fadeOutDelay = 0.0f;

        private const float FADE_OFFSET = 0.01f;

        public Action<FadeableItem> OnFadedIn = null;
        public Action<FadeableItem> OnFadedOut = null;


        #region API

        /// <summary>
        /// Method that deals with the gradual increase (from 0 to 255) of the alpha channel of the item's material albedo.
        /// </summary>
        public void FadeIn(float delay = default)
        {

            float selectedDelay = delay > 0.0f ? delay : fadeInDelay;
            StartCoroutine(InternalFadeIn(selectedDelay));

        }

        /// <summary>
        /// Method that deals with the gradual decrease (from 255 to 0) of the alpha channel of the item's material albedo.
        /// </summary>
        public void FadeOut(float delay = default)
        {

            float selectedDelay = delay > 0.0f ? delay : fadeOutDelay;
            StartCoroutine(InternalFadeOut(selectedDelay));

        }

        #endregion

        #region Internal methods

        private IEnumerator InternalFadeIn(float delay)
        {

            Color fadeColor = m_renderer.material.color;
            while (fadeColor.a < 1.0f)
            {
                fadeColor.a += FADE_OFFSET;
                m_renderer.material.color = fadeColor;
                yield return new WaitForSeconds(delay);
            }

            OnFadedIn?.Invoke(this);

        }

        private IEnumerator InternalFadeOut(float delay)
        {

            Color fadeColor = m_renderer.material.color;
            while (fadeColor.a > 0.0f)
            {
                fadeColor.a -= FADE_OFFSET;
                m_renderer.material.color = fadeColor;
                yield return new WaitForSeconds(delay);
            }

            OnFadedOut?.Invoke(this);

        }

        #endregion

    }

}