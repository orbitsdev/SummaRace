# Lessons Learned

Rules and patterns to prevent repeated mistakes.

---

## Session 1 (2026-04-08)

### Git Setup
- **Lesson**: Always create `.gitignore` BEFORE first commit
- **Pattern**: Unity projects generate 20,000+ files in Library/ – never commit these
- **Fix**: Use standard Unity .gitignore template

### MCP Connection
- **Lesson**: Restart Claude Code after configuring MCP in Unity
- **Pattern**: MCP tools won't appear until restart

---

## Unity-Specific

### Reusability Design (Good Pattern)
- **One scene, multiple levels**: Use single Mission scene + JSON data for all levels
- **Prefab everything reused 2+ times**: Teacher, buttons, dialogs, effects
- **Core singletons**: GameManager, SaveManager, AudioManager persist across scenes
- **ScriptableObjects for balance**: No hardcoded values, designers can tweak in Inspector
- **Shared UI folder**: Common buttons, panels, overlays in `Prefabs/UI/Common/`

---

## Code Quality

### Data Persistence (Unity vs Backend)
- **No database needed** for simple offline games
- **PlayerPrefs** = like SharedPreferences (key-value storage)
- **JSON files** = for complex nested data
- **SQLite** = overkill unless thousands of records
- SummaRace uses PlayerPrefs (~10 key-value pairs)

---

## Performance

_Add performance lessons here_

---

## Before Manual Work, Check for Unity Tools

### Always Search First
- **Lesson**: Before implementing features manually, check for free Unity packages
- **Pattern**: Unity has many free tools that save dev time
- **Free essentials**:
  - `com.unity.cinemachine` - Camera shake, follow, transitions (FREE)
  - `com.unity.inputsystem` - Modern input handling (FREE, already installed)
  - `com.unity.textmeshpro` - Better text rendering (FREE, often bundled)
  - `com.unity.2d.animation` - 2D skeletal animation (FREE, already installed)
  - DOTween - Tweening library (FREE on Asset Store)
- **Ask Claude**: "Is there a free Unity package for [feature]?" before coding from scratch
