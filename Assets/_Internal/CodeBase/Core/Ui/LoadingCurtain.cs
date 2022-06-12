using System.Collections;
using UnityEngine;

namespace _Internal.CodeBase.Core.Ui
{
    public class LoadingCurtain : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _curtainCanvasGroup;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _curtainCanvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }

        private IEnumerator FadeIn()
        {
            while (_curtainCanvasGroup.alpha > 0)
            {
                _curtainCanvasGroup.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }

            gameObject.SetActive(false);
        }
    }
}