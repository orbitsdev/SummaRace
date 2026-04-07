# Scene 01 — Name Entry

> **Personalize the experience.** Player enters their name and picks an avatar. The game saves this so the teacher can greet them by name throughout the game.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `01_NameEntry.unity` |
| **Type** | 2D |
| **Duration** | Until player taps Continue |
| **Next scene** | `02_TeacherWelcome.unity` |
| **Previous scene** | `00_Splash.unity` |
| **Build complexity** | ⭐⭐ Easy-Medium |
| **Estimated build time** | 3–4 hours |

---

## 🎯 Scene Purpose

This scene has **three jobs**:

1. 👤 **Personalization** — Get the player's name so the teacher can address them by name
2. 🎨 **Identity** — Let the player pick a fun avatar that represents them
3. 💾 **Save data** — Store the name and avatar in PlayerPrefs for the entire game

---

## 👤 Player Experience (Step-by-Step)

| Step | What Player Sees | What Player Does |
|---|---|---|
| 1 | Scene fades in from white | Watching |
| 2 | Sees "What's your name, runner?" | Reading |
| 3 | Empty text box appears | Taps the box |
| 4 | Phone keyboard pops up | Types name |
| 5 | Sees their name appear | Confirms |
| 6 | Sees 4 cute avatar options | Tapping options |
| 7 | One avatar gets highlighted | Picks favorite |
| 8 | Continue button becomes active | Taps Continue |
| 9 | Scene fades to next | Excited! |

**Total time:** 30 seconds to 2 minutes (depending on how long the player thinks about their avatar)

---

## 🎨 Visual Layout

```
┌─────────────────────────────────┐
│                                 │
│                                 │
│  What's your name, runner?      │  ← Question (large)
│                                 │
│  ┌───────────────────────┐     │
│  │ Type your name...     │     │  ← Text input field
│  └───────────────────────┘     │
│                                 │
│      Pick your avatar           │  ← Subtitle
│                                 │
│   🦊    🐻    🐰    🐼          │  ← 4 avatar circles
│  Fox   Bear  Bunny  Panda       │  ← Labels (optional)
│                                 │
│                                 │
│      ┌──────────────┐          │
│      │  Continue ▸  │          │  ← Button (disabled until name typed)
│      └──────────────┘          │
│                                 │
└─────────────────────────────────┘
```

### Layout Specifications

| Element | Position | Size | Anchor |
|---|---|---|---|
| Background | Full screen | Stretch | All corners |
| Question text | Top-center, Y+300 | Auto | Top-center |
| Name input field | Center, Y+150 | 600×80 px | Center |
| Subtitle "Pick your avatar" | Center, Y+30 | Auto | Center |
| Avatar group | Center, Y−80 | 600×120 px | Center |
| Each avatar circle | Spaced evenly | 100×100 px | Center |
| Continue button | Bottom, Y−250 | 280×80 px | Center |

---

## 🎨 Color Palette

| Element | Color | Hex |
|---|---|---|
| Background | Soft purple | `#EEEDFE` |
| Question text | Deep purple | `#26215C` |
| Subtitle text | Medium purple | `#534AB7` |
| Input field background | White | `#FFFFFF` |
| Input field border | Purple | `#534AB7` |
| Input placeholder | Light purple | `#7F77DD` |
| Input typed text | Dark purple | `#26215C` |
| Avatar inactive bg | Light purple | `#CECBF6` |
| Avatar active bg | Medium purple | `#AFA9EC` |
| Avatar active border | Deep purple | `#26215C` |
| Continue button bg (active) | Deep purple | `#26215C` |
| Continue button bg (disabled) | Gray | `#B4B2A9` |
| Continue button text | White | `#FFFFFF` |

---

## 📝 Text Content

| Element | Text | Font | Size | Weight |
|---|---|---|---|---|
| Main question | `What's your name, runner?` | Fredoka | 28px | Bold |
| Input placeholder | `Type your name...` | Fredoka | 18px | Regular |
| Subtitle | `Pick your avatar` | Fredoka | 18px | Regular |
| Avatar label "Fox" | `Fox` | Fredoka | 12px | Regular |
| Avatar label "Bear" | `Bear` | Fredoka | 12px | Regular |
| Avatar label "Bunny" | `Bunny` | Fredoka | 12px | Regular |
| Avatar label "Panda" | `Panda` | Fredoka | 12px | Regular |
| Continue button | `Continue ▸` | Fredoka | 20px | Bold |

### Validation Messages (shown if needed)

| Trigger | Message |
|---|---|
| Empty name + tap Continue | `Please type your name first!` |
| Name too long (>15 chars) | `Name is a bit too long, try shorter` |
| No avatar selected | `Pick your favorite animal!` |

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/menu_theme.mp3` |
| **Volume** | 0.5 |
| **Loop** | Yes |
| **Fade in** | 0.5 seconds |

### Sound Effects

| Trigger | File | Volume |
|---|---|---|
| Tap text input | `Audio/SFX/UI/button_click.wav` | 0.7 |
| Type letter (optional) | `Audio/SFX/UI/key_tap.wav` | 0.4 |
| Tap avatar | `Audio/SFX/UI/pop.wav` | 0.7 |
| Tap Continue (active) | `Audio/SFX/UI/button_confirm.wav` | 0.8 |
| Tap Continue (disabled) | `Audio/SFX/UI/error_soft.wav` | 0.6 |

**Source:** All from Dustyroom Free Casual Game SFX Pack

---

## 🎬 Animations

| Element | Animation | When | Duration |
|---|---|---|---|
| Whole scene | Fade in from white | On scene load | 0.5s |
| Question text | Slide down + fade in | At 0.2s | 0.4s |
| Input field | Scale (0.8→1) + fade | At 0.4s | 0.4s |
| Subtitle | Fade in | At 0.6s | 0.3s |
| Each avatar | Scale (0→1) | At 0.7s, 0.8s, 0.9s, 1.0s | 0.3s each |
| Continue button | Fade in (disabled state) | At 1.1s | 0.3s |
| Avatar tap | Scale bounce (1→1.2→1) | On tap | 0.2s |
| Selected avatar | Scale up + outline grow | On select | 0.2s |
| Continue button enable | Color fade gray→purple | When name typed | 0.3s |

### Avatar Selection Animation

When the player taps an avatar:
1. Tapped avatar scales up briefly (1.2× then back to 1×)
2. All other avatars scale slightly down (0.9×)
3. The selected one gets a thick purple outline
4. The previous selection (if any) returns to normal

---

## 🛠️ GameObject Hierarchy & Names

```
NameEntryScene
│
├── Main Camera                              [Tag: MainCamera]
│
├── Canvas_NameEntry                         [Tag: UICanvas]
│   │
│   ├── BG_Background                        [Tag: Untagged]
│   │   └── Image_BackgroundColor
│   │
│   ├── Group_QuestionArea                   [Tag: Untagged]
│   │   ├── Text_Question                    [Tag: Untagged]
│   │   └── InputField_Name                  [Tag: NameInput]
│   │       ├── Image_InputBackground
│   │       ├── Text_Placeholder
│   │       └── Text_TypedName
│   │
│   ├── Group_AvatarSelection                [Tag: Untagged]
│   │   ├── Text_AvatarSubtitle
│   │   └── Group_AvatarOptions              [Tag: Untagged]
│   │       ├── Avatar_Fox                   [Tag: Avatar]
│   │       │   ├── Image_AvatarBg
│   │       │   ├── Image_AvatarIcon
│   │       │   ├── Text_AvatarLabel
│   │       │   └── Image_SelectionRing      (hidden by default)
│   │       ├── Avatar_Bear                  [Tag: Avatar]
│   │       │   ├── Image_AvatarBg
│   │       │   ├── Image_AvatarIcon
│   │       │   ├── Text_AvatarLabel
│   │       │   └── Image_SelectionRing
│   │       ├── Avatar_Bunny                 [Tag: Avatar]
│   │       │   ├── Image_AvatarBg
│   │       │   ├── Image_AvatarIcon
│   │       │   ├── Text_AvatarLabel
│   │       │   └── Image_SelectionRing
│   │       └── Avatar_Panda                 [Tag: Avatar]
│   │           ├── Image_AvatarBg
│   │           ├── Image_AvatarIcon
│   │           ├── Text_AvatarLabel
│   │           └── Image_SelectionRing
│   │
│   ├── Button_Continue                      [Tag: Untagged]
│   │   ├── Image_ButtonBg
│   │   └── Text_ButtonLabel
│   │
│   └── Text_ValidationMessage               [Tag: Untagged] (hidden by default)
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   └── AudioSource_SFX                      [Tag: AudioSFX]
│
└── NameEntryManager                         [Tag: GameManager]
    └── NameEntryController.cs (script)
```

### Naming Convention Used

| Prefix | Type | Example |
|---|---|---|
| `Canvas_` | UI Canvas | `Canvas_NameEntry` |
| `BG_` | Background | `BG_Background` |
| `Group_` | Container | `Group_AvatarSelection` |
| `Avatar_` | Avatar object | `Avatar_Fox` |
| `Image_` | UI Image | `Image_AvatarIcon` |
| `Text_` | Text element | `Text_Question` |
| `InputField_` | Input field | `InputField_Name` |
| `Button_` | Button | `Button_Continue` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `UICanvas` | Canvas_NameEntry | Identifies main canvas |
| `NameInput` | InputField_Name | Script can find input field |
| `Avatar` | Avatar_Fox, Avatar_Bear, Avatar_Bunny, Avatar_Panda | Script identifies avatars |
| `GameManager` | NameEntryManager | Identifies controller |
| `AudioMusic` | AudioSource_Music | Music source |
| `AudioSFX` | AudioSource_SFX | SFX source |

---

## 💻 Scripts Required

### `NameEntryController.cs` — Main Scene Controller

**Location:** `Assets/_Game/Scripts/UI/NameEntryController.cs`
**Attached to:** `NameEntryManager` GameObject

**Responsibilities:**
1. Listen for text input changes
2. Validate name (not empty, max length)
3. Track which avatar is selected
4. Enable/disable Continue button based on validation
5. Save data to PlayerPrefs on Continue
6. Load next scene

**Inspector Variables:**

```csharp
[Header("UI References")]
public TMP_InputField nameInputField;       // Drag: InputField_Name
public Button continueButton;                // Drag: Button_Continue
public TextMeshProUGUI continueButtonText;
public TextMeshProUGUI validationMessage;
public Image continueButtonBg;

[Header("Avatar Buttons")]
public AvatarButton[] avatarButtons;        // Drag: All 4 Avatar_X objects

[Header("Colors")]
public Color buttonActiveColor = new Color(0.149f, 0.129f, 0.361f); // #26215C
public Color buttonDisabledColor = new Color(0.706f, 0.698f, 0.663f); // #B4B2A9

[Header("Validation")]
public int maxNameLength = 15;
public int minNameLength = 1;

[Header("Audio")]
public AudioSource sfxSource;
public AudioClip clickSound;
public AudioClip popSound;
public AudioClip confirmSound;
public AudioClip errorSound;

[Header("Next Scene")]
public string nextSceneName = "02_TeacherWelcome";
```

**Methods:**

```csharp
void Start()                          // Initialize, load saved data if any
void OnNameChanged(string newName)    // Validate and update button state
void OnAvatarSelected(int avatarIndex) // Track selected avatar
void OnContinueClicked()              // Validate, save, load next scene
bool ValidateInput()                  // Returns true if everything valid
void ShowValidationMessage(string msg) // Display error message
void SaveAndContinue()                // Write to PlayerPrefs and load next
void UpdateContinueButtonState()      // Enable/disable visually
```

### `AvatarButton.cs` — Per-Avatar Component

**Location:** `Assets/_Game/Scripts/UI/AvatarButton.cs`
**Attached to:** Each `Avatar_X` GameObject (4 total)

**Responsibilities:**
1. Detect tap on this avatar
2. Show selected/unselected state visually
3. Notify NameEntryController when selected

**Inspector Variables:**

```csharp
[Header("Identity")]
public int avatarIndex;              // 0=Fox, 1=Bear, 2=Bunny, 3=Panda
public string avatarName;            // "Fox", "Bear", etc.

[Header("Visuals")]
public Image avatarBackground;
public Image avatarIcon;
public Image selectionRing;          // Hidden until selected
public TextMeshProUGUI label;

[Header("Colors")]
public Color inactiveColor = new Color(0.808f, 0.796f, 0.965f); // #CECBF6
public Color activeColor = new Color(0.686f, 0.663f, 0.925f); // #AFA9EC
```

**Methods:**

```csharp
void OnTapped()                  // Called when player taps
void SetSelected(bool selected)  // Visual update
void PlaySelectAnimation()       // Bounce animation
```

---

## 📦 Assets Needed

### Visual Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Background (light purple) | `bg_purple_solid.png` | Create or solid color | ❌ TODO |
| Fox avatar icon | `avatar_fox.png` | Flaticon (cartoon style) | ❌ TODO |
| Bear avatar icon | `avatar_bear.png` | Flaticon (matching style) | ❌ TODO |
| Bunny avatar icon | `avatar_bunny.png` | Flaticon (matching style) | ❌ TODO |
| Panda avatar icon | `avatar_panda.png` | Flaticon (matching style) | ❌ TODO |
| Input field background | `input_field_bg.png` | UI Pack or create | ❌ TODO |
| Continue button bg | `button_purple.png` | UI Pack or create | ❌ TODO |
| Selection ring (for active avatar) | `selection_ring.png` | Create simple circle | ❌ TODO |

**💡 Tip:** Use Flaticon or Game-icons.net to find a **set** of cute animal icons all in the same art style. This keeps the avatars consistent.

### Audio Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Menu music | `menu_theme.mp3` | Pixabay | ❌ TODO |
| Button click | `button_click.wav` | Dustyroom Pack | ❌ TODO |
| Pop sound | `pop.wav` | Dustyroom Pack | ❌ TODO |
| Confirm sound | `button_confirm.wav` | Dustyroom Pack | ❌ TODO |
| Error sound | `error_soft.wav` | Dustyroom Pack | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- Same as Scene 00 (Orthographic, size 5)

### Canvas
- Same as Scene 00 (Screen Space Overlay, 1080×1920 reference)

### Input Field Settings
- **Content Type:** Standard
- **Character Limit:** 15
- **Validation:** Letters and numbers only (no special chars)
- **Auto-correction:** Off
- **Mobile keyboard:** Default

---

## 🔄 Scene Transitions

### Coming In
- **From:** `00_Splash`
- **Trigger:** Auto-advance from splash screen
- **Transition:** Fade from white (0.5s)

### Going Out
- **To:** `02_TeacherWelcome`
- **Trigger:** Player taps Continue (with valid name + avatar)
- **Transition:** Fade out (0.3s)
- **Method:** `SceneManager.LoadSceneAsync("02_TeacherWelcome")`

---

## 💾 Data Saved

When the player taps Continue, save these to PlayerPrefs:

```csharp
PlayerPrefs.SetString("playerName", nameInputField.text);
PlayerPrefs.SetInt("selectedAvatar", selectedAvatarIndex);
PlayerPrefs.SetInt("hasCompletedNameEntry", 1);
PlayerPrefs.Save();
```

### PlayerPrefs Keys Created

| Key | Type | Example Value |
|---|---|---|
| `playerName` | string | `"Ben"` |
| `selectedAvatar` | int | `1` (0=Fox, 1=Bear, 2=Bunny, 3=Panda) |
| `hasCompletedNameEntry` | int | `1` (0=no, 1=yes) |

### Returning Player Behavior

If `hasCompletedNameEntry == 1` (player has been here before):
- Pre-fill the name field with their saved name
- Pre-select their saved avatar
- Player can change them or just tap Continue

---

## 🎯 Validation Rules

### Name Field

| Rule | Action |
|---|---|
| Minimum 1 character | Required |
| Maximum 15 characters | Truncate input |
| Only letters, numbers, spaces | Filter input |
| Cannot be only spaces | Show validation message |
| First letter capitalized | Auto-capitalize (optional) |

### Avatar Selection

| Rule | Action |
|---|---|
| Default avatar (Fox) selected on first load | Auto-select |
| At least one must be selected | Required |

### Continue Button States

| State | Condition | Visual |
|---|---|---|
| **Disabled** | Name empty OR no avatar | Gray, 50% opacity |
| **Enabled** | Name valid + avatar selected | Purple, full opacity |
| **Pressed** | Player is tapping it | Slight scale down (0.95) |

---

## ✅ Build Checklist

### Setup
- [ ] Create `01_NameEntry.unity` scene
- [ ] Add to Build Settings as scene index 1
- [ ] Set Camera to Orthographic, size 5
- [ ] Create Canvas_NameEntry with correct settings

### GameObjects (use exact names!)
- [ ] Create `Canvas_NameEntry`
- [ ] Create `BG_Background` with `Image_BackgroundColor`
- [ ] Create `Group_QuestionArea`
- [ ] Create `Text_Question` with text "What's your name, runner?"
- [ ] Create `InputField_Name` (TMP Input Field)
- [ ] Create `Group_AvatarSelection`
- [ ] Create `Text_AvatarSubtitle` with "Pick your avatar"
- [ ] Create `Group_AvatarOptions`
- [ ] Create `Avatar_Fox` with all child elements
- [ ] Create `Avatar_Bear` with all child elements
- [ ] Create `Avatar_Bunny` with all child elements
- [ ] Create `Avatar_Panda` with all child elements
- [ ] Create `Button_Continue` with image and text
- [ ] Create `Text_ValidationMessage` (start hidden)
- [ ] Create `Group_Audio` with two AudioSources
- [ ] Create `NameEntryManager` empty GameObject

### Tags
- [ ] Tag `Canvas_NameEntry` as `UICanvas`
- [ ] Tag `InputField_Name` as `NameInput`
- [ ] Tag all 4 avatar GameObjects as `Avatar`
- [ ] Tag `NameEntryManager` as `GameManager`
- [ ] Tag audio sources as `AudioMusic` and `AudioSFX`

### Visual Setup
- [ ] Set background to soft purple `#EEEDFE`
- [ ] Set all text per spec (font, size, color)
- [ ] Place 4 avatars evenly spaced
- [ ] Set input field border purple
- [ ] Set Continue button to gray (disabled state)

### Avatar Setup (for each)
- [ ] Set unique `avatarIndex` (0–3)
- [ ] Set `avatarName` ("Fox", "Bear", etc.)
- [ ] Assign correct icon image
- [ ] Hide `Image_SelectionRing` initially
- [ ] Add Button component for tap detection

### Audio Setup
- [ ] Import menu music to Audio/Music/
- [ ] Import all SFX to Audio/SFX/UI/
- [ ] Assign clips to AudioSources
- [ ] Set music to loop and play on awake

### Scripts
- [ ] Create `AvatarButton.cs` in Scripts/UI/
- [ ] Create `NameEntryController.cs` in Scripts/UI/
- [ ] Attach `NameEntryController` to `NameEntryManager`
- [ ] Attach `AvatarButton` to each avatar
- [ ] Wire up all Inspector references
- [ ] Hook up button events (OnClick)

### Test
- [ ] Test text input — keyboard appears
- [ ] Test avatar selection — visual feedback
- [ ] Test Continue button — disabled when empty
- [ ] Test validation — error message shows
- [ ] Test save — data persists across scene loads
- [ ] Test returning — pre-fills with saved data
- [ ] Test transition to next scene

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 01 NameEntry complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Keyboard doesn't appear on mobile | Wrong InputField type | Use TMP_InputField, not legacy |
| Avatar selection doesn't show | SelectionRing always hidden | Check SetActive(true) in script |
| Continue button always disabled | Validation logic wrong | Debug.Log to check values |
| Name not saving | PlayerPrefs.Save() missing | Add it after SetString |
| Music doesn't play | Play on Awake unchecked | Check AudioSource component |
| Avatars overlap | Wrong layout group | Use Horizontal Layout Group |

---

## 💡 Tips

1. **Use Horizontal Layout Group** for the 4 avatars — auto-spaces them
2. **Use TMP_InputField**, not the legacy InputField (better for mobile)
3. **Test with a real device** — text input on mobile is different from PC
4. **Default to Fox** as the pre-selected avatar (most universally appealing)
5. **Animate the selection** — kids love visual feedback
6. **Don't allow special characters** — kids will type emojis and break things

---

## 🎓 Why This Scene Matters

This is where the game becomes **personal**. When the teacher says "Hi Ben!" later, it's only meaningful because the player typed their name here. Personalization is one of the strongest engagement tools in kids' games.

The avatar choice also gives kids a sense of **ownership** — "that's MY character running through the snow." Even though it doesn't affect gameplay, it makes the experience feel like theirs.

---

## 🚀 Next Scene

When Scene 01 is done, move to:

**`SCENE_02_TEACHER_WELCOME.md`** — Ms. Lumi greets the player by name

---

**End of Scene 01 — Name Entry Specification**
