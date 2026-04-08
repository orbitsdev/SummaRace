using UnityEngine;

namespace SummaRace.Player
{
    /// <summary>
    /// Handles 3-lane switching for the endless runner
    /// </summary>
    public class LaneSwitcher : MonoBehaviour
    {
        [Header("Lane Settings")]
        [SerializeField] private float _laneWidth = 3f;
        [SerializeField] private float _switchSpeed = 10f;

        [Header("Current State")]
        [SerializeField] private int _currentLane = 1; // 0=left, 1=center, 2=right

        private float _targetX;
        private bool _isSwitching;

        public int CurrentLane => _currentLane;
        public bool IsSwitching => _isSwitching;

        // Lane X positions
        private float LeftLaneX => -_laneWidth;
        private float CenterLaneX => 0f;
        private float RightLaneX => _laneWidth;

        void Start()
        {
            // Start in center lane
            _currentLane = 1;
            _targetX = CenterLaneX;
        }

        void Update()
        {
            if (_isSwitching)
            {
                // Smoothly move to target lane
                Vector3 pos = transform.position;
                pos.x = Mathf.MoveTowards(pos.x, _targetX, _switchSpeed * Time.deltaTime);
                transform.position = pos;

                // Check if reached target
                if (Mathf.Approximately(pos.x, _targetX))
                {
                    _isSwitching = false;
                }
            }
        }

        /// <summary>
        /// Move one lane to the left
        /// </summary>
        public void MoveLeft()
        {
            if (_currentLane > 0)
            {
                _currentLane--;
                UpdateTargetPosition();
                Debug.Log($"[LaneSwitcher] Moving to lane {_currentLane}");
            }
        }

        /// <summary>
        /// Move one lane to the right
        /// </summary>
        public void MoveRight()
        {
            if (_currentLane < 2)
            {
                _currentLane++;
                UpdateTargetPosition();
                Debug.Log($"[LaneSwitcher] Moving to lane {_currentLane}");
            }
        }

        private void UpdateTargetPosition()
        {
            _targetX = _currentLane switch
            {
                0 => LeftLaneX,
                1 => CenterLaneX,
                2 => RightLaneX,
                _ => CenterLaneX
            };
            _isSwitching = true;
        }

        /// <summary>
        /// Instantly snap to a specific lane (for resets)
        /// </summary>
        public void SnapToLane(int lane)
        {
            _currentLane = Mathf.Clamp(lane, 0, 2);
            _targetX = _currentLane switch
            {
                0 => LeftLaneX,
                1 => CenterLaneX,
                2 => RightLaneX,
                _ => CenterLaneX
            };

            Vector3 pos = transform.position;
            pos.x = _targetX;
            transform.position = pos;
            _isSwitching = false;
        }

        /// <summary>
        /// Get the X position of a specific lane
        /// </summary>
        public float GetLanePosition(int lane)
        {
            return lane switch
            {
                0 => LeftLaneX,
                1 => CenterLaneX,
                2 => RightLaneX,
                _ => CenterLaneX
            };
        }
    }
}
