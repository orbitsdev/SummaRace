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

_Add code quality lessons here_

---

## Performance

_Add performance lessons here_
