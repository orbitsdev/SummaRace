# SummaRace — Game Balance Document

> **All the hidden numbers that make the game feel right.** This is your single source of truth for every tunable value in SummaRace. Use these as starting points, then adjust during playtesting.

---

## 🎯 What This Document Is

This document lists every **tunable number** (also called "game balance variables") in SummaRace. These are the values that control:

- How fast things move
- How long things take
- How challenging the game feels
- How rewards and penalties work
- How the difficulty scales between levels

**These numbers are NOT visible to the player** — but they make or break the game's "feel."

---

## 📚 Game Balance Vocabulary

Before diving in, here are the terms you'll see throughout this document:

| Term | Meaning |
|---|---|
| **Game Balance** | The art of making numbers fair and fun |
| **Game Tuning** | The act of adjusting these numbers |
| **Game Feel** | How the numbers make playing feel |
| **Difficulty Curve** | How numbers change from Level 1 → Level 3 |
| **Tunable Parameters** | Variables you can edit in Unity Inspector |
| **Multiplier** | A number that scales another value (e.g., 1.5× speed) |
| **Threshold** | A trigger point (e.g., danger ≥ 100 = caught) |

---

## ⏱️ SECTION 1 — Timing Values

These control how long things take in the game.

### Mission Timer
The total time the player has to finish the run.

| Level | Duration | Why |
|---|---|---|
| Level 1 (Easy) | **90 seconds** | Generous for first-time players |
| Level 2 (Medium) | **75 seconds** | Slightly tighter to add pressure |
| Level 3 (Hard) | **60 seconds** | Real challenge for experienced players |

### Sprint Boost Duration
After picking a correct answer, how long does the speed boost last?

| Level | Duration | Why |
|---|---|---|
| All levels | **3 seconds** | Long enough to feel rewarding |

### Slowdown Duration
After picking a wrong answer, how long is the player slowed?

| Level | Duration | Why |
|---|---|---|
| Level 1 | **1.5 seconds** | Quick recovery |
| Level 2 | **2.0 seconds** | Slightly more punishing |
| Level 3 | **2.5 seconds** | Real consequence |

### Final Task Timer (Fix Wrong Answers)
How long the player has to fix wrong answers in the final summary.

| Level | Duration | Why |
|---|---|---|
| Level 1 | **45 seconds** | Lots of time for first-timers |
| Level 2 | **35 seconds** | Less time |
| Level 3 | **25 seconds** | Tight pressure |

### Scene Transition Times
Loading screens between scenes.

| Transition | Duration |
|---|---|
| Splash → Menu | **2 seconds** |
| Menu → Story | **1.5 seconds** |
| Story → Mission | **2 seconds** (longer to show "tip") |
| Mission → Summary | **1.5 seconds** |
| Summary → Victory | **1 second** |
| Victory → Next Level | **2 seconds** |

### Reading Phase Timing
Story reading scenes.

| Setting | Value |
|---|---|
| Minimum time per page | **3 seconds** (prevents skip-spamming) |
| Question popup delay | **0.5 seconds** after Next button |
| Question feedback display | **2 seconds** before continue |

---

## 🏃 SECTION 2 — Speed Values

How fast things move during the 3D run. All values are in **Unity units per second**.

### Player Speed

| Level | Base Speed | Sprint Multi | Slowdown Multi |
|---|---|---|---|
| Level 1 | **8.0** | **1.5×** (= 12.0) | **0.6×** (= 4.8) |
| Level 2 | **9.0** | **1.5×** (= 13.5) | **0.5×** (= 4.5) |
| Level 3 | **10.0** | **1.5×** (= 15.0) | **0.4×** (= 4.0) |

### Lane Switching
How fast the player moves between left/middle/right lanes.

| Setting | Value |
|---|---|
| Lane switch duration | **0.25 seconds** |
| Lane width (distance between lanes) | **2.0 units** |
| Lane switch animation curve | Ease-out |

### Camera Settings

| Setting | Value |
|---|---|
| Camera distance behind player | **6.0 units** |
| Camera height above player | **3.0 units** |
| Camera follow smoothness | **5.0** (higher = snappier) |
| Camera FOV (field of view) | **60 degrees** |

### Snow Patrol "Visual" Speed
Remember, the patrol doesn't really chase — it's a visual trick. These control how it APPEARS to move.

| Setting | Value | Why |
|---|---|---|
| Patrol "min distance" (looks far) | **30 units** | Safe zone visual |
| Patrol "max distance" (looks close) | **5 units** | Danger zone visual |
| Patrol position smoothing | **2.0** | Smooth visual transitions |

---

## 📏 SECTION 3 — Distance & Track Layout

How long the run is and where things are placed.

### Track Layout
The track is the main 3D environment for the run.

| Setting | Value |
|---|---|
| Total track length | **600 units** (~1 minute at base speed) |
| Number of lanes | **3** (left, middle, right) |
| Track width | **6 units** (3 lanes × 2 units each) |
| Track segment length | **30 units** (for tile-based generation) |

### Checkpoint Placement
The 5 question checkpoints along the track.

| Checkpoint | Distance from start | Element |
|---|---|---|
| 1 | **100 units** | Somebody |
| 2 | **200 units** | Wanted |
| 3 | **325 units** | But |
| 4 | **450 units** | So |
| 5 | **550 units** | Then |

The spacing is slightly uneven so it doesn't feel mechanical.

### Answer Card Positioning
Where the 3 answer cards appear at each checkpoint.

| Setting | Value |
|---|---|
| Card spawn distance ahead of player | **20 units** |
| Card height above ground | **1.5 units** |
| Card collider size | **1.5 × 1.5 × 0.5 units** |
| Card despawn delay (after passing) | **2 seconds** |

### Obstacle Placement (between checkpoints)
Optional decorative obstacles to dodge.

| Setting | Value |
|---|---|
| Obstacles per segment | **1-2** (random) |
| Minimum gap between obstacles | **15 units** |
| Obstacle types | Rocks, fallen logs, snow piles |

---

## ❄️ SECTION 4 — Danger Level (The Fake Chase Math)

This is the most important balance section. The `dangerLevel` variable controls when the player gets "caught."

### Core Variables

| Setting | Value | Range |
|---|---|---|
| `dangerLevel` minimum | **0** | Cannot go below |
| `dangerLevel` maximum | **100** | Triggers caught state |
| `dangerLevel` starting value | varies by level (see below) |

### Starting Danger Per Level

| Level | Starting Value | Why |
|---|---|---|
| Level 1 | **20** | Player feels safe initially |
| Level 2 | **30** | Slightly more pressure |
| Level 3 | **40** | Already half-dangerous |

### Correct Answer Reward
How much `dangerLevel` decreases when player picks correctly.

| Level | Reward Amount |
|---|---|
| Level 1 | **−20** (big reward) |
| Level 2 | **−15** (moderate reward) |
| Level 3 | **−12** (small reward) |

### Wrong Answer Penalty
How much `dangerLevel` increases when player picks wrong.

| Level | Penalty Amount |
|---|---|
| Level 1 | **+15** (mild punishment) |
| Level 2 | **+20** (moderate punishment) |
| Level 3 | **+25** (heavy punishment) |

### Caught Threshold
When `dangerLevel` reaches this, the player is caught and must restart the mission.

| Setting | Value |
|---|---|
| Caught threshold | **100** |

### Passive Danger Increase
Optional: should `dangerLevel` slowly increase even when nothing happens?

| Setting | Value | Why |
|---|---|---|
| Passive increase rate | **0** per second | KEEP AT ZERO for kids — too punishing |

### Example Scenarios

**Best case (Level 1) — perfect player:**
```
Start: dangerLevel = 20
Q1 ✓: -20 → 0 (capped at 0)
Q2 ✓: -20 → 0
Q3 ✓: -20 → 0
Q4 ✓: -20 → 0
Q5 ✓: -20 → 0
Result: NEVER caught, easy finish ✅
```

**Worst case (Level 1) — all wrong:**
```
Start: dangerLevel = 20
Q1 ✗: +15 → 35
Q2 ✗: +15 → 50
Q3 ✗: +15 → 65
Q4 ✗: +15 → 80
Q5 ✗: +15 → 95
Result: NOT caught (under 100), barely makes it ⚠️
```

**Worst case (Level 3) — all wrong:**
```
Start: dangerLevel = 40
Q1 ✗: +25 → 65
Q2 ✗: +25 → 90
Q3 ✗: +25 → 100 → CAUGHT! ❌
```

This means in Level 3, you can only afford **2 wrong answers** before being caught. That's the difficulty curve in action.

---

## ⭐ SECTION 5 — Scoring & Stars

How the player earns points and stars.

### Point Values

| Action | Points |
|---|---|
| Correct reading question (per page) | **20** |
| Wrong reading question | **0** (no penalty) |
| Correct mission element (per checkpoint) | **100** |
| Wrong mission element (collected anyway) | **0** |
| Time bonus (per second remaining) | **5** |
| Finish without getting caught | **50** (one-time bonus) |
| Perfect summary (no fixes needed) | **100** (one-time bonus) |

### Maximum Possible Score

For Level 1 with 90s timer:
```
Reading questions: 5 × 20 = 100 points
Mission elements: 5 × 100 = 500 points
Time bonus: ~30s remaining × 5 = 150 points
Finish bonus: 50 points
Perfect bonus: 100 points
─────────────────────────
TOTAL: 900 points (perfect run)
```

### Star Calculation

| Stars | Score Required | What It Means |
|---|---|---|
| ⭐⭐⭐ (3 stars) | **750+** points | Excellent! Almost perfect |
| ⭐⭐ (2 stars) | **500–749** points | Good job, keep practicing |
| ⭐ (1 star) | **250–499** points | You finished, that's what matters |
| 💫 (0 stars) | **< 250** points | (player can't get here if they finished) |

### Star Display
| Setting | Value |
|---|---|
| Stars to unlock next level | **1 star** |
| Stars to unlock bonus content | **3 stars** all levels |

---

## 🎮 SECTION 6 — Input & Controls

How the player interacts with the game.

### Touch (Mobile)

| Setting | Value |
|---|---|
| Swipe minimum distance | **50 pixels** |
| Swipe maximum time | **0.5 seconds** |
| Tap maximum distance | **10 pixels** (otherwise it's a swipe) |
| Tap maximum time | **0.3 seconds** |
| Lane switch swipe direction | Left/Right (horizontal swipe) |
| Jump action | Swipe Up |
| Slide action | Swipe Down |

### Keyboard (Desktop)

| Action | Key |
|---|---|
| Move left | **A** or **Left Arrow** |
| Move right | **D** or **Right Arrow** |
| Jump | **Space** or **Up Arrow** |
| Slide | **S** or **Down Arrow** |
| Pause | **Esc** or **P** |

### UI Button Sizes (kid-friendly)

| Element | Size |
|---|---|
| Main action buttons | **80 × 80 pixels** minimum |
| Secondary buttons | **60 × 60 pixels** minimum |
| Touch target padding | **20 pixels** around interactive elements |

---

## 🎨 SECTION 7 — Animation Timings

How long animations take to play.

### UI Animations

| Animation | Duration |
|---|---|
| Button press feedback | **0.1 seconds** |
| Scene fade in/out | **0.5 seconds** |
| Speech bubble appear | **0.4 seconds** |
| Star earned animation | **0.8 seconds** |
| Level complete celebration | **2.5 seconds** |

### Gameplay Animations

| Animation | Duration |
|---|---|
| Player jump | **0.5 seconds** |
| Player slide | **0.6 seconds** |
| Player lane switch | **0.25 seconds** |
| Element collected pop | **0.3 seconds** |
| Sprint boost trail effect | **3 seconds** (matches sprint duration) |
| Wrong answer red flash | **0.4 seconds** |
| Patrol "close" zoom | **1 second** |

### Camera Effects

| Effect | Value |
|---|---|
| Camera shake on wrong | **0.2 seconds**, **0.3 intensity** |
| Camera zoom on caught | **1.5 seconds**, zoom from 60° to 45° FOV |

---

## 🔊 SECTION 8 — Audio Levels

Default audio settings.

### Volume Levels (0.0 to 1.0)

| Audio Type | Default Volume |
|---|---|
| Master volume | **1.0** (100%) |
| Background music | **0.6** (60%) |
| Sound effects | **0.8** (80%) |
| Voice narration | **1.0** (100%) — most important |
| UI sounds | **0.7** (70%) |

### Audio Behavior

| Setting | Value |
|---|---|
| Music fade between scenes | **1 second** |
| Music volume during narration | **0.3** (auto-duck) |
| Sprint boost music speed | **1.1×** (slightly faster) |
| Caught music speed | **1.3×** (intense) |

---

## 💾 SECTION 9 — Save Data

What gets saved between sessions.

### Player Profile
| Key | Type | Default |
|---|---|---|
| `playerName` | string | "" |
| `selectedAvatar` | int (0-3) | 0 |
| `firstLaunch` | bool | true |
| `totalPlayTime` | float | 0 |

### Progress
| Key | Type | Default |
|---|---|---|
| `level1Stars` | int (0-3) | 0 |
| `level2Stars` | int (0-3) | 0 |
| `level3Stars` | int (0-3) | 0 |
| `level2Unlocked` | bool | false |
| `level3Unlocked` | bool | false |
| `gameCompleted` | bool | false |

### High Scores
| Key | Type | Default |
|---|---|---|
| `level1BestScore` | int | 0 |
| `level2BestScore` | int | 0 |
| `level3BestScore` | int | 0 |
| `level1BestTime` | float | 999 |
| `level2BestTime` | float | 999 |
| `level3BestTime` | float | 999 |

### Settings
| Key | Type | Default |
|---|---|---|
| `musicVolume` | float (0-1) | 0.6 |
| `sfxVolume` | float (0-1) | 0.8 |
| `narrationEnabled` | bool | true |
| `screenShake` | bool | true |
| `language` | string | "en" |

---

## 📊 SECTION 10 — Difficulty Curve Summary

How the 3 levels progress in difficulty.

### Quick Comparison Table

| Setting | Level 1 | Level 2 | Level 3 |
|---|---|---|---|
| Mission timer | 90s | 75s | 60s |
| Player speed | 8 | 9 | 10 |
| Slowdown multiplier | 0.6× | 0.5× | 0.4× |
| Slowdown duration | 1.5s | 2.0s | 2.5s |
| Starting danger | 20 | 30 | 40 |
| Correct reward | −20 | −15 | −12 |
| Wrong penalty | +15 | +20 | +25 |
| Wrong answers before caught | ~6 | ~4 | ~3 |
| Fix popup time | 45s | 35s | 25s |

### The Difficulty Story

- **Level 1** is meant to feel **forgiving and welcoming**. A player who pays attention can get caught only by being really careless. Even bad players will probably finish.
- **Level 2** introduces **real pressure**. Players who guess will struggle. Players who read carefully will succeed.
- **Level 3** is for **mastery**. Players need to apply the Somebody-Wanted-But-So-Then framework reliably. Mistakes have real consequences.

This curve teaches kids that **paying attention pays off**.

---

## 🧪 SECTION 11 — Playtesting Adjustments

These are signs that you need to adjust numbers, and what to change.

### "The game is too hard"
**Symptoms:** Players get caught often, never finish, give up
**Adjust:**
- ↑ Increase mission timer
- ↑ Increase correct answer reward (make it more negative, e.g., −15 → −20)
- ↓ Decrease wrong answer penalty
- ↓ Decrease starting dangerLevel
- ↑ Increase fix popup time

### "The game is too easy"
**Symptoms:** Players never get caught, finish quickly, get bored
**Adjust:**
- ↓ Decrease mission timer
- ↓ Decrease correct answer reward (make it less negative)
- ↑ Increase wrong answer penalty
- ↑ Increase starting dangerLevel

### "The game is too fast"
**Symptoms:** Players panic, can't read answer cards in time
**Adjust:**
- ↓ Decrease player base speed
- ↑ Increase distance between checkpoints
- ↑ Increase card spawn distance ahead of player

### "The game is too slow"
**Symptoms:** Players get bored between checkpoints
**Adjust:**
- ↑ Increase player base speed
- ↓ Decrease distance between checkpoints
- ↓ Decrease total track length

### "Wrong answers feel unfair"
**Symptoms:** Players think the slowdown is too punishing
**Adjust:**
- ↓ Decrease slowdown duration
- ↑ Increase slowdown multiplier (e.g., 0.5× → 0.7×)
- ↓ Decrease wrong answer penalty

### "Stars feel impossible to earn"
**Symptoms:** Players never get 3 stars
**Adjust:**
- ↓ Decrease star score thresholds (e.g., 750 → 600)
- ↑ Increase point values for actions

---

## 🎯 SECTION 12 — Quick Reference Card

Print this and stick it near your computer while developing.

### Critical Numbers (Memorize These)

```
MISSION DURATION:
  L1 = 90s    L2 = 75s    L3 = 60s

PLAYER SPEED:
  L1 = 8.0    L2 = 9.0    L3 = 10.0
  Sprint = ×1.5    Slowdown = ×0.6/0.5/0.4

DANGER LEVEL:
  Start: L1=20  L2=30  L3=40
  Correct: L1=-20  L2=-15  L3=-12
  Wrong:   L1=+15  L2=+20  L3=+25
  Caught at: 100

TRACK:
  Length = 600 units
  Lanes = 3 (2 units wide)
  Checkpoints at: 100, 200, 325, 450, 550

SCORING:
  Reading Q = 20 points
  Mission element = 100 points
  Time bonus = 5/sec
  Stars: 1⭐=250+  2⭐=500+  3⭐=750+
```

---

## 🔧 SECTION 13 — How to Use This in Unity

### Step 1: Create a ScriptableObject
Make a `LevelBalanceConfig.cs` ScriptableObject with all these values exposed in the Inspector.

```csharp
[CreateAssetMenu(fileName = "LevelBalance", menuName = "SummaRace/Level Balance")]
public class LevelBalanceConfig : ScriptableObject
{
    [Header("Timing")]
    public float missionDuration = 90f;
    public float sprintBoostDuration = 3f;
    public float slowdownDuration = 1.5f;
    public float fixWrongAnswerTime = 45f;

    [Header("Speed")]
    public float playerBaseSpeed = 8f;
    public float sprintMultiplier = 1.5f;
    public float slowdownMultiplier = 0.6f;

    [Header("Danger Level")]
    public int startingDanger = 20;
    public int correctAnswerReward = -20;
    public int wrongAnswerPenalty = 15;
    public int caughtThreshold = 100;

    [Header("Track")]
    public float trackLength = 600f;
    public float[] checkpointPositions = { 100, 200, 325, 450, 550 };

    [Header("Scoring")]
    public int pointsPerReadingQuestion = 20;
    public int pointsPerMissionElement = 100;
    public int pointsPerSecondRemaining = 5;
    public int finishBonus = 50;
    public int perfectBonus = 100;
    public int oneStarThreshold = 250;
    public int twoStarThreshold = 500;
    public int threeStarThreshold = 750;
}
```

### Step 2: Create 3 Asset Instances
- `Level1_Easy.asset` (use L1 values)
- `Level2_Medium.asset` (use L2 values)
- `Level3_Hard.asset` (use L3 values)

### Step 3: Reference in MissionManager
The `MissionManager` script loads the appropriate config when the level starts.

### Step 4: Tune in the Inspector
While playtesting, you can change any value in real-time without recompiling code. This is the magic of ScriptableObjects.

---

## 📝 Important Notes

1. **These are STARTING values, not final.** Every successful game tunes its numbers through playtesting.

2. **Test with REAL kids, not adults.** Adults will find this game way too easy. Kids will tell you what's actually hard.

3. **Change ONE number at a time** during playtesting. If you change 5 things, you don't know which one made the difference.

4. **Keep a tuning journal.** When you change a number, write down: old value, new value, why, and how it felt.

5. **Don't aim for perfection.** "Good enough" is fine for an MVP. You can patch numbers in v1.1.

6. **Trust kids' reactions over their words.** A kid who says "it's fine" but stops playing after one level is telling you something.

---

## 🎓 Glossary

| Term | Definition |
|---|---|
| **Tunable parameter** | A number you can change to adjust how the game feels |
| **Multiplier** | A number that scales another (e.g., 1.5× speed = 50% faster) |
| **Threshold** | A trigger point (e.g., dangerLevel = 100 → caught) |
| **Difficulty curve** | How hard the game gets over time |
| **Game feel** | The subjective sense of how the game plays |
| **Pacing** | How fast or slow events happen |
| **Iteration** | One round of "build → test → adjust → repeat" |
| **Playtesting** | Watching real people play to find problems |
| **MVP** | Minimum Viable Product — the simplest version that works |
| **ScriptableObject** | Unity's way to store data assets you can edit in the Inspector |

---

**End of Game Balance Document v1.0**

> **Remember:** These are starting values. You'll change them during playtesting. That's normal and expected. The goal isn't to guess perfect numbers — it's to build a system where you can easily adjust them.
