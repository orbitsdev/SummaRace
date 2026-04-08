using UnityEngine;
using System.Collections.Generic;

namespace SummaRace.Mission
{
    /// <summary>
    /// Spawns and recycles track segments as player moves forward.
    /// Uses object pooling for performance.
    /// </summary>
    public class TrackSpawner : MonoBehaviour
    {
        [Header("Track Settings")]
        [SerializeField] private GameObject _trackPrefab;
        [SerializeField] private int _poolSize = 5;
        [SerializeField] private float _segmentLength = 50f;

        [Header("Player Reference")]
        [SerializeField] private Transform _player;

        [Header("Spawn Settings")]
        [SerializeField] private float _spawnAheadDistance = 100f;
        [SerializeField] private float _despawnBehindDistance = 50f;

        private Queue<GameObject> _trackPool = new Queue<GameObject>();
        private List<GameObject> _activeSegments = new List<GameObject>();
        private float _nextSpawnZ = 0f;

        void Start()
        {
            // Auto-find player if not assigned
            if (_player == null)
            {
                GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                if (playerObj != null)
                    _player = playerObj.transform;
            }

            // Initialize pool
            InitializePool();

            // Spawn initial segments
            SpawnInitialSegments();
        }

        void Update()
        {
            if (_player == null) return;

            // Spawn new segments ahead
            while (_nextSpawnZ < _player.position.z + _spawnAheadDistance)
            {
                SpawnSegment();
            }

            // Recycle segments behind player
            RecycleSegmentsBehind();
        }

        private void InitializePool()
        {
            if (_trackPrefab == null)
            {
                Debug.LogWarning("[TrackSpawner] No track prefab assigned. Using existing track.");
                return;
            }

            for (int i = 0; i < _poolSize; i++)
            {
                GameObject segment = Instantiate(_trackPrefab, transform);
                segment.SetActive(false);
                _trackPool.Enqueue(segment);
            }
        }

        private void SpawnInitialSegments()
        {
            // Start spawning from behind player
            _nextSpawnZ = -_segmentLength;

            // Spawn enough to fill view
            int initialCount = Mathf.CeilToInt((_spawnAheadDistance + _despawnBehindDistance) / _segmentLength) + 1;

            for (int i = 0; i < initialCount; i++)
            {
                SpawnSegment();
            }
        }

        private void SpawnSegment()
        {
            GameObject segment = GetFromPool();
            if (segment == null) return;

            segment.transform.position = new Vector3(0, 0, _nextSpawnZ + _segmentLength / 2f);
            segment.SetActive(true);
            _activeSegments.Add(segment);

            _nextSpawnZ += _segmentLength;
        }

        private void RecycleSegmentsBehind()
        {
            float recycleZ = _player.position.z - _despawnBehindDistance;

            for (int i = _activeSegments.Count - 1; i >= 0; i--)
            {
                GameObject segment = _activeSegments[i];
                if (segment.transform.position.z < recycleZ)
                {
                    ReturnToPool(segment);
                    _activeSegments.RemoveAt(i);
                }
            }
        }

        private GameObject GetFromPool()
        {
            if (_trackPool.Count > 0)
            {
                return _trackPool.Dequeue();
            }

            // Pool empty - create new if prefab exists
            if (_trackPrefab != null)
            {
                GameObject segment = Instantiate(_trackPrefab, transform);
                return segment;
            }

            return null;
        }

        private void ReturnToPool(GameObject segment)
        {
            segment.SetActive(false);
            _trackPool.Enqueue(segment);
        }
    }
}
