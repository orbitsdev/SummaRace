# SummaRace 🏃‍❄️📚

> **Read. Run. Remember.** An educational endless runner that teaches kids how to summarize stories using the Somebody-Wanted-But-So-Then framework.

---

## 📋 Project Overview

| | |
|---|---|
| **Genre** | Educational endless runner |
| **Engine** | Unity (2D + 3D hybrid) |
| **Platform** | Android (mobile/tablet first) |
| **Audience** | Grades 2–4 (ages 7–10) |
| **Timeline** | 2 weeks for MVP |
| **Status** | Planning complete, ready for development |

---

## 🎮 What Is SummaRace?

SummaRace is an educational game where kids:

1. **Read** a short illustrated story (5 pages)
2. **Answer** quick comprehension questions while reading
3. **Run** through a snowy 3D track to escape the Snow Patrol
4. **Collect** the 5 key story elements (Somebody, Wanted, But, So, Then) like coins
5. **Type** a complete summary at the finish line
6. **Unlock** the next level and progress through 3 stories

The game teaches summarization through gameplay — kids pay attention to the story because they need the details to survive the chase.

---

## 📚 Documentation Files

This project has 4 main documentation files. **Read them in this order:**

### 1. 📄 SUMMARACE_GAME_PLAN.md
**The master plan.** Read this first. Covers:
- Game concept and educational goals
- Target audience and player persona
- Full game flow (10 scenes)
- All 3 stories with pages, questions, and answer tables
- Technical architecture (camera + fake chase system)
- 14-day development plan
- Scoring and reward system

### 2. 🎨 SUMMARACE_GAME_FLOW.svg
**The visual mockup.** Open in any browser. Shows all 10 game scenes side-by-side, the technical "fake chase" diagram, and summary cards for all 3 stories.

### 3. ✅ SUMMARACE_ASSET_CHECKLIST.md
**The shopping list.** Every asset you need to find or create before development. Organized by category with checkboxes and recommended sources (Mixamo, Kenney, Flaticon, Asset Store).

### 4. 🏗️ SUMMARACE_FOLDER_STRUCTURE.md
**The technical blueprint.** Complete Unity project folder structure, naming conventions, key scripts to write, .gitignore template, build settings, and Day 1 setup checklist.

---

## 🚀 Quick Start

### Phase 1 — Preparation (before touching Unity)
1. ✅ Read all 4 documentation files
2. 🛒 Work through the Asset Checklist — gather everything
3. ✏️ Convert the 3 stories to JSON format (template in Game Plan)
4. 🎨 Prepare/source all illustrations and icons

### Phase 2 — Project Setup (Day 1 of Unity work)
1. Install Unity 2022 LTS + Android module
2. Create new project with 3D URP template
3. Set up the folder structure (see Folder Structure doc)
4. Import endless runner template + DOTween
5. Initialize Git

### Phase 3 — Build (Days 2–14)
Follow the day-by-day plan in `SUMMARACE_GAME_PLAN.md`.

### Phase 4 — Ship
Build the APK, test on a real Android device, and (optionally) submit to Play Store.

---

## 🎯 The Core Innovation

The clever part of SummaRace is the **"fake chase" system** for the Snow Patrol:

> Instead of using expensive AI pathfinding, the Snow Patrol is a **visual-only** enemy whose distance is controlled by a single integer variable (`dangerLevel`). Correct answers decrease it; wrong answers increase it. When it hits the maximum, the player is "caught."

This is the same trick used by Subway Surfers, Temple Run, and Jetpack Joyride. Perfect control over difficulty, runs fast on mobile, easy to balance.

---

## 🛠️ Tech Stack

| Tool | Purpose |
|---|---|
| **Unity 2022 LTS** | Game engine |
| **C#** | Scripting |
| **Universal Render Pipeline (URP)** | Mobile-optimized graphics |
| **DOTween** | Animation library |
| **Mixamo** | Free character animations |
| **Kenney.nl / Flaticon** | Free art assets |

---

## 📐 Design Principles

1. **Never block progress.** Wrong answers always proceed.
2. **Always show the correct answer.** Learning never stops.
3. **No harsh feedback.** Friendly language always.
4. **The Sam test.** "Would Sam (age 8) love this?"
5. **Polish over scope.** Better to ship 1 polished level than 3 broken ones.

---

## 📊 Success Criteria

The MVP is "done" when:

- ✅ A player can complete all 3 levels start to finish
- ✅ Save/load works (player name, unlocked levels, stars)
- ✅ At least 1 story has voice narration
- ✅ Game runs at 30fps on a mid-range Android phone
- ✅ A real kid can play it without help and have fun
- ✅ APK exports cleanly for Play Store submission

---

**Made with ❤️ for kids who deserve learning that feels like play.**
