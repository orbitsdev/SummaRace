using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace SummaRace.UI
{
    /// <summary>
    /// Provides visual and haptic feedback when a button is pressed.
    /// Attach to any UI Button for press-scale effect and optional haptics.
    /// </summary>
    public class ButtonPressFeedback : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Header("Scale Animation")]
        [SerializeField] private float _pressedScale = 0.95f;
        [SerializeField] private float _duration = 0.1f;

        [Header("Haptics")]
        [SerializeField] private bool _enableHaptics = true;

        private Vector3 _originalScale;
        private Coroutine _scaleCoroutine;
        private bool _isPressed;

        void Awake()
        {
            _originalScale = transform.localScale;
        }

        void OnEnable()
        {
            // Reset scale when re-enabled
            transform.localScale = _originalScale;
            _isPressed = false;
        }

        void OnDisable()
        {
            if (_scaleCoroutine != null)
            {
                StopCoroutine(_scaleCoroutine);
                _scaleCoroutine = null;
            }
            transform.localScale = _originalScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_isPressed) return;
            _isPressed = true;

            if (_scaleCoroutine != null)
                StopCoroutine(_scaleCoroutine);

            _scaleCoroutine = StartCoroutine(AnimateScale(_originalScale * _pressedScale));

            if (_enableHaptics)
                TriggerHaptic();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isPressed) return;
            _isPressed = false;

            if (_scaleCoroutine != null)
                StopCoroutine(_scaleCoroutine);

            _scaleCoroutine = StartCoroutine(AnimateScale(_originalScale));
        }

        private IEnumerator AnimateScale(Vector3 targetScale)
        {
            Vector3 startScale = transform.localScale;
            float elapsed = 0f;

            while (elapsed < _duration)
            {
                elapsed += Time.unscaledDeltaTime;
                float t = Mathf.Clamp01(elapsed / _duration);
                // Ease out cubic for snappy feel
                float eased = 1f - Mathf.Pow(1f - t, 3f);
                transform.localScale = Vector3.Lerp(startScale, targetScale, eased);
                yield return null;
            }

            transform.localScale = targetScale;
            _scaleCoroutine = null;
        }

        private void TriggerHaptic()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            // Light vibration for button feedback
            try
            {
                using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                using (var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                using (var vibrator = activity.Call<AndroidJavaObject>("getSystemService", "vibrator"))
                {
                    if (vibrator != null)
                    {
                        // API 26+ uses VibrationEffect
                        using (var vibrationEffect = new AndroidJavaClass("android.os.VibrationEffect"))
                        {
                            var effect = vibrationEffect.CallStatic<AndroidJavaObject>(
                                "createOneShot", 15L, 100); // 15ms, medium amplitude
                            vibrator.Call("vibrate", effect);
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                // Fallback to simple vibrate if VibrationEffect not available
                Handheld.Vibrate();
            }
#elif UNITY_IOS && !UNITY_EDITOR
            // iOS haptic feedback - light impact
            // Note: Requires iOS 10+ and actual device
            Handheld.Vibrate();
#endif
        }

        /// <summary>
        /// Enable or disable haptic feedback at runtime
        /// </summary>
        public void SetHapticsEnabled(bool enabled)
        {
            _enableHaptics = enabled;
        }
    }
}
