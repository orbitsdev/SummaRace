using UnityEngine;
using SummaRace.Core;

namespace SummaRace.Mission
{
    /// <summary>
    /// Base class for all collectible items in the mission.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class Collectible : MonoBehaviour
    {
        [Header("Collectible Settings")]
        [SerializeField] protected string _collectibleType = "Generic";
        [SerializeField] protected bool _destroyOnCollect = true;

        [Header("Visual Feedback")]
        [SerializeField] protected float _rotateSpeed = 50f;
        [SerializeField] protected float _bobSpeed = 2f;
        [SerializeField] protected float _bobHeight = 0.3f;

        protected Vector3 _startPosition;
        protected bool _isCollected;

        protected virtual void Start()
        {
            _startPosition = transform.position;

            // Ensure trigger is set
            Collider col = GetComponent<Collider>();
            if (col != null)
                col.isTrigger = true;
        }

        protected virtual void Update()
        {
            if (_isCollected) return;

            // Rotate
            transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);

            // Bob up and down
            float newY = _startPosition.y + Mathf.Sin(Time.time * _bobSpeed) * _bobHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (_isCollected) return;

            if (other.CompareTag("Player"))
            {
                Collect();
            }
        }

        protected virtual void Collect()
        {
            _isCollected = true;

            // Trigger event
            if (EventBus.Instance != null)
            {
                EventBus.Instance.TriggerElementCollected(_collectibleType);
            }

            // Play sound
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayCollected();
            }

            OnCollected();

            if (_destroyOnCollect)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Override in subclasses for specific behavior
        /// </summary>
        protected virtual void OnCollected()
        {
            Debug.Log($"[Collectible] Collected: {_collectibleType}");
        }
    }
}
