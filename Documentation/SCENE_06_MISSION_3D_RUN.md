# Scene 06 — Mission 3D Run

> **THE MAIN GAMEPLAY SCENE.** Player runs through a snowy 3D track, collects answer elements at 5 checkpoints, and tries to outrun the Snow Patrol. This is where all the game mechanics come together.

> ⚠️ **This is the most complex scene in SummaRace.** Expect it to take 25–40% of total dev time.

---

## 📋 Quick Info

| Property | Value |
|---|---|
| **Scene file** | `06_Mission3DRun.unity` |
| **Type** | **3D** ⭐ (only 3D scene in the game) |
| **Duration** | 60–90 seconds (timer-based) |
| **Next scene** | `07_FinalSummary.unity` |
| **Previous scene** | `05_MissionIntro.unity` |
| **Build complexity** | ⭐⭐⭐⭐⭐ Very Hard |
| **Estimated build time** | 25–40 hours (largest scene) |

---

## 🎯 Scene Purpose

This is **the gameplay heart** of SummaRace. It has **seven jobs**:

1. 🏃 **Player movement** — Run forward automatically, switch lanes, jump, slide
2. 🎯 **Element collection** — Collect 5 answer elements at checkpoints
3. ❓ **Real-time questions** — 3 floating answer cards at each checkpoint
4. ❄️ **Snow Patrol pressure** — Visual chase that gets closer when player picks wrong
5. ⏱️ **Time pressure** — Mission timer counts down
6. 💯 **Score tracking** — Track correct/wrong answers and time bonus
7. 🏁 **Finish line** — Trigger victory sequence after 600 units

---

## 👤 Player Experience (Step-by-Step)

| Phase | What Player Sees | What Player Does |
|---|---|---|
| **Start** | "3-2-1 GO!" countdown | Watching, getting ready |
| **0–10s** | Player runs forward, snowy track ahead | Familiarizing with controls |
| **~10s** | First checkpoint approaches with 3 answer cards | Reading options |
| **~12s** | Player swipes to lane with correct answer | Tap/swipe |
| **~13s** | ✅ Correct! Sprint boost activates | Celebrating |
| **~20s** | Second checkpoint appears | Reading |
| **~22s** | Player picks wrong by accident ❌ | Frustrated |
| **~22s** | Slowdown + patrol gets closer | Worried |
| **~30s** | Player recovers, picks correct | Relief |
| **... continues for all 5 checkpoints ...** | | |
| **~55s** | Final checkpoint passed | Almost there! |
| **~60s** | Finish line approaches | Excited |
| **~62s** | Player crosses finish line | Victory! |
| **+1s** | Slow-motion finish + fade out | Anticipating result |
| **+2s** | Scene transitions to Final Summary | |

**Total time:** 60–90 seconds (depending on level and how often player gets caught)

---

## 🎨 Visual Layout (3D Scene)

### Camera Perspective

The camera follows the player from **behind and above**, third-person style:

```
        📷 (Camera, 6 units back, 3 units up)
         ↓
          🏃 (Player, in middle lane)
        ════ Track ahead
        ❄️🌲❄️🌲❄️ Trees and obstacles on sides
                     🏔️ Mountains in distance
```

### What Player Sees in Each Frame

```
┌─────────────────────────────────┐
│  [⏱ 0:42]            [⭐ 120]   │  ← HUD: timer, score (top corners)
│                                 │
│  [COLLECTED: 🐶 🏠 ? ? ?]      │  ← HUD: collected elements (top center)
│                                 │
│      🏔️    🏔️    🏔️             │  ← Distant mountains (3D bg)
│   🌲                  🌲        │  ← Trees on sides
│      🌲          🌲              │
│                                 │
│   ┌────┐  ┌────┐  ┌────┐       │  ← 3 answer cards (3D, floating)
│   │👫  │  │🌲  │  │😴  │       │     (when at checkpoint)
│   │met │  │got │  │fell│       │
│   │    │  │lost│  │... │       │
│   └────┘  └────┘  └────┘       │
│                                 │
│            🏃                    │  ← Player (3D character, middle lane)
│        ════════                  │  ← Track (3 lanes visible)
│                                 │
│    ◂  ▴  ▸                      │  ← Touch controls (or invisible)
└─────────────────────────────────┘
```

### Track Layout (Top-Down View)

```
      Lane 0        Lane 1        Lane 2
      (left)       (middle)       (right)
        |             |             |
   ┌────┴────┐   ┌────┴────┐   ┌────┴────┐
   │         │   │         │   │         │
   │    A    │   │    B    │   │    C    │  ← Checkpoint 1 (z=100)
   │         │   │         │   │         │
   └─────────┘   └─────────┘   └─────────┘
        |             |             |
        |             🏃             |          ← Player runs forward (z direction)
        |             |             |
        |             |             |
        |             |             |
   ┌────┴────┐   ┌────┴────┐   ┌────┴────┐
   │    A    │   │    B    │   │    C    │  ← Checkpoint 2 (z=200)
   └─────────┘   └─────────┘   └─────────┘
   
   ... (5 checkpoints total)
   
   ═══════════════════════════════════════  ← Finish line (z=600)
```

---

## 🎨 Color Palette

### Environment

| Element | Color | Hex |
|---|---|---|
| Sky | Light blue | `#B5D4F4` |
| Distant mountains | Cool gray-blue | `#6B8AA8` |
| Track surface (snow) | Off-white | `#F0F4F8` |
| Track lane lines | Light gray | `#C5CFD9` |
| Trees | Dark green | `#1F4D2B` |
| Tree snow caps | White | `#FFFFFF` |
| Fog (distance) | Light gray | `#D5DEE8` |

### HUD (UI Overlay)

| Element | Color | Hex |
|---|---|---|
| HUD background panels | Dark navy | `#042C53` |
| HUD text | White | `#FFFFFF` |
| Timer color (normal) | White | `#FFFFFF` |
| Timer color (warning <30s) | Yellow | `#EF9F27` |
| Timer color (danger <10s) | Red | `#A32D2D` |
| Score color | Yellow | `#EF9F27` |
| Element collected (correct) | Green | `#1D9E75` |
| Element collected (wrong) | Red | `#A32D2D` |
| Element not yet collected | Gray | `#5F5E5A` |

### Answer Cards

| Element | Color | Hex |
|---|---|---|
| Card background | White | `#FFFFFF` |
| Card border | Cyan | `#378ADD` |
| Card text | Dark navy | `#042C53` |
| Card icon background | Light blue | `#B5D4F4` |

### Feedback Effects

| Element | Color | Hex |
|---|---|---|
| Correct flash | Green | `#1D9E75` |
| Wrong flash | Red | `#A32D2D` |
| Sprint trail | Cyan | `#85B7EB` |
| Patrol fog (close) | Dark red | `#4A1B0C` |

---

## 📝 Text Content (HUD)

### Timer

| Text | When | Color |
|---|---|---|
| `⏱ 1:30` | Time > 30s | White |
| `⏱ 0:25` | Time 10–30s | Yellow |
| `⏱ 0:08` | Time < 10s | Red (pulsing) |

### Score

| Text | Update |
|---|---|
| `⭐ 0` | Start |
| `⭐ +100` | After correct answer (popup) |
| `⭐ 250` | Running total |

### Element Bar (5 slots)

| Slot State | Display |
|---|---|
| Empty | `?` (light gray) |
| Collected correct | `🐶` (green border) |
| Collected wrong | `👫` (red border, X) |

### Patrol Distance (Optional Display)

| Text | When |
|---|---|
| `❄ 28m ↑ FAR` | dangerLevel < 30 |
| `❄ 18m` | dangerLevel 30-60 |
| `❄ 8m ↓ DANGER` | dangerLevel > 60 |

### Question Banner (when at checkpoint)

| Text | Notes |
|---|---|
| `⚠ SOMEBODY — who is the main character?` | First checkpoint |
| `⚠ WANTED — what did they want?` | Second |
| `⚠ BUT — what was the problem?` | Third |
| `⚠ SO — what did they do?` | Fourth |
| `⚠ THEN — what happened in the end?` | Fifth |

### Countdown (start of mission)

```
3 ... 2 ... 1 ... GO!
```

### Caught Screen Text

| Text |
|---|
| `❄ CAUGHT BY PATROL!` |
| `The patrol got you!` |
| `Don't worry! Try again — you remember the story!` |
| `↻ Retry mission` (button) |
| `📖 Re-read story` (button) |

---

## 🎵 Audio

### Music

| Property | Value |
|---|---|
| **File** | `Audio/Music/mission_action.mp3` |
| **Volume** | 0.6 |
| **Loop** | Yes |
| **Speed** | 1.0× normally, 1.1× during sprint, 1.3× during danger |

### Sound Effects

| Trigger | File | Volume |
|---|---|---|
| Countdown beep (3, 2, 1) | `countdown_beep.wav` | 0.8 |
| Countdown GO! | `countdown_go.wav` | 1.0 |
| Footsteps (loop) | `footstep_snow.wav` | 0.5 |
| Sprint whoosh | `sprint_whoosh.wav` | 0.7 |
| Lane switch | `lane_swipe.wav` | 0.4 |
| Jump | `jump.wav` | 0.5 |
| Land | `land_snow.wav` | 0.5 |
| Slide | `slide.wav` | 0.5 |
| Correct answer collected | `correct_chime_big.wav` | 0.9 |
| Wrong answer collected | `wrong_buzz_big.wav` | 0.8 |
| Element added to bar | `element_collected.wav` | 0.7 |
| Patrol getting closer (warning) | `patrol_warning.wav` | 0.6 |
| Caught alarm | `caught_alarm.wav` | 1.0 |
| Timer warning (10s left) | `timer_warning.wav` | 0.7 |
| Finish line cross | `finish_line_chime.wav` | 1.0 |

### Ambient

| File | Volume |
|---|---|
| `wind_outdoor.wav` | 0.4 |

**Source:** Mostly Dustyroom Pack + Pixabay for footsteps and ambient

---

## 🎬 Animations

### Player Animations (Mixamo)

| Animation | When | Loop |
|---|---|---|
| Idle | At start (during countdown) | Yes |
| Run | Default movement | Yes |
| Sprint | After correct answer (3s) | Yes |
| Stumble | After wrong answer (1.5s) | No |
| Jump | On swipe up | No |
| Slide | On swipe down | No |
| Caught | When dangerLevel = 100 | No |
| Victory | At finish line | No |

### Snow Patrol Animations

| Animation | When |
|---|---|
| Walk | Default |
| Stomp (close) | When dangerLevel > 60 |

### Camera Effects

| Effect | When | Settings |
|---|---|---|
| Camera shake | Wrong answer | 0.3s, intensity 0.3 |
| Camera FOV zoom in | Sprint | 60° → 65° (0.3s) |
| Camera FOV zoom out | Slowdown | 60° → 55° (0.3s) |
| Camera zoom on caught | Game over | FOV 60 → 45 (1s) |

### UI Animations

| Element | Animation | When |
|---|---|---|
| Timer | Pulse (scale 1.0 ↔ 1.1) | When < 10s, looped |
| Score popup "+100" | Float up + fade | After correct answer |
| Element collected | Fly to bar + scale bounce | After collection |
| Wrong flash overlay | Red full-screen flash (0.3s) | Wrong answer |
| Correct flash overlay | Green flash (0.2s) | Correct answer |

---

## 🛠️ GameObject Hierarchy & Names

This is the **most complex hierarchy** in the game:

```
Mission3DRunScene
│
├── Main Camera                              [Tag: MainCamera]
│   └── CameraFollow.cs (script)
│
├── Directional Light                        [Tag: Untagged]
│
├── Group_Environment                        [Tag: Untagged]
│   ├── Skybox (or Sky Sphere)
│   ├── Group_Track                          [Tag: Untagged]
│   │   ├── TrackSegment_01                  [Tag: Track]
│   │   ├── TrackSegment_02                  [Tag: Track]
│   │   ├── TrackSegment_03                  [Tag: Track]
│   │   ├── ... (continues to fill 600 units)
│   │   └── TrackSegment_20                  [Tag: Track]
│   ├── Group_Decorations                    [Tag: Untagged]
│   │   ├── Tree_001 to Tree_050             [Tag: Background]
│   │   ├── Mountain_001                     [Tag: Background]
│   │   ├── Mountain_002                     [Tag: Background]
│   │   └── Rock_001 to Rock_020             [Tag: Background]
│   ├── ParticleSystem_SnowFall              [Tag: Untagged]
│   ├── Fog (Unity built-in)
│   └── FinishLine                           [Tag: FinishLine]
│       ├── Image_FinishBanner
│       └── BoxCollider (trigger)
│
├── Group_Checkpoints                        [Tag: Untagged]
│   ├── Checkpoint_01                        [Tag: Checkpoint]
│   │   ├── Card_Answer_A                    [Tag: AnswerCard]
│   │   │   ├── Mesh
│   │   │   ├── BoxCollider (trigger)
│   │   │   ├── Text_AnswerLabel (TMP)
│   │   │   └── AnswerCard.cs
│   │   ├── Card_Answer_B                    [Tag: AnswerCard]
│   │   │   └── (same structure)
│   │   └── Card_Answer_C                    [Tag: AnswerCard]
│   │       └── (same structure)
│   ├── Checkpoint_02                        [Tag: Checkpoint]
│   │   └── (3 answer cards)
│   ├── Checkpoint_03                        [Tag: Checkpoint]
│   ├── Checkpoint_04                        [Tag: Checkpoint]
│   └── Checkpoint_05                        [Tag: Checkpoint]
│
├── Player                                   [Tag: Player] [Layer: Player]
│   ├── Mesh_PlayerCharacter                 (FBX from Mixamo)
│   ├── Animator
│   ├── CharacterController
│   ├── PlayerController.cs
│   ├── LaneSwitcher.cs
│   ├── PlayerInput.cs
│   ├── PlayerAnimator.cs
│   ├── PlayerCollision.cs
│   └── PlayerHealthState.cs
│
├── SnowPatrol                               [Tag: SnowPatrol] [Layer: Patrol]
│   ├── Mesh_PatrolCharacter
│   ├── Animator
│   ├── ParticleSystem_PatrolFog
│   └── SnowPatrolVisual.cs
│
├── Canvas_HUD                               [Tag: UICanvas]
│   ├── Group_TopBar                         [Tag: Untagged]
│   │   ├── Text_Timer                       [Tag: Untagged]
│   │   └── Text_Score                       [Tag: Untagged]
│   ├── Group_ElementsBar                    [Tag: Untagged]
│   │   ├── Text_CollectedLabel
│   │   ├── ElementSlot_01                   [Tag: Untagged]
│   │   │   ├── Image_SlotBg
│   │   │   └── Image_SlotIcon
│   │   ├── ElementSlot_02
│   │   ├── ElementSlot_03
│   │   ├── ElementSlot_04
│   │   └── ElementSlot_05
│   ├── Group_QuestionBanner                 [Tag: Untagged] (hidden by default)
│   │   └── Text_QuestionPrompt
│   ├── Group_PatrolDistance                 [Tag: Untagged]
│   │   └── Text_PatrolDistance
│   ├── Image_CorrectFlash                   (full screen, hidden)
│   ├── Image_WrongFlash                     (full screen, hidden)
│   ├── Group_CountdownOverlay               [Tag: Untagged]
│   │   ├── Text_CountdownNumber
│   │   └── Text_CountdownGo
│   ├── Group_TouchControls                  [Tag: Untagged] (mobile only)
│   │   ├── Button_Left
│   │   ├── Button_Up (jump)
│   │   ├── Button_Right
│   │   └── Button_Down (slide)
│   └── Group_PauseButton                    [Tag: Untagged]
│       └── Button_Pause
│
├── Canvas_CaughtScreen                      [Tag: UICanvas] (hidden by default)
│   ├── Image_DimOverlay
│   ├── Group_CaughtContent
│   │   ├── Image_PatrolIcon
│   │   ├── Text_CaughtTitle ("CAUGHT!")
│   │   ├── Text_CaughtMessage
│   │   ├── Button_RetryMission             [Tag: Untagged]
│   │   └── Button_RereadStory              [Tag: Untagged]
│
├── EventSystem                              [Tag: Untagged] (auto-created)
│
├── Group_Audio                              [Tag: Untagged]
│   ├── AudioSource_Music                    [Tag: AudioMusic]
│   ├── AudioSource_SFX                      [Tag: AudioSFX]
│   ├── AudioSource_Footsteps                [Tag: AudioSFX]
│   ├── AudioSource_Voice                    [Tag: AudioVoice]
│   └── AudioSource_Ambient                  [Tag: AudioAmbient]
│
└── Mission3DRunManager                      [Tag: GameManager]
    ├── MissionManager.cs
    ├── DangerLevel.cs
    ├── MissionTimer.cs
    ├── ElementCollector.cs
    ├── CheckpointSpawner.cs
    └── ScoreTracker.cs
```

### Naming Convention

| Prefix | Type | Example |
|---|---|---|
| `TrackSegment_` | Track piece | `TrackSegment_01` |
| `Tree_`, `Mountain_`, `Rock_` | Decoration | `Tree_001` |
| `Checkpoint_` | Question checkpoint | `Checkpoint_01` |
| `Card_Answer_` | Answer option | `Card_Answer_A` |
| `ElementSlot_` | HUD element slot | `ElementSlot_01` |
| `Mesh_` | 3D mesh container | `Mesh_PlayerCharacter` |
| `Group_` | UI/object container | `Group_Checkpoints` |
| `Canvas_` | UI Canvas | `Canvas_HUD` |
| `Image_`, `Text_`, `Button_` | UI elements | `Text_Timer` |
| `AudioSource_` | Audio source | `AudioSource_Footsteps` |
| `ParticleSystem_` | Particles | `ParticleSystem_SnowFall` |

---

## 🏷️ Tags Used in This Scene

| Tag | GameObjects | Purpose |
|---|---|---|
| `MainCamera` | Main Camera | Built-in |
| `Player` | Player | Identifies player character |
| `AnswerCard` | All Card_Answer_X | Identifies all answer cards |
| `CorrectAnswer` | (set per card at runtime) | Marks correct answer |
| `WrongAnswer` | (set per card at runtime) | Marks wrong answer |
| `Checkpoint` | Checkpoint_01-05 | Identifies checkpoints |
| `Track` | TrackSegment_01-20 | Track ground pieces |
| `Background` | Trees, mountains, rocks | Decoration |
| `SnowPatrol` | SnowPatrol | The chase enemy |
| `FinishLine` | FinishLine | End of track trigger |
| `UICanvas` | Canvas_HUD, Canvas_CaughtScreen | Canvases |
| `GameManager` | Mission3DRunManager | Main controller |
| `AudioMusic` | AudioSource_Music | Music |
| `AudioSFX` | AudioSource_SFX, _Footsteps | Sounds |
| `AudioVoice` | AudioSource_Voice | Voice |
| `AudioAmbient` | AudioSource_Ambient | Wind |

---

## 📚 Layers Used in This Scene

| Layer | Number | GameObjects |
|---|---|---|
| `Default` | 0 | Most things |
| `UI` | 5 | All canvases |
| `Player` | 8 | Player character |
| `Track` | 9 | Track segments |
| `Obstacles` | 10 | Decorative obstacles (rocks, fallen logs) |
| `AnswerCards` | 11 | Answer cards |
| `Patrol` | 12 | Snow Patrol |
| `Background` | 13 | Trees, mountains, distant decorations |

---

## 💻 Scripts Required (THE BIG ONE)

This scene needs **the most scripts** in the game. Each does ONE thing.

### Player Scripts (attached to `Player` GameObject)

#### `PlayerController.cs`
**Location:** `Assets/_Game/Scripts/Player/PlayerController.cs`

**Responsibility:** Forward movement and overall state management

**Inspector Variables:**
```csharp
[Header("Movement")]
public float baseSpeed = 8f;
public float currentSpeed;
public float sprintMultiplier = 1.5f;
public float slowdownMultiplier = 0.6f;

[Header("State")]
public PlayerState currentState; // Normal, Sprinting, Slowed, Caught

[Header("References")]
public CharacterController characterController;
public Animator animator;
public LaneSwitcher laneSwitcher;
```

**Methods:**
```csharp
void Update()                      // Move forward each frame
void StartSprint(float duration)   // Boost speed for X seconds
void StartSlowdown(float duration) // Slow speed for X seconds
void OnCaught()                    // Stop player, trigger caught state
void Reset()                       // Reset to start position
```

#### `LaneSwitcher.cs`
**Location:** `Assets/_Game/Scripts/Player/LaneSwitcher.cs`

**Responsibility:** Smooth lane switching (left/middle/right)

**Inspector Variables:**
```csharp
[Header("Lane Settings")]
public int currentLane = 1;        // 0=left, 1=middle, 2=right
public float laneWidth = 2f;
public float switchDuration = 0.25f;
```

**Methods:**
```csharp
void SwitchLeft()
void SwitchRight()
IEnumerator SmoothSwitchToLane(int targetLane)
```

#### `PlayerInput.cs`
**Location:** `Assets/_Game/Scripts/Player/PlayerInput.cs`

**Responsibility:** Read touch swipes and keyboard input

**Methods:**
```csharp
void Update()
void DetectSwipe()                 // Touch input
void DetectKeyboard()              // Desktop input
void OnSwipeLeft()
void OnSwipeRight()
void OnSwipeUp()
void OnSwipeDown()
```

#### `PlayerAnimator.cs`
**Location:** `Assets/_Game/Scripts/Player/PlayerAnimator.cs`

**Responsibility:** Trigger animations (run, sprint, jump, etc.)

**Methods:**
```csharp
void PlayRun()
void PlaySprint()
void PlayJump()
void PlaySlide()
void PlayStumble()
void PlayCaught()
void PlayVictory()
```

#### `PlayerCollision.cs`
**Location:** `Assets/_Game/Scripts/Player/PlayerCollision.cs`

**Responsibility:** Detect collisions with answer cards, finish line

**Methods:**
```csharp
void OnTriggerEnter(Collider other)
// Detects: AnswerCard, FinishLine
```

### Mission Scripts (attached to `Mission3DRunManager`)

#### `MissionManager.cs`
**Location:** `Assets/_Game/Scripts/Mission/MissionManager.cs`

**Responsibility:** Top-level mission controller — coordinates everything

**Inspector Variables:**
```csharp
[Header("Mission Config")]
public LevelBalanceConfig levelConfig;  // ScriptableObject

[Header("References")]
public PlayerController player;
public DangerLevel dangerLevel;
public MissionTimer missionTimer;
public ElementCollector elementCollector;
public ScoreTracker scoreTracker;
public CheckpointSpawner checkpointSpawner;

[Header("UI")]
public CanvasGroup hudCanvas;
public CanvasGroup caughtCanvas;
public Image correctFlash;
public Image wrongFlash;

[Header("Countdown")]
public TextMeshProUGUI countdownText;
public float countdownDuration = 3f;
```

**Methods:**
```csharp
void Start()                          // Initialize, run countdown
IEnumerator CountdownSequence()       // 3-2-1-GO
void StartMission()                   // Begin running, timer, etc.
void OnCorrectAnswer()                // Sprint, +score, +element green
void OnWrongAnswer()                  // Slowdown, +element red, +danger
void OnCaught()                       // Stop everything, show caught UI
void OnFinishLineReached()            // Slow-mo, save data, transition
void RetryMission()                   // Reset state, start over
void RereadStory()                    // Go back to story reader
void TransitionToFinalSummary()       // Save data, load next scene
```

#### `DangerLevel.cs`
**Location:** `Assets/_Game/Scripts/Mission/DangerLevel.cs`

**Responsibility:** The "fake chase" math — tracks how close to caught

**Inspector Variables:**
```csharp
[Header("Config (from LevelBalance)")]
public int startingDanger = 20;
public int correctReward = -20;
public int wrongPenalty = 15;
public int caughtThreshold = 100;

[Header("Current State")]
public int currentDanger;

[Header("Visual References")]
public SnowPatrolVisual patrolVisual;
public TextMeshProUGUI patrolDistanceText;
```

**Methods:**
```csharp
void Initialize(LevelBalanceConfig config)
void OnCorrect()                     // Decrease danger
void OnWrong()                       // Increase danger
void UpdatePatrolVisual()            // Move snow patrol closer/farther
bool IsCaught()                      // Returns true if >= 100
public event System.Action OnCaughtEvent;
```

#### `MissionTimer.cs`
**Location:** `Assets/_Game/Scripts/Mission/MissionTimer.cs`

**Responsibility:** Countdown timer with visual feedback

**Inspector Variables:**
```csharp
public float startTime = 60f;
public float currentTime;
public TextMeshProUGUI timerText;
public Color normalColor = Color.white;
public Color warningColor = Color.yellow;
public Color dangerColor = Color.red;
```

**Methods:**
```csharp
void StartTimer()
void StopTimer()
void Update()                       // Decrement currentTime
void UpdateDisplay()                // Format and update color
public event System.Action OnTimeUpEvent;
```

#### `ElementCollector.cs`
**Location:** `Assets/_Game/Scripts/Mission/ElementCollector.cs`

**Responsibility:** Track which elements have been collected

**Inspector Variables:**
```csharp
public Image[] elementSlots;        // 5 slots in HUD
public Sprite[] elementIcons;        // 5 correct icons
public List<CollectedElement> collected = new List<CollectedElement>();
```

**Methods:**
```csharp
void CollectElement(int checkpointIndex, AnswerData answer)
void UpdateHUD()
List<CollectedElement> GetCollectedElements()
public class CollectedElement {
    public int checkpointIndex;
    public string answerText;
    public bool isCorrect;
}
```

#### `CheckpointSpawner.cs`
**Location:** `Assets/_Game/Scripts/Mission/CheckpointSpawner.cs`

**Responsibility:** Place 5 checkpoints with answer cards based on story data

**Methods:**
```csharp
void SpawnCheckpoints(StoryData story)  // Place all 5
void SpawnAnswerCardsForCheckpoint(int index, QuestionData q)
```

#### `ScoreTracker.cs`
**Location:** `Assets/_Game/Scripts/Mission/ScoreTracker.cs`

**Responsibility:** Calculate and display score

**Inspector Variables:**
```csharp
public int currentScore = 0;
public int pointsPerCorrect = 100;
public int pointsPerSecond = 5;
public TextMeshProUGUI scoreText;
```

**Methods:**
```csharp
void AddScore(int points)
void UpdateDisplay()
int CalculateFinalScore(float timeRemaining, bool wasCaught, bool perfect)
```

#### `SnowPatrolVisual.cs`
**Location:** `Assets/_Game/Scripts/Mission/SnowPatrolVisual.cs`

**Responsibility:** The fake chase — moves visual patrol closer/farther

**Inspector Variables:**
```csharp
public Transform player;
public float minDistance = 5f;       // When close (danger 100)
public float maxDistance = 30f;      // When far (danger 0)
public float smoothing = 2f;
```

**Methods:**
```csharp
void Update()                        // Lerp to target distance based on danger
void SetDangerLevel(int danger)      // Update target position
void PlayCloseEffect()               // Stomp animation, fog
void PlayFarEffect()                 // Calm animation
```

#### `AnswerCard.cs`
**Location:** `Assets/_Game/Scripts/Mission/AnswerCard.cs`

**Responsibility:** Per-card behavior — collision, visual, data

**Inspector Variables:**
```csharp
public string answerText;
public bool isCorrect;
public int checkpointIndex;
public TextMeshPro labelText;        // 3D text (not UI)
public Renderer cardRenderer;
public BoxCollider triggerCollider;
```

**Methods:**
```csharp
void Initialize(AnswerOption answer, int checkpoint)
void OnCollected()                   // Visual effect, notify mission
void PlayCollectAnimation()
```

### Camera Script

#### `CameraFollow.cs`
**Location:** `Assets/_Game/Scripts/Player/CameraFollow.cs`

**Responsibility:** Follow player smoothly from behind

**Inspector Variables:**
```csharp
public Transform target;             // Player
public Vector3 offset = new Vector3(0, 3, -6);
public float smoothing = 5f;
public float baseFOV = 60f;
public float sprintFOV = 65f;
public float slowdownFOV = 55f;
```

**Methods:**
```csharp
void LateUpdate()                    // Smooth follow
void SetFOV(float targetFOV)         // Lerp camera FOV
void Shake(float duration, float intensity)
```

---

## 📦 Assets Needed

### 3D Assets

| Asset | File Name | Source | Status |
|---|---|---|---|
| Player character model | `player_character.fbx` | Mixamo | ❌ TODO |
| Player animations (8) | Run, Sprint, Jump, Slide, Stumble, Idle, Caught, Victory | Mixamo | ❌ TODO |
| Snow Patrol model | `snow_patrol.fbx` | Mixamo or KayKit | ❌ TODO |
| Snow Patrol walk animation | `patrol_walk.fbx` | Mixamo | ❌ TODO |
| Track segment (snow road) | `snow_road_segment.fbx` | KayKit / Kenney | ❌ TODO |
| Pine tree (snowy) | `pine_tree_snow.fbx` | Quaternius / KayKit | ❌ TODO |
| Mountain background | `mountain_bg.fbx` | Quaternius | ❌ TODO |
| Rock decoration | `rock_snow.fbx` | KayKit | ❌ TODO |
| Answer card 3D mesh | Custom or Quad | Create | ❌ TODO |
| Finish line banner | `finish_banner.fbx` | Create | ❌ TODO |

### Materials

| Material | For | Notes |
|---|---|---|
| `mat_snow_ground.mat` | Track surface | White, slight bumpy normal |
| `mat_pine_tree.mat` | Trees | Green leaves, brown trunk |
| `mat_snow_caps.mat` | Tree snow | White, smooth |
| `mat_mountain.mat` | Mountains | Gray-blue, distant |
| `mat_answer_card.mat` | Cards | White with cyan border |
| `mat_skybox.mat` | Sky | Light blue gradient |

### Audio Assets

(See full list in audio section above — about 15 SFX files)

### UI Assets (HUD)

| Asset | File Name | Source | Status |
|---|---|---|---|
| HUD panel background | `hud_panel_dark.png` | Create | ❌ TODO |
| Element slot background | `slot_bg.png` | Create | ❌ TODO |
| Timer icon | `icon_timer_white.png` | Kenney | ❌ TODO |
| Star icon | `icon_star_yellow.png` | Kenney | ❌ TODO |
| Patrol icon | `icon_snowflake.png` | Kenney | ❌ TODO |
| 5 element icons (per level) | (see GAME_PLAN) | AI generation | ❌ TODO |

---

## ⚙️ Unity Settings

### Camera
- **Type:** Main Camera
- **Projection:** **Perspective** (this is 3D!)
- **FOV:** 60
- **Near plane:** 0.3
- **Far plane:** 200
- **Position:** Behind and above player (set by CameraFollow.cs)

### Lighting
- **Directional Light:** Sun at 45° angle from above
- **Color:** Slightly warm white (`#FFF8E1`)
- **Intensity:** 1.2
- **Shadows:** Soft shadows

### Fog (Important for atmosphere!)
- **Enable Fog:** Yes
- **Fog Color:** `#D5DEE8` (light gray)
- **Fog Mode:** Linear
- **Start:** 50
- **End:** 150

### Quality
- **Mobile preset**
- **Anti-aliasing:** Off (for performance)
- **Shadows:** Hard shadows only
- **Pixel light count:** 1

---

## 🔄 Scene Transitions

### Coming In
- **From:** `05_MissionIntro`
- **Trigger:** Player tapped Start mission
- **Reads:** `currentLevel` from PlayerPrefs
- **Transition in:** Fade in (0.5s) → countdown (3s) → mission starts

### Going Out (3 possible destinations)

**Path 1: Player reaches finish line (success)**
- **To:** `07_FinalSummary`
- **Saves:** mission score, time remaining, collected elements, was caught flag
- **Transition out:** Slow-mo + fade to white (1s)

**Path 2: Timer runs out**
- **To:** `07_FinalSummary` (treated as caught)
- **Behavior:** Same as caught

**Path 3: Player taps Retry (after caught)**
- **Action:** Reset scene state, restart countdown
- **No scene change**

---

## 💾 Data Read/Written

### Read From PlayerPrefs

```csharp
int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
int readingScore = PlayerPrefs.GetInt("readingScore", 0);
```

### Written To PlayerPrefs

```csharp
PlayerPrefs.SetInt("missionScore", currentScore);
PlayerPrefs.SetFloat("timeRemaining", missionTimer.currentTime);
PlayerPrefs.SetInt("wasCaught", wasCaught ? 1 : 0);
PlayerPrefs.SetString("collectedElements", JsonUtility.ToJson(collectedList));
PlayerPrefs.Save();
```

These are read by Scene 07 (Final Summary) and Scene 08 (Victory).

---

## 🎯 Game Logic Flow

### Main Game Loop

```
1. Scene loads
2. Show countdown (3-2-1-GO)
3. Start timer
4. Player runs forward automatically
5. Player approaches checkpoint
6. 3 answer cards spawn (1 correct + 2 wrong)
7. Player swipes to a lane
8. Player collides with selected card
9. Check if correct or wrong:
   - CORRECT:
     - Play correct sound
     - Add element to bar (green)
     - Trigger sprint boost (3s)
     - Add score (+100)
     - dangerLevel -= 15 (or per level)
     - Camera FOV zoom in
   - WRONG:
     - Play wrong sound + screen flash
     - Add element to bar (red)
     - Trigger slowdown (1.5s)
     - dangerLevel += 20 (or per level)
     - Camera shake
     - Patrol visually closer
10. Update HUD
11. Check if dangerLevel >= 100:
    - YES: Show CAUGHT screen, stop everything
    - NO: Continue running
12. Repeat for all 5 checkpoints
13. Cross finish line
14. Save data, transition to Final Summary
```

### Caught Flow

```
1. dangerLevel reaches 100
2. Player animation: caught
3. Camera zoom in (dramatic)
4. Music speeds up (1.3×)
5. Caught alarm plays
6. CAUGHT canvas fades in
7. Wait for player input:
   - Retry: Reset everything, run countdown again
   - Re-read: Load Story Reader scene
```

### Time Up Flow

```
1. timer reaches 0
2. Treated same as caught
3. (Could also have unique "time up" message)
```

---

## ✅ Build Checklist

⚠️ **This is the longest checklist of any scene. Build incrementally.**

### Phase 1: Basic 3D Setup (Day 1)
- [ ] Create `06_Mission3DRun.unity` scene
- [ ] Add to Build Settings as scene index 6
- [ ] Set up perspective camera
- [ ] Add directional light
- [ ] Set up fog
- [ ] Create simple flat ground plane (placeholder track)
- [ ] Add a cube as placeholder player
- [ ] Get player moving forward (PlayerController.cs)

### Phase 2: Player Movement (Day 1-2)
- [ ] Replace cube with Mixamo character
- [ ] Set up Animator with Run animation
- [ ] Implement LaneSwitcher.cs
- [ ] Implement PlayerInput.cs with swipe detection
- [ ] Test lane switching
- [ ] Add Sprint and Slowdown states
- [ ] Add CameraFollow.cs

### Phase 3: Track and Environment (Day 2-3)
- [ ] Import KayKit Forest Pack
- [ ] Replace placeholder track with snow road segments
- [ ] Place 600 units of track (20 segments)
- [ ] Add trees on sides
- [ ] Add mountains in background
- [ ] Add snow particles
- [ ] Set up skybox

### Phase 4: Checkpoints and Answer Cards (Day 3-4)
- [ ] Create AnswerCard prefab (3D card with TextMeshPro)
- [ ] Create Checkpoint prefab (parent for 3 cards)
- [ ] Implement CheckpointSpawner.cs
- [ ] Place 5 checkpoints at correct distances
- [ ] Test card collision detection
- [ ] Implement AnswerCard.cs collection logic

### Phase 5: HUD (Day 4-5)
- [ ] Create Canvas_HUD
- [ ] Build all HUD elements (timer, score, element bar, etc.)
- [ ] Wire up references in MissionManager
- [ ] Implement MissionTimer.cs
- [ ] Implement ScoreTracker.cs
- [ ] Implement ElementCollector.cs

### Phase 6: Game Logic (Day 5-6)
- [ ] Implement DangerLevel.cs
- [ ] Implement MissionManager.cs main loop
- [ ] Wire up correct/wrong answer handling
- [ ] Add visual feedback (flashes, sounds)
- [ ] Test full gameplay loop

### Phase 7: Snow Patrol (Day 6-7)
- [ ] Add Snow Patrol 3D model
- [ ] Implement SnowPatrolVisual.cs (fake chase)
- [ ] Add patrol fog particles
- [ ] Test patrol gets closer when wrong

### Phase 8: Caught Screen (Day 7)
- [ ] Create Canvas_CaughtScreen
- [ ] Implement caught state in MissionManager
- [ ] Wire up Retry and Re-read buttons
- [ ] Test caught flow

### Phase 9: Polish (Day 7-8)
- [ ] Add countdown 3-2-1-GO
- [ ] Add camera shake on wrong
- [ ] Add FOV zoom on sprint/slowdown
- [ ] Add element collection animations
- [ ] Add finish line and slow-mo
- [ ] Test all 3 levels with different configs

### Phase 10: Audio (Day 8)
- [ ] Add background music
- [ ] Add all SFX
- [ ] Add footstep loop
- [ ] Add ambient wind
- [ ] Test music speed changes

### Test
- [ ] Test full mission Level 1 (90s)
- [ ] Test full mission Level 2 (75s)
- [ ] Test full mission Level 3 (60s)
- [ ] Test all correct answers (perfect run)
- [ ] Test all wrong answers (caught)
- [ ] Test mix of correct/wrong
- [ ] Test retry button
- [ ] Test re-read button
- [ ] Test on real Android device
- [ ] Test performance (target: 60fps)

### Final
- [ ] Save scene
- [ ] Commit to Git: "feat: Scene 06 Mission3DRun complete"

---

## 🐛 Common Issues

| Issue | Cause | Solution |
|---|---|---|
| Player falls through track | Missing CharacterController collision | Add CharacterController + collider |
| Lane switching too jerky | No smoothing | Use DOTween or Lerp |
| Camera clips through trees | Near plane too close | Set near plane to 0.5+ |
| Cards spawn in wrong position | Coordinate confusion | Use local positions inside checkpoint |
| Patrol doesn't show | Far from camera, fog hides | Adjust fog distance |
| FPS drops on mobile | Too many trees | Use LOD or reduce count |
| dangerLevel resets between scenes | Not in singleton | Save to PlayerPrefs |
| Audio cuts off | Multiple sources | Use AudioManager |

---

## 💡 Tips

1. **Build incrementally** — Don't try to build everything at once
2. **Use placeholders** — Cube player, flat ground first, then upgrade
3. **Test movement first** — Don't add cards until player runs smoothly
4. **Use Mixamo** — Free, high-quality character animations
5. **Keep tree count low** — 50 max, use LOD groups
6. **Profile on device** — Mobile performance differs from editor
7. **Save the state** — When testing caught, also test resume
8. **Disable shadows on mobile** — Major performance saver

---

## 🎓 Why This Scene Matters

This is **THE GAME**. Everything else is support infrastructure. The 3D run is where players spend 60-70% of their time and where they form their opinion of SummaRace.

If this scene works well, the game succeeds.
If this scene feels janky, nothing else matters.

**Spend 80% of your QA time here.** Polish the run before polishing anything else.

---

## 🚀 Next Scene

When Scene 06 is done (which will take a while!), move to:

**`SCENE_07_FINAL_SUMMARY.md`** — The fix-wrong-answers + type summary task

This will cover:
- Loading collected elements from PlayerPrefs
- Showing fix popups for wrong elements (with timer)
- Text input for typing the summary
- Keyword validation
- Submit button
- Transition to Victory

---

**End of Scene 06 — Mission 3D Run Specification**

> **Remember:** This is the most complex scene. Build it slowly and test often. Don't rush.
