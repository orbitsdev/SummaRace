# Scene 02 — Teacher Welcome

> **Meet Ms. Lumi.** The teacher character appears for the first time and greets the player by name. This establishes the friendly, helpful guide who will accompany the player throughout the game.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `02_TeacherWelcome.unity` |
| **Type** | 2D |
| **Duration** | ~5–8 seconds (until player taps continue) |
| **Next scene** | `03_LevelSelect.unity` |
| **Previous scene** | `01_NameEntry.unity` |
| **Build complexity** | ⭐⭐ Easy-Medium |
| **Estimated build time** | 3–4 hours |

---

## 🎯 Scene Purpose

This scene has **four jobs**:

1. 👩‍🏫 **Introduce Ms. Lumi** — The friendly teacher character who guides the player
2. 👋 **Personalized greeting** — Address the player by their name from Scene 01
3. 📚 **Set expectations** — Tell the player what they're about to do (read stories, run, learn)
4. 🤝 **Build emotional connection** — Make the player feel welcomed and excited

---

## 👤 Player Experience (Step-by-Step)

| Time | What Player Sees | What Player Hears |
|---|---|---|
| **0.0s** | Scene fades in from previous scene | Soft music starts |
| **0.5s** | Snowy background visible | Music continues |
| **0.8s** | Ms. Lumi slides in from left | "Whoosh" sound |
| **1.2s** | Ms. Lumi waves animation plays | Cheerful chime |
| **1.5s** | Speech bubble appears | Pop sound |
| **1.7s** | Text types out letter-by-letter | Soft typing sounds |
| **3.5s** | Full message visible | Music continues |
| **4.0s** | "Tap to continue" appears | Subtle pulse sound |
| **?** | Player taps screen | Confirm sound |
| **+0.5s** | Scene fades out | Whoosh transition |

**Total time:** ~5–8 seconds depending on how fast player taps

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│                                 │
│         ❄  ❄    ❄                │  ← Snowy ambient
│                                 │
│                                 │
│                                 │
│           👩‍🏫                     │  ← Ms. Lumi (center)
│         (Ms. Lumi)              │  ← Name label below
│                                 │
│   ┌─────────────────────┐      │
│   │ "Hi Ben! I'm        │      │  ← Speech bubble
│   │  Ms. Lumi. Today    │      │     with personalized name
│   │  we'll read stories │      │
│   │  and race to        │      │
│   │  remember them.     │      │
│   │  Ready?"            │      │
│   └─────────────────────┘      │
│                                 │
│      [ Tap to continue ▸ ]      │  ← Pulsing prompt
│                                 │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Ms. Lumi character | Center, Y+200 | 400×400 px | Center |
| Name label | Below character | Auto | Center |
| Speech bubble | Center, Y−100 | 700×280 px | Center |
| Speech bubble text | Inside bubble | 600×220 px | Center of bubble |
| Continue prompt | Bottom, Y−250 | Auto | Bottom-center |
| Snow particles | Top of screen | Particle system | Top |

---

## 🎨 Color Palette

| Element | Color | Hex |
|---|---|---|
| Background top | Light teal | `#E1F5EE` |
| Background bottom | Soft mint | `#9FE1CB` |
| Ms. Lumi background circle | Mint | `#9FE1CB` |
| Speech bubble background | White | `#FFFFFF` |
| Speech bubble border | Teal | `#1D9E75` |
| Speech bubble text | Dark teal | `#04342C` |
| Name label text | Medium teal | `#0F6E56` |
| Continue prompt text | Deep teal | `#04342C` |
| Continue prompt bg | Dark teal | `#04342C` |
| Continue prompt button text | White | `#FFFFFF` |

### Why These Colors
**Teal** is the color associated with Ms. Lumi throughout the game. Every time the player sees teal, they should think "the teacher is here!" This builds visual consistency.

---

## 📝 Text Content

### Greeting Message (Personalized)

The greeting uses the player's name from PlayerPrefs:

```
"Hi {playerName}! I'm Ms. Lumi.
Today we'll read stories and race to
remember them. Ready?"
```

**Example with name "Ben":**
> "Hi Ben! I'm Ms. Lumi. Today we'll read stories and race to remember them. Ready?"

### Static Text Elements

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Character name label | `Ms. Lumi (your guide)` | Fredoka | 14px | Regular |
| Speech bubble text | (dynamic, see above) | Fredoka | 22px | Regular |
| Continue prompt | `Tap to continue ▸` | Fredoka | 18px | Bold |

### Fallback Messages

If `playerName` is empty for some reason:

```csharp
string playerName = PlayerPrefs.GetString("playerName", "friend");
string greeting = $"Hi {playerName}! I'm Ms. Lumi...";
```

So if no name, it says "Hi friend!" instead of "Hi !"

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/menu_theme.mp3` |
| **Volume** | 0.5 |
| **Loop** | Yes |
| **Crossfade from previous** | Yes (continues from Scene 01) |

**Note:** Use the same music as Scene 01 so it feels continuous, not jarring.

### Sound Effects

| Trigger | File | Volume | When |
|---|---|---|---|
| Ms. Lumi appears | `Audio/SFX/UI/whoosh_in.wav` | 0.6 | At 0.8s |
| Wave animation | `Audio/SFX/UI/cheerful_chime.wav` | 0.7 | At 1.2s |
| Speech bubble appears | `Audio/SFX/UI/pop_soft.wav` | 0.7 | At 1.5s |
| Letters typing | `Audio/SFX/UI/type_tick.wav` | 0.3 | Per letter (or every 3 letters) |
| Continue prompt appears | `Audio/SFX/UI/notification_soft.wav` | 0.5 | At 4.0s |
| Tap to continue | `Audio/SFX/UI/button_confirm.wav` | 0.8 | When player taps |

**Source:** All from Dustyroom Free Casual Game SFX Pack

### Voice Narration (Optional but Recommended)

| File | Duration | Content |
|---|---|---|
| `Audio/Voice/Teacher/lumi_welcome_generic.mp3` | ~3 seconds | "Hi! I'm Ms. Lumi..." |

**Note:** Since the name is dynamic, you can't pre-record the full greeting. Options:
- **Option A:** Record only the static parts ("I'm Ms. Lumi...")
- **Option B:** Use TTS to generate the greeting at runtime
- **Option C:** Skip narration in this scene (text only)

For MVP, **Option C is fine**.

---

## 🎬 Animations

| Element | Animation | When | Duration | Easing |
|---|---|---|---|---|
| Background | Fade in | 0.0s | 0.5s | EaseOut |
| Snow particles | Start emitting | 0.3s | continuous | — |
| Ms. Lumi character | Slide in from left + fade | 0.8s | 0.4s | EaseOutBack |
| Ms. Lumi pose | Idle → Wave → Talk | 1.2s | 0.5s each | — |
| Name label | Fade in | 1.4s | 0.3s | EaseOut |
| Speech bubble | Scale (0→1) + pop | 1.5s | 0.3s | EaseOutBack |
| Speech text | Typewriter effect | 1.7s | 1.8s | Linear |
| Continue prompt | Fade in + pulse loop | 4.0s | 0.4s | EaseOut |
| Continue prompt pulse | Scale 1.0 ↔ 1.05 (looped) | 4.0s | 0.8s | EaseInOut |
| All elements | Fade out | On tap | 0.3s | EaseIn |

### Ms. Lumi Animation Sequence

If using a 2D character with multiple poses (PNG sprites):

```
1. Idle pose (lumi_idle.png) — appears
2. Wave pose (lumi_wave.png) — at 1.2s for 0.5s
3. Talk pose (lumi_talk.png) — at 1.7s during text typing
4. Idle pose (lumi_idle.png) — at 3.5s after text done
```

If using just one PNG, skip the pose changes — just slide and fade in.

### Typewriter Effect

Use a script to reveal text letter-by-letter:

```csharp
IEnumerator TypewriterEffect(string fullText, float speed) {
    speechText.text = "";
    foreach (char letter in fullText) {
        speechText.text += letter;
        if (letter != ' ') PlayTickSound();
        yield return new WaitForSeconds(speed);
    }
}
```

**Recommended speed:** 0.04 seconds per letter (~25 letters per second)

---

## 🛠️ GameObject Hierarchy & Names

```
TeacherWelcomeScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_TeacherWelcome                    [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   ├── Image_BackgroundGradient
│   │   └── ParticleSystem_SnowFlakes        [Tag: Untagged]
│   │
│   ├── Group_Teacher                        [Tag: Untagged]
│   │   ├── Image_TeacherCharacter           [Tag: Teacher]
│   │   │   ├── Image_TeacherIdle            (active by default)
│   │   │   ├── Image_TeacherWave            (hidden by default)
│   │   │   └── Image_TeacherTalk            (hidden by default)
│   │   └── Text_TeacherName                 [Tag: Untagged]
│   │
│   ├── Group_SpeechBubble                   [Tag: Untagged]
│   │   ├── Image_SpeechBubbleBg
│   │   ├── Image_SpeechBubbleTail           (small triangle pointing to teacher)
│   │   └── Text_SpeechContent               [Tag: Untagged]
│   │
│   └── Button_Continue                      [Tag: Untagged]
│       ├── Image_ContinueBg
│       └── Text_ContinueLabel
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   ├── AudioSource_SFX                      [Tag: AudioSFX]
│   └── AudioSource_Voice                    [Tag: AudioVoice]
│
└── TeacherWelcomeManager                    [Tag: GameManager]
    └── TeacherWelcomeController.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_TeacherWelcome` |
| `BG_` | Background | `BG_Background` |
| `Group_` | Container | `Group_Teacher` |
| `Image_` | UI Image | `Image_TeacherCharacter` |
| `Text_` | Text element | `Text_SpeechContent` |
| `Button_` | Button | `Button_Continue` |
| `ParticleSystem_` | Particle system | `ParticleSystem_SnowFlakes` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_TeacherWelcome | Identifies main canvas |
| `Teacher` | Image_TeacherCharacter | Script can find Ms. Lumi |
| `GameManager` | TeacherWelcomeManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music source |
| `AudioSFX` | AudioSource_SFX | SFX source |
| `AudioVoice` | AudioSource_Voice | Voice source (if used) |

---

## 💻 Scripts Required

### `TeacherWelcomeController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/TeacherWelcomeController.cs`
**Attached to:** `TeacherWelcomeManager` GameObject

**Responsibilities:**
1. Load player name from PlayerPrefs
2. Build personalized greeting message
3. Run animation sequence (slide in, wave, type text)
4. Wait for player to tap
5. Load next scene (Level Select)

**Inspector Variables:**

```csharp
[Header("References")]
public Image teacherImage;
public Image teacherIdle;
public Image teacherWave;
public Image teacherTalk;
public TextMeshProUGUI teacherNameLabel;
public RectTransform speechBubble;
public TextMeshProUGUI speechText;
public Button continueButton;
public CanvasGroup continueButtonGroup;

[Header("Audio")]
public AudioSource musicSource;
public AudioSource sfxSource;
public AudioClip whooshSound;
public AudioClip chimeSound;
public AudioClip popSound;
public AudioClip typeSound;
public AudioClip notificationSound;
public AudioClip confirmSound;

[Header("Greeting Message")]
[TextArea(3, 5)]
public string greetingTemplate = "Hi {0}! I'm Ms. Lumi. Today we'll read stories and race to remember them. Ready?";
public string fallbackName = "friend";

[Header("Typewriter Effect")]
public float typingSpeed = 0.04f;        // Seconds per letter
public int playSoundEveryNLetters = 3;

[Header("Next Scene")]
public string nextSceneName = "03_LevelSelect";

[Header("Timing")]
public float teacherSlideInDelay = 0.8f;
public float speechBubbleDelay = 1.5f;
public float continuePromptDelay = 4.0f;
```

**Methods:**

```csharp
void Start()                          // Initialize everything
void LoadPlayerName()                 // Get from PlayerPrefs
string BuildGreeting(string name)     // Format the message
IEnumerator AnimationSequence()       // Main timeline
IEnumerator SlideInTeacher()          // Animate Ms. Lumi entrance
IEnumerator ShowSpeechBubble()        // Animate speech bubble
IEnumerator TypewriterEffect(string text) // Letter-by-letter reveal
IEnumerator ShowContinuePrompt()      // Pulsing prompt
void OnContinueClicked()              // Handle tap
void TransitionToNextScene()          // Fade out + load
```

### `TeacherPoseController.cs` — Optional Helper

**Location:** `Assets/_Game/Scripts/UI/TeacherPoseController.cs`
**Attached to:** `Image_TeacherCharacter` GameObject

**Responsibilities:**
- Manage which pose is visible (idle, wave, talk)
- Handle pose transitions

**Methods:**

```csharp
void ShowIdle()
void ShowWave()
void ShowTalk()
void ShowCheer()  // For other scenes
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Teal gradient background | `bg_teal_gradient.png` | Create or solid color | ❌ TODO |
| Snow particle texture | `snowflake_small.png` | Pixabay or Kenney | ❌ TODO |
| Ms. Lumi idle pose | `lumi_idle.png` | AI generation (Pixa/Recraft) | ❌ TODO |
| Ms. Lumi wave pose | `lumi_wave.png` | AI generation | ❌ TODO |
| Ms. Lumi talk pose | `lumi_talk.png` | AI generation | ❌ TODO |
| Ms. Lumi cheer pose | `lumi_cheer.png` | AI generation (for victory scenes) | ❌ TODO |
| Speech bubble background | `speech_bubble.png` | UI Pack or create | ❌ TODO |
| Speech bubble tail | `speech_bubble_tail.png` | Create simple triangle | ❌ TODO |
| Continue button bg | `button_teal.png` | UI Pack or create | ❌ TODO |

### AI Prompt for Ms. Lumi (use across all 4 poses)

> "Cute friendly cartoon teacher woman, warm smile, light brown hair in a bun, wearing a teal sweater with a snowflake pattern, white background, full body, children's book illustration style, soft watercolor colors"

Then vary by pose:
- **Idle:** "...standing, hands at her sides, gentle smile..."
- **Wave:** "...waving with right hand raised, big friendly smile..."
- **Talk:** "...one hand raised gesturing, mouth slightly open as if speaking..."
- **Cheer:** "...both hands raised celebrating, joyful expression..."

**💡 Pro tip:** Generate them all in one session with the same model and prompt structure to keep the style consistent.

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Whoosh in | `whoosh_in.wav` | Dustyroom Pack | ❌ TODO |
| Cheerful chime | `cheerful_chime.wav` | Dustyroom Pack | ❌ TODO |
| Pop soft | `pop_soft.wav` | Dustyroom Pack | ❌ TODO |
| Type tick | `type_tick.wav` | Dustyroom Pack | ❌ TODO |
| Notification soft | `notification_soft.wav` | Dustyroom Pack | ❌ TODO |
| Button confirm | `button_confirm.wav` | Dustyroom Pack | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- Same as previous scenes (Orthographic, size 5)

### Canvas
- Same as previous scenes (Screen Space Overlay, 1080×1920 reference)

### Particle System (Snow)
- **Emission rate:** 5 per second
- **Lifetime:** 5 seconds
- **Start size:** 0.1–0.3 (random)
- **Start speed:** 0.5–1.0
- **Direction:** Down with slight randomness
- **Color:** White with 80% alpha
- **Loop:** Yes

---

## 🔄 Scene Transitions

### Coming In
- **From:** `01_NameEntry`
- **Trigger:** Player tapped Continue with valid name
- **Transition in:** Fade in from previous (0.5s)

### Going Out
- **To:** `03_LevelSelect`
- **Trigger:** Player taps Continue button
- **Transition out:** Fade out (0.3s)
- **Method:** `SceneManager.LoadSceneAsync("03_LevelSelect")`

---

## 🎯 First-Time vs Returning Player

This scene behaves slightly differently for new vs returning players:

| Condition | Behavior |
|---|---|
| **First time** | Full greeting: "Hi [name]! I'm Ms. Lumi. Today we'll read stories..." |
| **Returning** | Short greeting: "Welcome back, [name]! Ready to read?" |
| **After Level 3 done** | Special: "Great job, [name]! Want to play again?" |

```csharp
bool isFirstWelcome = !PlayerPrefs.HasKey("hasSeenTeacherWelcome");
bool gameCompleted = PlayerPrefs.GetInt("gameCompleted", 0) == 1;

string greeting;
if (gameCompleted) {
    greeting = $"Great job, {playerName}! Want to play again?";
} else if (isFirstWelcome) {
    PlayerPrefs.SetInt("hasSeenTeacherWelcome", 1);
    greeting = $"Hi {playerName}! I'm Ms. Lumi. Today we'll read stories and race to remember them. Ready?";
} else {
    greeting = $"Welcome back, {playerName}! Ready to read?";
}
```

---

## ✅ Build Checklist

### Setup
- [ ] Create `02_TeacherWelcome.unity` scene
- [ ] Add to Build Settings as scene index 2
- [ ] Set Camera to Orthographic, size 5
- [ ] Create Canvas_TeacherWelcome

### GameObjects (use exact names!)
- [ ] Create `Canvas_TeacherWelcome`
- [ ] Create `BG_Background` with `Image_BackgroundGradient`
- [ ] Create `ParticleSystem_SnowFlakes`
- [ ] Create `Group_Teacher`
- [ ] Create `Image_TeacherCharacter` (parent for all poses)
- [ ] Create `Image_TeacherIdle` (active by default)
- [ ] Create `Image_TeacherWave` (start hidden)
- [ ] Create `Image_TeacherTalk` (start hidden)
- [ ] Create `Text_TeacherName` "Ms. Lumi (your guide)"
- [ ] Create `Group_SpeechBubble`
- [ ] Create `Image_SpeechBubbleBg`
- [ ] Create `Image_SpeechBubbleTail`
- [ ] Create `Text_SpeechContent` (start empty)
- [ ] Create `Button_Continue` (start hidden)
- [ ] Create `Image_ContinueBg`
- [ ] Create `Text_ContinueLabel` "Tap to continue ▸"
- [ ] Create `Group_Audio` with three AudioSources
- [ ] Create `TeacherWelcomeManager` empty GameObject

### Tags
- [ ] Tag `Canvas_TeacherWelcome` as `UICanvas`
- [ ] Tag `Image_TeacherCharacter` as `Teacher`
- [ ] Tag `TeacherWelcomeManager` as `GameManager`
- [ ] Tag audio sources appropriately

### Visual Setup
- [ ] Set background to teal gradient
- [ ] Set all text colors to teal palette
- [ ] Position Ms. Lumi center, Y+200
- [ ] Position speech bubble center, Y-100
- [ ] Position Continue button bottom, Y-250
- [ ] Setup snow particles with correct settings

### Audio Setup
- [ ] Import all SFX
- [ ] Music continues from previous scene
- [ ] Set volumes per spec

### Scripts
- [ ] Create `TeacherWelcomeController.cs` in Scripts/UI/
- [ ] Create `TeacherPoseController.cs` (optional)
- [ ] Attach `TeacherWelcomeController` to `TeacherWelcomeManager`
- [ ] Attach `TeacherPoseController` to `Image_TeacherCharacter`
- [ ] Wire up all Inspector references
- [ ] Set greeting template text

### Test
- [ ] Test with player name "Ben" (or any test name)
- [ ] Verify name appears correctly in greeting
- [ ] Test typewriter effect runs smoothly
- [ ] Test all animations play correctly
- [ ] Test continue button only enables after text done
- [ ] Test transition to Level Select
- [ ] Test with empty name (should use fallback "friend")
- [ ] Test returning player flow

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 02 TeacherWelcome complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Name shows as `{0}` | Format string not applied | Use `string.Format()` or `$""` |
| Text appears all at once | Typewriter coroutine not started | StartCoroutine() in correct method |
| Speech bubble too small | Wrong RectTransform size | Set to 700×280 explicitly |
| Pose changes don't show | All images active simultaneously | Use SetActive() to toggle |
| Continue button shows too early | Wrong delay | Set continuePromptDelay to 4.0f |
| Music restarts (jarring) | New AudioSource instead of continuing | Use AudioManager singleton |
| Snow particles don't show | Wrong sorting layer | Set to UI sorting layer |

---

## 💡 Tips

1. **Music continuity** — Use a persistent AudioManager so music doesn't restart between scenes
2. **Use TextMeshPro** for the speech bubble text — it handles word wrap better
3. **Test with long names** — "Maximilian" vs "Sue" — both should fit
4. **Snow particles** add charm but can be disabled on slow devices
5. **Speech bubble tail** should point toward Ms. Lumi for visual connection
6. **Don't make typing too slow** — 0.04s per letter is the sweet spot for kids

---

## 🎓 Why This Scene Matters

This is the **emotional anchor** of the entire game. Ms. Lumi will appear many more times (mission intros, victory screens), so this is where the player's relationship with her begins.

The personalized greeting is critical — when a kid sees their own name in the speech bubble, they feel **seen and valued**. It transforms the game from "an app" to "a game made for ME."

Studies show that personalized greetings in kids' apps **increase engagement by 40%**. This 5-second scene is one of the highest-ROI moments in the entire game.

---

## 🚀 Next Scene

When Scene 02 is done, move to:

**`SCENE_03_LEVEL_SELECT.md`** — Player picks which story to play (Level 1, 2, or 3)

This will cover:
- 3 story cards (one per level)
- Lock icons for unfinished levels
- Star indicators showing completion
- Card hover/tap animations
- Loading the selected story

---

**End of Scene 02 — Teacher Welcome Specification**
