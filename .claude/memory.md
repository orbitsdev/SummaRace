# SummaRace Project Memory

## Project Status: 🟡 Setup Complete - Ready to Build

**Last Updated:** 2026-04-08
**Unity Version:** 6000.4.1f1 (Unity 6)
**Platform:** Android (mobile/tablet)

---

## ✅ Completed

### Setup & Configuration
- [x] Unity project created with URP template
- [x] Git repository initialized
- [x] Pushed to GitHub: https://github.com/orbitsdev/SummaRace
- [x] `.gitignore` configured for Unity
- [x] `CLAUDE.md` created with Unity best practices
- [x] Unity-MCP (AI Game Developer) installed and connected
- [x] Claude Code connected to Unity Editor

### Current Scene State
- Scene: `SampleScene`
- Objects: Main Camera, Directional Light, Global Volume, Plane, Sphere (test)

---

## 🔲 To Do

### Phase 1: Project Structure
- [ ] Create `Assets/_Game/` folder structure
- [ ] Create 10 scene files (00_Splash through 99_GameComplete)
- [ ] Set up ScriptableObjects for game config
- [ ] Import DOTween (optional)

### Phase 2: Core Scripts
- [ ] GameManager.cs (singleton, level tracking)
- [ ] SaveManager.cs (PlayerPrefs wrapper)
- [ ] SceneLoader.cs (transitions with fade)
- [ ] AudioManager.cs (music/SFX)
- [ ] StoryLoader.cs (JSON parsing)

### Phase 3: Story Data
- [ ] Create StoryData.cs model
- [ ] Create PageData.cs model
- [ ] Create QuestionData.cs model
- [ ] Create level1.json story file

### Phase 4: Player & Mission
- [ ] PlayerController.cs (movement, lanes)
- [ ] DangerLevel.cs (fake chase system)
- [ ] CheckpointSpawner.cs
- [ ] AnswerCard.cs
- [ ] MissionManager.cs

### Phase 5: UI
- [ ] Create UI for each scene
- [ ] StoryReaderUI.cs
- [ ] MissionHUD.cs
- [ ] FinalSummaryUI.cs

### Phase 6: Art & Audio
- [ ] Import/create 3D player model
- [ ] Create track segments
- [ ] Import UI assets
- [ ] Add music and SFX

### Phase 7: Polish & Build
- [ ] Test on Android device
- [ ] Performance optimization
- [ ] Build APK

---

## 📝 Session Notes

### Session 1 (2026-04-08)
- Set up Unity project and GitHub repo
- Installed Unity-MCP for AI assistance
- Created CLAUDE.md with project guidelines
- Tested MCP connection - successfully created sphere
- Ready to start building game structure

---

## 🎮 Game Design Quick Reference

**Target:** Kids grades 2-4
**Framework:** Somebody-Wanted-But-So-Then

**10 Scenes:**
1. 00_Splash - Title
2. 01_NameEntry - Player setup
3. 02_TeacherWelcome - Ms. Lumi intro
4. 03_LevelSelect - Choose story
5. 04_StoryReader - Read story
6. 05_MissionIntro - Mission briefing
7. 06_Mission3DRun - Core gameplay
8. 07_FinalSummary - Type summary
9. 08_Victory - Stars earned
10. 99_GameComplete - Final celebration

**Fake Chase System:**
- `dangerLevel` int (0-10)
- Correct answer: -2
- Wrong answer: +3
- At 10: caught (visual only, never blocks progress)

---

## 🔧 MCP Commands Reference

```
Create GameObject: gameobject-create
Create Script: script-update-or-create
Create Scene: scene-create
Create Prefab: assets-prefab-create
Create Material: assets-material-create
Find Objects: gameobject-find
Add Component: gameobject-component-add
```

---

## 📁 Target Folder Structure

```
Assets/_Game/
├── Scenes/
├── Scripts/
│   ├── Core/
│   ├── Data/
│   ├── Player/
│   ├── Mission/
│   └── UI/
├── Prefabs/
├── ScriptableObjects/
└── Resources/Stories/
```
