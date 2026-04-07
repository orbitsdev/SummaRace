# Scene 03 — Level Select

> **Pick your adventure.** The player chooses which story to play. Three story cards are displayed — only Level 1 is unlocked at first. As the player completes levels, more unlock.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `03_LevelSelect.unity` |
| **Type** | 2D |
| **Duration** | Until player taps a story card |
| **Next scene** | `04_StoryReader.unity` (with selected level data) |
| **Previous scene** | `02_TeacherWelcome.unity` |
| **Build complexity** | ⭐⭐ Medium |
| **Estimated build time** | 4–5 hours |

---

## 🎯 Scene Purpose

This scene has **four jobs**:

1. 📚 **Show all 3 stories** — Display the 3 levels as visual cards
2. 🔒 **Show progression** — Lock unfinished levels with padlock icons
3. ⭐ **Show achievements** — Display stars earned per level
4. 🎯 **Let player choose** — Tap a card to load that story

---

## 👤 Player Experience (Step-by-Step)

| Time | What Player Sees | What Player Does |
|---|---|---|
| **0.0s** | Scene fades in | Watching |
| **0.3s** | Background appears | Looking around |
| **0.5s** | "Pick a story" header appears | Reading |
| **0.8s** | Card 1 (Level 1) slides in from left | Watching |
| **1.0s** | Card 2 (Level 2) slides in from left | Watching |
| **1.2s** | Card 3 (Level 3) slides in from left | Watching |
| **1.5s** | Back button appears (top-left) | Sees option |
| **+1s** | Player taps Level 1 card | Tapping |
| **Tap** | Card scales up briefly + sound | Confirmation |
| **+0.3s** | Scene fades to white | Anticipating |
| **+0.5s** | Story Reader scene loads | Excited! |

**Total time:** 3-10 seconds depending on player decision

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│  ◂                              │  ← Back button (top-left)
│                                 │
│         Pick a story            │  ← Header (large)
│                                 │
│  ┌───────────────────────────┐ │
│  │ 🐶  Level 1 — Max         │ │  ← Card 1 (UNLOCKED, highlighted)
│  │     ★☆☆ Easy              │ │
│  └───────────────────────────┘ │
│                                 │
│  ┌───────────────────────────┐ │
│  │ 🔒  Level 2 — Locked      │ │  ← Card 2 (LOCKED, dimmed)
│  │     ★★☆ Medium            │ │
│  └───────────────────────────┘ │
│                                 │
│  ┌───────────────────────────┐ │
│  │ 🔒  Level 3 — Locked      │ │  ← Card 3 (LOCKED, dimmed)
│  │     ★★★ Hard              │ │
│  └───────────────────────────┘ │
│                                 │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Back button | Top-left, padding 30px | 60×60 px | Top-left |
| Header text | Top-center, Y+350 | Auto | Top-center |
| Story cards group | Center | 700×900 px | Center |
| Each story card | Stacked vertically | 700×220 px | — |
| Card spacing | Between cards | 30 px gap | — |
| Card icon | Left of card | 100×100 px | Left of card |
| Card text | Right of icon | Auto | Center vertical |

### Card Internal Layout

```
┌──────────────────────────────────────────┐
│  ┌────┐                                  │
│  │ 🐶 │   Level 1 — Max the Lost Puppy  │
│  │    │                                  │
│  └────┘   ★ ★ ★    Easy                  │
└──────────────────────────────────────────┘
```

| Element | Position in card |
|---|---|
| Icon background | Left, 20px padding |
| Icon image | Centered in icon background |
| Title text | Right of icon, top |
| Stars | Right of icon, middle |
| Difficulty label | Right of icon, bottom |

---

## 🎨 Color Palette

| Element | Color | Hex |
|---|---|---|
| Background top | Soft amber | `#FAEEDA` |
| Background bottom | Light amber | `#FAC775` |
| Header text | Dark amber | `#412402` |
| Back button bg | White | `#FFFFFF` |
| Back button icon | Dark amber | `#412402` |

### Card Colors (Unlocked - Level 1)

| Element | Color | Hex |
|---|---|---|
| Card background | White | `#FFFFFF` |
| Card border | Bright amber | `#BA7517` (3px thick) |
| Icon background | Medium amber | `#FAC775` |
| Title text | Dark amber | `#412402` |
| Stars (filled) | Bright amber | `#EF9F27` |
| Stars (empty) | Light gray | `#D3D1C7` |
| Difficulty label | Medium amber | `#854F0B` |

### Card Colors (Locked - Levels 2 & 3)

| Element | Color | Hex |
|---|---|---|
| Card background | Light amber | `#FAC775` |
| Card border | Medium amber | `#854F0B` (1px thick) |
| Card overall opacity | 60% | — |
| Icon background | Bright amber | `#EF9F27` |
| Lock icon color | Dark amber | `#412402` |
| Title text | Dark amber (faded) | `#412402` |
| Difficulty label | Medium amber (faded) | `#854F0B` |

### Why These Colors
**Amber/orange** is the color associated with the Level Select screen. It's warm and inviting, like an open book. Locked cards are dimmed to clearly signal "you can't tap me yet."

---

## 📝 Text Content

### Header

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Main header | `Pick a story` | Fredoka | 32px | Bold |

### Card Content

| Card | Title | Subtitle | Stars |
|---|---|---|---|
| Level 1 | `Level 1 — Max the Lost Puppy` | `★☆☆ Easy` | (filled stars based on save data) |
| Level 2 | `Level 2 — Luna and the Kite` | `★★☆ Medium` | (filled stars or empty if locked) |
| Level 3 | `Level 3 — The Brave Turtle` | `★★★ Hard` | (filled stars or empty if locked) |

**When LOCKED**, replace title with:
- `Level 2 — Locked`
- `Level 3 — Locked`

Keep the difficulty label visible.

### Star Display Logic

Each card shows 3 star slots. Filled stars are based on PlayerPrefs:

```
Level 1 stars from PlayerPrefs.GetInt("level1Stars", 0)
- 0 stars: ☆☆☆
- 1 star:  ★☆☆
- 2 stars: ★★☆
- 3 stars: ★★★
```

The "★☆☆ Easy" / "★★☆ Medium" / "★★★ Hard" text in the spec refers to **difficulty stars**, NOT earned stars. Show both:

```
Level 1 — Max the Lost Puppy
[★ ★ ★] earned   |   Easy
```

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/menu_theme.mp3` |
| **Volume** | 0.5 |
| **Loop** | Yes |
| **Continues from** | Scene 02 (don't restart!) |

### Sound Effects

| Trigger | File | Volume | When |
|---|---|---|---|
| Scene appears | `Audio/SFX/UI/page_flip.wav` | 0.5 | At 0.0s |
| Cards slide in | `Audio/SFX/UI/swoosh_soft.wav` | 0.4 | Per card (0.8, 1.0, 1.2) |
| Tap unlocked card | `Audio/SFX/UI/button_confirm.wav` | 0.8 | On tap |
| Tap locked card | `Audio/SFX/UI/locked.wav` | 0.6 | On tap (rejection) |
| Tap back button | `Audio/SFX/UI/button_back.wav` | 0.7 | On tap |
| Hover over card (PC) | `Audio/SFX/UI/hover.wav` | 0.3 | On hover |

**Source:** All from Dustyroom Free Casual Game SFX Pack

---

## 🎬 Animations

| Element | Animation | When | Duration | Easing |
|---|---|---|---|---|
| Background | Fade in | 0.0s | 0.5s | EaseOut |
| Header | Slide down + fade in | 0.3s | 0.4s | EaseOutBack |
| Card 1 | Slide in from left + fade | 0.8s | 0.4s | EaseOutBack |
| Card 2 | Slide in from left + fade | 1.0s | 0.4s | EaseOutBack |
| Card 3 | Slide in from left + fade | 1.2s | 0.4s | EaseOutBack |
| Back button | Fade in | 1.5s | 0.3s | EaseOut |
| Card hover (active) | Scale 1.0 → 1.03 | On hover | 0.2s | EaseOut |
| Card tap (active) | Scale 1.0 → 0.95 → 1.05 → 1.0 | On tap | 0.3s | — |
| Card tap (locked) | Shake X | On tap | 0.3s | — |
| Selected card | Glow effect | On select | 0.5s | — |
| Scene exit | Fade to white | On selection | 0.4s | EaseIn |

### Locked Card Shake Animation

When player taps a locked card, the card shakes to indicate "no":

```csharp
card.transform.DOShakePosition(0.3f, strength: 10f, vibrato: 10);
PlaySound(lockedSound);
ShowTemporaryMessage("Complete the previous level first!");
```

### Card Hover Effect (Desktop Only)

On mobile, there's no hover. But on desktop:
- Card scales up slightly (1.03×)
- Border glows a bit brighter
- Cursor changes to "pointer"

---

## 🛠️ GameObject Hierarchy & Names

```
LevelSelectScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_LevelSelect                       [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   └── Image_BackgroundGradient
│   │
│   ├── Button_Back                          [Tag: BackButton]
│   │   ├── Image_BackButtonBg
│   │   └── Image_BackArrow
│   │
│   ├── Text_Header                          [Tag: Untagged]
│   │
│   ├── Group_StoryCards                     [Tag: Untagged]
│   │   ├── Card_Level1                      [Tag: StoryCard]
│   │   │   ├── Image_CardBackground
│   │   │   ├── Image_CardBorder
│   │   │   ├── Group_IconArea
│   │   │   │   ├── Image_IconBackground
│   │   │   │   └── Image_StoryIcon          (puppy emoji/icon)
│   │   │   ├── Group_TextArea
│   │   │   │   ├── Text_LevelTitle
│   │   │   │   ├── Group_StarsEarned
│   │   │   │   │   ├── Image_Star1
│   │   │   │   │   ├── Image_Star2
│   │   │   │   │   └── Image_Star3
│   │   │   │   └── Text_DifficultyLabel
│   │   │   └── Image_LockOverlay            (hidden if unlocked)
│   │   │
│   │   ├── Card_Level2                      [Tag: StoryCard]
│   │   │   └── (same structure as Level 1)
│   │   │
│   │   └── Card_Level3                      [Tag: StoryCard]
│   │       └── (same structure as Level 1)
│   │
│   └── Text_LockedMessage                   [Tag: Untagged] (hidden by default)
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   └── AudioSource_SFX                      [Tag: AudioSFX]
│
└── LevelSelectManager                       [Tag: GameManager]
    └── LevelSelectController.cs (script)
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_LevelSelect` |
| `BG_` | Background | `BG_Background` |
| `Group_` | Container | `Group_StoryCards` |
| `Card_` | Story card | `Card_Level1` |
| `Image_` | UI Image | `Image_StoryIcon` |
| `Text_` | Text element | `Text_LevelTitle` |
| `Button_` | Button | `Button_Back` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_LevelSelect | Identifies main canvas |
| `BackButton` | Button_Back | Identifies back navigation |
| `StoryCard` | Card_Level1, Card_Level2, Card_Level3 | Identifies all story cards |
| `GameManager` | LevelSelectManager | Controller identifier |
| `AudioMusic` | AudioSource_Music | Music source |
| `AudioSFX` | AudioSource_SFX | SFX source |

---

## 💻 Scripts Required

### `LevelSelectController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/LevelSelectController.cs`
**Attached to:** `LevelSelectManager` GameObject

**Responsibilities:**
1. Load progress data from PlayerPrefs (which levels unlocked, stars earned)
2. Update each card's state (unlocked/locked, stars filled)
3. Handle card tap events
4. Show validation message for locked cards
5. Load selected story scene
6. Handle back button

**Inspector Variables:**

```csharp
[Header("UI References")]
public Button backButton;
public StoryCard[] storyCards;        // Drag: Card_Level1, Card_Level2, Card_Level3
public TextMeshProUGUI lockedMessageText;
public CanvasGroup lockedMessageGroup;

[Header("Audio")]
public AudioSource sfxSource;
public AudioClip pageFlipSound;
public AudioClip swooshSound;
public AudioClip confirmSound;
public AudioClip lockedSound;
public AudioClip backSound;

[Header("Settings")]
public float cardSlideDelay = 0.2f;     // Delay between each card sliding in
public float lockedMessageDuration = 2f;

[Header("Scene Names")]
public string storyReaderSceneName = "04_StoryReader";
public string previousSceneName = "02_TeacherWelcome";
```

**Methods:**

```csharp
void Start()                           // Initialize, load data, animate cards
void LoadProgressData()                // Read from PlayerPrefs
void UpdateCardStates()                // Apply locked/unlocked + stars to each
IEnumerator AnimateCardsIn()           // Stagger card animations
void OnCardClicked(int levelNumber)    // Handle card tap
void OnBackClicked()                   // Handle back button
void ShowLockedMessage()               // Display "complete previous level first"
void LoadStoryReader(int levelNumber)  // Save selected level + load next scene
```

### `StoryCard.cs` — Per-Card Component

**Location:** `Assets/_Game/Scripts/UI/StoryCard.cs`
**Attached to:** Each `Card_LevelX` GameObject (3 total)

**Responsibilities:**
1. Display unlock state (visual)
2. Display stars earned
3. Detect tap and report to controller
4. Play hover/tap animations

**Inspector Variables:**

```csharp
[Header("Identity")]
public int levelNumber;               // 1, 2, or 3
public string levelTitle;             // "Level 1 — Max the Lost Puppy"
public string difficultyLabel;        // "Easy", "Medium", "Hard"
public Sprite levelIcon;              // The story icon (puppy, kite, turtle)

[Header("UI References")]
public Image cardBackground;
public Image cardBorder;
public Image iconBackground;
public Image storyIcon;
public TextMeshProUGUI titleText;
public TextMeshProUGUI difficultyText;
public Image[] starImages;            // Drag: Image_Star1, Image_Star2, Image_Star3
public GameObject lockOverlay;        // Hidden if unlocked

[Header("State Sprites")]
public Sprite starFilled;
public Sprite starEmpty;
public Sprite lockIcon;

[Header("Colors - Unlocked")]
public Color unlockedBgColor = Color.white;
public Color unlockedBorderColor = new Color(0.729f, 0.459f, 0.090f);  // #BA7517

[Header("Colors - Locked")]
public Color lockedBgColor = new Color(0.980f, 0.780f, 0.459f);        // #FAC775
public Color lockedBorderColor = new Color(0.522f, 0.310f, 0.043f);    // #854F0B
```

**Methods:**

```csharp
void SetUnlocked(bool unlocked)        // Apply unlock state visually
void SetStars(int starCount)           // Fill stars based on count
void OnTapped()                        // Notify controller
void PlayHoverAnimation()              // Scale up slightly
void PlayTapAnimation()                // Bounce
void PlayLockedAnimation()             // Shake (denied)
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Background gradient (amber) | `bg_amber_gradient.png` | Create or solid | ❌ TODO |
| Back arrow icon | `icon_back_arrow.png` | Kenney UI Pack | ❌ TODO |
| Level 1 icon (puppy) | `icon_puppy.png` | Flaticon | ❌ TODO |
| Level 2 icon (kite) | `icon_kite.png` | Flaticon | ❌ TODO |
| Level 3 icon (turtle) | `icon_turtle.png` | Flaticon | ❌ TODO |
| Lock icon | `icon_lock.png` | Kenney UI Pack | ❌ TODO |
| Star filled | `icon_star_filled.png` | Kenney UI Pack | ❌ TODO |
| Star empty | `icon_star_empty.png` | Kenney UI Pack | ❌ TODO |
| Card background | `card_white_rounded.png` | UI Pack or create | ❌ TODO |
| Card border | `card_border_amber.png` | Create or use border component | ❌ TODO |

**💡 Tip:** Use the same artist/style for all icons. Search Flaticon for "cute animal pack" or "kawaii animals" to get matching styles.

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Page flip | `page_flip.wav` | Dustyroom Pack | ❌ TODO |
| Swoosh soft | `swoosh_soft.wav` | Dustyroom Pack | ❌ TODO |
| Button confirm | `button_confirm.wav` | Dustyroom Pack | ❌ TODO |
| Locked sound | `locked.wav` | Dustyroom Pack | ❌ TODO |
| Button back | `button_back.wav` | Dustyroom Pack | ❌ TODO |
| Hover (optional) | `hover.wav` | Dustyroom Pack | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- Same as previous scenes (Orthographic, size 5)

### Canvas
- Same as previous scenes (Screen Space Overlay, 1080×1920 reference)

### Layout Group
- Use **Vertical Layout Group** on `Group_StoryCards` for automatic spacing
- Spacing: 30
- Child Force Expand: Width = true, Height = false

---

## 🔄 Scene Transitions

### Coming In
- **From:** `02_TeacherWelcome`
- **Trigger:** Player tapped Continue
- **Transition in:** Fade in (0.5s)

### Going Out (3 possible destinations)

**Path 1: Player taps an unlocked story card**
- **To:** `04_StoryReader`
- **Trigger:** Tap on unlocked Card
- **Save before leaving:** `PlayerPrefs.SetInt("currentLevel", levelNumber)`
- **Transition out:** Fade to white (0.4s)
- **Method:** `SceneManager.LoadSceneAsync("04_StoryReader")`

**Path 2: Player taps the back button**
- **To:** `02_TeacherWelcome` (or skip back to splash)
- **Trigger:** Tap on Back button
- **Transition out:** Fade out (0.3s)
- **Method:** `SceneManager.LoadSceneAsync(previousSceneName)`

**Path 3: Player taps a locked card**
- **No scene change** — show locked message and shake animation

---

## 💾 Data Read From PlayerPrefs

This scene reads (but does NOT write) the following:

```csharp
string playerName = PlayerPrefs.GetString("playerName", "friend");
int level1Stars = PlayerPrefs.GetInt("level1Stars", 0);
int level2Stars = PlayerPrefs.GetInt("level2Stars", 0);
int level3Stars = PlayerPrefs.GetInt("level3Stars", 0);
bool level2Unlocked = PlayerPrefs.GetInt("level2Unlocked", 0) == 1;
bool level3Unlocked = PlayerPrefs.GetInt("level3Unlocked", 0) == 1;
```

**Level 1 is ALWAYS unlocked.** Level 2 is only unlocked when Level 1 is complete (star count > 0). Level 3 is only unlocked when Level 2 is complete.

### Data Written When Player Selects

```csharp
PlayerPrefs.SetInt("currentLevel", selectedLevelNumber);
PlayerPrefs.Save();
```

This tells the StoryReader scene which story to load.

---

## 🎯 Card State Logic

| Level | Condition | State |
|---|---|---|
| Level 1 | Always | UNLOCKED |
| Level 2 | `level1Stars > 0` | UNLOCKED |
| Level 2 | `level1Stars == 0` | LOCKED |
| Level 3 | `level2Stars > 0` | UNLOCKED |
| Level 3 | `level2Stars == 0` | LOCKED |

### Visual Differences

| State | Visual |
|---|---|
| **Unlocked** | Full color, white background, thick amber border, no lock overlay |
| **Locked** | 60% opacity, amber background, thin border, lock icon overlay, locked title text |
| **Selected** | Brief glow effect + scale animation, then transition |

---

## ✅ Build Checklist

### Setup
- [ ] Create `03_LevelSelect.unity` scene
- [ ] Add to Build Settings as scene index 3
- [ ] Set Camera to Orthographic, size 5
- [ ] Create Canvas_LevelSelect

### GameObjects (use exact names!)
- [ ] Create `Canvas_LevelSelect`
- [ ] Create `BG_Background` with `Image_BackgroundGradient`
- [ ] Create `Button_Back` with arrow icon
- [ ] Create `Text_Header` with "Pick a story"
- [ ] Create `Group_StoryCards` with Vertical Layout Group
- [ ] Create `Card_Level1` with all child elements
  - [ ] `Image_CardBackground`
  - [ ] `Image_CardBorder`
  - [ ] `Group_IconArea`
  - [ ] `Image_IconBackground`
  - [ ] `Image_StoryIcon` (puppy)
  - [ ] `Group_TextArea`
  - [ ] `Text_LevelTitle`
  - [ ] `Group_StarsEarned`
  - [ ] `Image_Star1`, `Image_Star2`, `Image_Star3`
  - [ ] `Text_DifficultyLabel`
  - [ ] `Image_LockOverlay` (hidden)
- [ ] Duplicate for `Card_Level2` (kite icon)
- [ ] Duplicate for `Card_Level3` (turtle icon)
- [ ] Create `Text_LockedMessage` (hidden by default)
- [ ] Create `Group_Audio` with two AudioSources
- [ ] Create `LevelSelectManager` empty GameObject

### Tags
- [ ] Tag `Canvas_LevelSelect` as `UICanvas`
- [ ] Tag `Button_Back` as `BackButton`
- [ ] Tag all 3 card GameObjects as `StoryCard`
- [ ] Tag `LevelSelectManager` as `GameManager`
- [ ] Tag audio sources

### Visual Setup
- [ ] Set background to amber gradient
- [ ] Set Header text per spec
- [ ] Set unlocked colors on Card_Level1
- [ ] Set locked colors on Card_Level2 and Card_Level3
- [ ] Hide lock overlays on Card_Level1
- [ ] Show lock overlays on Card_Level2 and Card_Level3
- [ ] Set default star sprites (empty)

### Card Setup (for each)
- [ ] Set unique `levelNumber` (1, 2, 3)
- [ ] Set unique `levelTitle`
- [ ] Set unique `difficultyLabel`
- [ ] Assign correct icon
- [ ] Wire up all StoryCard component references
- [ ] Add Button component for tap detection

### Audio Setup
- [ ] Import all SFX
- [ ] Music continues from previous scene
- [ ] Set volumes per spec

### Scripts
- [ ] Create `StoryCard.cs` in Scripts/UI/
- [ ] Create `LevelSelectController.cs` in Scripts/UI/
- [ ] Attach `LevelSelectController` to `LevelSelectManager`
- [ ] Attach `StoryCard` to each card
- [ ] Wire up all Inspector references
- [ ] Hook up button events

### Test
- [ ] Test fresh state — only Level 1 unlocked
- [ ] Test with `level1Stars = 1` — Level 2 unlocks
- [ ] Test with `level2Stars = 1` — Level 3 unlocks
- [ ] Test all 3 unlocked — all cards interactive
- [ ] Test tap on unlocked card — loads StoryReader
- [ ] Test tap on locked card — shake + message
- [ ] Test back button — returns to TeacherWelcome
- [ ] Test star display — varies based on saved data
- [ ] Test card slide-in animations
- [ ] Test on multiple screen sizes

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 03 LevelSelect complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| All cards locked | Default PlayerPrefs not set | Always unlock Level 1 in code |
| Stars don't show correctly | Wrong sprite assignment | Check starFilled vs starEmpty |
| Card click triggers wrong level | Button event not wired | Check OnClick listener |
| Locked card still loads scene | Forgot to check unlocked state | Add `if (!unlocked) return;` |
| Cards overlap | Layout group not working | Check Vertical Layout Group settings |
| Animation not playing | DOTween not imported | Verify DOTween in project |
| Scene won't load | Not in Build Settings | Add via File → Build Settings |

---

## 💡 Tips

1. **Always unlock Level 1** — Even on first launch, Level 1 must be playable
2. **Use a Vertical Layout Group** — Don't manually position cards, let Unity handle spacing
3. **Test progression** — Manually set PlayerPrefs in code to test all states
4. **Card prefab** — Make Card_Level1 a prefab, then duplicate for Levels 2 and 3
5. **Consistent icons** — Use the same artist/style for all 3 story icons
6. **Don't auto-navigate** — Always require explicit tap on a card

---

## 🎓 Why This Scene Matters

The Level Select screen is where **player choice** happens for the first time. Up until now, the game has been guiding them. Here, the player makes their own decision.

The lock system is also crucial for kids:
- **Locked levels create motivation** — "I want to unlock that next!"
- **Unlocked levels create achievement** — "I earned this!"
- **Stars create replay value** — "I want all 3 stars on Level 1!"

This is the **dopamine loop** that keeps kids engaged.

---

## 🚀 Next Scene

When Scene 03 is done, move to:

**`SCENE_04_STORY_READER.md`** — Player reads the selected story page-by-page with comprehension questions

This will cover:
- Loading the JSON story file
- Page-by-page display (5 pages per story)
- Voice narration toggle
- Processing question popups after each page
- Score tracking for reading questions
- Transition to Mission Intro after final page

---

**End of Scene 03 — Level Select Specification**
