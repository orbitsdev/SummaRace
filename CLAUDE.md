# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

---

## Approach

- Think before acting. Read existing files before writing code.
- Be concise in output but thorough in reasoning.
- Prefer editing over rewriting whole files.
- Do not re-read files you have already read unless the file may have changed.
- Test your code before declaring done.
- No sycophantic openers or closing fluff.
- Keep solutions simple and direct.
- User instructions always override this file.

---

## Token-Saving Rules

For repetitive Unity tasks (creating scenes, folders, GameObjects, prefabs), **guide the user instead of using MCP tools**:
1. Tell the user what to create and how to name it
2. Provide step-by-step Unity Editor instructions
3. Only use MCP tools when automation is truly faster (bulk operations, complex scripts)

**Ask user to do manually:**
- Creating individual scenes, folders, or empty GameObjects
- Renaming assets
- Simple drag-and-drop operations
- Import settings

**Use MCP tools for:**
- Writing/updating C# scripts
- Complex component configurations
- Bulk operations (10+ items)
- Querying project state

---

## Development Principles

### 1. Plan Mode Default
- Enter plan mode for ANY non-trivial task (3+ steps or architectural decisions)
- If something goes sideways, STOP and re-plan immediately
- Use plan mode for verification steps, not just building
- Write detailed specs upfront to reduce ambiguity

### 2. Subagent Strategy
- Use subagents liberally to keep main context window clean
- Offload research, exploration, and parallel analysis to subagents
- For complex problems, throw more compute at it via subagents
- One task per subagent for focused execution

### 3. Self-Improvement Loop
- After ANY correction from the user: update `tasks/lessons.md` with the pattern
- Write rules for yourself that prevent the same mistake
- Ruthlessly iterate on these lessons until mistake rate drops
- Review lessons at session start for relevant project

### 4. Verification Before Done
- Never mark a task complete without proving it works
- Ask yourself: "Would a staff engineer approve this?"
- Run tests, check logs, demonstrate correctness

### 5. Demand Elegance (Balanced)
- For non-trivial changes: pause and ask "is there a more elegant way?"
- If a fix feels hacky: "Knowing everything I know now, implement the elegant solution"
- Skip this for simple, obvious fixes – don't over-engineer
- Challenge your own work before presenting it

### 6. Autonomous Bug Fixing
- When given a bug report: just fix it. Don't ask for hand-holding
- Point at logs, errors, failing tests – then resolve them
- Zero context switching required from the user

---

## Task Management

1. **Plan First**: Write plan to `tasks/todo.md` with checkable items
2. **Verify Plan**: Check in before starting implementation
3. **Track Progress**: Mark items complete as you go
4. **Explain Changes**: High-level summary at each step
5. **Document Results**: Add review section to `tasks/todo.md`
6. **Capture Lessons**: Update `tasks/lessons.md` after corrections

---

## Core Principles

- **Simplicity First**: Make every change as simple as possible. Impact minimal code.
- **No Laziness**: Find root causes. No temporary fixes. Senior developer standards.

---

## Project Overview

SummaRace is an educational endless runner game built in Unity that teaches kids (grades 2-4) how to summarize stories using the Somebody-Wanted-But-So-Then framework. Players read a story, then run through a 3D snowy track collecting story elements while being chased by the Snow Patrol.

**Engine:** Unity 6000.4.1f1 (Unity 6) with Universal Render Pipeline (URP)
**Platform:** Android (mobile/tablet first)
**Language:** C#

## Build Commands

```bash
# Open project in Unity (must have Unity Hub installed)
# Unity version: 6000.4.1f1

# Build for Android via command line
Unity -batchmode -projectPath . -buildTarget Android -executeMethod BuildScript.BuildAndroid -quit

# Run tests
Unity -batchmode -projectPath . -runTests -testPlatform PlayMode -quit
```

## Architecture

### Game Flow (10 Scenes)
1. `00_Splash` - Title screen
2. `01_NameEntry` - Player name + avatar selection
3. `02_TeacherWelcome` - Ms. Lumi introduction
4. `03_LevelSelect` - Choose story (1, 2, or 3)
5. `04_StoryReader` - Read story pages with comprehension questions
6. `05_MissionIntro` - Mission briefing
7. `06_Mission3DRun` - Core 3D endless runner gameplay
8. `07_FinalSummary` - Type summary from collected elements
9. `08_Victory` - Stars and level unlock
10. `99_GameComplete` - Final celebration

### Core Systems

**"Fake Chase" System:** The Snow Patrol enemy is visual-only. A `dangerLevel` integer controls its apparent distance. Correct answers decrease it; wrong answers increase it. At max, player is "caught."

**Story Data:** Stories are JSON files in `Assets/_Game/Resources/Stories/`. Each contains 5 pages with questions and 5 mission elements (Somebody, Wanted, But, So, Then).

### Folder Structure
```
Assets/_Game/           # Main game code (underscore keeps it at top)
  Scripts/
    Core/               # Singletons: GameManager, SaveManager, AudioManager
    Data/               # StoryData, PageData, QuestionData models
    Player/             # PlayerController, LaneSwitcher, PlayerInput
    Mission/            # MissionManager, DangerLevel, CheckpointSpawner
    UI/                 # One UI controller per scene
  Scenes/               # All .unity scene files
  Prefabs/              # Reusable game objects
  Resources/Stories/    # JSON story files (runtime-loaded)
Assets/Art/             # 2D and 3D visual assets
Assets/Audio/           # Music, SFX, voice narration
Assets/Plugins/         # Third-party assets (DOTween, etc.)
```

### Key Scripts to Implement
- `GameManager.cs` - Singleton tracking current level and progress
- `SaveManager.cs` - PlayerPrefs wrapper for save/load
- `DangerLevel.cs` - The fake chase variable system
- `PlayerController.cs` - Forward movement, lane switching, sprint/slowdown
- `CheckpointSpawner.cs` - Spawns 5 question checkpoints with answer cards
- `StoryLoader.cs` - Loads JSON story files into StoryData objects

## Naming Conventions

| Type | Convention | Example |
|------|------------|---------|
| Scripts | PascalCase | `PlayerController.cs` |
| Scenes | NumberPrefix_PascalCase | `06_Mission3DRun.unity` |
| Materials | snake_case_mat | `snow_ground_mat.mat` |
| Private vars | _camelCase | `_currentSpeed` |
| Public vars | camelCase | `playerSpeed` |
| Constants | UPPER_SNAKE | `MAX_DANGER_LEVEL` |

## Design Principles

1. **Never block progress** - Wrong answers always proceed
2. **Always show correct answer** - Learning continues even on mistakes
3. **No harsh feedback** - Use "Not quite!" instead of "Wrong!"
4. **Sam test** - Would an 8-year-old love this?
5. **Polish over scope** - Ship 2 polished levels rather than 3 broken ones

## Unity Best Practices

### Architecture
- **Composition over inheritance** - Prefer component-based design
- **ScriptableObjects for data** - Use for game config, story data, tuning values
- **Interfaces for polymorphism** - Define clear contracts between systems
- **Assembly definitions** - Use .asmdef files for faster compilation

### C# Standards
- **No `Find()` or `FindObjectOfType()`** - Cache references in Awake/Start or use dependency injection
- **Use `[SerializeField] private`** - Keep fields private, expose in Inspector when needed
- **Cache component references** - Never call GetComponent in Update loops
- **Frame-rate independence** - Use `Time.deltaTime` for all time-dependent calculations

### Memory & Performance
- **Zero allocations in hot paths** - No `new` in Update, use object pooling
- **Use NonAlloc APIs** - `Physics.RaycastNonAlloc()`, etc.
- **Profile before optimizing** - Use Unity Profiler to find actual bottlenecks
- **Target 30fps minimum** on mid-range Android devices

### Assets & Resources
- **Addressables over Resources.Load()** - Better memory management (for future scaling)
- **Sprite atlases** - Combine UI sprites to reduce draw calls
- **Per-platform import settings** - Compress textures appropriately for mobile

### UI & Input
- **New Input System** - Already included in project, use over legacy Input class
- **UI Toolkit or UGUI** - Consistent UI patterns across scenes
- **Events over polling** - Use UnityEvents or C# events for UI communication

### Rendering (URP)
- **GPU instancing** - Enable for repeated objects (trees, obstacles)
- **Baked lighting** - Pre-bake where possible for mobile performance
- **LOD groups** - Use for 3D models visible at varying distances

## Gameplay Code Rules

- **Data-driven values** - All gameplay values from ScriptableObjects or JSON, never hardcoded
- **State machines** - Use explicit states with documented transitions for player/game states
- **No direct UI references** - Use events/signals for cross-system communication
- **Separate logic from presentation** - Keep game logic testable and independent of visuals
