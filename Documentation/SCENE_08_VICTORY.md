# Scene 08 — Victory

> **The celebration moment.** The player has completed a level. Show their stars earned, score breakdown, and let them progress to the next level (or back to level select).

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `08_Victory.unity` |
| **Type** | 2D |
| **Duration** | ~5–10 seconds (player-paced) |
| **Next scene** | `03_LevelSelect.unity` OR `09_GameComplete.unity` |
| **Previous scene** | `07_FinalSummary.unity` |
| **Build complexity** | ⭐⭐ Easy-Medium |
| **Estimated build time** | 4–5 hours |

---

## 🎯 Scene Purpose

This scene has **five jobs**:

1. 🎉 **Celebrate the win** — Make the player feel proud and accomplished
2. ⭐ **Show stars earned** — Visual reward based on performance
3. 📊 **Show score breakdown** — How the score was calculated
4. 🔓 **Unlock next level** — Save progress
5. ➡️ **Offer next action** — Replay, next level, or back to menu

---

## 👤 Player Experience (Step-by-Step)

| Time | What Player Sees | What Player Hears |
|---|---|---|
| **0.0s** | Scene fades in from white | Victory music starts |
| **0.5s** | "LEVEL X COMPLETE" badge appears | Drum roll |
| **0.8s** | "You did it!" text bounces in | Cheerful chime |
| **1.2s** | First star appears (scale + spin) | Star sound 1 |
| **1.5s** | Second star appears | Star sound 2 |
| **1.8s** | Third star appears (if earned) | Star sound 3 |
| **2.2s** | Score counts up from 0 to final | Counting tick sounds |
| **3.5s** | Ms. Lumi appears (cheering) | Whoosh + cheer |
| **3.8s** | Speech bubble with congratulations | Pop sound |
| **4.5s** | Buttons appear (Next Level + Replay) | Button appear sound |
| **+1s** | Player taps a button | Confirm sound |
| **+0.5s** | Scene transitions | Whoosh out |

**Total time:** 5–10 seconds depending on player

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│                                 │
│      LEVEL 1 COMPLETE           │  ← Top badge
│                                 │
│         You did it!             │  ← Big celebration text
│                                 │
│       ⭐    ⭐    ⭐              │  ← Stars (animated in)
│                                 │
│        Score: 850               │  ← Score (counting up)
│                                 │
│   ┌───────────────────────┐    │
│   │ Reading: +100         │    │  ← Score breakdown
│   │ Mission: +500         │    │
│   │ Time bonus: +150      │    │
│   │ Perfect bonus: +100   │    │
│   │ ─────────────────     │    │
│   │ TOTAL: 850            │    │
│   └───────────────────────┘    │
│                                 │
│           👩‍🏫                    │  ← Ms. Lumi (cheer pose)
│                                 │
│   ┌───────────────────────┐    │
│   │ "Amazing, Ben!        │    │  ← Speech bubble
│   │  Level 2 unlocked!"   │    │
│   └───────────────────────┘    │
│                                 │
│   ┌──────┐    ┌──────────┐    │
│   │Replay│    │Next Level│    │  ← Action buttons
│   └──────┘    └──────────┘    │
│                                 │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All |
| "LEVEL X COMPLETE" badge | Top, Y+400 | Auto | Top-center |
| "You did it!" text | Center, Y+250 | Auto | Center |
| Stars row | Center, Y+100 | 400×100 px | Center |
| Each star | Spaced evenly | 80×80 px | — |
| Score text | Center, Y+10 | Auto | Center |
| Score breakdown panel | Center, Y-100 | 600×200 px | Center |
| Ms. Lumi character | Center, Y-280 | 200×200 px | Center |
| Speech bubble | Center, Y-400 | 600×100 px | Center |
| Replay button | Bottom-left, Y-150 | 180×60 px | Bottom-center-left |
| Next Level button | Bottom-right, Y-150 | 220×60 px | Bottom-center-right |

---

## 🎨 Color Palette

This scene uses **green** (success/victory color).

| Element | Color | Hex |
|---|---|---|
| Background top | Light green | `#EAF3DE` |
| Background bottom | Soft mint | `#C0DD97` |
| "LEVEL X COMPLETE" badge bg | Dark green | `#173404` |
| "LEVEL X COMPLETE" badge text | White | `#FFFFFF` |
| "You did it!" text | Dark green | `#173404` |
| Star (filled) | Bright gold | `#EF9F27` |
| Star (empty/missed) | Light gray | `#D3D1C7` |
| Star border | Dark amber | `#854F0B` |
| Star glow | Yellow | `#FAC775` |
| Score text | Dark green | `#173404` |
| Score breakdown bg | White | `#FFFFFF` |
| Score breakdown border | Green | `#639922` |
| Score breakdown text | Dark green | `#173404` |
| Score total line | Bright green | `#3B6D11` |
| Speech bubble bg | White | `#FFFFFF` |
| Speech bubble border | Teal | `#1D9E75` |
| Speech bubble text | Dark teal | `#04342C` |
| Replay button bg | White | `#FFFFFF` |
| Replay button border | Green | `#639922` |
| Replay button text | Dark green | `#173404` |
| Next Level button bg | Dark green | `#173404` |
| Next Level button text | White | `#FFFFFF` |

### Why These Colors
**Green** is universally associated with success, "go," and achievement. Combined with **gold stars**, it creates the classic "victory" feel that kids respond to.

---

## 📝 Text Content

### Static Elements

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Level complete badge | `LEVEL {N} COMPLETE` | Fredoka | 16px | Bold, letter-spacing 2px |
| Main celebration | `You did it!` | Fredoka | 42px | Bold |
| Score label | `Score:` | Fredoka | 24px | Regular |
| Score value | (dynamic) | Fredoka | 32px | Bold |
| Replay button | `↻ Replay` | Fredoka | 18px | Bold |
| Next Level button | `Next Level ▸` | Fredoka | 18px | Bold |

### Score Breakdown Text

```
Reading questions: +{readingScore}
Mission elements:  +{missionScore}
Time bonus:        +{timeBonus}
Finish bonus:      +{finishBonus}
Perfect bonus:     +{perfectBonus}
─────────────────────
TOTAL:             {finalScore}
```

### Ms. Lumi's Congratulations (Per Star Count)

| Stars | Message |
|---|---|
| 3 stars | `"Amazing, {name}! That was perfect! Level {N+1} is now unlocked!"` |
| 2 stars | `"Great job, {name}! You're doing wonderful! Level {N+1} is now unlocked!"` |
| 1 star | `"Good work, {name}! You finished! Level {N+1} is now unlocked!"` |

### Special Cases

| Condition | Message |
|---|---|
| Just finished Level 3 | `"Wow {name}! You completed all 3 stories! 🎉"` (Then go to Scene 09) |
| Replay (already 3 stars) | `"You already mastered this one!"` |

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/victory_fanfare.mp3` |
| **Volume** | 0.7 |
| **Loop** | Yes (after intro) |
| **Fade from previous** | Yes (0.5s) |

### Sound Effects

| Trigger | File | Volume | When |
|---|---|---|---|
| Level complete badge appears | `drumroll.wav` | 0.7 | At 0.5s |
| "You did it!" text | `cheer_short.wav` | 0.8 | At 0.8s |
| Star 1 appears | `star_appear_1.wav` | 0.8 | At 1.2s |
| Star 2 appears | `star_appear_2.wav` | 0.8 | At 1.5s |
| Star 3 appears | `star_appear_3.wav` | 0.9 | At 1.8s |
| Score counting | `count_tick.wav` | 0.4 | Per tick (rapid) |
| Score final | `score_final_chime.wav` | 0.7 | When done counting |
| Ms. Lumi appears | `whoosh_in.wav` | 0.5 | At 3.5s |
| Speech bubble | `pop_soft.wav` | 0.7 | At 3.8s |
| Buttons appear | `button_appear.wav` | 0.5 | At 4.5s |
| Replay tap | `button_back.wav` | 0.7 | On tap |
| Next Level tap | `button_confirm_big.wav` | 0.9 | On tap |

**Source:** Mostly Dustyroom Pack + Pixabay for victory fanfare

### Optional Voice

| File | When |
|---|---|
| `lumi_congrats_3stars.mp3` | If 3 stars earned |
| `lumi_congrats_2stars.mp3` | If 2 stars earned |
| `lumi_congrats_1star.mp3` | If 1 star earned |

---

## 🎬 Animations

| # | Element | Animation | When | Duration | Easing |
|---|---|---|---|---|---|
| 1 | Background | Fade in | 0.0s | 0.5s | EaseOut |
| 2 | "LEVEL X COMPLETE" badge | Drop down + scale | 0.5s | 0.4s | EaseOutBack |
| 3 | "You did it!" text | Scale (0→1) + bounce | 0.8s | 0.5s | EaseOutBack |
| 4 | Star 1 | Spin in (rotate 360°) + scale + glow | 1.2s | 0.4s | EaseOutBack |
| 5 | Star 2 | Same | 1.5s | 0.4s | EaseOutBack |
| 6 | Star 3 | Same | 1.8s | 0.4s | EaseOutBack |
| 7 | Score | Count up from 0 to final | 2.2s | 1.2s | Linear |
| 8 | Score breakdown | Fade in line by line | 2.5s | 0.2s each | EaseOut |
| 9 | Ms. Lumi | Slide in from bottom + cheer pose | 3.5s | 0.4s | EaseOutBack |
| 10 | Speech bubble | Scale + fade | 3.8s | 0.3s | EaseOutBack |
| 11 | Replay button | Slide in from left | 4.5s | 0.3s | EaseOutBack |
| 12 | Next Level button | Slide in from right | 4.5s | 0.3s | EaseOutBack |
| 13 | Next Level button pulse | Scale 1.0 ↔ 1.05 (looped) | 5.0s | 0.7s | EaseInOut |
| 14 | Stars (continuous) | Subtle pulse glow | 2.0s+ | 1.5s loop | EaseInOut |
| 15 | All elements | Fade out | On tap | 0.4s | EaseIn |

### Star Spin-In Animation

```csharp
star.transform.localScale = Vector3.zero;
Sequence starSeq = DOTween.Sequence();
starSeq.Append(star.transform.DOScale(1.3f, 0.3f).SetEase(Ease.OutBack));
starSeq.Append(star.transform.DOScale(1.0f, 0.1f));
star.transform.DORotate(new Vector3(0, 0, 360), 0.4f, RotateMode.FastBeyond360);
PlaySound(starSound);
```

### Score Count-Up Animation

```csharp
int displayScore = 0;
int targetScore = 850;
DOTween.To(() => displayScore, x => {
    displayScore = x;
    scoreText.text = displayScore.ToString();
    if (displayScore % 20 == 0) PlaySound(countTick);
}, targetScore, 1.2f);
```

---

## 🛠️ GameObject Hierarchy & Names

```
VictoryScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_Victory                           [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   ├── Image_BackgroundGradient
│   │   └── ParticleSystem_Confetti          (optional)
│   │
│   ├── Group_Header                         [Tag: Untagged]
│   │   ├── Image_LevelCompleteBadge
│   │   └── Text_LevelCompleteLabel          ("LEVEL 1 COMPLETE")
│   │
│   ├── Text_YouDidIt                        [Tag: Untagged] ("You did it!")
│   │
│   ├── Group_Stars                          [Tag: Untagged]
│   │   ├── Star_1
│   │   │   ├── Image_StarBg
│   │   │   ├── Image_StarIcon
│   │   │   └── Image_StarGlow
│   │   ├── Star_2
│   │   │   └── (same structure)
│   │   └── Star_3
│   │       └── (same structure)
│   │
│   ├── Group_Score                          [Tag: Untagged]
│   │   ├── Text_ScoreLabel ("Score:")
│   │   └── Text_ScoreValue (counts up)
│   │
│   ├── Panel_ScoreBreakdown                 [Tag: Untagged]
│   │   ├── Image_PanelBg
│   │   ├── Text_BreakdownReading
│   │   ├── Text_BreakdownMission
│   │   ├── Text_BreakdownTime
│   │   ├── Text_BreakdownFinish
│   │   ├── Text_BreakdownPerfect
│   │   ├── Image_DivisionLine
│   │   └── Text_BreakdownTotal
│   │
│   ├── Group_Teacher                        [Tag: Untagged]
│   │   └── Image_TeacherCharacter           [Tag: Teacher]
│   │       └── Image_TeacherCheer           (cheer pose)
│   │
│   ├── Group_SpeechBubble                   [Tag: Untagged]
│   │   ├── Image_SpeechBubbleBg
│   │   └── Text_SpeechContent
│   │
│   └── Group_Buttons                        [Tag: Untagged]
│       ├── Button_Replay                    [Tag: Untagged]
│       │   ├── Image_ReplayBg
│       │   └── Text_ReplayLabel
│       └── Button_NextLevel                 [Tag: Untagged]
│           ├── Image_NextLevelBg
│           └── Text_NextLevelLabel
│
├── EventSystem                              [Tag: Untagged]
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   ├── AudioSource_SFX                      [Tag: AudioSFX]
│   └── AudioSource_Voice                    [Tag: AudioVoice]
│
└── VictoryManager                           [Tag: GameManager]
    └── VictoryController.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_Victory` |
| `Group_` | Container | `Group_Stars` |
| `Panel_` | Panel | `Panel_ScoreBreakdown` |
| `Star_` | Star object | `Star_1`, `Star_2`, `Star_3` |
| `Image_`, `Text_`, `Button_` | UI elements | `Text_ScoreValue` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_Victory | Identifies main canvas |
| `Teacher` | Image_TeacherCharacter | Ms. Lumi reference |
| `GameManager` | VictoryManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music |
| `AudioSFX` | AudioSource_SFX | SFX |
| `AudioVoice` | AudioSource_Voice | Voice (if used) |

---

## 💻 Scripts Required

### `VictoryController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/VictoryController.cs`
**Attached to:** `VictoryManager` GameObject

**Responsibilities:**
1. Load final score and stats from PlayerPrefs
2. Calculate stars earned based on score
3. Save unlocked level progress
4. Run animation sequence
5. Handle button taps (Replay or Next Level)

**Inspector Variables:**

```csharp
[Header("UI References")]
public TextMeshProUGUI levelCompleteLabel;
public TextMeshProUGUI youDidItText;
public Image[] starImages;             // Drag: Star_1, Star_2, Star_3
public Image[] starGlows;
public TextMeshProUGUI scoreText;
public TextMeshProUGUI breakdownReading;
public TextMeshProUGUI breakdownMission;
public TextMeshProUGUI breakdownTime;
public TextMeshProUGUI breakdownFinish;
public TextMeshProUGUI breakdownPerfect;
public TextMeshProUGUI breakdownTotal;
public Image teacherImage;
public RectTransform speechBubble;
public TextMeshProUGUI speechText;
public Button replayButton;
public Button nextLevelButton;
public TextMeshProUGUI nextLevelButtonText;

[Header("Star Sprites")]
public Sprite starFilled;
public Sprite starEmpty;

[Header("Audio")]
public AudioSource musicSource;
public AudioSource sfxSource;
public AudioClip drumrollSound;
public AudioClip cheerSound;
public AudioClip starSound1;
public AudioClip starSound2;
public AudioClip starSound3;
public AudioClip countTickSound;
public AudioClip scoreFinalSound;
public AudioClip whooshInSound;
public AudioClip popSound;
public AudioClip buttonAppearSound;
public AudioClip buttonBackSound;
public AudioClip buttonConfirmSound;

[Header("Star Thresholds (from Game Balance)")]
public int oneStarThreshold = 250;
public int twoStarThreshold = 500;
public int threeStarThreshold = 750;

[Header("Scene Names")]
public string levelSelectSceneName = "03_LevelSelect";
public string gameCompleteSceneName = "09_GameComplete";
public string storyReaderSceneName = "04_StoryReader";
```

**Methods:**

```csharp
void Start()                              // Initialize, load data
void LoadScoreData()                      // Read all scores from PlayerPrefs
int CalculateStarsEarned(int finalScore)  // Returns 0, 1, 2, or 3
void SaveProgress(int starsEarned)        // Save to PlayerPrefs (unlock next level)
IEnumerator AnimationSequence()           // Main timeline
IEnumerator ShowStars(int starCount)      // Animate stars in
IEnumerator CountUpScore(int target)      // Animate score counting
IEnumerator ShowBreakdown()               // Reveal breakdown lines
IEnumerator ShowTeacher()                 // Slide Ms. Lumi in
string GetCongratsMessage(int stars, string playerName) // Per-star message
void OnReplayClicked()                    // Reload story reader
void OnNextLevelClicked()                 // Load next level OR game complete
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Green gradient background | `bg_green_gradient.png` | Create or solid | ❌ TODO |
| Confetti texture (optional) | `confetti.png` | Reuse from Scene 07 | ✅ Ready |
| Level complete badge bg | `badge_dark_green.png` | Create | ❌ TODO |
| Star filled (gold) | `star_gold.png` | Kenney UI | ❌ TODO |
| Star empty (gray) | `star_empty.png` | Kenney UI | ❌ TODO |
| Star glow effect | `star_glow.png` | Create (soft glow) | ❌ TODO |
| Score breakdown panel | `panel_white_rounded.png` | Reuse | ✅ Ready |
| Ms. Lumi cheer pose | `lumi_cheer.png` | AI generation | ❌ TODO |
| Speech bubble (reused) | `speech_bubble.png` | Reuse from Scene 02 | ✅ Ready |
| Replay button bg | `button_white_rounded.png` | Reuse | ✅ Ready |
| Next Level button bg | `button_dark_green.png` | Create | ❌ TODO |

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Victory fanfare music | `victory_fanfare.mp3` | Pixabay | ❌ TODO |
| Drumroll | `drumroll.wav` | Dustyroom Pack | ❌ TODO |
| Cheer short | `cheer_short.wav` | Dustyroom Pack | ❌ TODO |
| Star appear 1 | `star_appear_1.wav` | Dustyroom Pack | ❌ TODO |
| Star appear 2 | `star_appear_2.wav` | Dustyroom Pack | ❌ TODO |
| Star appear 3 | `star_appear_3.wav` | Dustyroom Pack | ❌ TODO |
| Count tick | `count_tick.wav` | Dustyroom Pack | ❌ TODO |
| Score final chime | `score_final_chime.wav` | Dustyroom Pack | ❌ TODO |
| Whoosh in | `whoosh_in.wav` | Reused | ✅ Ready |
| Pop soft | `pop_soft.wav` | Reused | ✅ Ready |
| Button appear | `button_appear.wav` | Dustyroom Pack | ❌ TODO |
| Button back | `button_back.wav` | Reused | ✅ Ready |
| Button confirm big | `button_confirm_big.wav` | Reused | ✅ Ready |

---

## ⚙️ Unity Settings

### Camera
- Same as previous 2D scenes (Orthographic, size 5)

### Canvas
- Same as previous 2D scenes (Screen Space Overlay, 1080×1920)

---

## 🔄 Scene Transitions

### Coming In
- **From:** `07_FinalSummary`
- **Trigger:** Player tapped Submit
- **Reads:** All score data from PlayerPrefs
- **Transition in:** Fade in (0.5s)

### Going Out (3 possible destinations)

**Path 1: Player taps Next Level (and there IS a next level)**
- **To:** `04_StoryReader` (with currentLevel incremented)
- **Saves:** `currentLevel++`
- **Method:** `SceneManager.LoadSceneAsync("04_StoryReader")`

**Path 2: Player just finished Level 3**
- **To:** `09_GameComplete`
- **Saves:** `gameCompleted = 1`
- **Method:** `SceneManager.LoadSceneAsync("09_GameComplete")`

**Path 3: Player taps Replay**
- **To:** `04_StoryReader` (same level)
- **Method:** `SceneManager.LoadSceneAsync("04_StoryReader")`

---

## 💾 Data Read/Written

### Read From PlayerPrefs

```csharp
int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
int readingScore = PlayerPrefs.GetInt("readingScore", 0);
int missionScore = PlayerPrefs.GetInt("missionScore", 0);
int summaryScore = PlayerPrefs.GetInt("summaryScore", 0);
float timeRemaining = PlayerPrefs.GetFloat("timeRemaining", 0);
bool wasCaught = PlayerPrefs.GetInt("wasCaught", 0) == 1;
int finalScore = PlayerPrefs.GetInt("finalScore", 0);
string playerName = PlayerPrefs.GetString("playerName", "friend");
```

### Written To PlayerPrefs

```csharp
// Save stars earned for this level
int starsEarned = CalculateStarsEarned(finalScore);
PlayerPrefs.SetInt($"level{currentLevel}Stars", 
    Mathf.Max(starsEarned, PlayerPrefs.GetInt($"level{currentLevel}Stars", 0)));

// Unlock next level
if (currentLevel == 1 && starsEarned > 0) {
    PlayerPrefs.SetInt("level2Unlocked", 1);
}
if (currentLevel == 2 && starsEarned > 0) {
    PlayerPrefs.SetInt("level3Unlocked", 1);
}
if (currentLevel == 3 && starsEarned > 0) {
    PlayerPrefs.SetInt("gameCompleted", 1);
}

// Save best score
int bestScore = PlayerPrefs.GetInt($"level{currentLevel}BestScore", 0);
if (finalScore > bestScore) {
    PlayerPrefs.SetInt($"level{currentLevel}BestScore", finalScore);
}

PlayerPrefs.Save();
```

**Important:** Always keep the **highest** stars earned. Don't overwrite a 3-star result with a 1-star replay!

---

## 🎯 Star Calculation Logic

```csharp
int CalculateStarsEarned(int finalScore) {
    if (finalScore >= threeStarThreshold) return 3;  // 750+
    if (finalScore >= twoStarThreshold) return 2;    // 500+
    if (finalScore >= oneStarThreshold) return 1;    // 250+
    return 0;  // Should not happen if player finished
}
```

### Star Display

| Stars | Visual |
|---|---|
| 3 | ⭐⭐⭐ (all gold) |
| 2 | ⭐⭐☆ (2 gold, 1 gray) |
| 1 | ⭐☆☆ (1 gold, 2 gray) |
| 0 | ☆☆☆ (all gray — shouldn't happen) |

---

## ✅ Build Checklist

### Setup
- [ ] Create `08_Victory.unity` scene
- [ ] Add to Build Settings as scene index 8

### GameObjects (use exact names!)
- [ ] Create `Canvas_Victory`
- [ ] Create `BG_Background`
- [ ] Create `Group_Header` with badge
- [ ] Create `Text_YouDidIt`
- [ ] Create `Group_Stars` with 3 star objects
- [ ] Each star: bg, icon, glow
- [ ] Create `Group_Score` with label and value
- [ ] Create `Panel_ScoreBreakdown` with all breakdown lines
- [ ] Create `Group_Teacher` with cheer pose
- [ ] Create `Group_SpeechBubble`
- [ ] Create `Group_Buttons`
- [ ] Create `Button_Replay`
- [ ] Create `Button_NextLevel`
- [ ] Create `Group_Audio` with three AudioSources
- [ ] Create `VictoryManager` GameObject

### Tags
- [ ] Tag canvas as `UICanvas`
- [ ] Tag teacher image as `Teacher`
- [ ] Tag manager as `GameManager`
- [ ] Tag audio sources

### Visual Setup
- [ ] Set background to green gradient
- [ ] Set all colors per palette
- [ ] Position all elements per layout

### Scripts
- [ ] Create `VictoryController.cs` in Scripts/UI/
- [ ] Attach to `VictoryManager`
- [ ] Wire up all Inspector references
- [ ] Set star thresholds (250/500/750)

### Test
- [ ] Test with score 200 → 0 stars (or 1 minimum?)
- [ ] Test with score 300 → 1 star
- [ ] Test with score 600 → 2 stars
- [ ] Test with score 900 → 3 stars
- [ ] Test star animations
- [ ] Test score count-up
- [ ] Test breakdown display
- [ ] Test Replay button → goes to story reader
- [ ] Test Next Level button → goes to next level
- [ ] Test after Level 3 → goes to GameComplete
- [ ] Test best score saving (don't overwrite higher)

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 08 Victory complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Stars don't appear | SetActive(false) not toggling | Check star.SetActive(true) |
| Score doesn't count up | DOTween not used | Use DOTween.To for smooth count |
| Wrong number of stars | Threshold logic wrong | Check >= vs > |
| Best score overwritten | No max check | Use Mathf.Max() before saving |
| Next level doesn't unlock | PlayerPrefs key wrong | Verify key spelling |
| After Level 3 wrong scene | Logic missing | Check `if (currentLevel == 3)` |

---

## 💡 Tips

1. **Keep best score** — Use Mathf.Max() so replays don't lower the score
2. **Stars matter most** — Always keep the highest star count earned
3. **Auto-progression** — After Level 3, auto-go to Game Complete scene
4. **Subtle particles** — Optional confetti adds polish but not required
5. **Voice congrats** — Pre-recorded voices for 3 different star counts
6. **Test edge cases** — Score 249 (no stars?), 250 (1 star), etc.

---

## 🎓 Why This Scene Matters

Victory scenes are the **dopamine hit** that keeps players coming back. Studies show players who feel rewarded after completing a level are **3x more likely to play again**.

The score breakdown is also educational — it shows the player **exactly what they earned points for**, reinforcing which behaviors are valuable (reading carefully, finishing quickly, no fixes needed).

This scene closes the loop: Read → Run → Reflect → **Reward**.

---

## 🚀 Next Scene

When Scene 08 is done, move to:

**`SCENE_09_GAME_COMPLETE.md`** — The final celebration after completing all 3 levels

This will cover:
- Special "ALL LEVELS COMPLETE" celebration
- Total score across all levels
- Special message from Ms. Lumi
- Option to replay any level
- Credits

---

**End of Scene 08 — Victory Specification**
