# SummaRace — Documentation Index

> **Your table of contents for the entire SummaRace project.** Start here to find any information about the game.

---

## 📚 All Documents (in recommended reading order)

### 1. 📖 README.md — Start Here
**What it is:** Quick project overview
**Read first if you:** Are new to the project, want a 5-minute summary
**Contains:**
- What SummaRace is (one paragraph)
- Tech stack (Unity, C#, etc.)
- Quick start guide
- Links to all other docs

---

### 2. 📋 SUMMARACE_GAME_PLAN.md — The Master Plan
**What it is:** Complete game design document
**Read second if you:** Want to understand the full game design
**Contains:**
- Game concept and educational goals
- Target audience (Grades 2–4) and player persona
- Full 10-scene flow
- All 3 stories with pages, questions, and answer tables
- Technical architecture (camera + fake chase system)
- 14-day development plan
- Scoring system
- Risk mitigations
- 15 sections in total

**Use this as:** Your single source of truth for "what the game is"

---

### 3. 🎨 SUMMARACE_GAME_FLOW.svg — Visual Mockup
**What it is:** Downloadable visual diagram of all scenes
**Read after:** You've read the Game Plan
**Contains (3 sections):**
- **Section 1:** Main flow scenes 1–10 (visual mockups)
- **Section 2:** Hidden scenes A–F (loading, correct, wrong, caught, fix, confirmation)
- **Section 3:** The 3 stories with elements
- Plus a complete branching flowchart and legend

**Use this for:** Showing the game to others, visualizing the flow

---

### 4. 🛒 SUMMARACE_ASSET_CHECKLIST.md — Asset Shopping List
**What it is:** Where to download every asset you need
**Read when:** You're ready to gather assets (before coding)
**Contains:**
- Sign-up checklist for Unity Asset Store, Mixamo, Sketchfab, Pixabay
- 16 sections covering every asset category
- Real verified links with licenses
- The "no thanks" itch.io trick
- Top 5 sources to bookmark
- Recommended download order (2-day plan)
- Free vs paid options
- Commercial use clarifications

**Use this as:** Your day 1-2 prep document before coding

---

### 5. 🏗️ SUMMARACE_FOLDER_STRUCTURE.md — Unity Project Setup
**What it is:** Complete Unity folder structure and naming conventions
**Read when:** You're setting up the Unity project
**Contains:**
- Full folder tree (Scripts, Art, Audio, etc.)
- Naming conventions (PascalCase, snake_case, etc.)
- .gitignore template
- 14 key scripts explained in priority order
- Recommended free Unity plugins
- Art import settings
- Android build settings
- Day 1 setup checklist

**Use this as:** Your reference when creating folders and naming files in Unity

---

### 6. ⚖️ SUMMARACE_GAME_BALANCE.md — All Tunable Numbers ⭐ NEW
**What it is:** Every number that controls how the game feels
**Read when:** You're about to start coding gameplay
**Contains (13 sections):**
- Game balance vocabulary
- Timing values (mission timer, sprints, slowdowns)
- Speed values (player, sprint multipliers)
- Distance & track layout
- Danger Level math (the fake chase formula)
- Scoring & stars
- Input & controls
- Animation timings
- Audio levels
- Save data structure
- Difficulty curve summary
- Playtesting adjustments (what to change when X happens)
- Quick reference card
- How to use in Unity (ScriptableObject example)

**Use this as:** Your reference for every "magic number" while coding

---

## 🗂️ Quick "Where Is It?" Index

Need to find something specific? Use this lookup table.

### Stories & Content
| Looking for... | Document | Section |
|---|---|---|
| The 3 stories (pages, questions) | GAME_PLAN | Section: "The 3 Stories" |
| Distractors and correct answers | GAME_PLAN | Story tables |
| Story illustrations needed | ASSET_CHECKLIST | Part 8 |
| Story page narration scripts | GAME_PLAN | Per story section |

### Game Mechanics
| Looking for... | Document | Section |
|---|---|---|
| What happens when correct/wrong | GAME_FLOW.svg | Section 2, scenes B/C |
| What happens when caught | GAME_FLOW.svg | Section 2, scene D |
| The "fake chase" technical design | GAME_PLAN | Section: "Technical Architecture" |
| Danger Level formula | GAME_BALANCE | Section 4 |
| Scoring formula | GAME_BALANCE | Section 5 |
| Star calculation | GAME_BALANCE | Section 5 |

### Visual Design
| Looking for... | Document | Section |
|---|---|---|
| Scene layouts | GAME_FLOW.svg | Section 1 |
| Color scheme | GAME_FLOW.svg | Throughout |
| UI button sizes | GAME_BALANCE | Section 6 |
| Animation timings | GAME_BALANCE | Section 7 |

### Development
| Looking for... | Document | Section |
|---|---|---|
| Folder structure | FOLDER_STRUCTURE | Top section |
| Naming conventions | FOLDER_STRUCTURE | Naming Conventions |
| Day-by-day plan | GAME_PLAN | Section 9 |
| Day 1 setup steps | FOLDER_STRUCTURE | Day 1 Setup Checklist |
| Required scripts | FOLDER_STRUCTURE | Key Scripts Explained |
| ScriptableObject example | GAME_BALANCE | Section 13 |

### Assets & Downloads
| Looking for... | Document | Section |
|---|---|---|
| Where to get free 3D models | ASSET_CHECKLIST | Parts 2–4 |
| Free sound effects | ASSET_CHECKLIST | Part 9 |
| Free music | ASSET_CHECKLIST | Part 10 |
| Free fonts | ASSET_CHECKLIST | Part 12 |
| Endless runner template | ASSET_CHECKLIST | Part 1 |
| KayKit Forest Pack info | ASSET_CHECKLIST | Part 2 |
| The "no thanks" itch.io trick | ASSET_CHECKLIST | Part on itch.io |
| Commercial use rules | ASSET_CHECKLIST | Bottom section |

### Player Experience
| Looking for... | Document | Section |
|---|---|---|
| Target audience | GAME_PLAN | Section 2 |
| Player persona "Sam" | GAME_PLAN | Section 2 |
| Reading questions | GAME_PLAN | Per story |
| Mission elements | GAME_PLAN | Per story |
| Final summary task | GAME_PLAN | Scene 9 |

---

## 🎯 Reading Paths by Goal

Different paths through the docs based on what you want to do.

### "I want to understand the game"
1. README.md (5 min)
2. SUMMARACE_GAME_FLOW.svg (10 min)
3. SUMMARACE_GAME_PLAN.md (30 min)

### "I want to start coding TODAY"
1. SUMMARACE_FOLDER_STRUCTURE.md → Day 1 Setup (15 min)
2. SUMMARACE_GAME_BALANCE.md → Section 13 (5 min)
3. Open Unity, start building scene 1

### "I need to gather assets first"
1. SUMMARACE_ASSET_CHECKLIST.md → Top 5 sites (5 min)
2. SUMMARACE_ASSET_CHECKLIST.md → Recommended download order (5 min)
3. Spend 1-2 days downloading

### "I need to balance the difficulty"
1. SUMMARACE_GAME_BALANCE.md → Section 12 Quick Reference (5 min)
2. SUMMARACE_GAME_BALANCE.md → Section 11 Playtesting Adjustments (10 min)
3. Apply to your code

### "I want to add a new feature"
1. SUMMARACE_GAME_PLAN.md → Section 13 Future Enhancements (5 min)
2. Discuss with Claude

---

## 🚨 What's NOT Yet Documented (Gaps)

These topics have been discussed in chat but aren't yet in any document. Consider adding them:

### Potentially needed docs
- [ ] **SUMMARACE_TECHNICAL_SPEC.md** — C# class diagrams, data flows
- [ ] **SUMMARACE_AUDIO_DESIGN.md** — When each sound plays, music transitions
- [ ] **SUMMARACE_ACCESSIBILITY.md** — Color blind mode, slower speed, etc.
- [ ] **SUMMARACE_PLAYTESTING_NOTES.md** — Track playtest results over time
- [ ] **SUMMARACE_BUG_TRACKER.md** — Known issues during development
- [ ] **SUMMARACE_RELEASE_NOTES.md** — What changed between versions

### Topics in chat but not in files
- The 6 hidden scenes details (loading, correct, wrong, caught, fix, confirmation) — these ARE in the SVG but not in markdown
- Itch.io "no thanks" trick — partially in checklist
- KayKit Forest Pack details — in checklist
- Commercial use clarifications — in checklist
- The discussion about "what's missing in the design"

**Recommendation:** When this chat ends, important info that's only in the conversation will be lost. If something matters, ask Claude to add it to the appropriate document.

---

## 📊 Document Status

| Document | Status | Last Updated | Notes |
|---|---|---|---|
| README.md | ✅ Complete | v1.0 | Project overview |
| SUMMARACE_GAME_PLAN.md | ✅ Complete | v1.0 | Master plan |
| SUMMARACE_GAME_FLOW.svg | ✅ Complete | v2.0 | All scenes incl. hidden |
| SUMMARACE_ASSET_CHECKLIST.md | ✅ Complete | v3.0 | Real verified links |
| SUMMARACE_FOLDER_STRUCTURE.md | ✅ Complete | v1.0 | Unity setup |
| SUMMARACE_GAME_BALANCE.md | ✅ Complete | v1.0 | All tunable numbers |
| SUMMARACE_INDEX.md | ✅ Complete | v1.0 | This file |

---

## 🎓 Glossary of Game Dev Terms (Quick Reference)

| Term | Meaning |
|---|---|
| **MVP** | Minimum Viable Product — simplest working version |
| **Asset** | Any file used in the game (image, sound, model) |
| **Prefab** | A reusable Unity GameObject template |
| **ScriptableObject** | Unity data container, editable in Inspector |
| **EULA** | End User License Agreement |
| **CC0** | Creative Commons Zero — public domain |
| **Free tier** | Free version of a paid product |
| **Endless runner** | Game where you run forward forever (Subway Surfers, Temple Run) |
| **Game balance** | Tuning numbers to make the game fair and fun |
| **Game feel** | How the game subjectively feels to play |
| **Playtesting** | Watching real users play to find problems |
| **Iteration** | Build → test → adjust → repeat |
| **HUD** | Heads-Up Display (the UI overlay during gameplay) |
| **NPC** | Non-Player Character (like Ms. Lumi) |
| **TTS** | Text-to-Speech (for narration) |
| **APK** | Android app file |
| **Inspector** | Unity panel where you edit object properties |
| **Lane runner** | Endless runner with fixed lanes (left/middle/right) |
| **Fake chase** | The trick where the enemy is visual only, not real AI |
| **Distractor** | A wrong answer designed to look plausible |
| **Somebody-Wanted-But-So-Then** | The story summarization framework |

---

## 📅 Document History

| Version | Date | Changes |
|---|---|---|
| v1.0 | Initial | Created all 5 base documents |
| v2.0 | Updates | Added hidden scenes to SVG |
| v3.0 | Updates | Added real asset links |
| v4.0 | Current | Added GAME_BALANCE.md and INDEX.md |

---

## 🎯 Next Recommended Actions

Based on what's done, here's what to do next:

### Option 1: Start coding (recommended)
You have **enough documentation** to begin. Open Unity, follow the Day 1 checklist in FOLDER_STRUCTURE.md.

### Option 2: Gather assets first
Spend 1-2 days working through ASSET_CHECKLIST.md before opening Unity.

### Option 3: Get more detailed docs
Ask Claude to create:
- A technical spec (C# class diagrams)
- An audio design doc (when each sound plays)
- A specific scene's detailed wireframe

### Option 4: Stop documenting, start building
Most game devs over-document and under-build. You have plenty. **Build something playable in Unity, even if it's ugly.** Documentation can wait.

---

**End of Index Document**

> **Tip:** Bookmark this file. When you forget where something is, come back here first.
