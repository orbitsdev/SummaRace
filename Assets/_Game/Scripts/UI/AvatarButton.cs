using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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
        [SerializeField] private Color _inactiveColor = new Color(0.808f, 0.796f, 0.965f);
        [SerializeField] private Color _activeColor = new Color(0.686f, 0.663f, 0.925f);

        public event Action<int> OnSelected;

        private bool _isSelected;

        public void Initialize()
        {
            var button = GetComponent<Button>();
            if (button != null)
                button.onClick.AddListener(OnTapped);

            SetSelected(false);
        }

        private void OnTapped()
        {
            OnSelected?.Invoke(avatarIndex);
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;

            if (_avatarBackground != null)
                _avatarBackground.color = selected ? _activeColor : _inactiveColor;

            if (_selectionRing != null)
                _selectionRing.gameObject.SetActive(selected);

            transform.localScale = selected ? Vector3.one * 1.1f : Vector3.one;
        }
    }
}
