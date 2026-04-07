# Scene 04 — Story Reader

> **The reading phase.** Player reads the selected story page-by-page (5 pages total), with voice narration and a comprehension question popup after each page. Score is tracked for star calculation.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `04_StoryReader.unity` |
| **Type** | 2D |
| **Duration** | 2–4 minutes (player-paced) |
| **Next scene** | `05_MissionIntro.unity` |
| **Previous scene** | `03_LevelSelect.unity` |
| **Build complexity** | ⭐⭐⭐ Medium-Hard |
| **Estimated build time** | 8–10 hours |

---

## 🎯 Scene Purpose

This scene has **five jobs**:

1. 📖 **Display the story** — Show all 5 pages of the selected story with illustrations
2. 🔊 **Narrate the story** — Optional voice narration (toggle on/off)
3. ❓ **Test comprehension** — A question popup after each page
4. 📊 **Track score** — Count correct reading questions for star calculation
5. ⏭️ **Pace the experience** — Let player control reading speed (Next/Back buttons)

---

## 👤 Player Experience (Step-by-Step)

| Step | What Player Sees | What Player Does |
|---|---|---|
| 1 | Scene fades in, shows page 1 | Watching |
| 2 | Illustration + story text appear | Reading |
| 3 | (Optional) Voice narration plays | Listening |
| 4 | Player reads at their own pace | Reading |
| 5 | Player taps "Next ▸" | Tapping |
| 6 | Question popup appears: "Who is the main character?" | Reading question |
| 7 | Player taps an answer | Selects |
| 8 | Feedback shows (correct ✓ or wrong ✗) | Sees result |
| 9 | "Continue" button appears | Taps |
| 10 | Page 2 loads with same flow | Repeats |
| ... | (Repeat for all 5 pages) | |
| Final | After page 5 question, scene transitions | Anticipating mission |

**Total time:** 2–4 minutes (depends on reading speed)

---

## 🎨 Visual Layout

### Main Reading View

```
┌─────────────────────────────────┐
│ ◂                  🔊  ⏸        │  ← Header: back, audio toggle, pause
│  Page 1 of 5                    │  ← Page indicator
│                                 │
│  ┌───────────────────────────┐ │
│  │                           │ │
│  │     [ illustration ]      │ │  ← Story illustration
│  │       🐶 in park          │ │     (hand-drawn style)
│  │                           │ │
│  └───────────────────────────┘ │
│                                 │
│  Max the puppy lived in a       │
│  small house by the park.       │  ← Story text
│  One sunny day, he wandered     │     (large, easy-to-read)
│  too far and got lost...        │
│                                 │
│  ┌──────┐         ┌──────────┐ │
│  │ ◂Back│         │ Next ▸   │ │  ← Navigation buttons
│  └──────┘         └──────────┘ │
└─────────────────────────────────┘
```

### Question Popup View (overlay)

```
┌─────────────────────────────────┐
│ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │  ← Dimmed background
│ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │
│ ░░  ┌──────────────────┐  ░░  │
│ ░░  │   QUICK CHECK    │  ░░  │
│ ░░  │                  │  ░░  │
│ ░░  │  Who is the      │  ░░  │  ← Question popup
│ ░░  │  main character? │  ░░  │
│ ░░  │                  │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ Max the puppy│ │  ░░  │  ← Answer A
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ The mailman  │ │  ░░  │  ← Answer B
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  │ ┌──────────────┐ │  ░░  │
│ ░░  │ │ A stray cat  │ │  ░░  │  ← Answer C
│ ░░  │ └──────────────┘ │  ░░  │
│ ░░  └──────────────────┘  ░░  │
│ ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Back button | Top-left, padding 30px | 60×60 px | Top-left |
| Audio toggle | Top-right, X-100 | 50×50 px | Top-right |
| Pause button | Top-right, padding 30px | 50×50 px | Top-right |
| Page indicator | Top-left, below back button | Auto | Top-left |
| Illustration frame | Top-center, Y+200 | 800×500 px | Top-center |
| Story text | Below illustration, Y-100 | 800×300 px | Center |
| Back button | Bottom-left, Y-150 | 140×60 px | Bottom-left |
| Next button | Bottom-right, Y-150 | 180×60 px | Bottom-right |

### Question Popup Layout

| Element | Position | Size | Anchor |
|---|---|---|---|
| Dim overlay | Full screen | Stretch | All |
| Popup background | Center | 700×600 px | Center |
| Question label "QUICK CHECK" | Top of popup | Auto | Top-center |
| Question text | Top of popup, Y-80 | Auto | Center |
| Answer buttons | Center, stacked | 600×60 px each | Center |
| Answer spacing | Between buttons | 16 px gap | — |

---

## 🎨 Color Palette

### Reading View

| Element | Color | Hex |
|---|---|---|
| Background top | Soft pink | `#FBEAF0` |
| Background bottom | Light pink | `#F4C0D1` |
| Page indicator text | Dark pink | `#72243E` |
| Illustration frame | White | `#FFFFFF` |
| Illustration border | Pink | `#D4537E` |
| Story text | Dark plum | `#4B1528` |
| Back button bg | White | `#FFFFFF` |
| Back button border | Pink | `#D4537E` |
| Back button text | Dark pink | `#72243E` |
| Next button bg | Dark plum | `#4B1528` |
| Next button text | White | `#FFFFFF` |
| Audio toggle (on) | Pink | `#D4537E` |
| Audio toggle (off) | Gray | `#888780` |

### Question Popup

| Element | Color | Hex |
|---|---|---|
| Dim overlay | Black 60% | `rgba(0,0,0,0.6)` |
| Popup background | Soft coral | `#FAECE7` |
| Popup border | Coral | `#D85A30` (3px) |
| "QUICK CHECK" label | Coral | `#993C1D` |
| Question text | Dark coral | `#4A1B0C` |
| Answer button bg | White | `#FFFFFF` |
| Answer button border | Coral | `#D85A30` |
| Answer button text | Dark coral | `#4A1B0C` |
| Answer correct (after tap) | Green | `#1D9E75` |
| Answer wrong (after tap) | Red | `#A32D2D` |

### Why These Colors
**Pink/coral** is the color associated with the reading phase. It evokes a warm, comfortable storybook feeling. Different from blue (splash), purple (name entry), teal (teacher), and amber (level select) — each phase has its own color identity.

---

## 📝 Text Content

### UI Labels

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Page indicator | `Page {current} of {total}` | Fredoka | 14px | Regular |
| Back button | `◂ Back` | Fredoka | 16px | Regular |
| Next button | `Next ▸` | Fredoka | 16px | Bold |
| Quick check label | `QUICK CHECK` | Fredoka | 12px | Bold, letter-spacing 2px |
| Continue button (after question) | `Continue ▸` | Fredoka | 16px | Bold |

### Story Text Styling

| Property | Value |
|---|---|
| Font | Patrick Hand (or Fredoka if simpler) |
| Size | 24px |
| Line height | 1.6 |
| Color | `#4B1528` (dark plum) |
| Alignment | Left or center |

**Why Patrick Hand?** It's a hand-written font that feels like a real storybook. Easy for kids to read, friendly looking.

### Story Content (loaded from JSON)

The actual story text comes from the JSON files:
- `Resources/Stories/level1.json` — Max the Lost Puppy
- `Resources/Stories/level2.json` — Luna and the Kite
- `Resources/Stories/level3.json` — The Brave Turtle

Example structure:

```json
{
  "title": "Max the Lost Puppy",
  "pages": [
    {
      "pageNumber": 1,
      "illustration": "level1_page1.png",
      "text": "Max the puppy lived in a small house by the park. One sunny day, he wandered too far and got lost...",
      "narrationFile": "level1_page1.mp3",
      "question": {
        "text": "Who is the main character?",
        "options": [
          {"text": "Max the puppy", "isCorrect": true},
          {"text": "The mailman", "isCorrect": false},
          {"text": "A stray cat", "isCorrect": false}
        ]
      }
    },
    // ... 4 more pages
  ]
}
```

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/reading_calm.mp3` |
| **Volume** | 0.4 (lower than menu — don't compete with narration) |
| **Loop** | Yes |
| **Crossfade from previous** | Yes (0.5s) |

### Voice Narration (Per Page)

| Property | Value |
|---|---|
| **Files** | `Audio/Voice/Stories/Level1/page1.mp3`, `page2.mp3`, etc. |
| **Volume** | 1.0 (full — most important audio) |
| **Loop** | No |
| **Music ducks during narration** | Yes (music drops to 0.2 while voice plays) |
| **Toggle** | Player can disable via header button |

### Sound Effects

| Trigger | File | Volume |
|---|---|---|
| Page flip (Next/Back) | `page_flip.wav` | 0.6 |
| Question popup appears | `popup_open.wav` | 0.7 |
| Tap correct answer | `correct_chime.wav` | 0.8 |
| Tap wrong answer | `wrong_buzz.wav` | 0.7 |
| Tap continue (after question) | `button_confirm.wav` | 0.8 |
| Tap audio toggle | `button_click.wav` | 0.6 |

**Source:** All from Dustyroom Free Casual Game SFX Pack

---

## 🎬 Animations

### Page Transition

| Element | Animation | Duration |
|---|---|---|
| Old page | Slide left + fade out | 0.3s |
| New page | Slide in from right + fade in | 0.4s |

### Question Popup

| Element | Animation | When | Duration |
|---|---|---|---|
| Dim overlay | Fade in (0→0.6 alpha) | On show | 0.3s |
| Popup | Scale (0.8→1.0) + fade in | On show | 0.4s |
| Answer buttons | Stagger fade in | After popup | 0.1s each |
| Tapped answer (correct) | Flash green + scale bounce | On tap | 0.4s |
| Tapped answer (wrong) | Flash red + shake | On tap | 0.4s |
| Other answers (after tap) | Fade to gray | 0.3s | 0.2s |
| Popup close | Scale + fade out | On continue | 0.3s |

### Score Display (Optional)

When player gets a question right, a small "+20 points" popup floats up from the answer:

```csharp
GameObject scorePopup = Instantiate(scorePopupPrefab, answerPosition, Quaternion.identity);
scorePopup.transform.DOMoveY(answerPosition.y + 100, 1f);
scorePopup.GetComponent<CanvasGroup>().DOFade(0, 1f);
Destroy(scorePopup, 1f);
```

---

## 🛠️ GameObject Hierarchy & Names

```
StoryReaderScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_StoryReader                       [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   └── Image_BackgroundGradient
│   │
│   ├── Group_Header                         [Tag: Untagged]
│   │   ├── Button_Back                      [Tag: BackButton]
│   │   │   ├── Image_BackButtonBg
│   │   │   └── Image_BackArrow
│   │   ├── Text_PageIndicator               [Tag: Untagged]
│   │   ├── Button_AudioToggle               [Tag: Untagged]
│   │   │   ├── Image_AudioOnIcon
│   │   │   └── Image_AudioOffIcon
│   │   └── Button_Pause                     [Tag: Untagged]
│   │       └── Image_PauseIcon
│   │
│   ├── Group_StoryContent                   [Tag: Untagged]
│   │   ├── Frame_Illustration               [Tag: Untagged]
│   │   │   ├── Image_IllustrationBg
│   │   │   └── Image_IllustrationContent    (changes per page)
│   │   └── Text_StoryContent                [Tag: Untagged]
│   │
│   ├── Group_Navigation                     [Tag: Untagged]
│   │   ├── Button_PreviousPage              [Tag: Untagged]
│   │   │   ├── Image_PrevButtonBg
│   │   │   └── Text_PrevLabel
│   │   └── Button_NextPage                  [Tag: Untagged]
│   │       ├── Image_NextButtonBg
│   │       └── Text_NextLabel
│   │
│   └── Group_QuestionPopup                  [Tag: Untagged] (hidden by default)
│       ├── Image_DimOverlay
│       ├── Image_PopupBackground
│       ├── Text_QuickCheckLabel             ("QUICK CHECK")
│       ├── Text_QuestionContent             (the question)
│       ├── Group_AnswerButtons              [Tag: Untagged]
│       │   ├── Button_AnswerA               [Tag: Untagged]
│       │   │   ├── Image_AnswerBg
│       │   │   └── Text_AnswerLabel
│       │   ├── Button_AnswerB               [Tag: Untagged]
│       │   │   └── (same structure)
│       │   └── Button_AnswerC               [Tag: Untagged]
│       │       └── (same structure)
│       └── Button_ContinueAfterQuestion     [Tag: Untagged] (hidden until answered)
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   ├── AudioSource_SFX                      [Tag: AudioSFX]
│   └── AudioSource_Voice                    [Tag: AudioVoice]
│
└── StoryReaderManager                       [Tag: GameManager]
    ├── StoryReaderController.cs (script)
    └── StoryDataLoader.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_StoryReader` |
| `Group_` | Container | `Group_QuestionPopup` |
| `Frame_` | Bordered container | `Frame_Illustration` |
| `Image_` | UI Image | `Image_IllustrationContent` |
| `Text_` | Text element | `Text_StoryContent` |
| `Button_` | Button | `Button_NextPage` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_StoryReader | Identifies main canvas |
| `BackButton` | Button_Back | Identifies back navigation |
| `GameManager` | StoryReaderManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music source |
| `AudioSFX` | AudioSource_SFX | SFX source |
| `AudioVoice` | AudioSource_Voice | Narration source |

---

## 💻 Scripts Required

### `StoryReaderController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/StoryReaderController.cs`
**Attached to:** `StoryReaderManager` GameObject

**Responsibilities:**
1. Load the correct story JSON based on `currentLevel` PlayerPref
2. Display pages one at a time
3. Handle Next/Back navigation
4. Show question popup after each page
5. Track score across all questions
6. Save score and load next scene

**Inspector Variables:**

```csharp
[Header("UI References")]
public Image illustrationImage;
public TextMeshProUGUI storyText;
public TextMeshProUGUI pageIndicator;
public Button previousButton;
public Button nextButton;
public Button backButton;
public Button audioToggleButton;
public Image audioOnIcon;
public Image audioOffIcon;

[Header("Question Popup")]
public GameObject questionPopupGroup;
public TextMeshProUGUI questionText;
public Button[] answerButtons;            // Drag: Button_AnswerA, B, C
public TextMeshProUGUI[] answerTexts;
public Image[] answerBackgrounds;
public Button continueAfterQuestionButton;

[Header("Audio")]
public AudioSource musicSource;
public AudioSource sfxSource;
public AudioSource voiceSource;
public AudioClip pageFlipSound;
public AudioClip popupOpenSound;
public AudioClip correctSound;
public AudioClip wrongSound;
public AudioClip confirmSound;

[Header("Settings")]
public float musicDuckVolume = 0.2f;     // Volume during narration
public float musicNormalVolume = 0.4f;
public Color correctColor = new Color(0.114f, 0.620f, 0.459f);  // #1D9E75
public Color wrongColor = new Color(0.639f, 0.176f, 0.176f);    // #A32D2D
public Color normalAnswerColor = Color.white;

[Header("Next Scene")]
public string nextSceneName = "05_MissionIntro";
```

**Methods:**

```csharp
void Start()                              // Initialize, load story
void LoadStoryData()                      // Read JSON file
void DisplayPage(int pageIndex)           // Show specific page
void OnNextClicked()                      // Show question popup or next page
void OnPreviousClicked()                  // Go back one page
void OnBackClicked()                      // Return to Level Select
void OnAudioToggleClicked()               // Toggle narration on/off
void ShowQuestionPopup(QuestionData q)    // Display question
void OnAnswerClicked(int answerIndex)     // Handle answer selection
void ShowAnswerFeedback(bool isCorrect)   // Visual feedback
void OnContinueAfterQuestion()            // Move to next page or finish
void PlayNarration(string fileName)      // Play voice file
void StopNarration()                      // Stop voice
void FinishStory()                        // All pages done, transition
void TransitionToNextScene()              // Save score, load mission
```

### `StoryDataLoader.cs` — JSON Data Loader

**Location:** `Assets/_Game/Scripts/Data/StoryDataLoader.cs`
**Attached to:** `StoryReaderManager` GameObject

**Responsibilities:**
1. Load JSON file from Resources folder
2. Parse into C# data classes
3. Provide methods to access story data

**Methods:**

```csharp
public StoryData LoadStory(int levelNumber)  // Load level1, level2, or level3
public PageData GetPage(int pageIndex)
public QuestionData GetQuestion(int pageIndex)
public int GetTotalPages()
public string GetStoryTitle()
```

### Data Classes (in same file or separate)

```csharp
[System.Serializable]
public class StoryData {
    public string title;
    public PageData[] pages;
}

[System.Serializable]
public class PageData {
    public int pageNumber;
    public string illustration;     // PNG file name
    public string text;             // Story text
    public string narrationFile;    // MP3 file name
    public QuestionData question;
}

[System.Serializable]
public class QuestionData {
    public string text;             // The question
    public AnswerOption[] options;  // 3 answers
}

[System.Serializable]
public class AnswerOption {
    public string text;
    public bool isCorrect;
}
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Pink gradient background | `bg_pink_gradient.png` | Create or solid | ❌ TODO |
| Back arrow icon | `icon_back_arrow.png` | Kenney UI | ❌ TODO |
| Audio on icon | `icon_audio_on.png` | Kenney UI | ❌ TODO |
| Audio off icon | `icon_audio_off.png` | Kenney UI | ❌ TODO |
| Pause icon | `icon_pause.png` | Kenney UI | ❌ TODO |
| Next button bg | `button_dark_plum.png` | Create | ❌ TODO |
| Back button bg | `button_white.png` | Create | ❌ TODO |
| Illustration frame | `frame_white_rounded.png` | Create | ❌ TODO |
| Popup background | `popup_coral_rounded.png` | Create | ❌ TODO |
| Answer button bg | `button_answer.png` | Create | ❌ TODO |

### Story Illustrations (5 per level = 15 total)

| Asset | File Name | Source | Status |
|---|---|---|---|
| Level 1 page 1 | `level1_page1.png` | AI generation | ❌ TODO |
| Level 1 page 2 | `level1_page2.png` | AI generation | ❌ TODO |
| Level 1 page 3 | `level1_page3.png` | AI generation | ❌ TODO |
| Level 1 page 4 | `level1_page4.png` | AI generation | ❌ TODO |
| Level 1 page 5 | `level1_page5.png` | AI generation | ❌ TODO |
| Level 2 pages | `level2_page1-5.png` | AI generation | ❌ TODO |
| Level 3 pages | `level3_page1-5.png` | AI generation | ❌ TODO |

**AI prompt template** (use for all illustrations):
> "Children's book illustration, soft watercolor style, bright cheerful colors, white background, [scene description for this page]"

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Reading music | `reading_calm.mp3` | Pixabay | ❌ TODO |
| Page flip | `page_flip.wav` | Dustyroom Pack | ❌ TODO |
| Popup open | `popup_open.wav` | Dustyroom Pack | ❌ TODO |
| Correct chime | `correct_chime.wav` | Dustyroom Pack | ❌ TODO |
| Wrong buzz | `wrong_buzz.wav` | Dustyroom Pack | ❌ TODO |
| Button confirm | `button_confirm.wav` | Dustyroom Pack | ❌ TODO |

### Voice Narration (Optional but Recommended)

| Asset | File Name | Source | Status |
|---|---|---|---|
| Level 1 narrations | `Voice/Stories/Level1/page1-5.mp3` | TTS or recorded | ❌ TODO |
| Level 2 narrations | `Voice/Stories/Level2/page1-5.mp3` | TTS or recorded | ❌ TODO |
| Level 3 narrations | `Voice/Stories/Level3/page1-5.mp3` | TTS or recorded | ❌ TODO |

**For TTS:** Use ElevenLabs (free tier) or Google Cloud TTS for natural voices.

### JSON Story Files

| Asset | File Name | Source | Status |
|---|---|---|---|
| Level 1 story | `Resources/Stories/level1.json` | Create from GAME_PLAN | ❌ TODO |
| Level 2 story | `Resources/Stories/level2.json` | Create from GAME_PLAN | ❌ TODO |
| Level 3 story | `Resources/Stories/level3.json` | Create from GAME_PLAN | ❌ TODO |

**💡 Tip:** Ask Claude to convert the stories from `SUMMARACE_GAME_PLAN.md` into JSON format!

---

## ⚙️ Unity Settings

### Camera
- Same as previous scenes (Orthographic, size 5)

### Canvas
- Same as previous scenes (Screen Space Overlay, 1080×1920 reference)

### Question Popup
- Use a separate Canvas with **higher sort order** (10) so it always renders on top
- Or use a child Canvas inside the main canvas

---

## 🔄 Scene Transitions

### Coming In
- **From:** `03_LevelSelect`
- **Trigger:** Player tapped a story card
- **Reads:** `currentLevel` from PlayerPrefs
- **Transition in:** Fade in (0.5s)

### Going Out (2 possible destinations)

**Path 1: Player completes all 5 pages**
- **To:** `05_MissionIntro`
- **Trigger:** Continue tapped after final page question
- **Saves:** `readingScore` to PlayerPrefs
- **Transition out:** Fade out (0.4s)
- **Method:** `SceneManager.LoadSceneAsync("05_MissionIntro")`

**Path 2: Player taps back button**
- **To:** `03_LevelSelect`
- **Trigger:** Tap back button (with confirmation popup)
- **Transition out:** Fade out (0.3s)

---

## 💾 Data Read/Written

### Read From PlayerPrefs

```csharp
int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
bool narrationEnabled = PlayerPrefs.GetInt("narrationEnabled", 1) == 1;
```

### Written To PlayerPrefs

```csharp
PlayerPrefs.SetInt("readingScore", correctAnswerCount * pointsPerCorrect);
PlayerPrefs.SetInt("narrationEnabled", narrationOn ? 1 : 0);
PlayerPrefs.Save();
```

The `readingScore` is read by Scene 08 (Victory) for star calculation.

---

## 🎯 Question Logic

### Per Page Flow

1. Player reads page text
2. Player taps "Next ▸"
3. Question popup appears for THIS page
4. Player taps an answer
5. Visual feedback shows (correct/wrong)
6. ALL answers stay visible but tapped one is highlighted
7. "Continue" button appears
8. Player taps Continue
9. Popup closes, next page loads

### Important: Always Proceed!

> Even if the player gets the question wrong, they STILL move to the next page. The score is tracked, but they don't get stuck. This is **critical for kids' UX** — never block progression.

### Score Calculation

```csharp
int totalReadingScore = 0;
int pointsPerCorrect = 20;  // From Game Balance

void OnAnswerClicked(int index) {
    if (currentQuestion.options[index].isCorrect) {
        totalReadingScore += pointsPerCorrect;
        ShowFeedback(true);
    } else {
        ShowFeedback(false);
    }
}
```

After all 5 pages: `readingScore` is between 0 and 100 (5 questions × 20 points).

---

## ✅ Build Checklist

### Setup
- [ ] Create `04_StoryReader.unity` scene
- [ ] Add to Build Settings as scene index 4
- [ ] Create Canvas_StoryReader

### GameObjects (use exact names!)
- [ ] Create `Canvas_StoryReader`
- [ ] Create `BG_Background`
- [ ] Create `Group_Header`
- [ ] Create `Button_Back`
- [ ] Create `Text_PageIndicator`
- [ ] Create `Button_AudioToggle` with on/off icons
- [ ] Create `Button_Pause`
- [ ] Create `Group_StoryContent`
- [ ] Create `Frame_Illustration` with `Image_IllustrationContent`
- [ ] Create `Text_StoryContent`
- [ ] Create `Group_Navigation`
- [ ] Create `Button_PreviousPage`
- [ ] Create `Button_NextPage`
- [ ] Create `Group_QuestionPopup` (start hidden)
- [ ] Create `Image_DimOverlay`
- [ ] Create `Image_PopupBackground`
- [ ] Create `Text_QuickCheckLabel`
- [ ] Create `Text_QuestionContent`
- [ ] Create `Group_AnswerButtons`
- [ ] Create `Button_AnswerA`, `Button_AnswerB`, `Button_AnswerC`
- [ ] Create `Button_ContinueAfterQuestion`
- [ ] Create `Group_Audio` with three AudioSources
- [ ] Create `StoryReaderManager` GameObject

### Tags
- [ ] Tag `Canvas_StoryReader` as `UICanvas`
- [ ] Tag `Button_Back` as `BackButton`
- [ ] Tag `StoryReaderManager` as `GameManager`
- [ ] Tag audio sources

### Visual Setup
- [ ] Set background to pink gradient
- [ ] Use Patrick Hand font for story text
- [ ] Use Fredoka for UI elements
- [ ] Set all colors per palette
- [ ] Position elements per layout

### Scripts
- [ ] Create `StoryDataLoader.cs` in Scripts/Data/
- [ ] Create data classes (StoryData, PageData, QuestionData, AnswerOption)
- [ ] Create `StoryReaderController.cs` in Scripts/UI/
- [ ] Attach both scripts to `StoryReaderManager`
- [ ] Wire up all Inspector references

### Story Data
- [ ] Create `Assets/_Game/Resources/Stories/` folder
- [ ] Create `level1.json` with full story data
- [ ] Create `level2.json` with full story data
- [ ] Create `level3.json` with full story data
- [ ] Verify JSON files load correctly in code

### Audio Setup
- [ ] Import reading music
- [ ] Import all SFX
- [ ] Import narration files (if available)
- [ ] Set up audio ducking (music drops during voice)

### Test
- [ ] Test loading Level 1 story
- [ ] Test loading Level 2 story
- [ ] Test loading Level 3 story
- [ ] Test page navigation (Next/Back)
- [ ] Test page indicator updates
- [ ] Test question popup appears after Next
- [ ] Test correct answer feedback
- [ ] Test wrong answer feedback
- [ ] Test always-proceed (wrong answer still moves on)
- [ ] Test audio toggle
- [ ] Test narration playback
- [ ] Test music ducking during narration
- [ ] Test final transition to mission scene
- [ ] Test back button returns to Level Select
- [ ] Test score calculation across multiple plays

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 04 StoryReader complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Story doesn't load | JSON file not in Resources | Move to `Resources/Stories/` |
| JSON parse error | Malformed JSON | Validate with JSONLint |
| Wrong story loads | currentLevel not set | Default to 1 if missing |
| Illustration doesn't show | Sprite not in Resources | Use `Resources.Load<Sprite>()` |
| Question popup doesn't appear | GameObject not active | Use `SetActive(true)` |
| Narration doesn't play | AudioSource muted | Check volume and mute state |
| Music doesn't duck | Volume not changing | Use coroutine to lerp volume |
| Page text overflows | Container too small | Increase Text component size |
| Back button skips ahead | Wrong scene name | Verify previous scene name |

---

## 💡 Tips

1. **Start with Level 1 only** — Get the loading and display working perfectly with Level 1, then duplicate for Levels 2 and 3
2. **Use TextMeshPro Pro** — Better text rendering, especially for longer story passages
3. **Patrick Hand font** is friendly but check legibility on small screens
4. **Pre-load illustrations** — Load all 5 page images on Start() to prevent lag
5. **Test with long answers** — Some answer text might be 8 words long; make sure it fits
6. **Don't auto-advance** — Always require player to tap Next (kids need pace control)
7. **Use a popup Canvas** — Separate canvas for the question popup to ensure it's always on top

---

## 🎓 Why This Scene Matters

This is the **core educational moment** of the game. Everything before this is setup; everything after is reinforcement. The reading + question loop is where actual learning happens.

The comprehension questions serve two purposes:
1. **They check understanding** — Did the player actually read?
2. **They prepare for the mission** — The same elements appear in the run

By the time the player enters the 3D run, they've already seen the answers in question form. The mission becomes about **remembering**, not guessing.

This is the **educational backbone** of SummaRace.

---

## 🚀 Next Scene

When Scene 04 is done, move to:

**`SCENE_05_MISSION_INTRO.md`** — Ms. Lumi explains the upcoming mission with the timer and elements

This will cover:
- Ms. Lumi reappears
- Explains mission rules
- Shows timer and elements preview
- "Start mission!" button
- Transition to the 3D run

---

**End of Scene 04 — Story Reader Specification**
