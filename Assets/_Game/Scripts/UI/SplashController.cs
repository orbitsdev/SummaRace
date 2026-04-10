using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

namespace SummaRace.UI
{
    public class SplashController : MonoBehaviour
    {
        [Header("Visual References")]
        [SerializeField] private CanvasGroup _backgroundGroup;
        [SerializeField] private Image _logoImage;
        [SerializeField] private CanvasGroup _fadeOverlay;

        [Header("Progress Bar")]
        [SerializeField] private Image _progressBarFill;
        [SerializeField] private TextMeshProUGUI _percentageText;
        [SerializeField] private GameObject _loadingGroup;
        [SerializeField] private TextMeshProUGUI _loadingLabel;

        [Header("Audio")]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private AudioClip _splashJingle;
        [SerializeField] private AudioClip _logoSound;
        [SerializeField] private AudioClip _whooshSound;

        [Header("Timing")]
        [SerializeField] private float _totalDuration = 20.0f;
        [SerializeField] private float _fadeOutDuration = 0.5f;

        [Header("Next Scene")]
        [SerializeField] private string _nextSceneName = "01_NameEntry";

        private bool _skipRequested;
        private AsyncOperation _preloadOperation;
        private float _progress;

        void Start()
        {
            bool isFirstLaunch = !PlayerPrefs.HasKey("hasLaunchedBefore");
            if (isFirstLaunch)
            {
                PlayerPrefs.SetInt("hasLaunchedBefore", 1);
                PlayerPrefs.Save();
            }

            // Hide everything initially
            SetAlpha(_backgroundGroup, 0f);
            SetImageAlpha(_logoImage, 0f);
            if (_logoImage != null)
                _logoImage.rectTransform.localScale = Vector3.zero;
            if (_progressBarFill != null) _progressBarFill.fillAmount = 0f;
            SetTextAlpha(_percentageText, 0f);
            SetTextAlpha(_loadingLabel, 0f);
            if (_fadeOverlay != null) _fadeOverlay.alpha = 0f;

            StartCoroutine(SplashSequence());
            StartCoroutine(PreloadNextScene());
        }

        void Update()
        {
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
                _skipRequested = true;
            else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
                _skipRequested = true;
        }

        private IEnumerator SplashSequence()
        {
            // 1. Background fade in (0.5s)
            yield return StartCoroutine(FadeCanvasGroup(_backgroundGroup, 0f, 1f, 0.5f));

            // 2. Logo bounces in with scale animation (0.6s)
            if (_musicSource != null && _splashJingle != null)
            {
                _musicSource.clip = _splashJingle;
                _musicSource.volume = 0.6f;
                _musicSource.Play();
            }

            if (_logoSound != null && _sfxSource != null)
                _sfxSource.PlayOneShot(_logoSound, 0.8f);

            if (_logoImage != null)
            {
                StartCoroutine(ScaleIn(_logoImage.rectTransform, 0.6f));
                StartCoroutine(FadeImageIn(_logoImage, 0.4f));
            }

            yield return new WaitForSeconds(1.0f);

            // 3. Loading label + progress bar appear
            StartCoroutine(FadeTextIn(_loadingLabel, 0.3f));
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(FadeTextIn(_percentageText, 0.3f));

            // 4. Progress bar fills over remaining time
            float animDuration = _totalDuration - 2.2f - _fadeOutDuration;
            if (animDuration < 1f) animDuration = 1f;

            float elapsed = 0f;
            while (elapsed < animDuration)
            {
                if (_skipRequested) break;
                elapsed += Time.deltaTime;
                _progress = Mathf.Clamp01(elapsed / animDuration);

                if (_progressBarFill != null)
                    _progressBarFill.fillAmount = _progress;

                if (_percentageText != null)
                    _percentageText.text = Mathf.RoundToInt(_progress * 100f) + "%";

                yield return null;
            }

            // Ensure 100%
            if (_progressBarFill != null) _progressBarFill.fillAmount = 1f;
            if (_percentageText != null) _percentageText.text = "100%";

            yield return new WaitForSeconds(0.3f);

            yield return StartCoroutine(TransitionOut());
        }

        private IEnumerator TransitionOut()
        {
            if (_whooshSound != null && _sfxSource != null)
                _sfxSource.PlayOneShot(_whooshSound, 0.5f);

            if (_fadeOverlay != null)
                yield return StartCoroutine(FadeCanvasGroup(_fadeOverlay, 0f, 1f, _fadeOutDuration));
            else
                yield return new WaitForSeconds(_fadeOutDuration);

            if (_preloadOperation != null)
                _preloadOperation.allowSceneActivation = true;
            else
                SceneManager.LoadScene(_nextSceneName);
        }

        private IEnumerator PreloadNextScene()
        {
            yield return new WaitForSeconds(0.5f);
            _preloadOperation = SceneManager.LoadSceneAsync(_nextSceneName);
            if (_preloadOperation != null)
                _preloadOperation.allowSceneActivation = false;
        }

        // --- Animation Helpers ---

        private IEnumerator FadeCanvasGroup(CanvasGroup group, float from, float to, float duration)
        {
            if (group == null) yield break;
            group.alpha = from;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                group.alpha = Mathf.Lerp(from, to, elapsed / duration);
                yield return null;
            }
            group.alpha = to;
        }

        private IEnumerator FadeTextIn(TextMeshProUGUI text, float duration)
        {
            if (text == null) yield break;
            Color c = text.color;
            c.a = 0f;
            text.color = c;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                c.a = Mathf.Lerp(0f, 1f, elapsed / duration);
                text.color = c;
                yield return null;
            }
            c.a = 1f;
            text.color = c;
        }

        private IEnumerator FadeImageIn(Image img, float duration)
        {
            if (img == null) yield break;
            Color c = img.color;
            c.a = 0f;
            img.color = c;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                c.a = Mathf.Lerp(0f, 1f, elapsed / duration);
                img.color = c;
                yield return null;
            }
            c.a = 1f;
            img.color = c;
        }

        private IEnumerator ScaleIn(RectTransform rt, float duration)
        {
            if (rt == null) yield break;
            rt.localScale = Vector3.zero;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / duration;
                float overshoot = 1.70158f;
                t = t - 1f;
                float scale = t * t * ((overshoot + 1f) * t + overshoot) + 1f;
                rt.localScale = Vector3.one * scale;
                yield return null;
            }
            rt.localScale = Vector3.one;
        }

        private void SetAlpha(CanvasGroup group, float alpha)
        {
            if (group != null) group.alpha = alpha;
        }

        private void SetImageAlpha(Image img, float alpha)
        {
            if (img == null) return;
            Color c = img.color;
            c.a = alpha;
            img.color = c;
        }

        private void SetTextAlpha(TextMeshProUGUI text, float alpha)
        {
            if (text == null) return;
            Color c = text.color;
            c.a = alpha;
            text.color = c;
        }
    }
}
