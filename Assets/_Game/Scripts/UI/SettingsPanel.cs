using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using SummaRace.Core;

namespace SummaRace.UI
{
    public class SettingsPanel : MonoBehaviour
    {
        [Header("Panel")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Button _closeButton;

        [Header("Sliders")]
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;

        [Header("Narration")]
        [SerializeField] private Toggle _narrationToggle;

        [Header("Quit")]
        [SerializeField] private Button _quitButton;

        [Header("Animation")]
        [SerializeField] private float _fadeDuration = 0.25f;

        private Coroutine _fadeCoroutine;

        void Awake()
        {
            if (_canvasGroup == null)
                _canvasGroup = GetComponent<CanvasGroup>();
        }

        void Start()
        {
            if (_closeButton != null)
                _closeButton.onClick.AddListener(Hide);

            if (_musicSlider != null)
                _musicSlider.onValueChanged.AddListener(OnMusicChanged);

            if (_sfxSlider != null)
                _sfxSlider.onValueChanged.AddListener(OnSFXChanged);

            if (_narrationToggle != null)
                _narrationToggle.onValueChanged.AddListener(OnNarrationChanged);

            if (_quitButton != null)
                _quitButton.onClick.AddListener(HandleQuit);
        }

        private void HandleQuit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        public void Show()
        {
            gameObject.SetActive(true);

            if (_canvasGroup == null)
                _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            LoadSettings();

            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
            _fadeCoroutine = StartCoroutine(FadeTo(1f));
        }

        public void Hide()
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayButtonClick();

            if (_fadeCoroutine != null) StopCoroutine(_fadeCoroutine);
            _fadeCoroutine = StartCoroutine(FadeOut());
        }

        private void LoadSettings()
        {
            float music = PlayerPrefs.GetFloat("musicVolume", 1f);
            float sfx = PlayerPrefs.GetFloat("sfxVolume", 1f);
            bool narration = PlayerPrefs.GetInt("narrationEnabled", 1) == 1;

            if (_musicSlider != null) _musicSlider.SetValueWithoutNotify(music);
            if (_sfxSlider != null) _sfxSlider.SetValueWithoutNotify(sfx);
            if (_narrationToggle != null) _narrationToggle.SetIsOnWithoutNotify(narration);
        }

        private void OnMusicChanged(float value)
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.SetMusicVolume(value);
        }

        private void OnSFXChanged(float value)
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.SetSFXVolume(value);
        }

        private void OnNarrationChanged(bool enabled)
        {
            if (SaveManager.Instance != null)
                SaveManager.Instance.SetNarrationEnabled(enabled);
        }

        private IEnumerator FadeTo(float target)
        {
            float start = _canvasGroup.alpha;
            float elapsed = 0f;

            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;

            while (elapsed < _fadeDuration)
            {
                elapsed += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(start, target, elapsed / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = target;
        }

        private IEnumerator FadeOut()
        {
            float start = _canvasGroup.alpha;
            float elapsed = 0f;

            _canvasGroup.interactable = false;

            while (elapsed < _fadeDuration)
            {
                elapsed += Time.deltaTime;
                _canvasGroup.alpha = Mathf.Lerp(start, 0f, elapsed / _fadeDuration);
                yield return null;
            }
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = false;
            gameObject.SetActive(false);
        }
    }
}
