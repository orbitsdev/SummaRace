using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SummaRace.Core;
using SummaRace.Mission;

namespace SummaRace.UI
{
    /// <summary>
    /// UI controller for the mission scene.
    /// Shows danger meter, question text, and feedback.
    /// </summary>
    public class MissionUI : MonoBehaviour
    {
        [Header("Danger Meter")]
        [SerializeField] private Slider _dangerSlider;
        [SerializeField] private Image _dangerFill;
        [SerializeField] private Gradient _dangerGradient;

        [Header("Question Display")]
        [SerializeField] private GameObject _questionPanel;
        [SerializeField] private TextMeshProUGUI _questionText;
        [SerializeField] private float _questionDisplayTime = 3f;

        [Header("Feedback")]
        [SerializeField] private TextMeshProUGUI _feedbackText;
        [SerializeField] private float _feedbackDisplayTime = 1.5f;

        [Header("Game Over")]
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _gameOverText;

        private void Start()
        {
            // Initialize UI
            if (_questionPanel != null)
                _questionPanel.SetActive(false);

            if (_gameOverPanel != null)
                _gameOverPanel.SetActive(false);

            if (_feedbackText != null)
                _feedbackText.gameObject.SetActive(false);

            // Subscribe to events
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnDangerLevelChanged += UpdateDangerMeter;
                EventBus.Instance.OnShowMessage += ShowQuestion;
                EventBus.Instance.OnAnswerCardCollected += ShowFeedback;
                EventBus.Instance.OnPlayerCaught += ShowGameOver;
            }

            // Initialize danger meter
            if (DangerLevel.Instance != null)
            {
                UpdateDangerMeter(DangerLevel.Instance.CurrentLevel);
            }
        }

        private void OnDestroy()
        {
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnDangerLevelChanged -= UpdateDangerMeter;
                EventBus.Instance.OnShowMessage -= ShowQuestion;
                EventBus.Instance.OnAnswerCardCollected -= ShowFeedback;
                EventBus.Instance.OnPlayerCaught -= ShowGameOver;
            }
        }

        private void UpdateDangerMeter(int level)
        {
            if (_dangerSlider == null) return;

            float normalized = level / 100f;
            _dangerSlider.value = normalized;

            // Update color based on danger
            if (_dangerFill != null && _dangerGradient != null)
            {
                _dangerFill.color = _dangerGradient.Evaluate(normalized);
            }
        }

        private void ShowQuestion(string text)
        {
            if (_questionPanel == null || _questionText == null) return;

            _questionText.text = text;
            _questionPanel.SetActive(true);

            CancelInvoke(nameof(HideQuestion));
            Invoke(nameof(HideQuestion), _questionDisplayTime);
        }

        private void HideQuestion()
        {
            if (_questionPanel != null)
                _questionPanel.SetActive(false);
        }

        private void ShowFeedback(bool isCorrect)
        {
            if (_feedbackText == null) return;

            _feedbackText.text = isCorrect ? "Correct!" : "Wrong!";
            _feedbackText.color = isCorrect ? Color.green : Color.red;
            _feedbackText.gameObject.SetActive(true);

            CancelInvoke(nameof(HideFeedback));
            Invoke(nameof(HideFeedback), _feedbackDisplayTime);
        }

        private void HideFeedback()
        {
            if (_feedbackText != null)
                _feedbackText.gameObject.SetActive(false);
        }

        private void ShowGameOver()
        {
            if (_gameOverPanel == null) return;

            _gameOverPanel.SetActive(true);

            if (_gameOverText != null)
                _gameOverText.text = "Caught by Snow Patrol!";
        }
    }
}
