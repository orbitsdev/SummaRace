using UnityEngine;
using SummaRace.Core;

namespace SummaRace.Mission
{
    /// <summary>
    /// Manages the "fake chase" danger level system.
    /// Higher danger = enemy appears closer. At max, player is "caught".
    /// </summary>
    public class DangerLevel : MonoBehaviour
    {
        public static DangerLevel Instance { get; private set; }

        [Header("Danger Settings")]
        [SerializeField] private int _currentLevel = 50;
        [SerializeField] private int _minLevel = 0;
        [SerializeField] private int _maxLevel = 100;

        [Header("Level Changes")]
        [SerializeField] private int _decreaseOnCorrect = 20;
        [SerializeField] private int _increaseOnWrong = 30;
        [SerializeField] private int _increaseOverTime = 1;
        [SerializeField] private float _timeIncreaseInterval = 3f;

        [Header("Enemy Visual")]
        [SerializeField] private Transform _enemy;
        [SerializeField] private float _enemyMinDistance = 20f;  // When danger = 0
        [SerializeField] private float _enemyMaxDistance = 5f;   // When danger = 100

        [Header("Player Reference")]
        [SerializeField] private Transform _player;

        private float _timeSinceLastIncrease;
        private bool _isActive;

        public int CurrentLevel => _currentLevel;
        public float NormalizedLevel => (float)_currentLevel / _maxLevel;
        public bool IsMaxDanger => _currentLevel >= _maxLevel;

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
            // Auto-find references
            if (_player == null)
            {
                GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                if (playerObj != null)
                    _player = playerObj.transform;
            }

            if (_enemy == null)
            {
                GameObject enemyObj = GameObject.Find("SnowPatrol");
                if (enemyObj != null)
                    _enemy = enemyObj.transform;
            }

            // Subscribe to events
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnAnswerCardCollected += OnAnswerCollected;
                EventBus.Instance.OnMissionStart += StartDanger;
                EventBus.Instance.OnMissionEnd += StopDanger;
            }
        }

        void OnDestroy()
        {
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnAnswerCardCollected -= OnAnswerCollected;
                EventBus.Instance.OnMissionStart -= StartDanger;
                EventBus.Instance.OnMissionEnd -= StopDanger;
            }
        }

        void Update()
        {
            if (!_isActive) return;

            // Increase danger over time
            _timeSinceLastIncrease += Time.deltaTime;
            if (_timeSinceLastIncrease >= _timeIncreaseInterval)
            {
                ChangeDanger(_increaseOverTime);
                _timeSinceLastIncrease = 0f;
            }

            // Update enemy position
            UpdateEnemyPosition();

            // Check if caught
            if (IsMaxDanger)
            {
                OnPlayerCaught();
            }
        }

        public void StartDanger()
        {
            _isActive = true;
            _timeSinceLastIncrease = 0f;
            Debug.Log("[DangerLevel] Started");
        }

        public void StopDanger()
        {
            _isActive = false;
            Debug.Log("[DangerLevel] Stopped");
        }

        public void SetInitialLevel(int level)
        {
            _currentLevel = Mathf.Clamp(level, _minLevel, _maxLevel);
            EventBus.Instance?.TriggerDangerLevelChanged(_currentLevel);
        }

        private void OnAnswerCollected(bool isCorrect)
        {
            if (isCorrect)
            {
                ChangeDanger(-_decreaseOnCorrect);
            }
            else
            {
                ChangeDanger(_increaseOnWrong);
            }
        }

        private void ChangeDanger(int amount)
        {
            int previousLevel = _currentLevel;
            _currentLevel = Mathf.Clamp(_currentLevel + amount, _minLevel, _maxLevel);

            if (_currentLevel != previousLevel)
            {
                EventBus.Instance?.TriggerDangerLevelChanged(_currentLevel);
                Debug.Log($"[DangerLevel] Changed: {previousLevel} -> {_currentLevel}");
            }
        }

        private void UpdateEnemyPosition()
        {
            if (_enemy == null || _player == null) return;

            // Calculate distance based on danger level
            float t = NormalizedLevel;
            float distance = Mathf.Lerp(_enemyMinDistance, _enemyMaxDistance, t);

            // Position enemy behind player
            Vector3 enemyPos = _player.position - _player.forward * distance;
            enemyPos.y = _enemy.position.y; // Keep original height

            _enemy.position = Vector3.Lerp(_enemy.position, enemyPos, Time.deltaTime * 2f);
        }

        private void OnPlayerCaught()
        {
            _isActive = false;
            EventBus.Instance?.TriggerPlayerCaught();
            Debug.Log("[DangerLevel] Player caught!");
        }
    }
}
