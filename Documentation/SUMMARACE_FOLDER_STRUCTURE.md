# SummaRace — Unity Project Folder Structure

A complete, production-ready folder structure for the SummaRace Unity project. This is organized to keep your code clean, your assets findable, and your collaborators (or future you) sane.

---

## 📁 Complete Folder Tree

```
SummaRace/                                  ← Unity project root
│
├── Assets/                                 ← Everything Unity sees lives here
│   │
│   ├── _Game/                              ← Underscore prefix keeps your work at the top
│   │   │
│   │   ├── Scenes/                         ← All Unity scenes (.unity files)
│   │   │   ├── 00_Splash.unity
│   │   │   ├── 01_NameEntry.unity
│   │   │   ├── 02_TeacherWelcome.unity
│   │   │   ├── 03_LevelSelect.unity
│   │   │   ├── 04_StoryReader.unity
│   │   │   ├── 05_MissionIntro.unity
│   │   │   ├── 06_Mission3DRun.unity      ← The core 3D gameplay scene
│   │   │   ├── 07_FinalSummary.unity
│   │   │   ├── 08_Victory.unity
│   │   │   └── 99_GameComplete.unity      ← Final celebration after Level 3
│   │   │
│   │   ├── Scripts/                        ← All C# code
│   │   │   │
│   │   │   ├── Core/                       ← Game-wide systems (singletons)
│   │   │   │   ├── GameManager.cs          ← Tracks current level, story progress
│   │   │   │   ├── SaveManager.cs          ← PlayerPrefs wrapper for save/load
│   │   │   │   ├── AudioManager.cs         ← Music & SFX playback
│   │   │   │   ├── SceneLoader.cs          ← Scene transitions with fade
│   │   │   │   └── EventBus.cs             ← Event system for decoupling
│   │   │   │
│   │   │   ├── Data/                       ← Data classes & ScriptableObjects
│   │   │   │   ├── StoryData.cs            ← Story model (pages, questions, elements)
│   │   │   │   ├── PageData.cs             ← Single page model
│   │   │   │   ├── QuestionData.cs         ← Question + options + correct index
│   │   │   │   ├── ElementData.cs          ← Mission element (Somebody/Wanted/etc)
│   │   │   │   ├── PlayerProgress.cs       ← Saved progress model
│   │   │   │   └── StoryLoader.cs          ← Loads JSON files into StoryData
│   │   │   │
│   │   │   ├── Player/                     ← 3D player character logic
│   │   │   │   ├── PlayerController.cs     ← Forward movement, sprint, slowdown
│   │   │   │   ├── LaneSwitcher.cs         ← Left/right/middle lane movement
│   │   │   │   ├── PlayerInput.cs          ← Swipe + keyboard input handling
│   │   │   │   └── PlayerAnimator.cs       ← Animation state machine controls
│   │   │   │
│   │   │   ├── Mission/                    ← The 3D run scene logic
│   │   │   │   ├── MissionManager.cs       ← Orchestrates the whole mission
│   │   │   │   ├── TrackGenerator.cs       ← Spawns track segments ahead
│   │   │   │   ├── CheckpointSpawner.cs    ← Spawns 5 question checkpoints
│   │   │   │   ├── AnswerCard.cs           ← Single answer card (collectible)
│   │   │   │   ├── DangerLevel.cs          ← The "fake chase" variable system
│   │   │   │   ├── SnowPatrolVisual.cs     ← Visual-only enemy follower
│   │   │   │   ├── MissionTimer.cs         ← Countdown timer
│   │   │   │   └── ElementCollector.cs     ← Tracks which elements collected
│   │   │   │
│   │   │   ├── UI/                         ← All UI controllers (one per scene)
│   │   │   │   ├── SplashUI.cs
│   │   │   │   ├── NameEntryUI.cs
│   │   │   │   ├── TeacherWelcomeUI.cs
│   │   │   │   ├── LevelSelectUI.cs
│   │   │   │   ├── StoryReaderUI.cs        ← Page navigation, narration toggle
│   │   │   │   ├── QuestionPopupUI.cs      ← Reading-phase question popup
│   │   │   │   ├── MissionIntroUI.cs
│   │   │   │   ├── MissionHUD.cs           ← In-game HUD (timer, collected bar)
│   │   │   │   ├── FinalSummaryUI.cs       ← Type summary + fix wrong elements
│   │   │   │   └── VictoryUI.cs
│   │   │   │
│   │   │   └── Utils/                      ← Helper scripts
│   │   │       ├── SwipeDetector.cs        ← Detects swipe gestures
│   │   │       ├── FadeTransition.cs       ← Screen fade in/out
│   │   │       ├── TextTyper.cs            ← Typewriter text effect for narration
│   │   │       └── KeywordValidator.cs     ← Validates typed summaries by keywords
│   │   │
│   │   ├── Prefabs/                        ← Reusable game objects
│   │   │   ├── Player/
│   │   │   │   ├── PlayerCharacter.prefab
│   │   │   │   ├── PlayerCamera.prefab
│   │   │   │   └── Avatars/              ← 4 swappable avatar skins
│   │   │   │       ├── AvatarFox.prefab
│   │   │   │       ├── AvatarBear.prefab
│   │   │   │       ├── AvatarRabbit.prefab
│   │   │   │       └── AvatarPanda.prefab
│   │   │   ├── Characters/               ← Reusable characters across scenes
│   │   │   │   └── Teacher.prefab        ← Ms. Lumi (used in 3+ scenes)
│   │   │   ├── Mission/
│   │   │   │   ├── TrackSegment.prefab
│   │   │   │   ├── Checkpoint.prefab
│   │   │   │   ├── AnswerCard.prefab
│   │   │   │   ├── SnowPatrol.prefab
│   │   │   │   └── Obstacle.prefab
│   │   │   ├── UI/
│   │   │   │   ├── Common/               ← Shared UI components
│   │   │   │   │   ├── ButtonPrimary.prefab
│   │   │   │   │   ├── ButtonSecondary.prefab
│   │   │   │   │   ├── DialogPanel.prefab
│   │   │   │   │   └── LoadingOverlay.prefab
│   │   │   │   ├── QuestionPopup.prefab
│   │   │   │   ├── ElementSlot.prefab
│   │   │   │   ├── StarBadge.prefab
│   │   │   │   └── SpeechBubble.prefab
│   │   │   └── Effects/
│   │   │       ├── SnowParticles.prefab
│   │   │       ├── CorrectFX.prefab
│   │   │       └── WrongFX.prefab
│   │   │
│   │   ├── ScriptableObjects/              ← Designer-tweakable settings
│   │   │   ├── GameConfig.asset            ← Speed, danger thresholds, etc
│   │   │   ├── AudioConfig.asset           ← Volume defaults
│   │   │   └── DifficultyTuning.asset      ← Per-level tuning values
│   │   │
│   │   └── Resources/                      ← Files loaded at runtime by name
│   │       ├── Stories/                    ← JSON story files
│   │       │   ├── level1.json
│   │       │   ├── level2.json
│   │       │   └── level3.json
│   │       └── Localization/               ← (For future Filipino version)
│   │           ├── en.json
│   │           └── fil.json
│   │
│   ├── Art/                                ← All visual assets
│   │   │
│   │   ├── 2D/
│   │   │   ├── UI/                         ← Buttons, panels, frames
│   │   │   │   ├── Buttons/
│   │   │   │   ├── Panels/
│   │   │   │   ├── Icons/                  ← Star, lock, heart, etc
│   │   │   │   └── Backgrounds/
│   │   │   │
│   │   │   ├── Characters/                 ← 2D character art
│   │   │   │   ├── Teacher/                ← Ms. Lumi poses
│   │   │   │   │   ├── lumi_idle.png
│   │   │   │   │   ├── lumi_wave.png
│   │   │   │   │   ├── lumi_talk.png
│   │   │   │   │   └── lumi_cheer.png
│   │   │   │   └── Avatars/                ← 4 player avatar choices
│   │   │   │       ├── avatar_fox.png
│   │   │   │       ├── avatar_bear.png
│   │   │   │       ├── avatar_rabbit.png
│   │   │   │       └── avatar_panda.png
│   │   │   │
│   │   │   ├── Illustrations/              ← Storybook page art
│   │   │   │   ├── Level1_Max/
│   │   │   │   │   ├── max_page1.png
│   │   │   │   │   ├── max_page2.png
│   │   │   │   │   ├── max_page3.png
│   │   │   │   │   ├── max_page4.png
│   │   │   │   │   └── max_page5.png
│   │   │   │   ├── Level2_Luna/
│   │   │   │   │   └── (5 PNGs)
│   │   │   │   └── Level3_Tito/
│   │   │   │       └── (5 PNGs)
│   │   │   │
│   │   │   └── ElementIcons/               ← The 45 collectible icons
│   │   │       ├── Level1/                 ← 15 icons (5 categories x 3 options)
│   │   │       ├── Level2/                 ← 15 icons
│   │   │       └── Level3/                 ← 15 icons
│   │   │
│   │   └── 3D/
│   │       ├── Characters/                 ← Player + Snow Patrol models
│   │       │   ├── Player/
│   │       │   │   ├── player_model.fbx
│   │       │   │   └── Animations/
│   │       │   │       ├── idle.fbx
│   │       │   │       ├── run.fbx
│   │       │   │       ├── sprint.fbx
│   │       │   │       ├── jump.fbx
│   │       │   │       ├── stumble.fbx
│   │       │   │       └── caught.fbx
│   │       │   └── SnowPatrol/
│   │       │       ├── patrol_model.fbx
│   │       │       └── patrol_walk.fbx
│   │       │
│   │       ├── Environment/                ← Track + scenery
│   │       │   ├── Track/
│   │       │   │   ├── snow_road.fbx
│   │       │   │   └── road_texture.png
│   │       │   ├── Trees/
│   │       │   │   └── pine_snow.fbx
│   │       │   ├── Mountains/
│   │       │   │   └── mountain_bg.fbx
│   │       │   └── Props/                  ← Rocks, signs, decorations
│   │       │
│   │       └── Materials/                  ← Materials & shaders
│   │           ├── snow_mat.mat
│   │           ├── tree_mat.mat
│   │           └── fog_mat.mat
│   │
│   │   └── SharedMaterials/                ← Shared materials across 2D/3D
│   │       ├── ui_glow_mat.mat
│   │       └── outline_mat.mat
│   │
│   ├── Audio/                              ← All audio files
│   │   ├── Music/
│   │   │   ├── menu_theme.mp3
│   │   │   ├── reading_calm.mp3
│   │   │   ├── mission_action.mp3
│   │   │   └── victory_fanfare.mp3
│   │   │
│   │   ├── SFX/
│   │   │   ├── UI/
│   │   │   │   ├── button_click.wav
│   │   │   │   ├── page_flip.wav
│   │   │   │   └── popup_open.wav
│   │   │   ├── Gameplay/
│   │   │   │   ├── correct_chime.wav
│   │   │   │   ├── wrong_buzz.wav
│   │   │   │   ├── element_collected.wav
│   │   │   │   ├── sprint_whoosh.wav
│   │   │   │   ├── footstep_snow.wav
│   │   │   │   ├── patrol_stomp.wav
│   │   │   │   └── caught_alarm.wav
│   │   │   └── Ambient/
│   │   │       └── snow_wind.wav
│   │   │
│   │   └── Voice/                          ← Narration files
│   │       ├── Teacher/
│   │       │   ├── lumi_welcome.mp3
│   │       │   ├── lumi_mission_intro.mp3
│   │       │   └── lumi_victory.mp3
│   │       └── Stories/
│   │           ├── Level1/
│   │           │   ├── max_page1.mp3
│   │           │   ├── max_page2.mp3
│   │           │   ├── max_page3.mp3
│   │           │   ├── max_page4.mp3
│   │           │   └── max_page5.mp3
│   │           ├── Level2/
│   │           │   └── (5 MP3s)
│   │           └── Level3/
│   │               └── (5 MP3s)
│   │
│   ├── Fonts/                              ← Custom fonts
│   │   ├── kid_friendly_main.ttf           ← Main UI font (rounded, friendly)
│   │   └── storybook_serif.ttf             ← For storybook reading pages
│   │
│   ├── Settings/                           ← Unity settings assets
│   │   ├── URP/                            ← Universal Render Pipeline configs
│   │   │   ├── URP_Mobile.asset
│   │   │   └── URP_Mobile_Renderer.asset
│   │   └── InputSystem/
│   │       └── PlayerInputActions.inputactions
│   │
│   └── Plugins/                            ← Third-party assets (keep separate!)
│       ├── EndlessRunnerTemplate/          ← The template you imported
│       ├── DOTween/                        ← Animation library (recommended)
│       └── TextMeshPro/                    ← Already included in Unity
│
├── Packages/                               ← Unity package manager files (auto)
├── ProjectSettings/                        ← Unity project settings (auto)
├── Library/                                ← Unity cache (gitignored)
├── Logs/                                   ← Unity logs (gitignored)
├── Temp/                                   ← Temp files (gitignored)
├── obj/                                    ← Compiler output (gitignored)
│
├── Builds/                                 ← Your APK exports
│   ├── Android/
│   └── Windows/                            ← (optional, for desktop testing)
│
├── Documentation/                          ← Project docs
│   ├── SUMMARACE_GAME_PLAN.md
│   ├── SUMMARACE_ASSET_CHECKLIST.md
│   ├── SUMMARACE_FOLDER_STRUCTURE.md      ← This file
│   └── SUMMARACE_GAME_FLOW.svg
│
├── .gitignore                              ← Tells Git which files to ignore
└── README.md                               ← Quick project overview
```

---

## 🔄 Reusability Design

This project is designed to **avoid duplication**. Key reusable elements:

### Single Mission Scene for All Levels
- `06_Mission3DRun.unity` handles ALL 3 story levels
- Story data loaded dynamically from JSON (level1.json, level2.json, level3.json)
- Same scripts, different data = zero duplication

### Shared Prefabs
| Prefab | Used In | Purpose |
|--------|---------|---------|
| Teacher.prefab | TeacherWelcome, MissionIntro, Victory | Ms. Lumi character |
| PlayerCharacter.prefab | Mission3DRun | Same player, swappable avatar |
| ButtonPrimary.prefab | All UI scenes | Consistent button style |
| DialogPanel.prefab | All UI scenes | Consistent dialog boxes |
| LoadingOverlay.prefab | Scene transitions | Fade in/out overlay |
| QuestionPopup.prefab | StoryReader, Mission | Same popup, different context |

### Core Singletons (Persist Across Scenes)
- **GameManager** - Current level, story progress, player name
- **SaveManager** - PlayerPrefs wrapper for save/load
- **AudioManager** - Music/SFX, volume settings
- **SceneLoader** - Transitions with fade

### Data-Driven Balance (ScriptableObjects)
- Change speed, danger levels, timers WITHOUT code changes
- One DifficultyTuning.asset with per-level values

---

## 🎯 Why This Structure Works

### 1. The `_Game/` underscore prefix
When you open the Assets folder in Unity, the underscore makes `_Game/` sort to the top, above the third-party assets in `Plugins/`. You'll find your own work instantly.

### 2. Separation of concerns
- **`Scripts/`** is split by purpose (Core, Player, Mission, UI) — never one giant folder of 50 scripts
- **`Art/`** is split by 2D vs 3D — easy to find what you need
- **`Audio/`** is split by Music, SFX, Voice — no audio chaos

### 3. Plugins kept separate
Third-party assets stay in `Plugins/` so when you update them, you don't accidentally overwrite your own files.

### 4. Resources only for runtime-loaded content
The `Resources/` folder is special in Unity — files inside it can be loaded by name at runtime. Use it ONLY for the JSON story files and localization. Putting too much in Resources bloats your build size.

### 5. ScriptableObjects for designer tuning
Game balance values (speed, danger thresholds, timer length) live in ScriptableObjects so you can tweak them in the Unity Inspector without recompiling code.

---

## 📜 Naming Conventions

Stick to these throughout the project to keep things readable:

| Type | Convention | Example |
|---|---|---|
| **Folders** | PascalCase | `PlayerControllers/` |
| **Scripts** | PascalCase | `PlayerController.cs` |
| **Scenes** | NumberPrefix_PascalCase | `06_Mission3DRun.unity` |
| **Prefabs** | PascalCase | `AnswerCard.prefab` |
| **Materials** | snake_case_mat | `snow_ground_mat.mat` |
| **Textures** | snake_case | `mountain_bg.png` |
| **Audio** | snake_case | `correct_chime.wav` |
| **JSON files** | lowercase | `level1.json` |
| **Variables (private)** | _camelCase | `_currentSpeed` |
| **Variables (public)** | camelCase | `playerSpeed` |
| **Constants** | UPPER_SNAKE | `MAX_DANGER_LEVEL` |
| **Methods** | PascalCase | `OnAnswerSelected()` |

---

## 🔄 Git Setup (.gitignore)

Create a `.gitignore` file in the project root with this content:

```
# Unity generated
[Ll]ibrary/
[Tt]emp/
[Oo]bj/
[Bb]uild/
[Bb]uilds/
[Ll]ogs/
[Uu]ser[Ss]ettings/

# MemoryCaptures can get excessive in size
[Mm]emoryCaptures/

# Asset meta data should only be ignored when the corresponding asset is also ignored
!/[Aa]ssets/**/*.meta

# Uncomment this line if you wish to ignore the asset store tools plugin
# /[Aa]ssets/AssetStoreTools*

# Autogenerated VS/MD/Consulo solution and project files
ExportedObj/
.consulo/
*.csproj
*.unityproj
*.sln
*.suo
*.tmp
*.user
*.userprefs
*.pidb
*.booproj
*.svd
*.pdb
*.mdb
*.opendb
*.VC.db

# Unity3D generated meta files
*.pidb.meta
*.pdb.meta
*.mdb.meta

# Unity3D generated file on crash reports
sysinfo.txt

# Builds
*.apk
*.aab
*.unitypackage
*.app

# Crashlytics generated file
crashlytics-build.properties

# Mac
.DS_Store

# Visual Studio Code
.vscode/

# JetBrains Rider
.idea/
```

---

## 🏗️ Key Scripts Explained

Here are the most important scripts you'll need to write, in priority order:

### Top Priority (Build first)

**1. `GameManager.cs`** (Singleton)
Tracks the current level, current story, player progress. Persists between scenes.

**2. `SaveManager.cs`** (Singleton)
Wraps PlayerPrefs. Methods: `SaveProgress()`, `LoadProgress()`, `UnlockLevel(int)`, `SetStars(int level, int stars)`.

**3. `StoryLoader.cs`**
Loads JSON files from `Resources/Stories/` and converts them to `StoryData` objects.

**4. `PlayerController.cs`** (Mission scene)
Handles forward movement, lane switching, sprint boost, slowdown when wrong answer.

**5. `DangerLevel.cs`** (Mission scene)
Implements your "fake chase" idea. A simple int variable that goes up when wrong, down when right. When it hits max → trigger caught state.

**6. `CheckpointSpawner.cs`** (Mission scene)
Spawns 5 question checkpoints along the track at specific distances. Each checkpoint instantiates 3 `AnswerCard` prefabs in the 3 lanes.

**7. `AnswerCard.cs`** (Prefab script)
A collectible card. On collision with player, reports correct/wrong to MissionManager.

**8. `MissionManager.cs`** (Mission scene)
Orchestrates everything: starts the mission, listens for answers, updates HUD, handles caught state, transitions to summary scene when finish line reached.

### Medium Priority

**9. `StoryReaderUI.cs`** — Page navigation, narration playback, question popup triggering
**10. `QuestionPopupUI.cs`** — Reading-phase question handling
**11. `MissionHUD.cs`** — Updates timer, score, collected elements bar
**12. `FinalSummaryUI.cs`** — Shows collected elements, allows fixing wrong ones, validates typed summary
**13. `KeywordValidator.cs`** — Checks if typed summary contains the right keywords

### Lower Priority

**14. `LevelSelectUI.cs`**, `NameEntryUI.cs`, `VictoryUI.cs`, `TeacherWelcomeUI.cs` — Simple UI scenes

---

## 💡 Recommended Free Plugins to Install

Before you start, install these free Unity packages — they save you tons of time:

| Plugin | Why You Need It | Where to Get |
|---|---|---|
| **DOTween (Free)** | Easy animations (fade, move, scale) without coding | Asset Store (free) |
| **TextMeshPro** | Better text rendering than legacy UI Text | Built into Unity |
| **Cinemachine** | Smart camera follow for the player | Built into Unity |
| **Universal Render Pipeline (URP)** | Better looking, mobile-friendly graphics | Built into Unity |
| **Input System** | Modern input handling for touch + keyboard | Built into Unity |
| **2D Sprite Editor** | For slicing UI atlases | Built into Unity |

---

## 🎨 Art Import Settings (Important!)

When you import art assets into Unity, use these settings to keep everything looking sharp:

### For 2D UI textures
- Texture Type: **Sprite (2D and UI)**
- Sprite Mode: Single
- Pixels Per Unit: 100
- Filter Mode: **Bilinear** (smooth) or **Point** (pixel art)
- Compression: High Quality
- Generate Mip Maps: **Off** (UI doesn't need them)

### For 3D character textures
- Texture Type: Default
- Filter Mode: Trilinear
- Compression: Normal Quality
- Generate Mip Maps: **On**
- Max Size: 1024 (mobile) or 2048 (desktop)

### For storybook illustrations
- Texture Type: Sprite (2D and UI)
- Max Size: 2048
- Compression: High Quality

---

## 📦 Build Settings for Android

When you're ready to build for Android:

1. **File → Build Settings → Android → Switch Platform**
2. **Player Settings:**
   - Company Name: (your name/company)
   - Product Name: SummaRace
   - Package Name: `com.yourname.summarace`
   - Version: 1.0
   - Minimum API Level: Android 7.0 (API 24) — covers 95%+ of devices
   - Target API Level: Latest installed
   - Scripting Backend: **IL2CPP** (required for Play Store)
   - Target Architectures: **ARMv7 + ARM64**
3. **Quality Settings:** Use a custom "Mobile" preset, disable shadows on lowest tier
4. **Graphics:** Use URP Mobile pipeline asset

---

## 🚀 Day 1 Setup Checklist

Before writing any code, do this on Day 1:

- [ ] Install Unity Hub
- [ ] Install Unity 2022 LTS (or newer LTS)
- [ ] Install Android Build Support module
- [ ] Create new project named "SummaRace" with **3D URP template**
- [ ] Switch platform to Android in Build Settings
- [ ] Create the entire folder structure above (empty folders are fine)
- [ ] Import DOTween Free from Asset Store
- [ ] Import the endless runner template
- [ ] Create empty scenes for all 10 game scenes (you'll fill them in later)
- [ ] Add all scenes to Build Settings in order
- [ ] Initialize Git in the project root with the .gitignore above
- [ ] Make your first commit: "Initial project setup"
- [ ] Copy the 3 documentation files into the `Documentation/` folder

When all of this is done, you're officially ready to start Day 2 (building the 3D track).

---

**End of Folder Structure Document**
