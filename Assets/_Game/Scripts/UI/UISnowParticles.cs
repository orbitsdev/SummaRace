using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace SummaRace.UI
{
    /// <summary>
    /// Creates falling snow particles as UI elements on a Canvas.
    /// Attach to a RectTransform container inside the canvas.
    /// </summary>
    public class UISnowParticles : MonoBehaviour
    {
        [SerializeField] private int _particleCount = 40;
        [SerializeField] private float _minSize = 4f;
        [SerializeField] private float _maxSize = 12f;
        [SerializeField] private float _minSpeed = 30f;
        [SerializeField] private float _maxSpeed = 80f;
        [SerializeField] private float _swayAmount = 20f;
        [SerializeField] private float _minAlpha = 0.2f;
        [SerializeField] private float _maxAlpha = 0.7f;

        private RectTransform _container;
        private List<RectTransform> _particles = new List<RectTransform>();
        private List<float> _speeds = new List<float>();
        private List<float> _swayOffsets = new List<float>();
        private float _containerHeight;
        private float _containerWidth;

        void Awake()
        {
            _container = GetComponent<RectTransform>();
        }

        void Start()
        {
            _containerHeight = _container.rect.height;
            _containerWidth = _container.rect.width;

            for (int i = 0; i < _particleCount; i++)
            {
                CreateParticle(true);
            }
        }

        void Update()
        {
            _containerHeight = _container.rect.height;
            _containerWidth = _container.rect.width;

            for (int i = 0; i < _particles.Count; i++)
            {
                var p = _particles[i];
                float speed = _speeds[i];
                float sway = Mathf.Sin(Time.time * 0.5f + _swayOffsets[i]) * _swayAmount;

                Vector2 pos = p.anchoredPosition;
                pos.y -= speed * Time.deltaTime;
                pos.x += sway * Time.deltaTime;

                // Reset when off screen
                if (pos.y < -_containerHeight * 0.5f - 20f)
                {
                    pos.y = _containerHeight * 0.5f + 20f;
                    pos.x = Random.Range(-_containerWidth * 0.5f, _containerWidth * 0.5f);
                }

                p.anchoredPosition = pos;
            }
        }

        private void CreateParticle(bool randomY)
        {
            var go = new GameObject("Snow");
            go.transform.SetParent(_container, false);

            var rt = go.AddComponent<RectTransform>();
            go.AddComponent<CanvasRenderer>();
            var img = go.AddComponent<Image>();
            img.color = new Color(1f, 1f, 1f, Random.Range(_minAlpha, _maxAlpha));
            img.raycastTarget = false;

            float size = Random.Range(_minSize, _maxSize);
            rt.sizeDelta = new Vector2(size, size);
            rt.anchorMin = new Vector2(0.5f, 0.5f);
            rt.anchorMax = new Vector2(0.5f, 0.5f);
            rt.pivot = new Vector2(0.5f, 0.5f);

            float x = Random.Range(-_containerWidth * 0.5f, _containerWidth * 0.5f);
            float y = randomY
                ? Random.Range(-_containerHeight * 0.5f, _containerHeight * 0.5f)
                : _containerHeight * 0.5f + 20f;
            rt.anchoredPosition = new Vector2(x, y);

            _particles.Add(rt);
            _speeds.Add(Random.Range(_minSpeed, _maxSpeed));
            _swayOffsets.Add(Random.Range(0f, Mathf.PI * 2f));
        }
    }
}
