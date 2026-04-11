# Scene 01 (Name Entry) Visual Overhaul — Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Transform Scene 01 from a flat blue rectangle with basic UI into a fully layered Arctic Adventure scene using existing plugin assets (Cartoon UI, Kenney Nature Kit) with snow particles, bouncy animations, and kid-friendly visual polish.

**Architecture:** The scene keeps its existing `NameEntryController.cs` and `AvatarButton.cs` logic intact. We add layered background GameObjects, replace plain UI sprites with Cartoon UI assets, enhance `AvatarButton` with bounce animations, and add a staggered entrance animation controller. All changes are visual — game logic stays the same.

**Tech Stack:** Unity 6 (URP), Cartoon UI plugin, Kenney Nature Kit (side-view sprites), existing UISnowParticles.cs, coroutine-based animations (no DOTween dependency — add later as enhancement).

**Reference:** `Documentation/SUMMARACE_VISUAL_THEME.md` for full color specs, layer system, animation timing.

---

## File Map

| Action | File | Responsibility |
|--------|------|---------------|
| Create | `Assets/_Game/Scripts/UI/SceneEntranceAnimator.cs` | Staggered entrance animations for any 2D scene |
| Create | `Assets/_Game/Scripts/Data/ThemeColors.cs` | ScriptableObject holding the Arctic Adventure palette |
| Create | `Assets/_Game/Resources/ThemeColors.asset` | Instance of ThemeColors with all color values |
| Modify | `Assets/_Game/Scripts/UI/AvatarButton.cs` | Add bounce animation on tap, gold ring color for selected |
| Modify | `Assets/_Game/Scripts/UI/NameEntryController.cs` | Wire up SceneEntranceAnimator, use ThemeColors, button pulse |
| Modify | `Assets/_Game/Scenes/01_NameEntry.unity` | Rebuild hierarchy with layers, Cartoon UI sprites, Kenney trees |

---

## Task 1: Create ThemeColors ScriptableObject

**Files:**
- Create: `Assets/_Game/Scripts/Data/ThemeColors.cs`

This centralizes all Arctic Adventure colors so they're not hardcoded in scripts. Reusable across all scenes.

- [ ] **Step 1: Create ThemeColors.cs**

```csharp
using UnityEngine;

namespace SummaRace.Data
{
    [CreateAssetMenu(fileName = "ThemeColors", menuName = "SummaRace/Theme Colors")]
    public class ThemeColors : ScriptableObject
    {
        [Header("Primary Palette")]
        public Color skyDark = new Color(0.051f, 0.278f, 0.631f);     // #0D47A1
        public Color skyMid = new Color(0.259f, 0.647f, 0.961f);      // #42A5F5
        public Color skyLight = new Color(0.529f, 0.808f, 0.922f);    // #87CEEB
        public Color ice = new Color(0.878f, 0.941f, 1.0f);           // #E0F0FF
        public Color snow = Color.white;
        public Color frost = new Color(0.690f, 0.769f, 0.871f);       // #B0C4DE

        [Header("Feedback")]
        public Color correct = new Color(0.0f, 0.749f, 0.647f);       // #00BFA5
        public Color wrong = new Color(0.937f, 0.325f, 0.314f);       // #EF5350
        public Color highlight = new Color(1.0f, 0.843f, 0.0f);       // #FFD700
        public Color disabled = new Color(0.690f, 0.745f, 0.773f);    // #B0BEC5

        [Header("Scene 01 Accent")]
        public Color accent = new Color(0.482f, 0.408f, 0.933f);      // #7B68EE (purple)

        [Header("Avatar Colors")]
        public Color avatarFox = new Color(1.0f, 0.541f, 0.396f);     // #FF8A65
        public Color avatarFrog = new Color(0.506f, 0.780f, 0.518f);  // #81C784
        public Color avatarDog = new Color(0.565f, 0.792f, 0.976f);   // #90CAF9
        public Color avatarPig = new Color(0.957f, 0.561f, 0.694f);   // #F48FB1

        [Header("Button States")]
        public Color buttonActive = new Color(0.118f, 0.533f, 0.898f);  // #1E88E5
        public Color buttonDisabled = new Color(0.690f, 0.745f, 0.773f); // #B0BEC5
        public Color buttonText = Color.white;
    }
}
```

Write this file using MCP `script-update-or-create` tool to path `_Game/Scripts/Data/ThemeColors.cs`.

- [ ] **Step 2: Check console for compilation errors**

Use MCP `console-get-logs` to verify no errors.

- [ ] **Step 3: Create ThemeColors asset instance**

In Unity Editor: Right-click in `Assets/_Game/Resources/` → Create → SummaRace → Theme Colors. Name it `ThemeColors`. The default values are already set in the script — no manual color entry needed.

Alternatively use MCP `manage_scriptable_object` or `manage_asset` to create the asset at `_Game/Resources/ThemeColors.asset`.

- [ ] **Step 4: Commit**

```bash
git add Assets/_Game/Scripts/Data/ThemeColors.cs Assets/_Game/Resources/ThemeColors*
git commit -m "feat: add ThemeColors ScriptableObject for Arctic Adventure palette"
```

---

## Task 2: Create SceneEntranceAnimator

**Files:**
- Create: `Assets/_Game/Scripts/UI/SceneEntranceAnimator.cs`

A reusable component that plays staggered entrance animations on a list of CanvasGroups/RectTransforms. Attach to any scene's Canvas and assign elements in order of appearance.

- [ ] **Step 1: Create SceneEntranceAnimator.cs**

```csharp
using UnityEngine;
using System;
using System.Collections;

namespace SummaRace.UI
{
    public class SceneEntranceAnimator : MonoBehaviour
    {
        [Serializable]
        public class AnimatedElement
        {
            public RectTransform target;
            public AnimationType type = AnimationType.FadeAndScale;
            public float delay;
            public float duration = 0.4f;
        }

        public enum AnimationType
        {
            FadeAndScale,   // Scale 0.8→1.05→1.0 + fade in
            SlideDown,      // From above + fade in
            SlideUp,        // From below + fade in
            ScaleBounce,    // Scale 0→1.2→0.95→1.0 (for avatars)
            FadeOnly        // Just alpha 0→1
        }

        [SerializeField] private AnimatedElement[] _elements;
        [SerializeField] private float _globalDelay = 0.3f;

        void Start()
        {
            // Hide all elements initially
            foreach (var elem in _elements)
            {
                if (elem.target == null) continue;
                var cg = GetOrAddCanvasGroup(elem.target);
                cg.alpha = 0f;
                if (elem.type == AnimationType.ScaleBounce)
                    elem.target.localScale = Vector3.zero;
                else if (elem.type == AnimationType.FadeAndScale)
                    elem.target.localScale = Vector3.one * 0.8f;
            }

            StartCoroutine(PlayEntrance());
        }

        private IEnumerator PlayEntrance()
        {
            yield return new WaitForSeconds(_globalDelay);

            foreach (var elem in _elements)
            {
                if (elem.target == null) continue;
                if (elem.delay > 0f)
                    yield return new WaitForSeconds(elem.delay);

                StartCoroutine(AnimateElement(elem));
            }
        }

        private IEnumerator AnimateElement(AnimatedElement elem)
        {
            var cg = GetOrAddCanvasGroup(elem.target);
            float elapsed = 0f;
            float dur = elem.duration;

            Vector2 startPos = elem.target.anchoredPosition;
            Vector2 offsetPos = startPos;

            if (elem.type == AnimationType.SlideDown)
                offsetPos = startPos + new Vector2(0, 60f);
            else if (elem.type == AnimationType.SlideUp)
                offsetPos = startPos - new Vector2(0, 60f);

            if (elem.type == AnimationType.SlideDown || elem.type == AnimationType.SlideUp)
                elem.target.anchoredPosition = offsetPos;

            while (elapsed < dur)
            {
                elapsed += Time.deltaTime;
                float t = Mathf.Clamp01(elapsed / dur);

                // Ease out back for bounce feel
                float eased = EaseOutBack(t);

                // Alpha always fades in linearly (capped at 1)
                cg.alpha = Mathf.Clamp01(t * 2f); // Reaches 1 at halfway

                switch (elem.type)
                {
                    case AnimationType.FadeAndScale:
                        // 0.8 → 1.05 → 1.0
                        float scale = Mathf.LerpUnclamped(0.8f, 1f, eased);
                        elem.target.localScale = Vector3.one * scale;
                        break;

                    case AnimationType.ScaleBounce:
                        // 0 → 1.2 → 0.95 → 1.0
                        float bounceScale = EaseBounceScale(t);
                        elem.target.localScale = Vector3.one * bounceScale;
                        break;

                    case AnimationType.SlideDown:
                    case AnimationType.SlideUp:
                        elem.target.anchoredPosition = Vector2.LerpUnclamped(offsetPos, startPos, eased);
                        break;

                    case AnimationType.FadeOnly:
                        // Alpha handled above
                        break;
                }

                yield return null;
            }

            // Ensure final state
            cg.alpha = 1f;
            elem.target.localScale = Vector3.one;
            if (elem.type == AnimationType.SlideDown || elem.type == AnimationType.SlideUp)
                elem.target.anchoredPosition = startPos;
        }

        private float EaseOutBack(float t)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1f;
            return 1f + c3 * Mathf.Pow(t - 1f, 3f) + c1 * Mathf.Pow(t - 1f, 2f);
        }

        private float EaseBounceScale(float t)
        {
            if (t < 0.4f)
                return Mathf.Lerp(0f, 1.2f, t / 0.4f);
            else if (t < 0.7f)
                return Mathf.Lerp(1.2f, 0.95f, (t - 0.4f) / 0.3f);
            else
                return Mathf.Lerp(0.95f, 1f, (t - 0.7f) / 0.3f);
        }

        private CanvasGroup GetOrAddCanvasGroup(RectTransform rt)
        {
            var cg = rt.GetComponent<CanvasGroup>();
            if (cg == null)
                cg = rt.gameObject.AddComponent<CanvasGroup>();
            return cg;
        }
    }
}
```

Write using MCP `script-update-or-create` to `_Game/Scripts/UI/SceneEntranceAnimator.cs`.

- [ ] **Step 2: Check console for compilation**

Use MCP `console-get-logs` to verify clean compilation.

- [ ] **Step 3: Commit**

```bash
git add Assets/_Game/Scripts/UI/SceneEntranceAnimator.cs
git commit -m "feat: add SceneEntranceAnimator for staggered entrance animations"
```

---

## Task 3: Update AvatarButton with bounce animation and theme colors

**Files:**
- Modify: `Assets/_Game/Scripts/UI/AvatarButton.cs`

Add a coroutine-based bounce animation on tap and use gold highlight for selected ring.

- [ ] **Step 1: Update AvatarButton.cs**

Replace the full file with:

```csharp
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
            // Bounce: 1.0 → 1.25 → 0.9 → 1.1 (selected) or 1.0 (unselected)
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
```

Write using MCP `script-update-or-create` to `_Game/Scripts/UI/AvatarButton.cs`.

- [ ] **Step 2: Check console for compilation**

Use MCP `console-get-logs`.

- [ ] **Step 3: Commit**

```bash
git add Assets/_Game/Scripts/UI/AvatarButton.cs
git commit -m "feat: add bounce animation and gold ring to AvatarButton"
```

---

## Task 4: Update NameEntryController with theme colors and button pulse

**Files:**
- Modify: `Assets/_Game/Scripts/UI/NameEntryController.cs`

Update the hardcoded purple/gray colors to use the Arctic Adventure skyblue palette. Add a gentle pulse animation on the Continue button when active.

- [ ] **Step 1: Update NameEntryController.cs**

Replace the full file with:

```csharp
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

namespace SummaRace.UI
{
    public class NameEntryController : MonoBehaviour
    {
        [Header("UI References")]
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Button _continueButton;
        [SerializeField] private Image _continueButtonBg;
        [SerializeField] private TextMeshProUGUI _validationMessage;
        [SerializeField] private CanvasGroup _fadeOverlay;

        [Header("Avatar Buttons")]
        [SerializeField] private AvatarButton[] _avatarButtons;

        [Header("Colors")]
        [SerializeField] private Color _buttonActiveColor = new Color(0.118f, 0.533f, 0.898f);   // #1E88E5
        [SerializeField] private Color _buttonDisabledColor = new Color(0.690f, 0.745f, 0.773f); // #B0BEC5

        [Header("Validation")]
        [SerializeField] private int _maxNameLength = 15;

        [Header("Next Scene")]
        [SerializeField] private string _nextSceneName = "02_TeacherWelcome";

        private int _selectedAvatarIndex;
        private bool _isTransitioning;
        private Coroutine _pulseCoroutine;

        void Start()
        {
            if (_nameInputField != null)
            {
                _nameInputField.characterLimit = _maxNameLength;
                _nameInputField.onValueChanged.AddListener(HandleNameChanged);
            }

            for (int i = 0; i < _avatarButtons.Length; i++)
            {
                _avatarButtons[i].Initialize();
                _avatarButtons[i].OnSelected += HandleAvatarSelected;
            }

            if (_continueButton != null)
                _continueButton.onClick.AddListener(HandleContinueClicked);

            if (_validationMessage != null)
                _validationMessage.gameObject.SetActive(false);

            _selectedAvatarIndex = PlayerPrefs.GetInt("selectedAvatar", 0);
            if (PlayerPrefs.HasKey("playerName") && _nameInputField != null)
                _nameInputField.text = PlayerPrefs.GetString("playerName", "");

            HandleAvatarSelected(_selectedAvatarIndex);
            UpdateButtonVisual();

            if (_fadeOverlay != null)
            {
                _fadeOverlay.alpha = 1f;
                StartCoroutine(AnimateFade(1f, 0f, 0.5f));
            }
        }

        private void HandleNameChanged(string text)
        {
            if (_validationMessage != null)
                _validationMessage.gameObject.SetActive(false);
            UpdateButtonVisual();
        }

        private void HandleAvatarSelected(int index)
        {
            _selectedAvatarIndex = index;
            for (int i = 0; i < _avatarButtons.Length; i++)
                _avatarButtons[i].SetSelected(i == index);
            UpdateButtonVisual();
        }

        private void HandleContinueClicked()
        {
            if (_isTransitioning) return;

            string playerName = _nameInputField != null ? _nameInputField.text.Trim() : "";
            if (string.IsNullOrEmpty(playerName))
            {
                if (_validationMessage != null)
                {
                    _validationMessage.text = "Please type your name first!";
                    _validationMessage.gameObject.SetActive(true);
                }
                return;
            }

            if (playerName.Length > 0)
                playerName = char.ToUpper(playerName[0]) + playerName.Substring(1);

            PlayerPrefs.SetString("playerName", playerName);
            PlayerPrefs.SetInt("selectedAvatar", _selectedAvatarIndex);
            PlayerPrefs.SetInt("hasCompletedNameEntry", 1);
            PlayerPrefs.Save();

            _isTransitioning = true;
            StartCoroutine(DoTransitionOut());
        }

        private void UpdateButtonVisual()
        {
            string text = _nameInputField != null ? _nameInputField.text.Trim() : "";
            bool canContinue = !string.IsNullOrEmpty(text);

            if (_continueButtonBg != null)
                _continueButtonBg.color = canContinue ? _buttonActiveColor : _buttonDisabledColor;
            if (_continueButton != null)
                _continueButton.interactable = canContinue;

            // Start or stop pulse animation
            if (canContinue && _pulseCoroutine == null)
                _pulseCoroutine = StartCoroutine(PulseButton());
            else if (!canContinue && _pulseCoroutine != null)
            {
                StopCoroutine(_pulseCoroutine);
                _pulseCoroutine = null;
                if (_continueButton != null)
                    _continueButton.transform.localScale = Vector3.one;
            }
        }

        private IEnumerator PulseButton()
        {
            Transform btn = _continueButton.transform;
            while (true)
            {
                // Scale 1.0 → 1.04 → 1.0 over 1.5s
                float elapsed = 0f;
                float duration = 1.5f;
                while (elapsed < duration)
                {
                    elapsed += Time.deltaTime;
                    float t = elapsed / duration;
                    float scale = 1f + 0.04f * Mathf.Sin(t * Mathf.PI);
                    btn.localScale = Vector3.one * scale;
                    yield return null;
                }
                btn.localScale = Vector3.one;
            }
        }

        private IEnumerator DoTransitionOut()
        {
            // Stop pulse
            if (_pulseCoroutine != null)
            {
                StopCoroutine(_pulseCoroutine);
                _pulseCoroutine = null;
            }

            if (_fadeOverlay != null)
            {
                _fadeOverlay.blocksRaycasts = true;
                yield return StartCoroutine(AnimateFade(0f, 1f, 0.3f));
            }
            SceneManager.LoadScene(_nextSceneName);
        }

        private IEnumerator AnimateFade(float from, float to, float duration)
        {
            if (_fadeOverlay == null) yield break;
            _fadeOverlay.alpha = from;
            float elapsed = 0f;
            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                _fadeOverlay.alpha = Mathf.Lerp(from, to, elapsed / duration);
                yield return null;
            }
            _fadeOverlay.alpha = to;
            _fadeOverlay.blocksRaycasts = to > 0.5f;
        }
    }
}
```

Write using MCP `script-update-or-create` to `_Game/Scripts/UI/NameEntryController.cs`.

- [ ] **Step 2: Check console for compilation**

Use MCP `console-get-logs`.

- [ ] **Step 3: Commit**

```bash
git add Assets/_Game/Scripts/UI/NameEntryController.cs
git commit -m "feat: update NameEntryController with Arctic theme colors and button pulse"
```

---

## Task 5: Rebuild Scene 01 hierarchy with layered background

**Files:**
- Modify: `Assets/_Game/Scenes/01_NameEntry.unity` (via Unity Editor / MCP tools)

This is the big visual task. We rebuild the scene hierarchy to add background layers using Kenney and Cartoon UI assets. This task is done primarily through MCP tools manipulating the scene.

**Target hierarchy:**

```
01_NameEntry
├── Main Camera
├── Canvas_Background          (Render Mode: Screen Space - Overlay, Sort Order: 0)
│   ├── BG_Sky                 (Image: gradient sky blue #4A90D9 → #D4EAFF)
│   ├── BG_Clouds              (Container for 2-3 cloud images)
│   │   ├── Cloud_1            (Image: white ellipse, alpha 0.7)
│   │   └── Cloud_2            (Image: white ellipse, alpha 0.5)
│   ├── BG_Mountains           (Container)
│   │   ├── Mountain_1         (Image: triangular shape, #9EC5E0, alpha 0.6)
│   │   ├── Mountain_2         (Image: triangular shape, #8BB8D8, alpha 0.5)
│   │   └── Mountain_3         (Image: triangular shape, #9EC5E0, alpha 0.6)
│   ├── BG_Trees               (Container for Kenney pine sprites)
│   │   ├── Tree_Left_1        (Image: tree_pineDefaultA.png)
│   │   ├── Tree_Left_2        (Image: tree_pineSmallA.png)
│   │   ├── Tree_Right_1       (Image: tree_pineTallA.png)
│   │   └── Tree_Right_2       (Image: tree_pineSmallB.png)
│   ├── BG_SnowGround          (Image: white/ice ellipse at bottom)
│   └── BG_SnowParticles       (UISnowParticles component)
│
├── Canvas_NameEntry           (Render Mode: Screen Space - Overlay, Sort Order: 1)
│   ├── Panel_Main             (Image: Cartoon UI "Panel Light" sprite, center)
│   │   ├── Text_Question      ("What's your name, runner?" Fredoka Bold 28px #0D47A1)
│   │   ├── InputField_Name    (TMP InputField with Cartoon UI panel border)
│   │   ├── Text_AvatarSubtitle ("Pick your avatar" Fredoka 18px #42A5F5)
│   │   ├── Group_Avatars      (HorizontalLayoutGroup)
│   │   │   ├── Avatar_Fox     (Cartoon UI Circle Orange + Icons/fox)
│   │   │   ├── Avatar_Frog    (Cartoon UI Circle Green + Icons/frog)
│   │   │   ├── Avatar_Dog     (Cartoon UI Circle Skyblue + Icons/Dog)
│   │   │   └── Avatar_Pig     (Cartoon UI Circle Pink + Icons/Pig)
│   │   └── Button_Continue    (Cartoon UI "Long Round Skyblue" sprite)
│   ├── Text_ValidationMessage (Hidden by default)
│   └── FadeOverlay            (CanvasGroup, black Image, blocks raycasts)
│
├── NameEntryManager           (NameEntryController.cs)
│   └── SceneEntranceAnimator  (SceneEntranceAnimator.cs — or on Canvas_NameEntry)
│
├── EventSystem
└── Group_Audio
    ├── AudioSource_Music
    └── AudioSource_SFX
```

- [ ] **Step 1: Open Scene 01**

Use MCP `scene-open` or `assets-find` to find and open `01_NameEntry.unity`.

- [ ] **Step 2: Create Canvas_Background**

Create a new Canvas GameObject named `Canvas_Background`:
- Render Mode: Screen Space - Overlay
- Sort Order: 0 (renders behind the UI canvas)
- Canvas Scaler: Scale With Screen Size, Reference Resolution 1080×1920

Use MCP `gameobject-create` and `gameobject-component-add` / `gameobject-component-modify`.

- [ ] **Step 3: Create sky gradient background**

Create `BG_Sky` under Canvas_Background:
- RectTransform: Stretch to fill (anchors 0,0 to 1,1)
- Image component with color `#87CEEB` (sky blue)
- This is a solid color for now; gradient can be achieved with a simple gradient texture or a UI shader later

- [ ] **Step 4: Create cloud objects**

Create `BG_Clouds` container under Canvas_Background, then 2 child Images:
- `Cloud_1`: White circle/ellipse image, anchored upper-left area, alpha 0.7, size ~200×60
- `Cloud_2`: White circle/ellipse image, anchored upper-right area, alpha 0.5, size ~150×50

For cloud shapes, use a simple white circle sprite (Unity default or create one). Set Image Type to Simple.

- [ ] **Step 5: Create mountain silhouettes**

Create `BG_Mountains` container, then 3 child Images:
- Use triangle/mountain shapes. For quick setup, create 3 Image objects with a white triangle sprite, tinted to `#9EC5E0` (mountain 1, 3) and `#8BB8D8` (mountain 2)
- Position: anchored to bottom-center area, overlapping, different heights
- Alpha: 0.5–0.6

If no triangle sprite exists, use a simple white sprite rotated, or create a mountain sprite.

- [ ] **Step 6: Add Kenney pine trees**

Find Kenney side-view tree sprites:
- Use MCP `assets-find` with filter `tree_pineDefault` to locate tree sprites
- Create `BG_Trees` container under Canvas_Background
- Add 4 Image children using these Kenney sprites:
  - `Tree_Left_1`: `tree_pineDefaultA.png`, anchored bottom-left, size ~150×250
  - `Tree_Left_2`: `tree_pineSmallA.png`, anchored bottom-left (offset right), size ~100×180
  - `Tree_Right_1`: `tree_pineTallA.png`, anchored bottom-right, size ~120×280
  - `Tree_Right_2`: `tree_pineSmallB.png`, anchored bottom-right (offset left), size ~90×160
- Set Preserve Aspect Ratio on all tree images

- [ ] **Step 7: Create snow ground**

Create `BG_SnowGround` under Canvas_Background:
- Image with white color
- Anchored to bottom of screen
- Height: ~300px (covers bottom ~15% of screen)
- Top edge should be curved — use a sprite with curved top edge, or position it so only the flat area shows
- For quick setup: use a white Image with anchors at bottom, stretched horizontally

- [ ] **Step 8: Add snow particles**

Create `BG_SnowParticles` under Canvas_Background:
- RectTransform: Stretch to fill entire canvas
- Add `UISnowParticles` component (already exists in project)
- Settings: particleCount=40, minSize=3, maxSize=10, minSpeed=25, maxSpeed=60, minAlpha=0.3, maxAlpha=0.7

- [ ] **Step 9: Update existing Canvas_NameEntry**

Set existing Canvas_NameEntry Sort Order to 1 (so it renders above Canvas_Background).

- [ ] **Step 10: Replace Continue button visuals with Cartoon UI**

Find the Cartoon UI Long Round Skyblue sprite:
- Use MCP `assets-find` with filter `Long Round Skyblue`
- Replace the Continue button's Image source sprite with this Cartoon UI sprite
- Set Image Type to Sliced (9-slice) if the sprite supports it
- Keep the existing Button component and text

- [ ] **Step 11: Replace avatar background circles with Cartoon UI**

For each avatar (Fox, Frog, Dog, Pig):
- Find Cartoon UI circle sprites: `Circle Orange`, `Circle Green`, `Circle Skyblue`, `Circle Pink`
- Use MCP `assets-find` with filter `Circle Orange` etc.
- Replace each avatar's `_avatarBackground` Image source sprite with the matching Cartoon UI circle sprite
- Replace each avatar's `_avatarIcon` Image with the Cartoon UI animal icon:
  - Fox: `assets-find` filter `fox` in Cartoon UI Icons folder
  - Frog: `assets-find` filter `frog`
  - Dog: `assets-find` filter `Dog`
  - Pig: `assets-find` filter `Pig`

- [ ] **Step 12: Update text colors to Arctic theme**

Update all text elements in the scene:
- Question text: Color `#0D47A1` (Sky Dark), Fredoka Bold 28px
- Subtitle text: Color `#42A5F5` (Sky Mid), Fredoka Regular 18px
- Input field text: Color `#0D47A1`
- Input placeholder: Color `#B0C4DE` (Frost)
- Validation message: Color `#EF5350` (Wrong/Error)
- Avatar labels: Color `#0D47A1`, Fredoka 12px
- Button text: White

- [ ] **Step 13: Add SceneEntranceAnimator**

Add `SceneEntranceAnimator` component to `NameEntryManager` (or Canvas_NameEntry):
- Assign elements in order:
  1. `Panel_Main` — FadeAndScale, delay 0.0s, duration 0.4s
  2. `Text_Question` — SlideDown, delay 0.15s, duration 0.35s
  3. `InputField_Name` — FadeAndScale, delay 0.1s, duration 0.3s
  4. `Text_AvatarSubtitle` — FadeOnly, delay 0.1s, duration 0.25s
  5. `Avatar_Fox` — ScaleBounce, delay 0.05s, duration 0.3s
  6. `Avatar_Frog` — ScaleBounce, delay 0.08s, duration 0.3s
  7. `Avatar_Dog` — ScaleBounce, delay 0.08s, duration 0.3s
  8. `Avatar_Pig` — ScaleBounce, delay 0.08s, duration 0.3s
  9. `Button_Continue` — FadeAndScale, delay 0.1s, duration 0.3s

- [ ] **Step 14: Update Inspector values on NameEntryController**

On the `NameEntryManager` GameObject's `NameEntryController` component:
- Set `_buttonActiveColor` to `#1E88E5` (RGB: 0.118, 0.533, 0.898)
- Set `_buttonDisabledColor` to `#B0BEC5` (RGB: 0.690, 0.745, 0.773)

On each `AvatarButton` component:
- Set `_inactiveColor` to `#E0F0FF` (RGB: 0.878, 0.941, 1.0)
- Set `_activeColor` to `#87CEEB` (RGB: 0.529, 0.808, 0.922)
- Set `_ringColor` to `#FFD700` (RGB: 1.0, 0.843, 0.0)

- [ ] **Step 15: Save scene**

Use MCP `scene-save` to save the scene.

- [ ] **Step 16: Commit**

```bash
git add -A
git commit -m "feat: rebuild Scene 01 with Arctic Adventure layered background and Cartoon UI"
```

---

## Task 6: Visual verification and polish

**Files:**
- Modify: `Assets/_Game/Scenes/01_NameEntry.unity` (adjustments only)

- [ ] **Step 1: Enter Play Mode and take screenshot**

Use MCP `editor-application-set-state` to enter play mode, then `screenshot-game-view` to capture the result.

- [ ] **Step 2: Verify checklist**

Check against the quality checklist from the theme spec:
- [ ] Background has 5+ layers (sky, mountains, trees, snow, particles)
- [ ] All buttons use Cartoon UI sprites
- [ ] Snow particles are falling
- [ ] Text uses Fredoka font with dark blue color
- [ ] Avatar tap has bounce animation
- [ ] Continue button pulses when active
- [ ] Entrance animations are staggered
- [ ] Touch targets are minimum 80×80px

- [ ] **Step 3: Adjust positions/sizes as needed**

Based on the screenshot, adjust:
- Tree positions and sizes so they frame the UI nicely
- Snow ground height so it looks natural
- Cloud positions
- Mountain heights
- Panel size and position

- [ ] **Step 4: Exit Play Mode**

Use MCP `editor-application-set-state` to exit play mode.

- [ ] **Step 5: Save scene and final commit**

```bash
git add -A
git commit -m "polish: adjust Scene 01 visual layout and positions"
```

---

## Summary

| Task | What it does | Estimated effort |
|------|-------------|-----------------|
| 1 | ThemeColors ScriptableObject | 5 min |
| 2 | SceneEntranceAnimator script | 10 min |
| 3 | AvatarButton bounce + gold ring | 5 min |
| 4 | NameEntryController theme colors + pulse | 5 min |
| 5 | Rebuild Scene 01 hierarchy with layers | 30 min |
| 6 | Visual verification and polish | 15 min |

**Total: ~70 minutes**

Tasks 1–4 are script changes (can be done via MCP script tools). Task 5 is scene manipulation (MCP gameobject tools + manual Inspector adjustments). Task 6 is play-test and polish.
