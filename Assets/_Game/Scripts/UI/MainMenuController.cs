using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using SummaRace.Core;

namespace SummaRace.UI
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _settingsButton;

        [Header("UI")]
        [SerializeField] private CanvasGroup _fadeOverlay;

        [Header("Settings Panel")]
        [SerializeField] private SettingsPanel _settingsPanel;

        [Header("Scene Transitions")]
        [SerializeField] private string _playScene = "01_NameEntry";
        [SerializeField] private string _continueScene = "03_LevelSelect";

        private bool _isTransitioning;
        private Coroutine _pulseCoroutine;

        void Start()
        {
            if (_playButton != null)
            {
                _playButton.onClick.AddListener(HandlePlay);
                _pulseCoroutine = StartCoroutine(PulseButton(_playButton.transform));
            }
            if (_continueButton != null)
                _continueButton.onClick.AddListener(HandleContinue);
            if (_settingsButton != null)
                _settingsButton.onClick.AddListener(HandleSettings);

            UpdateContinueButton();

            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayMenuMusic();

            if (_fadeOverlay != null)
            {
                _fadeOverlay.alpha = 1f;
                StartCoroutine(AnimateFade(1f, 0f, 0.5f));
            }
        }

        private void UpdateContinueButton()
        {
            bool hasSave = PlayerPrefs.HasKey("playerName") &&
                           !string.IsNullOrEmpty(PlayerPrefs.GetString("playerName"));

            if (_continueButton != null)
                _continueButton.gameObject.SetActive(hasSave);
        }

        private void HandlePlay()
        {
            if (_isTransitioning) return;
            PlayClickSound();
            _isTransitioning = true;
            if (_pulseCoroutine != null) StopCoroutine(_pulseCoroutine);
            StartCoroutine(TransitionTo(_playScene));
        }

        private void HandleContinue()
        {
            if (_isTransitioning) return;
            PlayClickSound();
            _isTransitioning = true;
            if (_pulseCoroutine != null) StopCoroutine(_pulseCoroutine);
            StartCoroutine(TransitionTo(_continueScene));
        }

        private void HandleSettings()
        {
            PlayClickSound();
            if (_settingsPanel != null)
                _settingsPanel.Show();
        }

        private void PlayClickSound()
        {
            if (AudioManager.Instance != null)
                AudioManager.Instance.PlayButtonClick();
        }

        private IEnumerator PulseButton(Transform btn)
        {
            while (true)
            {
                float elapsed = 0f;
                float duration = 1.5f;
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    float t = elapsed / duration;
                    float scale = 1f + 0.06f * Mathf.Sin(t * Mathf.PI);
                    btn.localScale = Vector3.one * scale;
                    yield return null;
                }
                btn.localScale = Vector3.one;
            }
        }

        private IEnumerator TransitionTo(string sceneName)
        {
            if (_fadeOverlay != null)
            {
                _fadeOverlay.blocksRaycasts = true;
                yield return StartCoroutine(AnimateFade(0f, 1f, 0.3f));
            }
            SceneManager.LoadScene(sceneName);
        }

        private IEnumerator AnimateFade(float from, float to, float duration)
        {
            if (_fadeOverlay == null) yield break;
            _fadeOverlay.alpha = from;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                _fadeOverlay.alpha = Mathf.Lerp(from, to, elapsed / duration);
                yield return null;
            }
            _fadeOverlay.alpha = to;
            _fadeOverlay.blocksRaycasts = to > 0.5f;
        }
    }
}
