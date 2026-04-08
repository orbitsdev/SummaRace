using UnityEngine;
using SummaRace.Core;
using SummaRace.Data;

namespace SummaRace.Mission
{
    /// <summary>
    /// A checkpoint gate where player must choose the correct answer.
    /// Spawns answer cards in the 3 lanes.
    /// </summary>
    public class Checkpoint : MonoBehaviour
    {
        [Header("Checkpoint Settings")]
        [SerializeField] private int _checkpointIndex;
        [SerializeField] private string _elementType; // "Somebody", "Wanted", etc.

        [Header("Answer Card Spawning")]
        [SerializeField] private GameObject _answerCardPrefab;
        [SerializeField] private float _laneWidth = 3f;
        [SerializeField] private float _spawnHeight = 1f;

        [Header("Question Data")]
        [SerializeField] private string _questionText;
        [SerializeField] private string[] _answers = new string[3];
        [SerializeField] private int _correctAnswerIndex;

        private bool _isActivated;
        private AnswerCard[] _spawnedCards = new AnswerCard[3];

        public int CheckpointIndex => _checkpointIndex;
        public string ElementType => _elementType;

        void Start()
        {
            // Ensure we have a trigger collider for activation
            Collider col = GetComponent<Collider>();
            if (col != null)
                col.isTrigger = true;
        }

        void OnTriggerEnter(Collider other)
        {
            if (_isActivated) return;

            if (other.CompareTag("Player"))
            {
                ActivateCheckpoint();
            }
        }

        /// <summary>
        /// Set up checkpoint with element data
        /// </summary>
        public void Setup(int index, ElementData element)
        {
            _checkpointIndex = index;
            _elementType = element.type;
            _answers = element.options;
            _correctAnswerIndex = element.correctIndex;
            _questionText = $"Choose the {element.type}:";
        }

        /// <summary>
        /// Manually set up checkpoint
        /// </summary>
        public void Setup(int index, string type, string[] answers, int correctIndex)
        {
            _checkpointIndex = index;
            _elementType = type;
            _answers = answers;
            _correctAnswerIndex = correctIndex;
            _questionText = $"Choose the {type}:";
        }

        private void ActivateCheckpoint()
        {
            _isActivated = true;

            // Show question UI
            EventBus.Instance?.TriggerShowMessage(_questionText);

            // Spawn answer cards in the 3 lanes
            SpawnAnswerCards();

            Debug.Log($"[Checkpoint] Activated checkpoint {_checkpointIndex}: {_elementType}");
        }

        private void SpawnAnswerCards()
        {
            if (_answerCardPrefab == null)
            {
                Debug.LogWarning("[Checkpoint] No answer card prefab assigned!");
                return;
            }

            float[] lanePositions = { -_laneWidth, 0f, _laneWidth };

            // Shuffle answer positions for variety
            int[] shuffledIndices = ShuffleIndices(3);

            for (int i = 0; i < 3; i++)
            {
                int answerIndex = shuffledIndices[i];

                Vector3 spawnPos = transform.position + new Vector3(lanePositions[i], _spawnHeight, 10f);
                GameObject cardObj = Instantiate(_answerCardPrefab, spawnPos, Quaternion.identity);

                AnswerCard card = cardObj.GetComponent<AnswerCard>();
                if (card != null)
                {
                    bool isCorrect = answerIndex == _correctAnswerIndex;
                    card.Setup(_answers[answerIndex], isCorrect);
                    _spawnedCards[i] = card;
                }
            }
        }

        private int[] ShuffleIndices(int count)
        {
            int[] indices = new int[count];
            for (int i = 0; i < count; i++)
                indices[i] = i;

            // Fisher-Yates shuffle
            for (int i = count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                int temp = indices[i];
                indices[i] = indices[j];
                indices[j] = temp;
            }

            return indices;
        }

        /// <summary>
        /// Clean up spawned cards (called after player passes)
        /// </summary>
        public void Cleanup()
        {
            foreach (var card in _spawnedCards)
            {
                if (card != null)
                    Destroy(card.gameObject);
            }
        }
    }
}
