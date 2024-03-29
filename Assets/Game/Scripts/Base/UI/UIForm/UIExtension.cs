//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using GameFramework.UI;
using System.Collections;
using UnityEditor.SceneTemplate;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Game
{
    public static class UIExtension
    {
        private static Transform m_InstanceRoot;
        public static Transform InstanceRoot
        {
            get
            {
                if (m_InstanceRoot == null)
                {
                    m_InstanceRoot = GameEntry.UI.transform.Find("UI Form Instances");
                }
                return m_InstanceRoot;
            }
        }

        private static IUIManager m_UIManager;
        public static IUIManager UIManager
        {
            get
            {
                if (m_UIManager == null)
                {
                    m_UIManager = GameFrameworkEntry.GetModule<IUIManager>();
                }
                return m_UIManager;
            }
        }

        public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup, float alpha, float duration)
        {
            float time = 0f;
            float originalAlpha = canvasGroup.alpha;
            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }

        public static IEnumerator SmoothValue(this Slider slider, float value, float duration)
        {
            float time = 0f;
            float originalValue = slider.value;
            while (time < duration)
            {
                time += Time.deltaTime;
                slider.value = Mathf.Lerp(originalValue, value, time / duration);
                yield return new WaitForEndOfFrame();
            }

            slider.value = value;
        }

        public static void OpenUIInitForm(this UIComponent uiComponent)
        {
            var initForm = InstanceRoot.Find("UIInitForm");
            if (initForm != null)
            {
                initForm.gameObject.SetActive(true);
            }
        }



    }
}
