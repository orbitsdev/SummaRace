using UnityEngine;

namespace SummaRace.UI
{
    public class MenuCharacterRunner : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _leftBound = -18f;
        [SerializeField] private float _rightBound = 18f;
        [SerializeField] private float _groundY = 0f;
        [SerializeField] private float _zPosition = 5f;
        [SerializeField] private bool _startMovingRight = true;
        [SerializeField] private float _bobAmount = 0.1f;
        [SerializeField] private float _bobSpeed = 10f;

        private bool _movingRight;

        void Start()
        {
            _movingRight = _startMovingRight;
            FaceDirection();
        }

        void Update()
        {
            float direction = _movingRight ? 1f : -1f;
            float x = transform.position.x + direction * _speed * Time.deltaTime;

            // Bounce at bounds - turn around
            if (x > _rightBound)
            {
                x = _rightBound;
                _movingRight = false;
                FaceDirection();
            }
            else if (x < _leftBound)
            {
                x = _leftBound;
                _movingRight = true;
                FaceDirection();
            }

            float bob = Mathf.Sin(Time.time * _bobSpeed) * _bobAmount;
            transform.position = new Vector3(x, _groundY + bob, _zPosition);
        }

        private void FaceDirection()
        {
            float yRot = _movingRight ? 90f : -90f;
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }
}
