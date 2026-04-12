using UnityEngine;
using TMPro;

namespace SummaRace.UI
{
    public class FloatingSWBSTWords : MonoBehaviour
    {
        [System.Serializable]
        public struct WordConfig
        {
            public string word;
            public Color color;
            public Vector3 startPosition;
            public float orbitRadius;
            public float orbitSpeed;
            public float bobSpeed;
            public float bobHeight;
        }

        [SerializeField] private float _fontSize = 6f;
        [SerializeField] private float _rotationWobble = 10f;

        private WordConfig[] _words;
        private GameObject[] _wordObjects;
        private float[] _timeOffsets;

        void Start()
        {
            _words = new WordConfig[]
            {
                new WordConfig {
                    word = "Somebody", color = new Color(0.26f, 0.65f, 0.96f), // #42A5F5
                    startPosition = new Vector3(-6, 3, 8), orbitRadius = 2f,
                    orbitSpeed = 0.4f, bobSpeed = 1.2f, bobHeight = 0.5f
                },
                new WordConfig {
                    word = "Wanted", color = new Color(1f, 0.84f, 0f), // #FFD700
                    startPosition = new Vector3(6, 4, 10), orbitRadius = 2.5f,
                    orbitSpeed = 0.35f, bobSpeed = 1.0f, bobHeight = 0.6f
                },
                new WordConfig {
                    word = "But", color = new Color(1f, 0.60f, 0f), // #FF9800
                    startPosition = new Vector3(0, 2.5f, 14), orbitRadius = 1.5f,
                    orbitSpeed = 0.5f, bobSpeed = 1.4f, bobHeight = 0.4f
                },
                new WordConfig {
                    word = "So", color = new Color(0.40f, 0.73f, 0.42f), // #66BB6A
                    startPosition = new Vector3(-8, 3.5f, 12), orbitRadius = 2f,
                    orbitSpeed = 0.45f, bobSpeed = 0.9f, bobHeight = 0.5f
                },
                new WordConfig {
                    word = "Then", color = new Color(0.67f, 0.28f, 0.74f), // #AB47BC
                    startPosition = new Vector3(8, 2f, 6), orbitRadius = 1.8f,
                    orbitSpeed = 0.3f, bobSpeed = 1.1f, bobHeight = 0.7f
                },
            };

            _wordObjects = new GameObject[_words.Length];
            _timeOffsets = new float[_words.Length];

            for (int i = 0; i < _words.Length; i++)
            {
                _timeOffsets[i] = i * 1.3f; // stagger the animations
                _wordObjects[i] = CreateWord(_words[i]);
            }
        }

        private GameObject CreateWord(WordConfig config)
        {
            var go = new GameObject($"SWBST_{config.word}");
            go.transform.SetParent(transform);
            go.transform.position = config.startPosition;

            var tmp = go.AddComponent<TextMeshPro>();
            tmp.text = config.word;
            tmp.fontSize = _fontSize;
            tmp.fontStyle = FontStyles.Bold;
            tmp.color = config.color;
            tmp.alignment = TextAlignmentOptions.Center;
            tmp.enableWordWrapping = false;

            // Face camera
            go.transform.rotation = Quaternion.Euler(0, 180, 0);

            return go;
        }

        void Update()
        {
            Camera cam = Camera.main;

            for (int i = 0; i < _words.Length; i++)
            {
                if (_wordObjects[i] == null) continue;

                float t = Time.time + _timeOffsets[i];
                var config = _words[i];
                var basePos = config.startPosition;

                // Orbit around start position
                float orbitX = Mathf.Cos(t * config.orbitSpeed) * config.orbitRadius;
                float orbitZ = Mathf.Sin(t * config.orbitSpeed) * config.orbitRadius;

                // Bob up and down
                float bobY = Mathf.Sin(t * config.bobSpeed) * config.bobHeight;

                Vector3 pos = new Vector3(
                    basePos.x + orbitX,
                    basePos.y + bobY,
                    basePos.z + orbitZ
                );

                _wordObjects[i].transform.position = pos;

                // Face camera (billboard)
                if (cam != null)
                {
                    Vector3 lookDir = _wordObjects[i].transform.position - cam.transform.position;
                    lookDir.y = 0;
                    if (lookDir.sqrMagnitude > 0.01f)
                        _wordObjects[i].transform.rotation = Quaternion.LookRotation(lookDir);
                }

                // Slight rotation wobble
                float wobble = Mathf.Sin(t * 2f) * _rotationWobble;
                _wordObjects[i].transform.rotation *= Quaternion.Euler(wobble * 0.3f, 0, wobble);
            }
        }
    }
}
