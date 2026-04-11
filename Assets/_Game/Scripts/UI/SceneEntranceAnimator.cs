using UnityEngine;
using System;
using System.Collections;

namespace SummaRace.UI
{
    public class SceneEntranceAnimator : MonoBehaviour
    {
        [Serializable]
        public class AnimatedElement
        {
            public RectTransform target;
            public AnimationType type = AnimationType.FadeAndScale;
            public float delay;
            public float duration = 0.4f;
        }

        public enum AnimationType
        {
            FadeAndScale,
            SlideDown,
            SlideUp,
            ScaleBounce,
            FadeOnly
        }

        [SerializeField] private AnimatedElement[] _elements;
        [SerializeField] private float _globalDelay = 0.3f;

        void Start()
        {
            foreach (var elem in _elements)
            {
                if (elem.target == null) continue;
                var cg = EnsureCanvasGroup(elem.target);
                cg.alpha = 0f;
                if (elem.type == AnimationType.ScaleBounce)
                    elem.target.localScale = Vector3.zero;
                else if (elem.type == AnimationType.FadeAndScale)
                    elem.target.localScale = Vector3.one * 0.8f;
            }

            StartCoroutine(PlayEntrance());
        }

        private IEnumerator PlayEntrance()
        {
            yield return new WaitForSeconds(_globalDelay);

            foreach (var elem in _elements)
            {
                if (elem.target == null) continue;
                if (elem.delay > 0f)
                    yield return new WaitForSeconds(elem.delay);

                StartCoroutine(AnimateElement(elem));
            }
        }

        private IEnumerator AnimateElement(AnimatedElement elem)
        {
            var cg = EnsureCanvasGroup(elem.target);
            float elapsed = 0f;
            float dur = elem.duration;

            Vector2 startPos = elem.target.anchoredPosition;
            Vector2 offsetPos = startPos;

            if (elem.type == AnimationType.SlideDown)
                offsetPos = startPos + new Vector2(0, 60f);
            else if (elem.type == AnimationType.SlideUp)
                offsetPos = startPos - new Vector2(0, 60f);

            if (elem.type == AnimationType.SlideDown || elem.type == AnimationType.SlideUp)
                elem.target.anchoredPosition = offsetPos;

            while (elapsed < dur)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / dur);

                float eased = EaseOutBack(t);

                cg.alpha = Mathf.Clamp01(t * 2f);

                switch (elem.type)
                {
                    case AnimationType.FadeAndScale:
                        float scale = Mathf.LerpUnclamped(0.8f, 1f, eased);
                        elem.target.localScale = Vector3.one * scale;
                        break;

                    case AnimationType.ScaleBounce:
                        float bounceScale = EaseBounceScale(t);
                        elem.target.localScale = Vector3.one * bounceScale;
                        break;

                    case AnimationType.SlideDown:
                    case AnimationType.SlideUp:
                        elem.target.anchoredPosition = Vector2.LerpUnclamped(offsetPos, startPos, eased);
                        break;

                    case AnimationType.FadeOnly:
                        break;
                }

                yield return null;
            }

            cg.alpha = 1f;
            elem.target.localScale = Vector3.one;
            if (elem.type == AnimationType.SlideDown || elem.type == AnimationType.SlideUp)
                elem.target.anchoredPosition = startPos;
        }

        private float EaseOutBack(float t)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1f;
            return 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
        }

        private float EaseBounceScale(float t)
        {
            if (t < 0.4f)
                return Mathf.Lerp(0f, 1.2f, t / 0.4f);
            else if (t < 0.7f)
                return Mathf.Lerp(1.2f, 0.95f, (t - 0.4f) / 0.3f);
            else
                return Mathf.Lerp(0.95f, 1f, (t - 0.7f) / 0.3f);
        }

        private CanvasGroup EnsureCanvasGroup(RectTransform rt)
        {
            var cg = rt.GetComponent<CanvasGroup>();
            if (cg == null)
                cg = rt.gameObject.AddComponent<CanvasGroup>();
            return cg;
        }
    }
}
