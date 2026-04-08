using UnityEngine;

namespace SummaRace.Mission
{
    /// <summary>
    /// Spawns checkpoints at fixed intervals along the track.
    /// Each checkpoint presents a question with answer cards.
    /// </summary>
    public class CheckpointSpawner : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _checkpointPrefab;

        [Header("Spawn Settings")]
        [SerializeField] private float _firstCheckpointZ = 50f;
        [SerializeField] private float _spacingBetween = 100f;
        [SerializeField] private int _totalCheckpoints = 5;

        [Header("Test Data")]
        [SerializeField] private string[] _testQuestions = new string[]
        {
            "Who is the main character?",
            "What did they want?",
            "But what happened?",
            "So what did they do?",
            "Then what happened?"
        };

        [SerializeField] private string[] _testCorrectAnswers = new string[]
        {
            "The lion",
            "To find food",
            "A storm came",
            "Found shelter",
            "They were safe"
        };

        private void Start()
        {
            SpawnCheckpoints();
        }

        private void SpawnCheckpoints()
        {
            if (_checkpointPrefab == null)
            {
                Debug.LogError("[CheckpointSpawner] Checkpoint prefab not assigned!");
                return;
            }

            for (int i = 0; i < _totalCheckpoints; i++)
            {
                float zPos = _firstCheckpointZ + (i * _spacingBetween);
                Vector3 spawnPos = new Vector3(0, 0, zPos);

                GameObject checkpoint = Instantiate(_checkpointPrefab, spawnPos, Quaternion.identity);
                checkpoint.name = $"Checkpoint_{i + 1}";

                // Set up checkpoint data
                Checkpoint cp = checkpoint.GetComponent<Checkpoint>();
                if (cp != null)
                {
                    string question = i < _testQuestions.Length ? _testQuestions[i] : $"Question {i + 1}";
                    string correct = i < _testCorrectAnswers.Length ? _testCorrectAnswers[i] : "Correct";
                    string[] answers = new string[] { correct, "Wrong A", "Wrong B" };

                    cp.Setup(i, "Element", answers, 0);
                }

                Debug.Log($"[CheckpointSpawner] Spawned checkpoint {i + 1} at Z={zPos}");
            }
        }
    }
}
