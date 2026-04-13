using UnityEngine;
using System.Collections;

namespace SummaRace.UI
{
    public class MenuCharacterRunner : MonoBehaviour
    {
        public enum MovementMode { Horizontal, Depth, Oval }

        [Header("Movement")]
        [SerializeField] private MovementMode _mode = MovementMode.Oval;
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _groundY = 0f;
        [SerializeField] private float _bobAmount = 0.1f;
        [SerializeField] private float _bobSpeed = 10f;

        [Header("Oval Settings")]
        [SerializeField] private Vector3 _ovalCenter = new Vector3(0f, 0f, 5f);
        [SerializeField] private float _ovalRadiusX = 6f;  // Width of oval
        [SerializeField] private float _ovalRadiusZ = 3f;  // Depth of oval
        [SerializeField] private float _startAngle = 0f;   // Starting position on oval (degrees)
        [SerializeField] private bool _clockwise = true;

        [Header("Linear Settings (for Horizontal/Depth modes)")]
        [SerializeField] private float _nearBound = 2f;
        [SerializeField] private float _farBound = 10f;
        [SerializeField] private float _fixedPosition = 0f;
        [SerializeField] private bool _startMovingForward = true;

        [Header("Greeting Animation")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _greetingTrigger = "Wave";
        [SerializeField] private float _greetingBounceScale = 1.2f;
        [SerializeField] private float _greetingBounceDuration = 0.4f;

        private float _currentAngle;
        private bool _movingForward;
        private bool _isGreeting;

        void Start()
        {
            _currentAngle = _startAngle * Mathf.Deg2Rad;
            _movingForward = _startMovingForward;

            if (_mode != MovementMode.Oval)
                FaceDirection();
        }

        void Update()
        {
            float bob = Mathf.Sin(Time.time * _bobSpeed) * _bobAmount;

            if (_mode == MovementMode.Oval)
            {
                UpdateOvalMovement(bob);
            }
            else
            {
                UpdateLinearMovement(bob);
            }
        }

        private void UpdateOvalMovement(float bob)
        {
            // Calculate angular speed based on linear speed and average radius
            float avgRadius = (_ovalRadiusX + _ovalRadiusZ) * 0.5f;
            float angularSpeed = _speed / avgRadius;

            // Update angle
            float direction = _clockwise ? -1f : 1f;
            _currentAngle += direction * angularSpeed * Time.deltaTime;

            // Calculate position on oval
            float x = _ovalCenter.x + Mathf.Cos(_currentAngle) * _ovalRadiusX;
            float z = _ovalCenter.z + Mathf.Sin(_currentAngle) * _ovalRadiusZ;

            transform.position = new Vector3(x, _groundY + bob, z);

            // Face movement direction (tangent to oval)
            float nextAngle = _currentAngle + direction * 0.1f;
            float nextX = _ovalCenter.x + Mathf.Cos(nextAngle) * _ovalRadiusX;
            float nextZ = _ovalCenter.z + Mathf.Sin(nextAngle) * _ovalRadiusZ;

            Vector3 moveDir = new Vector3(nextX - x, 0, nextZ - z).normalized;
            if (moveDir.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(moveDir);
            }
        }

        private void UpdateLinearMovement(float bob)
        {
            float direction = _movingForward ? 1f : -1f;

            if (_mode == MovementMode.Depth)
            {
                float z = transform.position.z + direction * _speed * Time.deltaTime;

                if (z > _farBound)
                {
                    z = _farBound;
                    _movingForward = false;
                    FaceDirection();
                }
                else if (z < _nearBound)
                {
                    z = _nearBound;
                    _movingForward = true;
                    FaceDirection();
                }

                transform.position = new Vector3(_fixedPosition, _groundY + bob, z);
            }
            else
            {
                float x = transform.position.x + direction * _speed * Time.deltaTime;

                if (x > _farBound)
                {
                    x = _farBound;
                    _movingForward = false;
                    FaceDirection();
                }
                else if (x < _nearBound)
                {
                    x = _nearBound;
                    _movingForward = true;
                    FaceDirection();
                }

                transform.position = new Vector3(x, _groundY + bob, _fixedPosition);
            }
        }

        private void FaceDirection()
        {
            float yRot;
            if (_mode == MovementMode.Depth)
            {
                yRot = _movingForward ? 0f : 180f;
            }
            else
            {
                yRot = _movingForward ? 90f : -90f;
            }
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

        /// <summary>
        /// Play a greeting animation when menu loads.
        /// Uses Animator trigger if available, otherwise does a scale bounce.
        /// </summary>
        public void PlayGreeting()
        {
            if (_isGreeting) return;
            _isGreeting = true;

            // Try animator trigger first
            if (_animator != null && HasAnimatorParameter(_greetingTrigger))
            {
                _animator.SetTrigger(_greetingTrigger);
                _isGreeting = false;
                return;
            }

            // Fallback: scale bounce
            StartCoroutine(GreetingBounce());
        }

        private IEnumerator GreetingBounce()
        {
            Vector3 originalScale = transform.localScale;
            float elapsed = 0f;
            float halfDuration = _greetingBounceDuration * 0.5f;

            // Scale up
            while (elapsed < halfDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / halfDuration;
                float scale = Mathf.Lerp(1f, _greetingBounceScale, t);
                transform.localScale = originalScale * scale;
                yield return null;
            }

            // Scale down
            elapsed = 0f;
            while (elapsed < halfDuration)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / halfDuration;
                float scale = Mathf.Lerp(_greetingBounceScale, 1f, t);
                transform.localScale = originalScale * scale;
                yield return null;
            }

            transform.localScale = originalScale;
            _isGreeting = false;
        }

        private bool HasAnimatorParameter(string paramName)
        {
            if (_animator == null) return false;

            foreach (var param in _animator.parameters)
            {
                if (param.name == paramName)
                    return true;
            }
            return false;
        }
    }
}
