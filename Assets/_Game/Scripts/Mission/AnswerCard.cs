using UnityEngine;
using SummaRace.Core;

namespace SummaRace.Mission
{
    /// <summary>
    /// Answer card that player can collect. Can be correct or wrong.
    /// </summary>
    public class AnswerCard : Collectible
    {
        [Header("Answer Settings")]
        [SerializeField] private bool _isCorrect;
        [SerializeField] private string _answerText;

        [Header("Visual")]
        [SerializeField] private Renderer _cardRenderer;
        [SerializeField] private Color _correctColor = Color.green;
        [SerializeField] private Color _wrongColor = Color.red;
        [SerializeField] private bool _showColorHint = false; // For debugging

        public bool IsCorrect => _isCorrect;
        public string AnswerText => _answerText;

        protected override void Start()
        {
            base.Start();
            _collectibleType = _isCorrect ? "CorrectAnswer" : "WrongAnswer";

            if (_showColorHint && _cardRenderer != null)
            {
                _cardRenderer.material.color = _isCorrect ? _correctColor : _wrongColor;
            }
        }

        protected override void OnCollected()
        {
            // Trigger answer event
            if (EventBus.Instance != null)
            {
                EventBus.Instance.TriggerAnswerCardCollected(_isCorrect);
            }

            // Play appropriate sound
            if (AudioManager.Instance != null)
            {
                if (_isCorrect)
                    AudioManager.Instance.PlayCorrect();
                else
                    AudioManager.Instance.PlayWrong();
            }

            Debug.Log($"[AnswerCard] Collected {(_isCorrect ? "CORRECT" : "WRONG")} answer: {_answerText}");
        }

        /// <summary>
        /// Set up the answer card data
        /// </summary>
        public void Setup(string text, bool isCorrect)
        {
            _answerText = text;
            _isCorrect = isCorrect;
            _collectibleType = isCorrect ? "CorrectAnswer" : "WrongAnswer";
        }
    }
}
