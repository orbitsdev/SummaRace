using UnityEngine;

namespace SummaRace.Player
{
    /// <summary>
    /// Simple camera follow script - follows the player with offset
    /// </summary>
    public class CameraFollow : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform _target;

        [Header("Offset")]
        [SerializeField] private Vector3 _offset = new Vector3(0f, 5f, -8f);

        [Header("Smoothing")]
        [SerializeField] private float _smoothSpeed = 10f;
        [SerializeField] private bool _smoothFollow = true;

        void Start()
        {
            // Auto-find player if not assigned
            if (_target == null)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    _target = player.transform;
                }
            }

            // Set initial position
            if (_target != null)
            {
                transform.position = _target.position + _offset;
            }
        }

        void LateUpdate()
        {
            if (_target == null) return;

            Vector3 desiredPosition = _target.position + _offset;

            if (_smoothFollow)
            {
                transform.position = Vector3.Lerp(
                    transform.position,
                    desiredPosition,
                    _smoothSpeed * Time.deltaTime
                );
            }
            else
            {
                transform.position = desiredPosition;
            }
        }

        /// <summary>
        /// Set the follow target at runtime
        /// </summary>
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        /// <summary>
        /// Camera shake effect
        /// </summary>
        public void Shake(float duration = 0.2f, float magnitude = 0.3f)
        {
            StartCoroutine(ShakeCoroutine(duration, magnitude));
        }

        private System.Collections.IEnumerator ShakeCoroutine(float duration, float magnitude)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.position += new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
