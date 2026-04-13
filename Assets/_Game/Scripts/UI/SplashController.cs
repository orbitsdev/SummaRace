using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;
using SummaRace.Core;

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

        [Header("Skip Indicator")]
        [SerializeField] private TextMeshProUGUI _skipText;
        [SerializeField] private CanvasGroup _skipGroup;
        [SerializeField] private float _skipAppearTime = 1.5f;

        [Header("Audio")]
        [SerializeField] private AudioSource _sfxSource;
        [SerializeField] private AudioClip _logoSound;
        [SerializeField] private AudioClip _whooshSound;

        [Header("Timing")]
        [SerializeField] private float _totalDuration = 2.5f;
        [SerializeField] private float _fadeOutDuration = 0.5f;

        [Header("Next Scene")]
        [SerializeField] private string _nextSceneName = "00_MainMenu";

        private bool _skipRequested;
        private bool _isTransitioning;
        private AsyncOperation _preloadOperation;
        private float _progress;
        private float _elapsedTime;

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

            // Hide skip indicator initially
            if (_skipGroup != null) _skipGroup.alpha = 0f;
            if (_skipText != null) SetTextAlpha(_skipText, 0f);

            StartCoroutine(SplashSequence());
            StartCoroutine(PreloadNextScene());
        }

        void Update()
        {
            _elapsedTime += Time.deltaTime;

            // Show skip indicator after delay
            if (_elapsedTime >= _skipAppearTime && !_isTransitioning)
            {
                ShowSkipIndicator();
            }

            bool inputDetected = false;
            if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
                inputDetected = true;
            else if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
                inputDetected = true;

            if (inputDetected && !_isTransitioning)
            {
                _skipRequested = true;
                ShowSkipFeedback();
            }
        }

        private void ShowSkipIndicator()
        {
            if (_skipGroup != null && _skipGroup.alpha < 1f)
            {
                _skipGroup.alpha = Mathf.MoveTowards(_skipGroup.alpha, 1f, Time.deltaTime * 3f);
            }
            else if (_skipText != null)
            {
                Color c = _skipText.color;
                if (c.a < 1f)
                {
                    c.a = Mathf.MoveTowards(c.a, 1f, Time.deltaTime * 3f);
                    _skipText.color = c;
                }
            }
        }

        private void ShowSkipFeedback()
        {
            // Brief visual feedback when skip is triggered
            if (_logoImage != null)
            {
                StartCoroutine(PulseScale(_logoImage.rectTransform, 1.05f, 0.1f));
            }
        }

        private IEnumerator PulseScale(RectTransform rt, float targetScale, float duration)
        {
            if (rt == null) yield break;

            Vector3 original = rt.localScale;
            Vector3 target = original * targetScale;

            float half = duration * 0.5f;
            float elapsed = 0f;

            // Scale up
            while (elapsed < half)
            {
                elapsed += Time.deltaTime;
                rt.localScale = Vector3.Lerp(original, target, elapsed / half);
                yield return null;
            }

            // Scale down
            elapsed = 0f;
            while (elapsed < half)
            {
                elapsed += Time.deltaTime;
                rt.localScale = Vector3.Lerp(target, original, elapsed / half);
                yield return null;
            }

            rt.localScale = original;
        }

        private IEnumerator SplashSequence()
        {
            // Timeline for 2.5s total:
            // 0.0s - 0.3s: Background fades in
            // 0.3s - 0.8s: Logo scales in with bounce + chime SFX
            // 0.8s - 1.0s: Loading text fades in
            // 1.0s - 2.0s: Progress bar fills
            // 2.0s - 2.5s: Transition out with whoosh

            // 1. Background fade in (0.3s)
            yield return StartCoroutine(FadeCanvasGroup(_backgroundGroup, 0f, 1f, 0.3f));

            // 2. Logo bounces in with scale animation (0.5s) + play chime
            PlaySFX(_logoSound);

            if (_logoImage != null)
            {
                StartCoroutine(ScaleIn(_logoImage.rectTransform, 0.5f));
                StartCoroutine(FadeImageIn(_logoImage, 0.3f));
            }

            yield return new WaitForSeconds(0.5f);

            // 3. Loading label + progress bar appear (0.2s)
            StartCoroutine(FadeTextIn(_loadingLabel, 0.2f));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(FadeTextIn(_percentageText, 0.2f));

            yield return new WaitForSeconds(0.1f);

            // 4. Progress bar fills (1.0s) - tied to actual preload when possible
            float progressDuration = 1.0f;
            float elapsed = 0f;

            while (elapsed < progressDuration)
            {
                if (_skipRequested) break;
                elapsed += Time.deltaTime;

                // Blend timer progress with real preload progress if available
                float timerProgress = Mathf.Clamp01(elapsed / progressDuration);
                float realProgress = _preloadOperation != null ? _preloadOperation.progress / 0.9f : 1f;

                // Use whichever is slower to avoid jarring jumps
                _progress = Mathf.Min(timerProgress, Mathf.Max(timerProgress * 0.5f, realProgress));

                if (_progressBarFill != null)
                    _progressBarFill.fillAmount = _progress;

                if (_percentageText != null)
                    _percentageText.text = Mathf.RoundToInt(_progress * 100f) + "%";

                yield return null;
            }

            // Ensure 100%
            if (_progressBarFill != null) _progressBarFill.fillAmount = 1f;
            if (_percentageText != null) _percentageText.text = "100%";

            yield return new WaitForSeconds(0.1f);

            yield return StartCoroutine(TransitionOut());
        }

        private void PlaySFX(AudioClip clip)
        {
            if (clip == null) return;

            // Prefer AudioManager if available (persists across scenes)
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(clip);
            }
            else if (_sfxSource != null)
            {
                // Fallback to local audio source
                _sfxSource.PlayOneShot(clip, 0.8f);
            }
        }

        private IEnumerator TransitionOut()
        {
            _isTransitioning = true;

            // Hide skip indicator
            if (_skipGroup != null) _skipGroup.alpha = 0f;
            if (_skipText != null) SetTextAlpha(_skipText, 0f);

            // Play whoosh sound
            PlaySFX(_whooshSound);

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
