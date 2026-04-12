using UnityEngine;

namespace SummaRace.UI
{
    public class MenuCharacterRunner : MonoBehaviour
    {
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private float _radius = 4f;
        [SerializeField] private float _speed = 1.2f;
        [SerializeField] private float _startAngle = 0f;

        private float _angle;
        private Animator _animator;

        void Start()
        {
            _angle = _startAngle * Mathf.Deg2Rad;
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            _angle += _speed * Time.deltaTime;

            Vector3 center = _centerPoint != null ? _centerPoint.position : Vector3.zero;
            float x = center.x + Mathf.Cos(_angle) * _radius;
            float z = center.z + Mathf.Sin(_angle) * _radius;

            Vector3 newPos = new Vector3(x, center.y, z);

            // Face movement direction
            Vector3 direction = newPos - transform.position;
            if (direction.sqrMagnitude > 0.001f)
                transform.rotation = Quaternion.LookRotation(direction);

            transform.position = newPos;
        }
    }
}
