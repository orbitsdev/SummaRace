using UnityEngine;
using UnityEngine.InputSystem;

namespace SummaRace.Player
{
    /// <summary>
    /// Handles player input for lane switching (swipe on mobile, arrow keys on desktop)
    /// </summary>
    [RequireComponent(typeof(LaneSwitcher))]
    public class PlayerInput : MonoBehaviour
    {
        [Header("Touch Settings")]
        [SerializeField] private float _swipeThreshold = 50f;

        [Header("References")]
        private LaneSwitcher _laneSwitcher;
        private PlayerController _playerController;

        // Touch tracking
        private Vector2 _touchStartPos;
        private bool _isTouching;

        void Awake()
        {
            _laneSwitcher = GetComponent<LaneSwitcher>();
            _playerController = GetComponent<PlayerController>();
        }

        void Update()
        {
            HandleKeyboardInput();
            HandleTouchInput();
        }

        private void HandleKeyboardInput()
        {
            if (Keyboard.current == null) return;

            // W = Start running / Sprint
            if (Keyboard.current.wKey.wasPressedThisFrame)
            {
                _playerController?.StartRunning();
            }

            // S = Stop running
            if (Keyboard.current.sKey.wasPressedThisFrame)
            {
                _playerController?.StopRunning();
            }

            // A = Move left lane
            if (Keyboard.current.leftArrowKey.wasPressedThisFrame ||
                Keyboard.current.aKey.wasPressedThisFrame)
            {
                _laneSwitcher.MoveLeft();
            }

            // D = Move right lane
            if (Keyboard.current.rightArrowKey.wasPressedThisFrame ||
                Keyboard.current.dKey.wasPressedThisFrame)
            {
                _laneSwitcher.MoveRight();
            }

            // Sprint with Shift or Space (while running)
            if (Keyboard.current.shiftKey.isPressed ||
                Keyboard.current.spaceKey.isPressed)
            {
                _playerController?.Sprint();
            }
            else
            {
                _playerController?.ResetSpeed();
            }
        }

        private void HandleTouchInput()
        {
            if (Touchscreen.current == null) return;

            var touch = Touchscreen.current.primaryTouch;

            // Touch began
            if (touch.press.wasPressedThisFrame)
            {
                _touchStartPos = touch.position.ReadValue();
                _isTouching = true;
            }

            // Touch ended
            if (touch.press.wasReleasedThisFrame && _isTouching)
            {
                Vector2 touchEndPos = touch.position.ReadValue();
                Vector2 swipeDelta = touchEndPos - _touchStartPos;

                // Check if it's a horizontal swipe
                if (Mathf.Abs(swipeDelta.x) > _swipeThreshold &&
                    Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
                {
                    if (swipeDelta.x > 0)
                    {
                        _laneSwitcher.MoveRight();
                    }
                    else
                    {
                        _laneSwitcher.MoveLeft();
                    }
                }

                _isTouching = false;
            }
        }

        /// <summary>
        /// Called by UI buttons for mobile
        /// </summary>
        public void OnLeftButtonPressed()
        {
            _laneSwitcher.MoveLeft();
        }

        /// <summary>
        /// Called by UI buttons for mobile
        /// </summary>
        public void OnRightButtonPressed()
        {
            _laneSwitcher.MoveRight();
        }
    }
}
