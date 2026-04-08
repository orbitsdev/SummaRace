using UnityEngine;
using SummaRace.Core;

namespace SummaRace.Player
{
    /// <summary>
    /// Controls player forward movement and speed variations
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float _baseSpeed = 10f;
        [SerializeField] private float _sprintMultiplier = 1.5f;
        [SerializeField] private float _slowMultiplier = 0.5f;

        [Header("State")]
        [SerializeField] private bool _isRunning;
        [SerializeField] private float _currentSpeed;

        private bool _isSprinting;
        private bool _isSlowed;

        public float CurrentSpeed => _currentSpeed;
        public bool IsRunning => _isRunning;

                [Header("Debug")]
        [SerializeField] private bool _autoStartForTesting = false;

        void Start()
        {
            _currentSpeed = _baseSpeed;

            // Subscribe to events
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnMissionStart += StartRunning;
                EventBus.Instance.OnMissionEnd += StopRunning;
                EventBus.Instance.OnPlayerCaught += OnCaught;
            }

            // Auto-start for testing (disable in production)
            if (_autoStartForTesting)
            {
                StartRunning();
            }
        }

        void OnDestroy()
        {
            if (EventBus.Instance != null)
            {
                EventBus.Instance.OnMissionStart -= StartRunning;
                EventBus.Instance.OnMissionEnd -= StopRunning;
                EventBus.Instance.OnPlayerCaught -= OnCaught;
            }
        }

        void Update()
        {
            if (!_isRunning) return;

            // Move forward continuously
            transform.Translate(Vector3.forward * _currentSpeed * Time.deltaTime);
        }

        public void StartRunning()
        {
            _isRunning = true;
            _currentSpeed = _baseSpeed;
            Debug.Log("[PlayerController] Started running");
        }

        public void StopRunning()
        {
            _isRunning = false;
            _currentSpeed = 0f;
            Debug.Log("[PlayerController] Stopped running");
        }

        public void Sprint()
        {
            if (!_isRunning) return;
            _isSprinting = true;
            _isSlowed = false;
            UpdateSpeed();
        }

        public void Slow()
        {
            if (!_isRunning) return;
            _isSlowed = true;
            _isSprinting = false;
            UpdateSpeed();
        }

        public void ResetSpeed()
        {
            _isSprinting = false;
            _isSlowed = false;
            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            if (_isSprinting)
                _currentSpeed = _baseSpeed * _sprintMultiplier;
            else if (_isSlowed)
                _currentSpeed = _baseSpeed * _slowMultiplier;
            else
                _currentSpeed = _baseSpeed;
        }

        private void OnCaught()
        {
            StopRunning();
            Debug.Log("[PlayerController] Player caught by Snow Patrol!");
        }

        /// <summary>
        /// Set base speed from story data
        /// </summary>
        public void SetBaseSpeed(float speed)
        {
            _baseSpeed = speed;
            UpdateSpeed();
        }
    }
}
