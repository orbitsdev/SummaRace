using UnityEngine;

namespace SummaRace.UI
{
    /// <summary>
    /// Adjusts RectTransform to respect device safe area (notches, dynamic islands, etc.)
    /// Attach to a full-screen UI element that should avoid unsafe regions.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaFitter : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Rect _lastSafeArea;
        private Vector2Int _lastScreenSize;
        private ScreenOrientation _lastOrientation;

        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        void Start()
        {
            ApplySafeArea();
        }

        void Update()
        {
            if (HasScreenChanged())
            {
                ApplySafeArea();
            }
        }

        private bool HasScreenChanged()
        {
            return Screen.safeArea != _lastSafeArea ||
                   Screen.width != _lastScreenSize.x ||
                   Screen.height != _lastScreenSize.y ||
                   Screen.orientation != _lastOrientation;
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;

            _lastSafeArea = safeArea;
            _lastScreenSize = new Vector2Int(Screen.width, Screen.height);
            _lastOrientation = Screen.orientation;

            if (Screen.width == 0 || Screen.height == 0)
                return;

            // Convert safe area to anchor coordinates (0-1 range)
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }

#if UNITY_EDITOR
        [ContextMenu("Simulate iPhone Notch")]
        private void SimulateNotch()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchorMin = new Vector2(0f, 0.034f);
            _rectTransform.anchorMax = new Vector2(1f, 0.96f);
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }

        [ContextMenu("Reset Safe Area")]
        private void ResetSafeArea()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = Vector2.one;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
        }
#endif
    }
}
