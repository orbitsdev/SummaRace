# SummaRace — Complete Game Plan

> **Tagline:** Read. Run. Remember.
> **Genre:** Educational endless runner
> **Target audience:** Grades 2–4 (ages 7–10)
> **Platform:** Mobile/tablet (Android first), desktop later
> **Engine:** Unity (2D + 3D hybrid)
> **Development timeline:** 2 weeks (MVP)

---

## 1. Game Concept

SummaRace teaches kids how to summarize stories using the **Somebody–Wanted–But–So–Then** framework. Players read a short story, then run through a snowy 3D track collecting the 5 key story elements like coins. At the finish line, they assemble those elements into a written summary. The chase mechanic ensures kids actually pay attention while reading, because they know they'll need the details to survive.

### The Educational Goal
By the end of 3 stories, players have practiced the Somebody-Wanted-But-So-Then framework three times in a fun, memorable way. The framework becomes second nature — they can apply it to any story they read in school.

### The Player's Goal
Read a story → Survive the Snow Patrol chase → Collect the correct story elements → Write a complete summary → Beat all 3 levels.

---

## 2. Target Audience

| Group | Description |
|---|---|
| 🟢 **Primary** | Grades 2–4 (ages 7–10) — main learners |
| 🟡 **Secondary** | Grade 1 with parent help; Grade 5 for review |
| 🔴 **Not for** | Under 6, over 12, adults |

### Player Persona — "Sam, age 8"
Sam is in 3rd grade. She loves Subway Surfers and reads short stories but struggles to summarize them. She has a 15-minute attention span for educational apps, gets frustrated by harsh feedback, and is motivated by stars and cute characters. SummaRace must feel like a game she chooses to play, not homework her parents force on her.

---

## 3. Full Game Flow

```
START
  ↓
1. Splash screen
  ↓
2. Enter name + pick avatar
  ↓
3. Teacher (Ms. Lumi) welcomes player
  ↓
4. Select story (Level 1, 2, or 3)
  ↓
5. Read story page-by-page
       └─ After each page → processing question (always proceed)
  ↓
6. Mission intro from Ms. Lumi
  ↓
7. THE 3D RUN (mission)
       └─ 5 question checkpoints (Somebody, Wanted, But, So, Then)
       └─ Correct = sprint boost; Wrong = slowdown
       └─ Snow Patrol chases — getting caught restarts the run
  ↓
8. Finish line reached
  ↓
9. Final summary task
       └─ Fix wrong elements (30s timer)
       └─ Type the full summary sentence
  ↓
10. Victory screen + stars + level unlock
  ↓
NEXT LEVEL (repeat) → until Level 3 complete → Final celebration
```

---

## 4. Detailed Scene Breakdown

### Scene 1 — Splash / Title
- **Type:** 2D
- **Contents:** Logo, tagline, Start button, Settings button
- **Duration:** 3–5 seconds
- **Build complexity:** ⭐ Easy

### Scene 2 — Name & Avatar
- **Type:** 2D
- **Contents:** Text input field, 4 avatar choices, Continue button
- **Logic:** Save name to PlayerPrefs
- **Build complexity:** ⭐ Easy

### Scene 3 — Teacher Welcome
- **Type:** 2D
- **Contents:** Ms. Lumi character (PNG), speech bubble, Continue button
- **Logic:** Reads player name from PlayerPrefs and inserts into greeting
- **Build complexity:** ⭐ Easy

### Scene 4 — Level Select
- **Type:** 2D
- **Contents:** 3 story cards, lock icons, star indicators
- **Logic:** Read unlocked levels from PlayerPrefs; tap to start
- **Build complexity:** ⭐ Easy

### Scene 5 — Story Reader
- **Type:** 2D
- **Contents:** Page background, illustration, text, narration toggle, page indicator, Next button
- **Logic:** Load story JSON, display pages one at a time, trigger question popup after each page
- **Build complexity:** ⭐⭐ Medium

### Scene 6 — Processing Question Popup
- **Type:** 2D overlay
- **Contents:** Question text, 3 answer buttons, feedback message
- **Logic:** Track score (correct count), feedback shown for both right and wrong, always proceed
- **Build complexity:** ⭐⭐ Medium

### Scene 7 — Mission Intro
- **Type:** 2D
- **Contents:** Ms. Lumi character, mission briefing speech bubble, Start button
- **Build complexity:** ⭐ Easy

### Scene 8 — The 3D Run (CORE GAMEPLAY)
- **Type:** 3D
- **Contents:**
  - Endless snowy track (3 lanes)
  - 3D player character with run/sprint/jump animations
  - 3D Snow Patrol enemy (visual only — see technical notes below)
  - 5 question checkpoints with floating answer cards
  - HUD: timer, score, collected elements bar, distance indicator
  - Lane controls (swipe + arrow buttons)
  - Optional decorative obstacles between checkpoints
- **Build complexity:** ⭐⭐⭐⭐ Hard

### Scene 9 — Final Summary Task
- **Type:** 2D
- **Contents:** Collected elements display, 30-second timer, fix popups for wrong elements, text input field, Submit button
- **Logic:** Validate fixes, accept the typed sentence (keyword-based check)
- **Build complexity:** ⭐⭐⭐ Medium-Hard

### Scene 10 — Victory
- **Type:** 2D
- **Contents:** Stars (1–3), Ms. Lumi celebrating, Next Level button, Replay button
- **Logic:** Calculate stars based on time + correctness; unlock next level
- **Build complexity:** ⭐ Easy

---

## 5. Technical Architecture (Your Camera Idea — Brilliant!)

You suggested something really smart: **the Snow Patrol doesn't need to be a real chasing AI.** Instead, it's a visual trick that uses the camera. Here's how that works in Unity:

### The "Fake Chase" System

Most endless runners (Subway Surfers, Temple Run, Jetpack Joyride) don't actually have a real enemy chasing the player with AI. They use this trick:

1. **The camera is locked behind the player** at a fixed offset
2. **The Snow Patrol model is positioned in the camera's view** as a "follower" that always stays at a certain distance behind the player on screen
3. The "distance" between player and patrol is just a **number variable** (e.g., `dangerLevel`), not real physical distance
4. When the player picks correctly → `dangerLevel` decreases → patrol is rendered farther away
5. When the player picks wrong → `dangerLevel` increases → patrol is rendered closer
6. When `dangerLevel` reaches max → "Caught!" → restart mission

### Why This Works Better Than Real AI
- ✅ **Performance:** No expensive pathfinding or collision checks
- ✅ **Predictable:** You control exactly when caught happens
- ✅ **Easier to balance:** Just tweak numbers in the inspector
- ✅ **No physics bugs:** The patrol can't get stuck on terrain
- ✅ **Cinematic:** You can make the patrol look terrifying without it actually being a threat to the game logic

### The Camera Setup

```
        [Camera] ← rotates and follows
            │
            │  fixed offset
            ↓
        [Player] ← moves on track (3 lanes)
            │
            │  visual offset based on dangerLevel
            ↓
        [SnowPatrol] ← rendered in foggy distance
```

Both the player and patrol are children of a "TrackRoot" object that moves forward. The world (track, trees, obstacles) actually moves *toward* the player rather than the player moving forward — this is the classic endless runner trick.

### Element Cards Connected to Camera

You also mentioned the answer cards being "connected to the camera." That's a smart way to phrase it. Here's how it works:

- The 5 question checkpoints are placed at fixed positions on the track (e.g., at distance 100m, 200m, 300m, 400m, 500m from start)
- As the track scrolls toward the player, the checkpoints come into view naturally
- When a checkpoint is ~30m away, the 3 answer cards spawn in the 3 lanes
- The cards have colliders — when the player runs into one, it triggers the answer logic
- After the player passes the checkpoint, the cards disappear

This is much simpler than tying them to the camera directly. The track does all the work.

---

## 6. The 3 Stories

Each story has:
- 5 pages of text (with illustrations)
- 5 reading-phase questions (one per page)
- 5 mission-phase elements (Somebody, Wanted, But, So, Then)
- Each element has 1 correct answer + 2 distractors

### LEVEL 1 — "Max the Lost Puppy" (Easy)

**Theme:** A puppy gets lost and finds his way home.
**Difficulty:** Short sentences, simple vocabulary, familiar setting.

**Pages:**
1. Max the puppy lived in a small house by the park with his owner Lily. Every morning, Lily took him for a walk on the same path.
2. One sunny day, Max saw a butterfly. He chased it off the path and ran into the deep woods.
3. When Max stopped running, he looked around. Everything looked strange. He could not see Lily anywhere. He was lost!
4. Max sniffed the ground. He remembered the smell of his favorite tree near home. He followed the smell, step by step.
5. After a long walk, Max saw his house. Lily was waiting on the porch. She hugged him tight and said, "I missed you, Max!"

**Reading questions (one per page):**
1. Who did Max live with? → Lily ✓ / The mailman / A stray cat
2. What did Max chase off the path? → A butterfly ✓ / A squirrel / A ball
3. How did Max feel when he was lost? → Scared ✓ / Happy / Sleepy
4. How did Max find his way back? → He followed familiar smells ✓ / He climbed a tree / He barked loudly
5. Who was waiting for Max at home? → Lily ✓ / A cat / The mailman

**Mission elements (collected during the run):**

| Element | ✅ Correct | ❌ Distractor 1 | ❌ Distractor 2 |
|---|---|---|---|
| **Somebody** | Max the puppy | The mailman | A stray cat |
| **Wanted** | To find his way home | To eat a big bone | To chase the butterfly forever |
| **But** | He got lost in the woods | He met a friend | He fell asleep |
| **So** | He followed familiar smells | He climbed a tree | He barked loudly |
| **Then** | Lily found him and hugged him | He found a bone | He went swimming |

**Final summary (target):**
> Max the puppy wanted to find his way home, but he got lost in the woods, so he followed familiar smells, and then Lily found him and hugged him.

---

### LEVEL 2 — "Luna and the Broken Kite" (Medium)

**Theme:** A girl's kite breaks and she fixes it with help from a friend.
**Difficulty:** Slightly longer sentences, more vocabulary.

**Pages:**
1. Luna loved flying her red kite at the park. It was a gift from her grandfather and she took it everywhere.
2. One windy afternoon, Luna ran across the grass with her kite high in the sky. She felt like she was flying with it.
3. Suddenly, the wind became too strong. The string snapped, and the kite crashed into a tree. The kite tore in half.
4. Luna sat down and almost cried. Her friend Ravi came over. "Don't worry," he said. "I will help you fix it." They went to Ravi's house and used tape and colorful paper.
5. The next day, Luna and Ravi went back to the park. The kite flew higher than ever before. Luna smiled and thanked her best friend.

**Reading questions:**
1. Who gave Luna the kite? → Her grandfather ✓ / Her teacher / Ravi
2. Where did Luna fly her kite? → At the park ✓ / At the beach / In her yard
3. What happened to the kite? → The string snapped and it tore ✓ / It flew away forever / A dog ate it
4. Who helped Luna fix the kite? → Ravi ✓ / Her grandfather / A stranger
5. How did Luna feel at the end? → Happy and thankful ✓ / Sad / Angry

**Mission elements:**

| Element | ✅ Correct | ❌ Distractor 1 | ❌ Distractor 2 |
|---|---|---|---|
| **Somebody** | Luna | Ravi's mother | A park ranger |
| **Wanted** | To fly her red kite | To buy a new kite | To climb a tree |
| **But** | The wind broke her kite | She lost the string | A dog stole it |
| **So** | Ravi helped her fix it with tape and paper | She bought a new one | She gave up and went home |
| **Then** | The kite flew higher than ever | She never flew kites again | She got a puppy instead |

**Final summary (target):**
> Luna wanted to fly her red kite, but the wind broke her kite, so Ravi helped her fix it with tape and paper, and then the kite flew higher than ever.

---

### LEVEL 3 — "The Brave Little Turtle" (Hard)

**Theme:** A small turtle wants to win a race against bigger animals.
**Difficulty:** Longer sentences, more complex plot, character emotions.

**Pages:**
1. In a quiet forest pond lived a small turtle named Tito. All the bigger animals teased him because he was slow. Tito dreamed of winning the great Forest Race one day.
2. When the day of the race came, Tito stood at the starting line with the rabbit, the fox, and the deer. Everyone laughed when they saw him. "You will never win, little turtle!" they shouted.
3. The race began. The rabbit, the fox, and the deer ran ahead and quickly disappeared from sight. Tito started slowly but did not give up. He kept walking, one step at a time.
4. Halfway through the race, Tito found the rabbit sleeping under a tree, the fox eating berries, and the deer drinking from the pond. They had stopped to rest because they were so far ahead. Tito quietly walked past all of them.
5. When Tito crossed the finish line first, the whole forest cheered. The other animals woke up and ran, but it was too late. From that day on, no one ever teased Tito again.

**Reading questions:**
1. Why did the other animals tease Tito? → Because he was slow ✓ / Because he was small / Because he was green
2. Who else was in the race? → The rabbit, fox, and deer ✓ / The owl and the bear / The frog and the fish
3. What did Tito do when the race started? → He kept walking, one step at a time ✓ / He gave up / He took a shortcut
4. Why did the other animals stop? → They were resting because they were ahead ✓ / They got hurt / They were lost
5. How did the story end? → Tito won and was never teased again ✓ / Tito lost / The race was canceled

**Mission elements:**

| Element | ✅ Correct | ❌ Distractor 1 | ❌ Distractor 2 |
|---|---|---|---|
| **Somebody** | Tito the small turtle | The rabbit | The fox |
| **Wanted** | To win the great Forest Race | To make new friends | To find food |
| **But** | The other animals were faster and teased him | He had a broken leg | He got lost in the forest |
| **So** | He kept walking slowly and never gave up | He cheated and took a shortcut | He asked for a head start |
| **Then** | He crossed the finish line first and won | He came in second place | He gave up halfway |

**Final summary (target):**
> Tito the small turtle wanted to win the great Forest Race, but the other animals were faster and teased him, so he kept walking slowly and never gave up, and then he crossed the finish line first and won.

---

## 7. Items / Visual Assets per Story

These are the icons that appear on the floating answer cards. All can be found as **free emoji-style icons** or **simple low-poly 3D models** in Unity Asset Store, Mixamo, or free icon sites like Flaticon.

### Level 1 — Max the Puppy
| Element | Correct icon | Distractor icons |
|---|---|---|
| Somebody | 🐶 puppy | 👨 mailman, 🐱 cat |
| Wanted | 🏠 house | 🦴 bone, 🦋 butterfly |
| But | 🌲 trees / forest | 🤝 friends, 😴 zZz |
| So | 👃 nose sniffing | 🌳 climbing tree, 🔊 bark |
| Then | 🤗 hug | 🦴 bone, 🏊 swimming |

### Level 2 — Luna's Kite
| Element | Correct icon | Distractor icons |
|---|---|---|
| Somebody | 👧 girl | 👩 mother, 👮 ranger |
| Wanted | 🪁 red kite | 🛒 shop, 🌳 tree |
| But | 💨 strong wind | ✂️ scissors, 🐕 dog |
| So | 🛠️ tape & paper | 💰 buy new, 🚪 go home |
| Then | 🪁⬆️ kite high | 🚫🪁 no kite, 🐶 puppy |

### Level 3 — Tito the Turtle
| Element | Correct icon | Distractor icons |
|---|---|---|
| Somebody | 🐢 turtle | 🐰 rabbit, 🦊 fox |
| Wanted | 🏆 trophy | 👫 friends, 🍎 food |
| But | 😤 teased | 🦴 broken leg, 🗺️ lost |
| So | 🚶 keep walking | ✂️ shortcut, 🏁 head start |
| Then | 🥇 first place | 🥈 second place, 🛑 give up |

### Recommended approach for the icons
For **fastest development**, use one of these:
1. **Flaticon.com** — Download free icon sets in a consistent cartoon style
2. **Game-icons.net** — Free game-style icons (creative commons)
3. **Kenney.nl** — Free game asset packs with consistent style (highly recommended for kids' games)
4. **Unity Asset Store** — search "cartoon icons", "kids icons", "education pack"

For the **3D characters** (player + Snow Patrol):
1. **Mixamo** (free) — Download a kid character + free run/idle/jump animations
2. **Unity Asset Store** — search "stylized character pack", "low poly character"
3. **Synty Studios POLYGON** packs — affordable, professional, lots of variety

---

## 8. Unity Asset Recommendations

### Essential (must have)

| Need | Asset | Source |
|---|---|---|
| Endless runner template | Endless Runner Sample Game (free Unity sample) | Unity Asset Store |
| Snowy environment | "Low Poly Winter Pack" or "Snow Environment" | Unity Asset Store (many free) |
| Player character | "Stylized Boy/Girl Character" | Mixamo / Asset Store |
| Snow Patrol enemy | "Yeti" or "Snowman Enemy" | Asset Store / Sketchfab |
| Run animations | Mixamo (free) — run, sprint, jump, stumble, idle | Mixamo.com |
| Fog / atmosphere | Built-in Unity fog + particle system | Unity built-in |
| 2D teacher character | Custom illustration or Flaticon character | Flaticon / your own |
| UI kit | "Cartoon UI Kit" or "Kids UI" | Asset Store |
| Sound effects | "Casual Game SFX Pack" | Asset Store / freesound.org |
| Background music | "Cute Game Music Pack" | Asset Store / freesound.org |

### Tutorials you already found (perfect!)

1. **Endless Runner Tutorial** — base mechanic
   https://www.youtube.com/watch?v=Ldyw5IFkEUQ

2. **Fog effect tutorial** — atmosphere for Snow Patrol chase
   https://www.youtube.com/watch?v=IlKaB1etrik

---

## 9. Two-Week Development Plan

### Week 1 — Foundation & Content
| Day | Tasks |
|---|---|
| **Day 1** | Project setup. Download all assets. Create folder structure. Import endless runner template. |
| **Day 2** | Build the 3D track scene. Get the player running on a 3-lane track with swipe controls. |
| **Day 3** | Add Snow Patrol "fake chase" system. Add HUD (timer, distance indicator). |
| **Day 4** | Build the question checkpoint system: spawn 3 cards in lanes, detect collision, trigger answer logic. |
| **Day 5** | Build the 2D Story Reader scene: pages, narration toggle, next button. |
| **Day 6** | Build the processing question popup. Wire up scoring. |
| **Day 7** | Connect everything: Story → Reader → Mission → end of mission. Test full Level 1 flow. |

### Week 2 — Polish & Complete Content
| Day | Tasks |
|---|---|
| **Day 8** | Build the Final Summary Task scene: collected elements, fix popup, typing field. |
| **Day 9** | Build name entry, level select, teacher welcome, mission intro scenes. |
| **Day 10** | Implement victory screen, star calculation, level unlock progression. |
| **Day 11** | Add story content for Levels 2 and 3. Test full game flow. |
| **Day 12** | Add audio: narration, SFX, background music. Add visual polish. |
| **Day 13** | Bug fixes, playtesting with a real kid if possible, balance tuning. |
| **Day 14** | Final build. Export APK for Android. Document and ship. |

---

## 10. Story & Question Data Format (JSON Template)

To make adding new stories easy later, store all content as JSON files. Here's the recommended structure:

```json
{
  "level": 1,
  "title": "Max the Lost Puppy",
  "difficulty": "easy",
  "pages": [
    {
      "page_number": 1,
      "text": "Max the puppy lived in a small house...",
      "illustration": "max_page1.png",
      "narration": "max_page1.mp3",
      "question": {
        "text": "Who did Max live with?",
        "options": ["Lily", "The mailman", "A stray cat"],
        "correct_index": 0
      }
    }
  ],
  "elements": [
    {
      "category": "Somebody",
      "icon_correct": "puppy.png",
      "options": [
        {"text": "Max the puppy", "icon": "puppy.png", "correct": true},
        {"text": "The mailman", "icon": "mailman.png", "correct": false},
        {"text": "A stray cat", "icon": "cat.png", "correct": false}
      ]
    }
  ],
  "target_summary": "Max the puppy wanted to find his way home, but he got lost in the woods, so he followed familiar smells, and then Lily found him and hugged him."
}
```

This way, adding new stories later means just creating a new JSON file — no coding required.

---

## 11. Scoring & Reward System

### Per Level Stars
| Stars | Requirement |
|---|---|
| ⭐⭐⭐ | All reading questions correct + all mission elements correct on first try + finished mission with time to spare |
| ⭐⭐ | Most correct + finished mission |
| ⭐ | Finished the level (even if many wrong answers) |

### Reading Score Affects Mission
- 5/5 reading questions correct → 60 seconds for mission
- 3–4 correct → 50 seconds
- 0–2 correct → 40 seconds

This creates a natural connection between paying attention while reading and succeeding in the run.

---

## 12. Critical Design Principles

1. **Never block progress.** Wrong answers always proceed. Even getting caught only restarts the run, never the level.
2. **Always show the correct answer.** When the player gets something wrong, they see the right answer immediately. Learning never stops.
3. **No harsh feedback.** No red Xs, no "FAIL" screens, no scary sounds. Use friendly language: "Not quite!" instead of "Wrong!"
4. **Sam test:** Every design decision must pass the "Would Sam (age 8) love this?" test.
5. **Polish over scope.** Better to ship 1 polished level than 3 broken ones. If you run out of time, cut Level 3 — don't ship a buggy game.

---

## 13. Future Enhancements (After MVP)

These are NOT for the 2-week build, but worth noting for later versions:

- 🌍 Filipino/Tagalog language version
- 📚 More stories (10+ levels)
- 👨‍👩‍👧 Parent/teacher dashboard with progress reports
- 🎨 Customizable avatars
- 🏆 Daily challenges and rewards
- 👥 Multiplayer races (compete with classmates)
- 🎤 Voice-recognition typing for very young kids
- 📊 Adaptive difficulty (easier stories for struggling readers)

---

## 14. Risks & Mitigations

| Risk | Mitigation |
|---|---|
| Typing summary is hard for kids | Use keyword-based validation (any sentence containing the 5 elements counts) |
| 2 weeks is tight | Cut Level 3 if needed; ship 2 polished levels instead of 3 rushed ones |
| 3D run is technically complex | Use the existing endless runner template — don't build from scratch |
| Audio recording takes time | Use TTS (text-to-speech) for v1; record real narration in v2 |
| Asset style mismatch | Pick assets from one or two creators (Kenney, Synty) for visual consistency |

---

## 15. Success Criteria for the MVP

The MVP is "done" when:
- ✅ A player can complete all 3 levels start to finish
- ✅ Saves work (player name, unlocked levels, stars)
- ✅ Audio narration plays for at least 1 story
- ✅ The game runs at 30fps on a mid-range Android phone
- ✅ A real kid (not a developer) can play it without help and have fun
- ✅ APK exports cleanly for Play Store submission

---

**End of Game Plan v1.0**
