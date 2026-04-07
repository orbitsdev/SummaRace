# Scene 05 — Mission Intro

> **The pre-run briefing.** Ms. Lumi reappears to explain the mission rules before the player enters the 3D run. Shows the timer, element count, and gets the player psyched up for the challenge.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `05_MissionIntro.unity` |
| **Type** | 2D |
| **Duration** | ~5–8 seconds (until player taps Start) |
| **Next scene** | `06_Mission3DRun.unity` |
| **Previous scene** | `04_StoryReader.unity` |
| **Build complexity** | ⭐⭐ Easy-Medium |
| **Estimated build time** | 3–4 hours |

---

## 🎯 Scene Purpose

This scene has **four jobs**:

1. 🔄 **Transition cleanly** — Bridge from reading (calm) to running (action)
2. 👩‍🏫 **Explain the mission** — Tell player what to do in the 3D run
3. ⚠️ **Set expectations** — Show timer and element count so they know the challenge
4. 🎯 **Build excitement** — Get player pumped up before the run starts

---

## 👤 Player Experience (Step-by-Step)

| Time | What Player Sees | What Player Hears |
|---|---|---|
| **0.0s** | Scene fades in | Music transitions (calm → energetic) |
| **0.3s** | Snowy outdoor background | Wind ambient starts |
| **0.5s** | Ms. Lumi slides in from left | "Whoosh" sound |
| **0.8s** | Ms. Lumi is standing, talking pose | — |
| **1.0s** | Speech bubble appears | Pop sound |
| **1.2s** | Text types out letter-by-letter | Tick sounds |
| **3.0s** | Full message visible | — |
| **3.2s** | Info badges appear (⏱ 60s + 5 elements) | Ding sound per badge |
| **3.8s** | "Start mission!" button appears | Energetic chime |
| **+1s** | Player taps Start button | Confirm sound |
| **+0.3s** | Scene fades to white | Whoosh transition |

**Total time:** 5–8 seconds

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│                                 │
│    ❄   ❄    ❄      ❄          │  ← Snow particles
│                                 │
│                                 │
│           👩‍🏫                     │  ← Ms. Lumi (center top)
│                                 │
│                                 │
│   ┌─────────────────────┐      │
│   │ "Now run through    │      │
│   │  the snow and       │      │  ← Speech bubble
│   │  collect the 5      │      │
│   │  story parts.       │      │
│   │  Watch out — the    │      │
│   │  Snow Patrol is     │      │
│   │  coming!"           │      │
│   │                     │      │
│   │  [⏱ 60s] [5 items]  │      │  ← Info badges inside bubble
│   └─────────────────────┘      │
│                                 │
│      ┌─────────────────┐       │
│      │ Start mission! ▸│       │  ← Button (bouncing)
│      └─────────────────┘       │
│                                 │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Snow particles | Top half | Particle system | Top |
| Ms. Lumi character | Center, Y+250 | 350×350 px | Center |
| Speech bubble | Center, Y−50 | 700×340 px | Center |
| Speech text | Inside bubble, top | 600×220 px | Top of bubble |
| Info badges group | Inside bubble, bottom | 600×50 px | Bottom of bubble |
| Timer badge | Left of group | 100×40 px | Left |
| Elements badge | Right of group | 140×40 px | Right |
| Start button | Bottom, Y−280 | 320×80 px | Bottom-center |

---

## 🎨 Color Palette

This scene uses **teal** (Ms. Lumi's color) mixed with **action-ready accents**.

| Element | Color | Hex |
|---|---|---|
| Background top | Teal sky | `#9FE1CB` |
| Background bottom | Mint | `#E1F5EE` |
| Ms. Lumi background circle | Bright mint | `#5DCAA5` |
| Speech bubble background | White | `#FFFFFF` |
| Speech bubble border | Teal | `#1D9E75` (3px) |
| Speech bubble text | Dark teal | `#04342C` |
| Info badge background | Light mint | `#E1F5EE` |
| Info badge border | Medium teal | `#0F6E56` |
| Info badge text | Dark teal | `#04342C` |
| Start button background | Dark teal | `#04342C` |
| Start button text | White | `#FFFFFF` |
| Start button pulse glow | Bright teal | `#1D9E75` |

### Why These Colors
The teal palette maintains Ms. Lumi's identity while the **dark teal Start button** signals "this is serious, but exciting!" The button uses the darkest color in the palette to make it stand out and feel like a "power button."

---

## 📝 Text Content

### Speech Bubble Text

The speech bubble contains the mission briefing. It's mostly static but adjusts slightly per level:

**Level 1 (Easy) version:**
> "Now run through the snow and collect the 5 story parts. Watch out — the Snow Patrol is coming!"

**Level 2 (Medium) version:**
> "Time to run again! Grab all 5 story parts. The patrol is faster this time — stay alert!"

**Level 3 (Hard) version:**
> "This is the hardest one! Collect all 5 parts and outrun the patrol. I believe in you!"

### Info Badges

| Badge | Text | Icon |
|---|---|---|
| Timer | `{seconds}s` (e.g., `60s`) | ⏱ |
| Elements | `5 elements` | 📦 or ⭐ |

The timer value comes from the Level Balance config:
- Level 1: `90s`
- Level 2: `75s`
- Level 3: `60s`

### UI Labels

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Speech bubble | (dynamic, see above) | Fredoka | 22px | Regular |
| Timer badge | (dynamic: e.g., "⏱ 60s") | Fredoka | 14px | Bold |
| Elements badge | `5 elements` | Fredoka | 14px | Bold |
| Start button | `Start mission! ▸` | Fredoka | 22px | Bold |

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/mission_intro.mp3` |
| **Volume** | 0.5 |
| **Loop** | Yes |
| **Fade from previous** | Yes (0.8s crossfade from reading music) |

**Note:** This music should feel more "energetic" than reading music, hinting at the action to come. But it shouldn't be the full action music yet — that starts in Scene 06.

### Sound Effects

| Trigger | File | Volume | When |
|---|---|---|---|
| Ms. Lumi appears | `whoosh_in.wav` | 0.6 | At 0.5s |
| Speech bubble appears | `pop_soft.wav` | 0.7 | At 1.0s |
| Typewriter tick | `type_tick.wav` | 0.3 | Per 3 letters |
| Info badge 1 appears | `ding_small.wav` | 0.6 | At 3.2s |
| Info badge 2 appears | `ding_small.wav` | 0.6 | At 3.4s |
| Start button appears | `chime_energetic.wav` | 0.7 | At 3.8s |
| Start button pulse | (part of loop) | — | — |
| Tap Start button | `button_confirm_big.wav` | 0.9 | On tap |
| Scene transition | `whoosh_out.wav` | 0.5 | On exit |

**Source:** All from Dustyroom Free Casual Game SFX Pack

### Ambient Sound

| File | Volume |
|---|---|
| `snow_wind_soft.wav` | 0.3 |

---

## 🎬 Animations

| # | Element | Animation | When | Duration | Easing |
|---|---|---|---|---|---|
| 1 | Background | Fade in | 0.0s | 0.5s | EaseOut |
| 2 | Snow particles | Start emitting | 0.2s | continuous | — |
| 3 | Ms. Lumi | Slide in from left + fade | 0.5s | 0.4s | EaseOutBack |
| 4 | Ms. Lumi pose | Change to "talk" pose | 1.0s | — | — |
| 5 | Speech bubble | Scale (0→1) + fade | 1.0s | 0.3s | EaseOutBack |
| 6 | Speech text | Typewriter effect | 1.2s | 1.8s | Linear |
| 7 | Timer badge | Scale pop + slide up | 3.2s | 0.3s | EaseOutBack |
| 8 | Elements badge | Scale pop + slide up | 3.4s | 0.3s | EaseOutBack |
| 9 | Start button | Scale (0→1) + fade | 3.8s | 0.4s | EaseOutBack |
| 10 | Start button pulse | Scale 1.0 ↔ 1.08 (loop) | 4.2s | 0.7s | EaseInOut |
| 11 | Start button glow | Outer glow pulse (loop) | 4.2s | 1.0s | EaseInOut |
| 12 | All elements | Fade out | On tap | 0.3s | EaseIn |

### Start Button Pulse Animation

The Start button should **subtly pulse** to attract the player's eye:

```csharp
startButton.transform.DOScale(1.08f, 0.7f)
    .SetLoops(-1, LoopType.Yoyo)
    .SetEase(Ease.InOutSine);

// Optional: glow effect
startButtonGlow.DOFade(0.8f, 1.0f)
    .SetLoops(-1, LoopType.Yoyo)
    .SetEase(Ease.InOutSine);
```

### Typewriter Effect (Same as Scene 02)

```csharp
IEnumerator TypewriterEffect(string fullText, float speed) {
    speechText.text = "";
    int letterCount = 0;
    foreach (char letter in fullText) {
        speechText.text += letter;
        if (letter != ' ' && letterCount % 3 == 0) PlayTickSound();
        letterCount++;
        yield return new WaitForSeconds(speed);
    }
}
```

---

## 🛠️ GameObject Hierarchy & Names

```
MissionIntroScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_MissionIntro                      [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   ├── Image_BackgroundGradient
│   │   └── ParticleSystem_SnowFlakes        [Tag: Untagged]
│   │
│   ├── Group_Teacher                        [Tag: Untagged]
│   │   └── Image_TeacherCharacter           [Tag: Teacher]
│   │       ├── Image_TeacherIdle            (hidden)
│   │       ├── Image_TeacherWave            (hidden)
│   │       └── Image_TeacherTalk            (active)
│   │
│   ├── Group_SpeechBubble                   [Tag: Untagged]
│   │   ├── Image_SpeechBubbleBg
│   │   ├── Image_SpeechBubbleTail           (pointing up to teacher)
│   │   ├── Text_SpeechContent
│   │   └── Group_InfoBadges                 [Tag: Untagged]
│   │       ├── Badge_Timer                  [Tag: Untagged]
│   │       │   ├── Image_BadgeBg
│   │       │   ├── Image_TimerIcon
│   │       │   └── Text_TimerValue
│   │       └── Badge_Elements               [Tag: Untagged]
│   │           ├── Image_BadgeBg
│   │           ├── Image_ElementsIcon
│   │           └── Text_ElementsValue
│   │
│   └── Button_StartMission                  [Tag: Untagged]
│       ├── Image_ButtonBg
│       ├── Image_ButtonGlow                 (for pulse effect)
│       └── Text_ButtonLabel
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   ├── AudioSource_SFX                      [Tag: AudioSFX]
│   └── AudioSource_Ambient                  [Tag: AudioAmbient]
│
└── MissionIntroManager                      [Tag: GameManager]
    └── MissionIntroController.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_MissionIntro` |
| `Group_` | Container | `Group_InfoBadges` |
| `Badge_` | Info badge | `Badge_Timer` |
| `Image_` | UI Image | `Image_TimerIcon` |
| `Text_` | Text element | `Text_SpeechContent` |
| `Button_` | Button | `Button_StartMission` |
| `ParticleSystem_` | Particle system | `ParticleSystem_SnowFlakes` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_MissionIntro | Identifies main canvas |
| `Teacher` | Image_TeacherCharacter | Script can find Ms. Lumi |
| `GameManager` | MissionIntroManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music source |
| `AudioSFX` | AudioSource_SFX | SFX source |
| `AudioAmbient` | AudioSource_Ambient | Ambient wind |

---

## 💻 Scripts Required

### `MissionIntroController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/MissionIntroController.cs`
**Attached to:** `MissionIntroManager` GameObject

**Responsibilities:**
1. Load current level info (for dynamic text and timer value)
2. Run animation sequence
3. Play typewriter effect on speech text
4. Show info badges with correct values
5. Animate Start button pulse
6. Handle Start button tap → load 3D run

**Inspector Variables:**

```csharp
[Header("UI References")]
public Image teacherImage;
public Image teacherTalkPose;
public RectTransform speechBubble;
public TextMeshProUGUI speechText;
public GameObject badgeTimerGroup;
public GameObject badgeElementsGroup;
public TextMeshProUGUI timerValueText;
public TextMeshProUGUI elementsValueText;
public Button startButton;
public Image startButtonGlow;

[Header("Audio")]
public AudioSource musicSource;
public AudioSource sfxSource;
public AudioSource ambientSource;
public AudioClip whooshInSound;
public AudioClip popSound;
public AudioClip typeTickSound;
public AudioClip dingSound;
public AudioClip chimeEnergeticSound;
public AudioClip startConfirmSound;
public AudioClip whooshOutSound;

[Header("Mission Messages (per level)")]
[TextArea(2, 4)]
public string level1Message = "Now run through the snow and collect the 5 story parts. Watch out — the Snow Patrol is coming!";
[TextArea(2, 4)]
public string level2Message = "Time to run again! Grab all 5 story parts. The patrol is faster this time — stay alert!";
[TextArea(2, 4)]
public string level3Message = "This is the hardest one! Collect all 5 parts and outrun the patrol. I believe in you!";

[Header("Timing")]
public float typingSpeed = 0.04f;
public int playSoundEveryNLetters = 3;
public float badge1Delay = 3.2f;
public float badge2Delay = 3.4f;
public float startButtonDelay = 3.8f;

[Header("Next Scene")]
public string nextSceneName = "06_Mission3DRun";
```

**Methods:**

```csharp
void Start()                          // Initialize, load level data
void LoadLevelData()                  // Get current level + timer
string GetMissionMessage(int level)   // Return correct message per level
int GetMissionTimer(int level)        // Return timer based on level
IEnumerator AnimationSequence()       // Main timeline
IEnumerator SlideInTeacher()          // Animate Ms. Lumi
IEnumerator ShowSpeechBubble()        // Animate speech bubble
IEnumerator TypewriterEffect(string text)
IEnumerator ShowInfoBadges()          // Reveal badges one by one
IEnumerator ShowStartButton()         // Scale in + start pulse
void StartButtonPulseLoop()           // DOTween pulse animation
void OnStartClicked()                 // Handle tap, transition
```

---

## 📦 Assets Needed

### Visual Assets

Most assets are **reused** from Scene 02 (Teacher Welcome):

| Asset | File Name | Source | Status |
|---|---|---|---|
| Ms. Lumi idle pose | `lumi_idle.png` | Reused from Scene 02 | ✅ Ready (if Scene 02 done) |
| Ms. Lumi talk pose | `lumi_talk.png` | Reused from Scene 02 | ✅ Ready |
| Speech bubble bg | `speech_bubble.png` | Reused from Scene 02 | ✅ Ready |
| Speech bubble tail | `speech_bubble_tail.png` | Reused | ✅ Ready |
| Snow particle texture | `snowflake_small.png` | Reused | ✅ Ready |

### New Assets for This Scene

| Asset | File Name | Source | Status |
|---|---|---|---|
| Teal gradient background (outdoor) | `bg_teal_outdoor.png` | Create or solid | ❌ TODO |
| Timer icon (clock) | `icon_timer.png` | Kenney UI Pack | ❌ TODO |
| Elements icon (stars or box) | `icon_elements.png` | Kenney UI Pack | ❌ TODO |
| Badge background | `badge_pill_bg.png` | Create (pill shape) | ❌ TODO |
| Start button background | `button_dark_teal.png` | Create | ❌ TODO |
| Start button glow | `button_glow_teal.png` | Create (soft glow) | ❌ TODO |

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Mission intro music | `mission_intro.mp3` | Pixabay | ❌ TODO |
| Whoosh in | `whoosh_in.wav` | Dustyroom Pack (reused) | ✅ Ready |
| Pop soft | `pop_soft.wav` | Dustyroom Pack (reused) | ✅ Ready |
| Type tick | `type_tick.wav` | Dustyroom Pack (reused) | ✅ Ready |
| Ding small | `ding_small.wav` | Dustyroom Pack | ❌ TODO |
| Chime energetic | `chime_energetic.wav` | Dustyroom Pack | ❌ TODO |
| Button confirm big | `button_confirm_big.wav` | Dustyroom Pack | ❌ TODO |
| Whoosh out | `whoosh_out.wav` | Dustyroom Pack | ❌ TODO |
| Snow wind soft | `snow_wind_soft.wav` | Pixabay (reused) | ✅ Ready |

---

## ⚙️ Unity Settings

### Camera
- Same as previous scenes (Orthographic, size 5)

### Canvas
- Same as previous scenes (Screen Space Overlay, 1080×1920 reference)

### Particle System (Snow)
- Same setup as Scene 02
- **Emission rate:** 8 per second (slightly more than Scene 02 to feel more active)
- **Lifetime:** 5 seconds
- **Color:** White with 80% alpha

---

## 🔄 Scene Transitions

### Coming In
- **From:** `04_StoryReader`
- **Trigger:** Player completed all 5 pages of the story
- **Transition in:** Fade in (0.5s)
- **Music crossfade:** reading_calm → mission_intro (0.8s)

### Going Out
- **To:** `06_Mission3DRun`
- **Trigger:** Player taps Start mission button
- **Transition out:** Fade to white (0.3s)
- **Method:** `SceneManager.LoadSceneAsync("06_Mission3DRun")`
- **Music:** Starts fading out during transition (continues into mission)

---

## 💾 Data Read From PlayerPrefs

```csharp
int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
// Use this to determine:
// - Which message to show
// - What timer value to display
```

### No Data Written

This scene doesn't save anything. It just displays information.

---

## 🎯 Per-Level Customization

The scene dynamically adjusts based on `currentLevel`:

```csharp
void LoadLevelData() {
    int level = PlayerPrefs.GetInt("currentLevel", 1);
    
    // Get the right message
    string message = level switch {
        1 => level1Message,
        2 => level2Message,
        3 => level3Message,
        _ => level1Message
    };
    
    // Get the right timer value
    int timerSeconds = level switch {
        1 => 90,
        2 => 75,
        3 => 60,
        _ => 90
    };
    
    timerValueText.text = $"{timerSeconds}s";
    elementsValueText.text = "5 elements";  // Always 5
}
```

---

## ✅ Build Checklist

### Setup
- [ ] Create `05_MissionIntro.unity` scene
- [ ] Add to Build Settings as scene index 5
- [ ] Set Camera to Orthographic, size 5
- [ ] Create Canvas_MissionIntro

### GameObjects (use exact names!)
- [ ] Create `Canvas_MissionIntro`
- [ ] Create `BG_Background` with `Image_BackgroundGradient`
- [ ] Create `ParticleSystem_SnowFlakes`
- [ ] Create `Group_Teacher`
- [ ] Create `Image_TeacherCharacter` with poses
- [ ] Create `Group_SpeechBubble`
- [ ] Create `Image_SpeechBubbleBg`
- [ ] Create `Image_SpeechBubbleTail`
- [ ] Create `Text_SpeechContent` (start empty)
- [ ] Create `Group_InfoBadges`
- [ ] Create `Badge_Timer` with icon and text
- [ ] Create `Badge_Elements` with icon and text
- [ ] Create `Button_StartMission` (start hidden)
- [ ] Create `Image_ButtonBg`
- [ ] Create `Image_ButtonGlow`
- [ ] Create `Text_ButtonLabel` "Start mission! ▸"
- [ ] Create `Group_Audio` with three AudioSources
- [ ] Create `MissionIntroManager` GameObject

### Tags
- [ ] Tag `Canvas_MissionIntro` as `UICanvas`
- [ ] Tag `Image_TeacherCharacter` as `Teacher`
- [ ] Tag `MissionIntroManager` as `GameManager`
- [ ] Tag audio sources

### Visual Setup
- [ ] Set background to teal gradient
- [ ] Set all text colors per palette
- [ ] Position Ms. Lumi center top
- [ ] Position speech bubble center
- [ ] Position Start button bottom
- [ ] Setup snow particles

### Audio Setup
- [ ] Import mission intro music
- [ ] Import all SFX (reuse from previous scenes where possible)
- [ ] Set music to loop
- [ ] Setup ambient wind

### Scripts
- [ ] Create `MissionIntroController.cs` in Scripts/UI/
- [ ] Attach to `MissionIntroManager`
- [ ] Wire up all Inspector references
- [ ] Configure per-level messages

### Test
- [ ] Test Level 1 — shows 90s timer
- [ ] Test Level 2 — shows 75s timer with different message
- [ ] Test Level 3 — shows 60s timer with different message
- [ ] Verify typewriter effect
- [ ] Verify badge animations
- [ ] Verify Start button pulses
- [ ] Verify music crossfade from previous scene
- [ ] Test tap Start → loads 3D run scene
- [ ] Test on multiple screen sizes

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 05 MissionIntro complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Wrong message shows | Level not loaded | Check PlayerPrefs.GetInt call |
| Timer shows "0s" | Hardcoded fallback | Provide valid defaults |
| Start button doesn't pulse | DOTween loop missing | Add .SetLoops(-1) to tween |
| Music jarring transition | No crossfade | Use AudioManager with fade |
| Badges appear all at once | Delays wrong | Check SetDelay() values |
| Ms. Lumi wrong pose | SetActive order wrong | Hide all, then show talk |
| Speech bubble cut off | Text too long | Increase container size |

---

## 💡 Tips

1. **Reuse assets from Scene 02** — Ms. Lumi poses, speech bubble, etc.
2. **Per-level messages** — Write distinct messages so each level feels unique
3. **Use AudioManager** — Singleton for music continuity
4. **Pulse animation** — Subtle but important, catches the eye
5. **Test all 3 levels** — Make sure timer value changes correctly
6. **Don't auto-advance** — Always wait for tap, gives player time to read

---

## 🎓 Why This Scene Matters

This scene is the **emotional shift** from reading mode to action mode. Up until now, the player has been calm and reading. Now they need to be ready to run, react, and make decisions fast.

This scene serves as a **mental warm-up**:
- Reminds them what the elements are (they just saw them in questions)
- Warns them about the Snow Patrol (psychological prep)
- Shows the timer (creates urgency)
- Pumps them up with Ms. Lumi's encouragement

Without this scene, players would be jarred — going straight from reading text to running in 3D. This brief pause lets them mentally transition.

---

## 🚀 Next Scene

When Scene 05 is done, move to:

**`SCENE_06_MISSION_3D_RUN.md`** — THE BIG ONE! The actual 3D endless runner with all the gameplay

This will cover:
- 3D track setup
- Player character with lane switching
- Answer cards at checkpoints
- Snow Patrol "fake chase" system
- Danger level tracking
- HUD (timer, score, collected elements)
- Correct/wrong feedback
- Finish line
- Transition to final summary

**⚠️ This is the most complex scene in the game — expect a LONG document!**

---

**End of Scene 05 — Mission Intro Specification**
