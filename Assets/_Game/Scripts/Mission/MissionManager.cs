using UnityEngine;
using SummaRace.Core;
using SummaRace.Data;

namespace SummaRace.Mission
{
    /// <summary>
    /// Manages the overall mission flow - checkpoints, scoring, completion.
    /// </summary>
    public class MissionManager : MonoBehaviour
    {
        public static MissionManager Instance { get; private set; }

        [Header("Mission Settings")]
        [SerializeField] private int _totalCheckpoints = 5;

        [Header("Current Progress")]
        [SerializeField] private int _currentCheckpoint;
        [SerializeField] private int _correctAnswers;
        [SerializeField] private int _wrongAnswers;

        [Header("State")]
        [SerializeField] private bool _isMissionActive;
        [SerializeField] private bool _isMissionComplete;

        public int CurrentCheckpoint => _currentCheckpoint;
        public int CorrectAnswers => _correctAnswers;
        public int WrongAnswers => _wrongAnswers;
        public bool IsMissionActive => _isMissionActive;
        public bool IsMissionComplete => _isMissionComplete;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            // Subscribe to events
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnAnswerCardCollected += OnAnswerCollected;
            }

            // Auto-start mission for testing
            StartMission();
        }

        void OnDestroy()
        {
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnAnswerCardCollected -= OnAnswerCollected;
            }
        }

        public void StartMission()
        {
            _currentCheckpoint = 0;
            _correctAnswers = 0;
            _wrongAnswers = 0;
            _isMissionActive = true;
            _isMissionComplete = false;

            // Start danger system
            if (DangerLevel.Instance != null)
            {
                DangerLevel.Instance.StartDanger();
            }

            EventBus.Instance?.TriggerMissionStart();
            Debug.Log("[MissionManager] Mission started!");
        }

        private void OnAnswerCollected(bool isCorrect)
        {
            if (!_isMissionActive) return;

            _currentCheckpoint++;

            if (isCorrect)
            {
                _correctAnswers++;
                Debug.Log($"[MissionManager] Correct! ({_correctAnswers}/{_totalCheckpoints})");
            }
            else
            {
                _wrongAnswers++;
                Debug.Log($"[MissionManager] Wrong! ({_wrongAnswers} mistakes)");
            }

            // Check if mission complete
            if (_currentCheckpoint >= _totalCheckpoints)
            {
                CompleteMission();
            }
        }

        private void CompleteMission()
        {
            _isMissionActive = false;
            _isMissionComplete = true;

            // Stop danger
            if (DangerLevel.Instance != null)
            {
                DangerLevel.Instance.StopDanger();
            }

            // Calculate stars
            int stars = CalculateStars();

            // Update game manager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.collectedCorrect = _correctAnswers;
                GameManager.Instance.collectedWrong = _wrongAnswers;
                GameManager.Instance.CompleteLevel(stars);
            }

            EventBus.Instance?.TriggerMissionEnd();
            Debug.Log($"[MissionManager] Mission complete! Stars: {stars}");

            // Load summary scene
            if (SceneLoader.Instance != null)
            {
                SceneLoader.Instance.LoadFinalSummary();
            }
        }

        private int CalculateStars()
        {
            // 3 stars: 5/5 correct
            // 2 stars: 4/5 correct
            // 1 star: 3/5 or less correct
            if (_correctAnswers >= 5) return 3;
            if (_correctAnswers >= 4) return 2;
            return 1;
        }

        /// <summary>
        /// Called when player is caught by Snow Patrol
        /// </summary>
        public void OnPlayerCaught()
        {
            _isMissionActive = false;

            Debug.Log("[MissionManager] Player caught! Mission failed.");

            // Could reload scene or show retry screen
            if (SceneLoader.Instance != null)
            {
                SceneLoader.Instance.ReloadCurrentScene();
            }
        }
    }
}
