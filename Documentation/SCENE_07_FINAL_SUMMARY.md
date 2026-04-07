# Scene 07 — Final Summary

> **The reflection moment.** After the run, the player must fix any wrong answers they collected and type a complete summary of the story using the Somebody-Wanted-But-So-Then framework.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `07_FinalSummary.unity` |
| **Type** | 2D |
| **Duration** | 1–3 minutes (player-paced) |
| **Next scene** | `08_Victory.unity` |
| **Previous scene** | `06_Mission3DRun.unity` |
| **Build complexity** | ⭐⭐⭐ Medium |
| **Estimated build time** | 6–8 hours |

---

## 🎯 Scene Purpose

This scene has **four jobs**:

1. ⚠️ **Show wrong answers** — Highlight which elements need fixing
2. 🔧 **Allow correction** — Let player tap correct answer (with timer pressure)
3. ✍️ **Test summarization** — Player types a sentence using the elements
4. 📊 **Final score calculation** — Add typing bonus to total score

---

## 👤 Player Experience (Step-by-Step)

### If Player Has Wrong Answers:

| Step | What Player Sees | What Player Does |
|---|---|---|
| 1 | Scene fades in | Watching |
| 2 | Element bar shown with green ✓ and red ✗ items | Reading |
| 3 | First wrong element popup appears with timer | Reading |
| 4 | Player taps correct answer | Tapping |
| 5 | Element turns green ✓ | Relief |
| 6 | Next wrong element popup (if any) | Repeat |
| 7 | All elements correct, popup closes | Success |
| 8 | Summary input appears with 5 element prompts | Reading prompts |
| 9 | Player types summary in text box | Typing |
| 10 | Player taps Submit | Tapping |
| 11 | Brief validation animation | Anticipating |
| 12 | Scene fades to Victory | Excited |

### If Player Has All Correct (No Wrong):

| Step | What Player Sees | What Player Does |
|---|---|---|
| 1 | Scene fades in | Watching |
| 2 | "All elements correct!" celebration | Smiling |
| 3 | Skip directly to typing summary | Reading prompts |
| 4 | Player types summary | Typing |
| 5 | Player taps Submit | Tapping |
| 6 | Scene fades to Victory | Excited |

**Total time:** 1–3 minutes

---

## 🎨 Visual Layout

### Phase 1: Element Status View

```
┌─────────────────────────────────┐
│  ⏱ FINAL TASK 0:24              │  ← Header with overall timer
│                                 │
│       Write your summary        │  ← Title
│                                 │
│  ┌───────────────────────────┐ │
│  │ Somebody:                 │ │
│  │ ┌─────────────────────┐   │ │
│  │ │ Max the puppy ✓    │   │ │  ← Green = correct
│  │ └─────────────────────┘   │ │
│  │                           │ │
│  │ Wanted:                   │ │
│  │ ┌─────────────────────┐   │ │
│  │ │ to find way home ✓ │   │ │
│  │ └─────────────────────┘   │ │
│  │                           │ │
│  │ But:                      │ │
│  │ ┌─────────────────────┐   │ │
│  │ │ he met a friend ✗  │   │ │  ← Red = wrong (tap to fix)
│  │ └─────────────────────┘   │ │
│  │                           │ │
│  │ So:                       │ │
│  │ ┌─────────────────────┐   │ │
│  │ │ followed smells ✓  │   │ │
│  │ └─────────────────────┘   │ │
│  │                           │ │
│  │ Then:                     │ │
│  │ ┌─────────────────────┐   │ │
│  │ │ owner found him ✓  │   │ │
│  │ └─────────────────────┘   │ │
│  └───────────────────────────┘ │
│                                 │
│  Your summary:                  │
│  ┌───────────────────────────┐ │
│  │ [text input field]        │ │
│  └───────────────────────────┘ │
│                                 │
│      ┌──────────────┐          │
│      │   Submit ▸   │          │  ← Disabled until valid
│      └──────────────┘          │
└─────────────────────────────────┘
```

### Phase 2: Fix Popup (overlay when wrong element exists)

```
┌─────────────────────────────────┐
│ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │  ← Dimmed background
│ ░░  ┌──────────────────┐  ░░  │
│ ░░  │  ⏱ 18s LEFT      │  ░░  │
│ ░░  │                  │  ░░  │
│ ░░  │  BUT — what was  │  ░░  │  ← Question
│ ░░  │  the problem?    │  ░░  │
│ ░░  │                  │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ 👫 He met a  │ │  ░░  │  ← Wrong pick (red)
│ ░░  │ │   friend ✗   │ │  ░░  │
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ 🌲 He got    │ │  ░░  │  ← Other options
│ ░░  │ │   lost       │ │  ░░  │
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ 😴 He fell   │ │  ░░  │
│ ░░  │ │   asleep     │ │  ░░  │
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  │                  │  ░░  │
│ ░░  │ Tap correct one  │  ░░  │
│ ░░  └──────────────────┘  ░░  │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All |
| Header bar | Top, full width | 1080×100 px | Top |
| Timer text | Top-left of header | Auto | Top-left |
| Title "Write your summary" | Top, Y-150 | Auto | Center |
| Elements panel | Center, Y+50 | 800×600 px | Center |
| Each element row | Inside panel | 760×60 px | Stacked |
| Summary input field | Below panel, Y-300 | 800×120 px | Center |
| Submit button | Bottom, Y-150 | 280×80 px | Center |

---

## 🎨 Color Palette

This scene uses **purple** to match the reflection/thinking theme.

| Element | Color | Hex |
|---|---|---|
| Background | Soft lavender | `#EEEDFE` |
| Header bar | Deep purple | `#26215C` |
| Header text | White | `#FFFFFF` |
| Title text | Deep purple | `#26215C` |
| Elements panel bg | White | `#FFFFFF` |
| Elements panel border | Purple | `#7F77DD` |
| Element label (Somebody, etc.) | Medium purple | `#7F77DD` |
| Correct element bg | Light teal | `#E1F5EE` |
| Correct element text | Dark teal | `#04342C` |
| Wrong element bg | Light red | `#FCEBEB` |
| Wrong element text | Dark red | `#501313` |
| Wrong element border | Red | `#A32D2D` (2px, pulsing) |
| Input field bg | White | `#FFFFFF` |
| Input field border | Purple | `#7F77DD` |
| Input field text | Deep purple | `#26215C` |
| Submit button (active) | Deep purple | `#26215C` |
| Submit button (disabled) | Gray | `#B4B2A9` |
| Submit button text | White | `#FFFFFF` |

### Fix Popup Colors

| Element | Color | Hex |
|---|---|---|
| Dim overlay | Black 50% | `rgba(0,0,0,0.5)` |
| Popup background | White | `#FFFFFF` |
| Popup border | Amber | `#BA7517` (2px) |
| Timer label | Amber | `#BA7517` |
| Question text | Dark amber | `#412402` |
| Wrong answer (already picked) bg | Light red | `#FCEBEB` |
| Wrong answer border | Red | `#A32D2D` (2px) |
| Other answer bg | White | `#FFFFFF` |
| Other answer border | Amber | `#BA7517` |
| Hint text | Medium amber | `#854F0B` |

---

## 📝 Text Content

### UI Labels

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Header timer | `⏱ FINAL TASK 0:30` | Fredoka | 14px | Bold |
| Title | `Write your summary` | Fredoka | 28px | Bold |
| Element labels | `Somebody:`, `Wanted:`, `But:`, `So:`, `Then:` | Fredoka | 14px | Regular |
| Input placeholder | `Type your summary here...` | Fredoka | 16px | Regular |
| Submit button | `Submit ▸` | Fredoka | 18px | Bold |

### Fix Popup Text

| Element | Text | Notes |
|---|---|---|
| Timer | `⏱ {seconds}s LEFT` | Counts down |
| Question prompt | (varies by element type) | See below |
| Hint | `Tap the correct answer to fix it` | Always shown |

### Question Prompts (per element)

| Element | Prompt |
|---|---|
| Somebody | `SOMEBODY — who was the main character?` |
| Wanted | `WANTED — what did they want?` |
| But | `BUT — what was the problem?` |
| So | `SO — what did they do?` |
| Then | `THEN — what happened in the end?` |

### Summary Validation

The player's summary should contain keywords related to all 5 elements. Validation is **lenient** — kids' typing isn't perfect.

**Keyword examples (Level 1 - Max the Puppy):**
- Somebody keywords: "max", "puppy", "dog"
- Wanted keywords: "home", "find", "way back"
- But keywords: "lost", "wandered", "got"
- So keywords: "smell", "followed", "nose"
- Then keywords: "found", "owner", "lily", "hugged"

**Validation rule:** At least 3 of 5 element keywords must be present.

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/reflection_calm.mp3` |
| **Volume** | 0.5 |
| **Loop** | Yes |
| **Fade from previous** | Yes (0.5s) |

### Sound Effects

| Trigger | File | Volume |
|---|---|---|
| Scene appears | `paper_rustle.wav` | 0.5 |
| Fix popup appears | `popup_open.wav` | 0.7 |
| Tap correct answer (in popup) | `correct_chime.wav` | 0.8 |
| Element fixed (turns green) | `element_fixed.wav` | 0.7 |
| All elements correct | `all_correct_fanfare.wav` | 0.9 |
| Type letter (optional) | `type_tick.wav` | 0.2 |
| Tap Submit (valid) | `submit_confirm.wav` | 0.9 |
| Tap Submit (invalid) | `error_soft.wav` | 0.6 |
| Timer warning (10s left) | `timer_warning.wav` | 0.7 |
| Timer up (auto-skip) | `timer_alarm.wav` | 0.8 |

**Source:** Dustyroom Free Casual Game SFX Pack

---

## 🎬 Animations

| Element | Animation | When | Duration |
|---|---|---|---|
| Scene | Fade in | 0.0s | 0.5s |
| Title | Slide down + fade | 0.2s | 0.4s |
| Elements panel | Scale (0.9→1) + fade | 0.4s | 0.4s |
| Each element row | Stagger fade in | 0.6s + 0.1s each | 0.3s each |
| Wrong element border | Pulse (alpha 0.5↔1.0) | continuous | 1s loop |
| Fix popup | Scale (0.8→1) + fade | On show | 0.3s |
| Fix popup tap correct | Element flashes green + scales | On tap | 0.4s |
| Element row "fixed" | Color change red→green | On fix | 0.5s |
| All correct celebration | Confetti + sound | When all green | 1.5s |
| Input field | Fade in | After fix done | 0.3s |
| Submit button | Color shift gray→purple | When summary valid | 0.3s |
| Submit pressed | Scale bounce (1→0.95→1) | On tap | 0.2s |
| Scene exit | Fade out | On submit | 0.4s |

### Confetti Effect (Optional)

When all elements become correct, a brief confetti burst plays:

```csharp
ParticleSystem confetti = Instantiate(confettiPrefab);
confetti.Play();
PlaySound(allCorrectFanfare);
yield return new WaitForSeconds(1.5f);
ShowSummaryInput();
```

---

## 🛠️ GameObject Hierarchy & Names

```
FinalSummaryScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_FinalSummary                      [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   └── Image_BackgroundColor
│   │
│   ├── Group_Header                         [Tag: Untagged]
│   │   ├── Image_HeaderBg
│   │   └── Text_HeaderTimer
│   │
│   ├── Text_Title                           [Tag: Untagged]
│   │
│   ├── Panel_Elements                       [Tag: Untagged]
│   │   ├── Image_PanelBg
│   │   ├── Image_PanelBorder
│   │   ├── ElementRow_Somebody              [Tag: Untagged]
│   │   │   ├── Text_ElementLabel            ("Somebody:")
│   │   │   ├── Image_ElementBg
│   │   │   └── Text_ElementValue
│   │   ├── ElementRow_Wanted                [Tag: Untagged]
│   │   │   └── (same structure)
│   │   ├── ElementRow_But                   [Tag: Untagged]
│   │   ├── ElementRow_So                    [Tag: Untagged]
│   │   └── ElementRow_Then                  [Tag: Untagged]
│   │
│   ├── Group_SummaryInput                   [Tag: Untagged]
│   │   ├── Text_SummaryLabel                ("Your summary:")
│   │   └── InputField_Summary               [Tag: SummaryInput]
│   │       ├── Image_InputBg
│   │       ├── Text_Placeholder
│   │       └── Text_TypedSummary
│   │
│   ├── Button_Submit                        [Tag: Untagged]
│   │   ├── Image_SubmitBg
│   │   └── Text_SubmitLabel
│   │
│   └── Text_ValidationMessage               [Tag: Untagged] (hidden)
│
├── Canvas_FixPopup                          [Tag: UICanvas] (separate, hidden)
│   ├── Image_DimOverlay
│   ├── Image_PopupBg
│   ├── Text_PopupTimer
│   ├── Text_PopupQuestion
│   ├── Group_AnswerOptions                  [Tag: Untagged]
│   │   ├── Button_AnswerOption_A            [Tag: Untagged]
│   │   ├── Button_AnswerOption_B            [Tag: Untagged]
│   │   └── Button_AnswerOption_C            [Tag: Untagged]
│   └── Text_PopupHint
│
├── Canvas_Confetti                          [Tag: Untagged]
│   └── ParticleSystem_Confetti              [Tag: Untagged]
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   └── AudioSource_SFX                      [Tag: AudioSFX]
│
└── FinalSummaryManager                      [Tag: GameManager]
    ├── FinalSummaryController.cs (script)
    └── SummaryValidator.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_FinalSummary` |
| `Panel_` | UI Panel | `Panel_Elements` |
| `Group_` | Container | `Group_SummaryInput` |
| `ElementRow_` | Element row | `ElementRow_Somebody` |
| `Image_`, `Text_`, `Button_` | UI elements | `Text_HeaderTimer` |
| `InputField_` | Input field | `InputField_Summary` |
| `ParticleSystem_` | Particles | `ParticleSystem_Confetti` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_FinalSummary, Canvas_FixPopup | Identifies canvases |
| `SummaryInput` | InputField_Summary | Script can find input |
| `GameManager` | FinalSummaryManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music |
| `AudioSFX` | AudioSource_SFX | SFX |

---

## 💻 Scripts Required

### `FinalSummaryController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/FinalSummaryController.cs`
**Attached to:** `FinalSummaryManager` GameObject

**Responsibilities:**
1. Load collected elements from PlayerPrefs
2. Display elements with correct/wrong states
3. Show fix popups for wrong elements
4. Handle fix interactions
5. Validate summary input
6. Save final score and load Victory scene

**Inspector Variables:**

```csharp
[Header("UI References")]
public TextMeshProUGUI headerTimerText;
public TextMeshProUGUI titleText;
public ElementRow[] elementRows;          // 5 element row components
public TMP_InputField summaryInputField;
public Button submitButton;
public Image submitButtonBg;
public TextMeshProUGUI validationMessage;

[Header("Fix Popup")]
public GameObject fixPopupCanvas;
public TextMeshProUGUI popupTimerText;
public TextMeshProUGUI popupQuestionText;
public Button[] answerOptionButtons;
public TextMeshProUGUI[] answerOptionTexts;
public Image[] answerOptionBackgrounds;

[Header("Confetti")]
public ParticleSystem confettiParticles;

[Header("Audio")]
public AudioSource sfxSource;
public AudioClip paperRustleSound;
public AudioClip popupOpenSound;
public AudioClip correctChimeSound;
public AudioClip elementFixedSound;
public AudioClip allCorrectFanfareSound;
public AudioClip submitConfirmSound;
public AudioClip errorSound;
public AudioClip timerWarningSound;

[Header("Settings")]
public Color correctColor = new Color(0.882f, 0.961f, 0.933f);  // #E1F5EE
public Color wrongColor = new Color(0.988f, 0.922f, 0.922f);    // #FCEBEB
public Color disabledColor = new Color(0.706f, 0.698f, 0.663f); // #B4B2A9
public Color activeColor = new Color(0.149f, 0.129f, 0.361f);   // #26215C

[Header("Timer")]
public float fixPopupDuration = 30f;
public float overallTaskDuration = 60f;

[Header("Validation")]
public int minKeywordsRequired = 3;       // Min keywords for valid summary

[Header("Next Scene")]
public string nextSceneName = "08_Victory";
```

**Methods:**

```csharp
void Start()                              // Initialize, load data
void LoadCollectedElements()              // From PlayerPrefs
void DisplayElements()                    // Show all 5 with states
void CheckForWrongElements()              // Are there any to fix?
IEnumerator FixWrongElementsSequence()    // Show popups one by one
void ShowFixPopup(int elementIndex)       // Display fix popup
IEnumerator FixPopupTimer(float duration) // Countdown
void OnAnswerOptionClicked(int answerIndex) // Handle fix tap
void OnElementFixed(int elementIndex)     // Update state
void ShowAllCorrectCelebration()          // Confetti + sound
void ShowSummaryInputUI()                 // Reveal input field
void OnSummaryChanged(string text)        // Validate as user types
bool ValidateSummary(string text)         // Check keywords
void OnSubmitClicked()                    // Save and load next
void TransitionToNextScene()              // Save data, load Victory
```

### `SummaryValidator.cs` — Validation Logic

**Location:** `Assets/_Game/Scripts/Utils/SummaryValidator.cs`
**Attached to:** `FinalSummaryManager` GameObject

**Responsibilities:**
1. Check if user's summary contains required keywords
2. Return validation result and missing keywords

**Inspector Variables:**

```csharp
[Header("Keyword Lists per Element (set per level)")]
public string[] somebodyKeywords;
public string[] wantedKeywords;
public string[] butKeywords;
public string[] soKeywords;
public string[] thenKeywords;
```

**Methods:**

```csharp
public ValidationResult Validate(string userSummary, int requiredCount)
public class ValidationResult {
    public bool isValid;
    public int matchedCount;
    public string[] missingElements;
}
```

### `ElementRow.cs` — Per-Row Component

**Location:** `Assets/_Game/Scripts/UI/ElementRow.cs`
**Attached to:** Each `ElementRow_X` GameObject (5 total)

**Responsibilities:**
1. Display element name and value
2. Show correct/wrong state visually
3. Animate state change

**Inspector Variables:**

```csharp
[Header("Identity")]
public string elementType;            // "Somebody", "Wanted", "But", "So", "Then"
public int elementIndex;              // 0-4

[Header("References")]
public TextMeshProUGUI labelText;
public TextMeshProUGUI valueText;
public Image backgroundImage;
public Image borderImage;

[Header("State Colors")]
public Color correctBgColor;
public Color wrongBgColor;
public Color borderPulseColor;
```

**Methods:**

```csharp
void SetElement(string value, bool isCorrect)
void AnimateFix()                     // Red → green animation
void StartPulseBorder()                // For wrong elements
void StopPulseBorder()
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Soft lavender background | `bg_lavender.png` | Create or solid | ❌ TODO |
| Header bar background | `header_bar_purple.png` | Create | ❌ TODO |
| Elements panel bg | `panel_white_rounded.png` | Create | ❌ TODO |
| Element row bg (correct) | `row_bg_teal.png` | Create | ❌ TODO |
| Element row bg (wrong) | `row_bg_red.png` | Create | ❌ TODO |
| Input field background | `input_white_rounded.png` | Reuse | ✅ Ready |
| Submit button bg | `button_purple_rounded.png` | Reuse from Scene 01 | ✅ Ready |
| Popup background | `popup_white_rounded.png` | Create | ❌ TODO |
| Popup border | `popup_border_amber.png` | Create | ❌ TODO |
| Confetti texture | `confetti.png` | Create or download | ❌ TODO |
| Check icon (✓) | `icon_check.png` | Kenney UI | ❌ TODO |
| X icon (✗) | `icon_x.png` | Kenney UI | ❌ TODO |
| Element icons (per level, per question) | (45 total — already in checklist) | AI generation | ❌ TODO |

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Reflection music | `reflection_calm.mp3` | Pixabay | ❌ TODO |
| Paper rustle | `paper_rustle.wav` | Dustyroom Pack | ❌ TODO |
| Popup open | `popup_open.wav` | Reused | ✅ Ready |
| Correct chime | `correct_chime.wav` | Reused | ✅ Ready |
| Element fixed | `element_fixed.wav` | Dustyroom Pack | ❌ TODO |
| All correct fanfare | `all_correct_fanfare.wav` | Dustyroom Pack | ❌ TODO |
| Type tick | `type_tick.wav` | Reused | ✅ Ready |
| Submit confirm | `submit_confirm.wav` | Dustyroom Pack | ❌ TODO |
| Error soft | `error_soft.wav` | Reused | ✅ Ready |
| Timer warning | `timer_warning.wav` | Dustyroom Pack | ❌ TODO |
| Timer alarm | `timer_alarm.wav` | Dustyroom Pack | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- Same as previous 2D scenes (Orthographic, size 5)

### Canvas
- Main canvas: same as before
- **Fix Popup canvas:** Higher sort order (10) so it always renders on top

### Input Field Settings
- **Content Type:** Standard (or AutoCorrected for kids)
- **Character Limit:** 200
- **Multi-line:** Yes
- **Mobile keyboard:** Default

---

## 🔄 Scene Transitions

### Coming In
- **From:** `06_Mission3DRun`
- **Trigger:** Player crossed finish line OR timer ran out
- **Reads:** `collectedElements` JSON, `currentLevel`, `missionScore`, `wasCaught`
- **Transition in:** Fade in (0.5s)

### Going Out
- **To:** `08_Victory`
- **Trigger:** Player taps Submit (with valid summary)
- **Saves:** `summaryScore` (typing bonus), `finalScore`
- **Transition out:** Fade out (0.5s)
- **Method:** `SceneManager.LoadSceneAsync("08_Victory")`

---

## 💾 Data Read/Written

### Read From PlayerPrefs

```csharp
int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
int missionScore = PlayerPrefs.GetInt("missionScore", 0);
int readingScore = PlayerPrefs.GetInt("readingScore", 0);
float timeRemaining = PlayerPrefs.GetFloat("timeRemaining", 0);
bool wasCaught = PlayerPrefs.GetInt("wasCaught", 0) == 1;
string collectedJson = PlayerPrefs.GetString("collectedElements", "");
List<CollectedElement> collected = JsonUtility.FromJson<CollectedElementList>(collectedJson).items;
```

### Written To PlayerPrefs

```csharp
PlayerPrefs.SetInt("summaryScore", summaryBonus);     // 100 if perfect, 50 if okay
PlayerPrefs.SetInt("finalScore", totalScore);         // Sum of all scores
PlayerPrefs.SetString("playerSummary", typedText);    // Save what they wrote
PlayerPrefs.Save();
```

---

## 🎯 Game Logic Flow

### Main Flow

```
1. Scene loads
2. Load collected elements from PlayerPrefs
3. Display all 5 element rows with their states
4. Check: are there wrong elements?
   - YES: Start fix sequence
   - NO: Skip to summary input
5. Fix sequence:
   - For each wrong element:
     - Show fix popup with timer
     - Wait for correct answer OR timer up
     - Mark as fixed
   - Show "all correct" celebration
6. Show summary input field
7. Wait for player to type summary
8. Validate as they type (button enables when valid)
9. Player taps Submit
10. Calculate final score
11. Save data, transition to Victory
```

### Score Calculation

```csharp
int finalScore = 0;
finalScore += readingScore;          // From Story Reader (max 100)
finalScore += missionScore;          // From 3D Run (varies)
finalScore += summaryBonus;          // From this scene

// Time bonus (if not caught)
if (!wasCaught) {
    finalScore += Mathf.RoundToInt(timeRemaining * 5);
    finalScore += 50;                // Finish bonus
}

// Perfect bonus (no fixes needed)
if (noFixesNeeded) {
    finalScore += 100;
}
```

---

## ✅ Build Checklist

### Setup
- [ ] Create `07_FinalSummary.unity` scene
- [ ] Add to Build Settings as scene index 7
- [ ] Set Camera to Orthographic, size 5

### GameObjects (use exact names!)
- [ ] Create `Canvas_FinalSummary`
- [ ] Create `BG_Background`
- [ ] Create `Group_Header` with `Image_HeaderBg` and `Text_HeaderTimer`
- [ ] Create `Text_Title` "Write your summary"
- [ ] Create `Panel_Elements` with `Image_PanelBg`
- [ ] Create 5 `ElementRow_X` GameObjects
- [ ] Each row needs: label, value, background, border
- [ ] Create `Group_SummaryInput`
- [ ] Create `Text_SummaryLabel` "Your summary:"
- [ ] Create `InputField_Summary` (TMP, multi-line)
- [ ] Create `Button_Submit`
- [ ] Create `Text_ValidationMessage` (hidden)
- [ ] Create `Canvas_FixPopup` (separate canvas, hidden)
- [ ] Create `Image_DimOverlay`
- [ ] Create `Image_PopupBg`
- [ ] Create `Text_PopupTimer`
- [ ] Create `Text_PopupQuestion`
- [ ] Create 3 `Button_AnswerOption_X`
- [ ] Create `Text_PopupHint`
- [ ] Create `Canvas_Confetti` with particle system
- [ ] Create `Group_Audio` with two AudioSources
- [ ] Create `FinalSummaryManager` GameObject

### Tags
- [ ] Tag canvases as `UICanvas`
- [ ] Tag `InputField_Summary` as `SummaryInput`
- [ ] Tag `FinalSummaryManager` as `GameManager`
- [ ] Tag audio sources

### Visual Setup
- [ ] Set background to lavender
- [ ] Set all colors per palette
- [ ] Layout 5 element rows in panel
- [ ] Position summary input field
- [ ] Hide fix popup canvas by default

### Scripts
- [ ] Create `ElementRow.cs` in Scripts/UI/
- [ ] Create `SummaryValidator.cs` in Scripts/Utils/
- [ ] Create `FinalSummaryController.cs` in Scripts/UI/
- [ ] Attach controllers to manager
- [ ] Attach `ElementRow.cs` to each element row
- [ ] Configure keyword lists per level (in SummaryValidator)
- [ ] Wire up all Inspector references

### Test
- [ ] Test with all correct elements (skip fix flow)
- [ ] Test with 1 wrong element
- [ ] Test with multiple wrong elements
- [ ] Test fix popup timer countdown
- [ ] Test tapping correct answer
- [ ] Test tapping wrong answer (should not advance)
- [ ] Test summary input
- [ ] Test summary validation (valid keywords)
- [ ] Test summary validation (invalid - too short)
- [ ] Test Submit button enable/disable
- [ ] Test transition to Victory
- [ ] Test all 3 levels

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 07 FinalSummary complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Elements don't load | JSON parse error | Validate JSON format |
| Wrong element doesn't show red | Color not applied | Check ElementRow.cs SetElement |
| Fix popup shows for correct | Logic error | Skip if isCorrect |
| Timer doesn't count down | Coroutine not running | StartCoroutine() |
| Submit always disabled | Validation too strict | Lower minKeywordsRequired |
| Submit always enabled | Validation not checking | Call Validate() onChange |
| Confetti doesn't show | Particle system not playing | Check Play() and Loop |
| Multiple popups overlap | Not waiting for previous | Use coroutine sequence |

---

## 💡 Tips

1. **Be lenient with validation** — Kids' typing is messy. 3/5 keywords is enough.
2. **Don't punish wrong answers** — In fix popup, wrong taps just don't advance.
3. **Use TMP_InputField multi-line** — Allows natural sentence typing
4. **Pre-fill keyword lists** — Use `SUMMARACE_GAME_PLAN.md` content
5. **Show all elements** — Even correct ones, so player sees full picture
6. **Test with bad typing** — "max wantd to find his hom" should still pass
7. **Confetti is optional** — Skip if it slows down build

---

## 🎓 Why This Scene Matters

This scene is **the learning consolidation moment**. The player has:
1. Read the story (Scene 04)
2. Answered comprehension questions (Scene 04)
3. Collected elements while running (Scene 06)

But they haven't yet **synthesized** what they learned. This scene asks them to put it all together in their own words.

This is **the highest learning value moment** in the game. Reading is passive. Answering questions is recognition. **Writing a summary is active recall** — the gold standard of learning.

The fix popup is also crucial — it gives a second chance to learn from mistakes without the pressure of running. This is **scaffolded learning**.

---

## 🚀 Next Scene

When Scene 07 is done, move to:

**`SCENE_08_VICTORY.md`** — The celebration scene with stars, score, and level unlock

This will cover:
- Star calculation display
- Final score breakdown
- "Level X complete!" message
- Ms. Lumi congratulations
- Next level button
- Save unlock progress

---

**End of Scene 07 — Final Summary Specification**
