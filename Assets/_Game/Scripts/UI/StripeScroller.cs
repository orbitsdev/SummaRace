using UnityEngine;
using UnityEngine.UI;

namespace SummaRace.UI
{
    /// <summary>
    /// Scrolls a tiled UI image to create animated stripe effect.
    /// </summary>
    public class StripeScroller : MonoBehaviour
    {
        [SerializeField] private float _scrollSpeed = 30f;
        
        private RectTransform _rt;
        private float _offset;

        void Awake()
        {
            _rt = GetComponent<RectTransform>();
        }

        void Update()
        {
            _offset += _scrollSpeed * Time.deltaTime;
            if (_rt != null)
            {
                _rt.anchoredPosition = new Vector2(_offset % 32f, 0f);
            }
        }
    }
}
