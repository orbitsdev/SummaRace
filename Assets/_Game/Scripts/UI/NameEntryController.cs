using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace SummaRace.UI
{
    public class NameEntryController : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Image _continueButtonBg;
        [SerializeField] private TextMeshProUGUI _validationMessage;
        [SerializeField] private CanvasGroup _fadeOverlay;

        [Header("Avatar Buttons")]
        [SerializeField] private AvatarButton[] _avatarButtons;

        [Header("Colors")]
        [SerializeField] private Color _buttonActiveColor = new Color(0.118f, 0.533f, 0.898f);   // #1E88E5
        [SerializeField] private Color _buttonDisabledColor = new Color(0.690f, 0.745f, 0.773f); // #B0BEC5

        [Header("Validation")]
        [SerializeField] private int _maxNameLength = 15;

        [Header("Next Scene")]
        [SerializeField] private string _nextSceneName = "02_TeacherWelcome";

        private int _selectedAvatarIndex;
        private bool _isTransitioning;
        private Coroutine _pulseCoroutine;

        void Start()
        {
            if (_nameInputField != null)
            {
                _nameInputField.characterLimit = _maxNameLength;
                _nameInputField.onValueChanged.AddListener(HandleNameChanged);
            }

            for (int i = 0; i < _avatarButtons.Length; i++)
            {
                _avatarButtons[i].Initialize();
                _avatarButtons[i].OnSelected += HandleAvatarSelected;
            }

            if (_continueButton != null)
                _continueButton.onClick.AddListener(HandleContinueClicked);

            if (_validationMessage != null)
                _validationMessage.gameObject.SetActive(false);

            _selectedAvatarIndex = PlayerPrefs.GetInt("selectedAvatar", 0);
            if (PlayerPrefs.HasKey("playerName") && _nameInputField != null)
                _nameInputField.text = PlayerPrefs.GetString("playerName", "");

            HandleAvatarSelected(_selectedAvatarIndex);
            UpdateButtonVisual();

            if (_fadeOverlay != null)
            {
                _fadeOverlay.alpha = 1f;
                StartCoroutine(AnimateFade(1f, 0f, 0.5f));
            }
        }

        private void HandleNameChanged(string text)
        {
            if (_validationMessage != null)
                _validationMessage.gameObject.SetActive(false);
            UpdateButtonVisual();
        }

        private void HandleAvatarSelected(int index)
        {
            _selectedAvatarIndex = index;
            for (int i = 0; i < _avatarButtons.Length; i++)
                _avatarButtons[i].SetSelected(i == index);
            UpdateButtonVisual();
        }

        private void HandleContinueClicked()
        {
            if (_isTransitioning) return;

            string playerName = _nameInputField != null ? _nameInputField.text.Trim() : "";
            if (string.IsNullOrEmpty(playerName))
            {
                if (_validationMessage != null)
                {
                    _validationMessage.text = "Please type your name first!";
                    _validationMessage.gameObject.SetActive(true);
                }
                return;
            }

            if (playerName.Length > 0)
                playerName = char.ToUpper(playerName[0]) + playerName.Substring(1);

            PlayerPrefs.SetString("playerName", playerName);
            PlayerPrefs.SetInt("selectedAvatar", _selectedAvatarIndex);
            PlayerPrefs.SetInt("hasCompletedNameEntry", 1);
            PlayerPrefs.Save();

            _isTransitioning = true;
            StartCoroutine(DoTransitionOut());
        }

        private void UpdateButtonVisual()
        {
            string text = _nameInputField != null ? _nameInputField.text.Trim() : "";
            bool canContinue = !string.IsNullOrEmpty(text);

            if (_continueButtonBg != null)
                _continueButtonBg.color = canContinue ? _buttonActiveColor : _buttonDisabledColor;
            if (_continueButton != null)
                _continueButton.interactable = canContinue;

            if (canContinue && _pulseCoroutine == null)
                _pulseCoroutine = StartCoroutine(PulseButton());
            else if (!canContinue && _pulseCoroutine != null)
            {
                StopCoroutine(_pulseCoroutine);
                _pulseCoroutine = null;
                if (_continueButton != null)
                    _continueButton.transform.localScale = Vector3.one;
            }
        }

        private IEnumerator PulseButton()
        {
            Transform btn = _continueButton.transform;
            while (true)
            {
                float elapsed = 0f;
                float duration = 1.5f;
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    float t = elapsed / duration;
                    float scale = 1f + 0.04f * Mathf.Sin(t * Mathf.PI);
                    btn.localScale = Vector3.one * scale;
                    yield return null;
                }
                btn.localScale = Vector3.one;
            }
        }

        private IEnumerator DoTransitionOut()
        {
            if (_pulseCoroutine != null)
            {
                StopCoroutine(_pulseCoroutine);
                _pulseCoroutine = null;
            }

            if (_fadeOverlay != null)
            {
                _fadeOverlay.blocksRaycasts = true;
                yield return StartCoroutine(AnimateFade(0f, 1f, 0.3f));
            }
            SceneManager.LoadScene(_nextSceneName);
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
