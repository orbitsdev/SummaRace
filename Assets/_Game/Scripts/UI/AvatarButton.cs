using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;

namespace SummaRace.UI
{
    public class AvatarButton : MonoBehaviour
    {
        [Header("Identity")]
        public int avatarIndex;
        public string avatarName;

        [Header("Visuals")]
        [SerializeField] private Image _avatarBackground;
        [SerializeField] private Image _avatarIcon;
        [SerializeField] private Image _selectionRing;
        [SerializeField] private TextMeshProUGUI _label;

        [Header("Colors")]
        [SerializeField] private Color _inactiveColor = new Color(0.878f, 0.941f, 1.0f);  // Ice #E0F0FF
        [SerializeField] private Color _activeColor = new Color(0.529f, 0.808f, 0.922f);   // Sky light #87CEEB
        [SerializeField] private Color _ringColor = new Color(1.0f, 0.843f, 0.0f);         // Gold #FFD700

        public event Action<int> OnSelected;

        private bool _isSelected;
        private Coroutine _bounceCoroutine;

        public void Initialize()
        {
            var button = GetComponent<Button>();
            if (button != null)
                button.onClick.AddListener(OnTapped);

            SetSelected(false);
        }

        private void OnTapped()
        {
            if (_bounceCoroutine != null)
                StopCoroutine(_bounceCoroutine);
            _bounceCoroutine = StartCoroutine(PlayBounce());

            OnSelected?.Invoke(avatarIndex);
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;

            if (_avatarBackground != null)
                _avatarBackground.color = selected ? _activeColor : _inactiveColor;

            if (_selectionRing != null)
            {
                _selectionRing.gameObject.SetActive(selected);
                if (selected)
                    _selectionRing.color = _ringColor;
            }

            // Only set scale directly if not currently bouncing
            if (_bounceCoroutine == null)
                transform.localScale = selected ? Vector3.one * 1.1f : Vector3.one;
        }

        private IEnumerator PlayBounce()
        {
            float elapsed = 0f;
            float duration = 0.3f;
            float targetScale = _isSelected ? 1.1f : 1.0f;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / duration);
                float scale;

                if (t < 0.3f)
                    scale = Mathf.Lerp(1f, 1.25f, t / 0.3f);
                else if (t < 0.6f)
                    scale = Mathf.Lerp(1.25f, 0.9f, (t - 0.3f) / 0.3f);
                else
                    scale = Mathf.Lerp(0.9f, targetScale, (t - 0.6f) / 0.4f);

                transform.localScale = Vector3.one * scale;
                yield return null;
            }

            transform.localScale = Vector3.one * targetScale;
            _bounceCoroutine = null;
        }
    }
}
