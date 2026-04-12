using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using SummaRace.Core;

namespace SummaRace.UI
{
    public class LevelSelectController : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private CanvasGroup _fadeOverlay;

        [Header("Story Cards")]
        [SerializeField] private StoryCardUI[] _storyCards;

        [Header("Story Info")]
        [SerializeField] private string[] _storyTitles = { "Max the Puppy", "The Lost Kitten", "Brave Little Fox" };
        [SerializeField] private string[] _storyDifficulties = { "Easy", "Medium", "Hard" };
        [SerializeField] private Color[] _cardAccentColors = {
            new Color(0.26f, 0.65f, 0.96f),  // Sky blue
            new Color(0.40f, 0.73f, 0.42f),  // Green
            new Color(0.94f, 0.60f, 0.22f)   // Orange
        };

        [Header("Colors")]
        [SerializeField] private Color _lockedOverlayColor = new Color(0f, 0f, 0f, 0.6f);
        [SerializeField] private Color _starFilledColor = new Color(1f, 0.843f, 0f);    // Gold
        [SerializeField] private Color _starEmptyColor = new Color(0.690f, 0.745f, 0.773f); // Gray

        [Header("Next Scene")]
        [SerializeField] private string _nextSceneName = "04_StoryReader";

        private bool _isTransitioning;

        void Start()
        {
            string playerName = PlayerPrefs.GetString("playerName", "Explorer");
            if (_playerNameText != null)
                _playerNameText.text = $"Hi, {playerName}!";

            SetupCards();

            if (_fadeOverlay != null)
            {
                _fadeOverlay.alpha = 1f;
                StartCoroutine(AnimateFade(1f, 0f, 0.5f));
            }
        }

        private void SetupCards()
        {
            bool[] levelsUnlocked = { true, false, false };
            int[] starsPerLevel = new int[3];

            if (GameManager.Instance != null)
            {
                levelsUnlocked = GameManager.Instance.levelsUnlocked;
                starsPerLevel = GameManager.Instance.starsPerLevel;
            }

            for (int i = 0; i < _storyCards.Length && i < 3; i++)
            {
                StoryCardUI card = _storyCards[i];
                if (card == null) continue;

                int levelIndex = i;
                bool unlocked = levelsUnlocked[i];
                int stars = starsPerLevel[i];

                card.Setup(
                    _storyTitles[i],
                    _storyDifficulties[i],
                    _cardAccentColors[i],
                    unlocked,
                    stars,
                    _starFilledColor,
                    _starEmptyColor,
                    _lockedOverlayColor
                );

                if (card.cardButton != null)
                {
                    card.cardButton.onClick.RemoveAllListeners();
                    card.cardButton.onClick.AddListener(() => HandleCardClicked(levelIndex));
                }
            }
        }

        private void HandleCardClicked(int levelIndex)
        {
            if (_isTransitioning) return;

            bool[] levelsUnlocked = { true, false, false };
            if (GameManager.Instance != null)
                levelsUnlocked = GameManager.Instance.levelsUnlocked;

            if (!levelsUnlocked[levelIndex])
                return;

            if (GameManager.Instance != null)
                GameManager.Instance.SelectLevel(levelIndex + 1);

            _isTransitioning = true;
            StartCoroutine(DoTransitionOut());
        }

        private IEnumerator DoTransitionOut()
        {
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

    [System.Serializable]
    public class StoryCardUI
    {
        public Button cardButton;
        public Image cardBackground;
        public Image storyThumbnail;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI difficultyText;
        public Image[] starIcons;
        public GameObject lockOverlay;

        public void Setup(
            string title,
            string difficulty,
            Color accentColor,
            bool unlocked,
            int stars,
            Color starFilledColor,
            Color starEmptyColor,
            Color lockedOverlayColor)
        {
            if (titleText != null)
                titleText.text = title;

            if (difficultyText != null)
                difficultyText.text = difficulty;

            if (cardBackground != null)
                cardBackground.color = unlocked ? accentColor : new Color(0.5f, 0.5f, 0.5f);

            if (lockOverlay != null)
                lockOverlay.SetActive(!unlocked);

            if (cardButton != null)
                cardButton.interactable = unlocked;

            for (int i = 0; i < starIcons.Length && i < 3; i++)
            {
                if (starIcons[i] != null)
                    starIcons[i].color = i < stars ? starFilledColor : starEmptyColor;
            }
        }
    }
}
