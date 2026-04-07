# Scene 00 — Splash Screen

> **The first impression of SummaRace.** Shows the game logo, plays a welcome sound, hides loading time, and transitions to the Name Entry scene.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `00_Splash.unity` |
| **Type** | 2D |
| **Duration** | ~3 seconds (auto-advance) |
| **Next scene** | `01_NameEntry.unity` |
| **Previous scene** | None (first scene) |
| **Build complexity** | ⭐ Easy |
| **Estimated build time** | 2–3 hours |

---

## 🎯 Scene Purpose

The splash screen has **three jobs**:

1. 🎨 **Establish brand identity** — Show the SummaRace logo and tagline
2. ⏳ **Hide loading time** — Preload core systems and next scene in background
3. 🚀 **Transition smoothly** — Auto-advance to Name Entry after 3 seconds

---

## 👤 Player Experience (Step-by-Step)

| Time | What Player Sees | What Player Hears |
|---|---|---|
| **0.0s** | Black screen | Silence |
| **0.3s** | Snowy background fades in | Soft wind ambient |
| **0.6s** | SummaRace logo bounces in | Cheerful "ding!" |
| **1.0s** | Tagline fades in | Short jingle plays |
| **1.3s** | Decorative icon appears | Music continues |
| **1.5s** | Loading spinner appears | Music continues |
| **2.5s** | Loading complete, fade starts | Music finishes |
| **3.0s** | Fade to white, scene transitions | Whoosh sound |

**Total: ~3 seconds**

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│                                 │
│      ❄  ❄    ❄                  │  ← Optional snow particles
│                                 │
│         📚                      │  ← Decorative icon (80×80px)
│                                 │
│      SummaRace                  │  ← Logo (Fredoka Bold 64px)
│                                 │
│   Read. Run. Remember.          │  ← Tagline (Fredoka 18px)
│                                 │
│         ⟳ Loading...            │  ← Spinner + text
│                                 │
│                          v1.0   │  ← Version (corner)
└─────────────────────────────────┘
```

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Decorative icon | Center, Y+150 | 80×80 px | Center |
| Logo "SummaRace" | Center | 60% width | Center |
| Tagline | Center, Y−40 | Auto | Center |
| Loading spinner | Center bottom, Y−250 | 40×40 px | Bottom-center |
| Version "v1.0" | Bottom-right corner | Auto | Bottom-right |

---

## 🎨 Color Palette

| Element | Color | Hex |
|---|---|---|
| Background top | Light blue sky | `#B5D4F4` |
| Background bottom | Soft blue | `#E6F1FB` |
| Logo text | Deep navy | `#042C53` |
| Logo subtitle | Medium blue | `#185FA5` |
| Tagline text | Soft blue | `#185FA5` |
| Loading text | Light gray-blue | `#85B7EB` |
| Spinner color | Bright blue | `#378ADD` |
| Version text | Subtle gray | `#888780` |

---

## 📝 Text Content

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Subtitle | `LEARN BY RUNNING` | Fredoka | 14px | Regular, letter-spacing 2px |
| Logo | `SummaRace` | Fredoka | 64px | Bold |
| Tagline | `Read. Run. Remember.` | Fredoka | 18px | Regular |
| Loading text | `Loading...` | Fredoka | 14px | Regular |
| Version | `v1.0` | Fredoka | 10px | Regular |

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/splash_jingle.mp3` |
| **Duration** | 2.5 seconds |
| **Volume** | 0.6 |
| **Loop** | No |

**Source:** Search Pixabay for "logo intro" or "happy jingle"

### Sound Effects

| Trigger | File | Volume | When |
|---|---|---|---|
| Logo appears | `Audio/SFX/UI/logo_ding.wav` | 0.8 | At 0.6s |
| Scene transition | `Audio/SFX/UI/whoosh_soft.wav` | 0.5 | At 2.8s |

**Source:** Dustyroom Free Casual Game SFX Pack

### Ambient (Optional)

| File | Volume |
|---|---|
| `Audio/SFX/Ambient/snow_wind_soft.wav` | 0.2 |

---

## 🎬 Animations (Using DOTween)

| # | Element | Animation | Duration | Delay | Easing |
|---|---|---|---|---|---|
| 1 | Background | Fade in (0→1) | 0.5s | 0.0s | EaseOut |
| 2 | Decorative icon | Scale (0→1) + fade | 0.4s | 0.4s | EaseOutBack |
| 3 | Logo | Slide down + fade | 0.5s | 0.6s | EaseOutBack |
| 4 | Tagline | Fade in | 0.4s | 1.0s | EaseOut |
| 5 | Loading spinner | Fade in + rotate | 0.3s | 1.2s | EaseOut |
| 6 | Spinner rotation | Rotate Z 360° (looped) | 1.0s | continuous | Linear |
| 7 | All elements | Fade to white | 0.5s | 2.5s | EaseIn |

### DOTween Code Example

```csharp
backgroundImage.DOFade(1f, 0.5f);
iconImage.transform.DOScale(1f, 0.4f).SetDelay(0.4f).SetEase(Ease.OutBack);
logoText.transform.DOLocalMoveY(originalY, 0.5f).SetDelay(0.6f).SetEase(Ease.OutBack);
logoText.DOFade(1f, 0.5f).SetDelay(0.6f);
taglineText.DOFade(1f, 0.4f).SetDelay(1.0f);
spinnerImage.DOFade(1f, 0.3f).SetDelay(1.2f);

// Continuous rotation
spinnerImage.transform.DORotate(new Vector3(0, 0, -360f), 1f, RotateMode.FastBeyond360)
    .SetLoops(-1, LoopType.Restart)
    .SetEase(Ease.Linear);
```

---

## 🛠️ GameObject Hierarchy & Names

**Use these EXACT names** in Unity. Names matter for finding objects in code and keeping the scene organized.

```
SplashScene
│
├── Main Camera                          [Tag: MainCamera]
│
├── Canvas_Splash                        [Tag: Untagged]
│   │
│   ├── BG_Background                    [Tag: Untagged]
│   │   └── Image_BackgroundGradient
│   │
│   ├── Group_Content                    [Tag: Untagged]
│   │   ├── Image_DecorativeIcon         [Tag: Untagged]
│   │   ├── Text_Subtitle                [Tag: Untagged]
│   │   ├── Text_Logo                    [Tag: Untagged]
│   │   └── Text_Tagline                 [Tag: Untagged]
│   │
│   ├── Group_Loading                    [Tag: Untagged]
│   │   ├── Image_LoadingSpinner         [Tag: Untagged]
│   │   └── Text_Loading                 [Tag: Untagged]
│   │
│   └── Text_Version                     [Tag: Untagged]
│
├── EventSystem                          [Tag: Untagged] (auto-created)
│
├── Group_Audio                          [Tag: Untagged]
│   ├── AudioSource_Music                [Tag: AudioMusic]
│   ├── AudioSource_SFX                  [Tag: AudioSFX]
│   └── AudioSource_Ambient              [Tag: AudioAmbient]
│
└── SplashManager                        [Tag: GameManager]
    └── SplashController.cs (script)
```

### Naming Convention Used

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_Splash` |
| `BG_` | Background container | `BG_Background` |
| `Group_` | Container/holder | `Group_Content` |
| `Image_` | UI Image | `Image_LoadingSpinner` |
| `Text_` | TextMeshPro text | `Text_Logo` |
| `AudioSource_` | Audio source | `AudioSource_Music` |
| (no prefix) | Manager/script holder | `SplashManager` |

**Why these prefixes?** They make the hierarchy easy to scan. You instantly know what each object is.

---

## 🏷️ Tags Required

Tags are how scripts find specific GameObjects. Create these tags in Unity (Edit → Project Settings → Tags and Layers).

### Tags Needed for This Scene

| Tag | Purpose | Used By |
|---|---|---|
| `MainCamera` | Built-in tag for camera | Unity built-in |
| `GameManager` | Identifies the splash controller | Other scripts |
| `AudioMusic` | Music audio source | AudioManager |
| `AudioSFX` | SFX audio source | AudioManager |
| `AudioAmbient` | Ambient audio source | AudioManager |

### Project-Wide Tags (Create These Once)

While we're at it, here are ALL the tags you'll need across the whole game. Create them all on Day 1:

| Tag | Purpose | Scene |
|---|---|---|
| `MainCamera` | Camera identifier | All |
| `GameManager` | Singleton manager | All |
| `Player` | Player character | Scene 06 (3D run) |
| `AnswerCard` | Floating answer card | Scene 06 |
| `CorrectAnswer` | Correct answer card | Scene 06 |
| `WrongAnswer` | Wrong answer card | Scene 06 |
| `Checkpoint` | Question checkpoint | Scene 06 |
| `Obstacle` | Track obstacle | Scene 06 |
| `SnowPatrol` | Enemy patrol | Scene 06 |
| `FinishLine` | End of track | Scene 06 |
| `AudioMusic` | Music source | All |
| `AudioSFX` | SFX source | All |
| `AudioVoice` | Voice/narration source | Scenes 5, 6 |
| `AudioAmbient` | Ambient sound | All |
| `Teacher` | Ms. Lumi character | Scenes 2, 5, 7, 10 |
| `UICanvas` | Main canvas | All |
| `Avatar` | Player avatar | Scene 1 |

---

## 📚 Layers Required

Layers control rendering and physics. Create these via Edit → Project Settings → Tags and Layers.

### Layers for This Scene

| Layer | Number | Purpose |
|---|---|---|
| `Default` | 0 | Built-in (everything) |
| `UI` | 5 | Built-in (UI elements) |

### Project-Wide Layers (Create These Once)

| Layer | Suggested # | Purpose |
|---|---|---|
| `Default` | 0 | Built-in |
| `UI` | 5 | Built-in |
| `Player` | 8 | Player character (Scene 06) |
| `Track` | 9 | Track ground (Scene 06) |
| `Obstacles` | 10 | Track obstacles (Scene 06) |
| `AnswerCards` | 11 | Floating answer cards (Scene 06) |
| `Patrol` | 12 | Snow Patrol (Scene 06) |
| `Background` | 13 | Distant scenery (Scene 06) |

---

## 💻 Scripts Required

### Just ONE script for this scene:

#### `SplashController.cs`

**Location:** `Assets/_Game/Scripts/UI/SplashController.cs`

**Attached to:** `SplashManager` GameObject

**Responsibilities:**
1. Plays animations on Start()
2. Plays audio at correct times
3. Loads next scene asynchronously
4. Auto-advances after delay
5. Allows tap to skip

**Inspector Variables:**

```csharp
[Header("Visual References")]
public Image backgroundImage;          // Drag: Image_BackgroundGradient
public Image decorativeIcon;           // Drag: Image_DecorativeIcon
public TextMeshProUGUI subtitleText;   // Drag: Text_Subtitle
public TextMeshProUGUI logoText;       // Drag: Text_Logo
public TextMeshProUGUI taglineText;    // Drag: Text_Tagline
public Image loadingSpinner;           // Drag: Image_LoadingSpinner
public TextMeshProUGUI loadingText;    // Drag: Text_Loading

[Header("Audio References")]
public AudioSource musicSource;        // Drag: AudioSource_Music
public AudioSource sfxSource;          // Drag: AudioSource_SFX
public AudioClip splashJingle;
public AudioClip logoSound;
public AudioClip whooshSound;

[Header("Timing")]
public float totalDuration = 3.0f;
public float fadeOutDuration = 0.5f;

[Header("Next Scene")]
public string nextSceneName = "01_NameEntry";
```

**Methods:**

```csharp
void Start()                         // Initialize and start sequence
IEnumerator SplashSequence()         // Main animation timeline
IEnumerator PreloadNextScene()       // Async preload
void OnTapToSkip()                   // Skip splash (optional)
void TransitionOut()                 // Fade out and load next
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Snowy gradient background | `splash_bg.png` | Create or Pixabay | ❌ TODO |
| SummaRace logo (text) | Use TextMeshPro | Built-in | ✅ Ready |
| Decorative icon (book/snowflake) | `splash_icon.png` | Flaticon or Kenney | ❌ TODO |
| Loading spinner sprite | `loading_spinner.png` | Built-in or download | ❌ TODO |

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Splash jingle | `splash_jingle.mp3` | Pixabay | ❌ TODO |
| Logo "ding" SFX | `logo_ding.wav` | Dustyroom Pack | ❌ TODO |
| Whoosh transition | `whoosh_soft.wav` | Dustyroom Pack | ❌ TODO |
| Snow wind ambient (optional) | `snow_wind_soft.wav` | Pixabay | ❌ TODO |

### Fonts

| Asset | File Name | Source | Status |
|---|---|---|---|
| Fredoka Regular | `Fredoka-Regular.ttf` | Google Fonts | ❌ TODO |
| Fredoka Bold | `Fredoka-Bold.ttf` | Google Fonts | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- **Type:** Main Camera
- **Projection:** Orthographic
- **Size:** 5
- **Background:** Solid Color (white)
- **Position:** (0, 0, -10)

### Canvas
- **Render Mode:** Screen Space - Overlay
- **UI Scale Mode:** Scale With Screen Size
- **Reference Resolution:** 1080 × 1920 (portrait)
- **Match:** Width or Height = 0.5
- **Reference Pixels Per Unit:** 100

### Quality
- Mobile preset
- Disable shadows
- Disable post-processing

---

## 🔄 Scene Transitions

### Coming In
- **From:** Application start
- **Method:** First scene loaded by Unity
- **Transition:** Black to splash (built-in)

### Going Out
- **To:** `01_NameEntry`
- **Trigger:** After 3 seconds OR player taps screen
- **Method:** `SceneManager.LoadSceneAsync("01_NameEntry")`
- **Transition:** Fade to white over 0.5s

---

## 🎯 First-Time vs Returning Player

| Condition | Behavior |
|---|---|
| **First launch** | Show full 3-second splash |
| **Returning** | Show 2-second splash (faster) |

```csharp
bool isFirstLaunch = !PlayerPrefs.HasKey("hasLaunchedBefore");
if (isFirstLaunch) {
    PlayerPrefs.SetInt("hasLaunchedBefore", 1);
    totalDuration = 3.0f;
} else {
    totalDuration = 2.0f;
}
```

---

## ✅ Build Checklist

### Setup
- [ ] Create `00_Splash.unity` scene
- [ ] Add to Build Settings as scene index 0
- [ ] Create all project-wide tags (see Tags section)
- [ ] Create all project-wide layers (see Layers section)
- [ ] Set Camera to Orthographic, size 5
- [ ] Create Canvas with correct settings
- [ ] Import Fredoka font into Assets/Fonts/

### GameObjects (use exact names!)
- [ ] Create `Canvas_Splash`
- [ ] Create `BG_Background` with `Image_BackgroundGradient`
- [ ] Create `Group_Content` with all child elements
- [ ] Create `Image_DecorativeIcon`
- [ ] Create `Text_Subtitle` "LEARN BY RUNNING"
- [ ] Create `Text_Logo` "SummaRace"
- [ ] Create `Text_Tagline` "Read. Run. Remember."
- [ ] Create `Group_Loading` with spinner and text
- [ ] Create `Image_LoadingSpinner`
- [ ] Create `Text_Loading`
- [ ] Create `Text_Version` "v1.0" in corner
- [ ] Create `Group_Audio` with three AudioSources
- [ ] Create empty `SplashManager` GameObject

### Tags
- [ ] Tag `SplashManager` as `GameManager`
- [ ] Tag `AudioSource_Music` as `AudioMusic`
- [ ] Tag `AudioSource_SFX` as `AudioSFX`
- [ ] Tag `AudioSource_Ambient` as `AudioAmbient`

### Visual Setup
- [ ] Set all colors per palette
- [ ] Set all text per spec (font, size, content)
- [ ] Set all anchors correctly
- [ ] Position elements per layout

### Audio Setup
- [ ] Import splash jingle to Audio/Music/
- [ ] Import logo ding to Audio/SFX/UI/
- [ ] Import whoosh to Audio/SFX/UI/
- [ ] Assign clips to AudioSources
- [ ] Set volumes per spec

### Script
- [ ] Create `SplashController.cs` in Scripts/UI/
- [ ] Implement Start() and SplashSequence()
- [ ] Implement PreloadNextScene()
- [ ] Attach to `SplashManager`
- [ ] Wire up all Inspector references

### Test
- [ ] Test in Game view at 1080×1920
- [ ] Test on multiple aspect ratios
- [ ] Verify animations play correctly
- [ ] Verify audio plays at correct times
- [ ] Verify auto-advance works
- [ ] Verify next scene loads
- [ ] Test on real device if possible

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 00 Splash complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Logo stretched | Canvas Scaler wrong | Set "Scale With Screen Size" |
| Audio doesn't play | AudioSource missing/muted | Check Inspector |
| Animation doesn't run | DOTween not imported | Import from Asset Store |
| Next scene fails | Not in Build Settings | Add via File → Build Settings |
| Spinner doesn't rotate | Rotation script missing | Add DOTween rotation |
| Text blurry | Wrong Pixels Per Unit | Set to 100 |
| Tiny on tablet | Match value wrong | Set Match to 0.5 |

---

## 💡 Tips

1. **Build visuals first**, audio second, animations third
2. **Test in Game view**, not Scene view
3. **Use placeholders first** — replace with final assets later
4. **Comment out audio while testing** to avoid annoying loops
5. **Save often** with `Ctrl+S`
6. **Test multiple resolutions** in Game view

---

## 🎓 Why This Scene Matters

Even though the splash screen is simple, it's important because:

1. **First impressions** — Polished splash = professional game
2. **Hides loading** — Without it, players see a black screen
3. **Establishes tone** — Music + colors set expectations
4. **Builds trust** — Polished games keep players

A great splash takes 3 seconds and 2 hours of work. Worth it.

---

## 🚀 Next Scene

When Scene 00 is done, move to:

**`SCENE_01_NAME_ENTRY.md`** — Player name input + avatar selection

---

**End of Scene 00 — Splash Specification**
