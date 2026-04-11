# SummaRace — Visual Theme Specification

> **Theme: Arctic Adventure** — A bright, layered, snowy world that feels alive. Every screen is a window into the game world, not a flat form page.

---

## Core Philosophy

1. **No flat backgrounds** — Every scene has depth: sky → distant elements → mid-ground → foreground → snow → particles → UI
2. **Use every asset we have** — Cartoon UI sprites for panels/buttons, Kenney Nature Kit for environment, Easy Chara for Ms. Lumi, Trees Package for 3D trees, BOXOPHOBIC for skybox
3. **Alive, not static** — Snowflakes always falling, elements gently swaying, buttons breathing, parallax on tilt
4. **Kid-first design** — Big touch targets, bouncy animations, bright readable colors, visual feedback for everything
5. **Consistent but varied** — Same UI framework (Cartoon UI Skyblue set) across all scenes, but each scene has its own accent color and environmental mood

---

## Master Color System

### Primary Palette (Skyblue Arctic)

| Role | Color | Hex | Usage |
|------|-------|-----|-------|
| **Sky Dark** | Deep blue | `#0D47A1` | Headers, strong text, emphasis |
| **Sky Mid** | Bright blue | `#42A5F5` | Borders, active states, links |
| **Sky Light** | Sky blue | `#87CEEB` | Backgrounds, hover states |
| **Ice** | Pale blue | `#E0F0FF` | Cards, panels, light backgrounds |
| **Snow** | White | `#FFFFFF` | Primary surface, text on dark |
| **Frost** | Soft gray-blue | `#B0C4DE` | Disabled states, subtle borders |

### Accent Colors (Per-Scene)

Each scene keeps the Skyblue Arctic base but adds an accent color for personality:

| Scene | Accent | Hex | Cartoon UI Set | Mood |
|-------|--------|-----|----------------|------|
| 00 Splash | Ice Blue | `#87CEEB` | Skyblue | Brand intro |
| 01 Name Entry | Purple | `#7B68EE` | Purple | Personalization |
| 02 Teacher Welcome | Teal | `#26A69A` | Green | Warmth, trust |
| 03 Level Select | Amber | `#FFB300` | Yellow | Choice, adventure |
| 04 Story Reader | Rose | `#F48FB1` | Pink | Comfort, reading |
| 05 Mission Intro | Teal | `#26A69A` | Green | Continuity |
| 06 3D Run | Snow White | `#E0F0FF` | Skyblue | Action, cold |
| 07 Final Summary | Lavender | `#B39DDB` | Purple | Reflection |
| 08 Victory | Green | `#66BB6A` | Green | Celebration |
| 09 Game Complete | Gold | `#FFD54F` | Yellow | Mastery |

### Feedback Colors

| State | Color | Hex |
|-------|-------|-----|
| Correct/Success | Teal green | `#00BFA5` |
| Wrong/Error | Soft red | `#EF5350` |
| Warning | Amber | `#FFB300` |
| Disabled | Gray | `#B0BEC5` |
| Highlight/Selected | Gold | `#FFD700` |

---

## Layer System (Every 2D Scene)

Every non-3D scene (00–05, 07–09) uses this layered approach:

```
┌─────────────────────────────────────────┐
│ Layer 7: UI Elements (Canvas)           │  Cartoon UI panels, buttons, text
│ Layer 6: Particle Effects               │  Snowflakes, sparkles, confetti
│ Layer 5: Foreground Decorations         │  Close trees, snowman, rocks
│ Layer 4: Snow Ground                    │  Curved white/ice-blue ground
│ Layer 3: Mid-ground Elements            │  Kenney trees, buildings, Ms. Lumi
│ Layer 2: Distant Background             │  Mountains, hills, aurora
│ Layer 1: Sky                            │  BOXOPHOBIC skybox or gradient
└─────────────────────────────────────────┘
```

### Layer Details

**Layer 1 — Sky**
- Use BOXOPHOBIC "Polyverse Skies - Blue Sky" as base
- Add gradient overlay for scene mood (e.g., warmer for Level Select, cooler for 3D Run)
- Clouds: 2–3 soft white ellipses, slowly drifting right (0.5px/s)
- Optional: Sun or moon depending on scene mood
- Optional: Aurora borealis for special scenes (Victory, Game Complete) using a scrolling gradient shader

**Layer 2 — Distant Background**
- Snowy mountain silhouettes (2–3 overlapping triangular shapes)
- Colors: 20–30% opacity of scene accent color
- Very slow parallax: moves at 5% of any camera/tilt movement
- Can include distant pine tree line

**Layer 3 — Mid-ground Elements**
- **Kenney Nature Kit** trees (side-view sprites): 3–5 trees of varying height
- **Trees Package Lite** 3D trees: For scenes that use a 3D camera (Scene 06)
- **Easy Chara** Ms. Lumi: Appears in Scenes 02, 05, 08, 09
- Buildings, signs, decorations from Kenney as needed
- Medium parallax: moves at 15% of tilt

**Layer 4 — Snow Ground**
- Curved white surface (not flat!) — use an ellipse/bezier shape
- Gradient: Ice (#E0F0FF) at the curve edge → White (#FFFFFF) at bottom
- Subtle sparkle dots (small white circles with glow, randomly placed)
- Optional: footprint trail, sled tracks, animal tracks for personality

**Layer 5 — Foreground Decorations**
- Closest trees/bushes (larger, slightly blurred for depth-of-field effect)
- Positioned at screen edges (left 10%, right 10%) so they frame the UI
- Snowman, ice crystals, small animals peeking out
- Fast parallax: moves at 30% of tilt

**Layer 6 — Particle Effects**
- **Snow particles**: Always present in every scene
  - Count: 30–50 particles on screen
  - Size: Random 2–6px
  - Speed: Random 20–40px/s downward, slight horizontal drift
  - Opacity: Random 0.3–0.8
  - Shape: Circle (soft) or 6-point snowflake sprite
- **Scene-specific**: Sparkles (Victory), confetti (Game Complete), fireflies (Story Reader)

**Layer 7 — UI Elements**
- All UI uses **Cartoon UI** sprites as frames/backgrounds
- Panels: Use "Panel Light" or "Panel Brown" as card backgrounds
- Buttons: Use "Long Round [Color]" sprites from Cartoon UI
- Icons: Use Cartoon UI icon set (animal icons for avatars, white icons for navigation)
- Text: Fredoka font, always with slight shadow for readability over busy backgrounds

---

## UI Component Specifications

### Buttons (Cartoon UI)

| Button Type | Sprite | Usage |
|-------------|--------|-------|
| Primary action | `Long Round Skyblue` | Continue, Submit, Start |
| Secondary action | `Long Round Grey` | Back, Skip, Replay |
| Danger/Cancel | `Long Round Red` | Close, Cancel |
| Success | `Long Round Green` | Confirm, Correct |
| Accent (per scene) | `Long Round [Accent Color]` | Scene-specific actions |
| Avatar/Selection | `Circle [Color]` or `Circle Big [Color]` | Avatar picks, level cards |
| Disabled | `Long Round Grey` at 50% opacity | Any inactive button |

**Button animations:**
- Hover/focus: Scale to 1.05×, 0.1s ease
- Press: Scale to 0.95×, 0.05s
- Release: Bounce back to 1.0× with overshoot (1.08× → 1.0×), 0.2s
- Disabled tap: Gentle shake (3px left-right, 2 cycles), 0.3s
- Enable transition: Color fade from gray → active color, 0.3s

### Panels (Cartoon UI)

| Panel Type | Sprite | Usage |
|------------|--------|-------|
| Content card | `Panel Light` | Story cards, element panels, score panels |
| Header bar | `Title Bar [Color]` | Scene titles, section headers |
| Dialog/popup | `Panel Brown` + `Title Bar [Color]` | Question popups, fix dialogs |
| Victory banner | `Victory Title Bar [Color]` | Level complete, badges |
| Store/selection | `Store [Color]` | Level select cards |

**Panel treatment:**
- All panels get a subtle drop shadow: `0 4px 12px rgba(0,0,0,0.15)`
- Entrance animation: Scale from 0.8× → 1.0× with bounce, fade in, 0.3s
- Content inside panels: 16px padding, Fredoka font

### Input Fields

- Background: `Panel Light` sprite or white rounded rect
- Border: 3px solid, scene accent color
- Placeholder text: 40% opacity of text color
- Active state: Border glows (box-shadow pulse animation)
- Text: Fredoka Regular, `#0D47A1`

### Avatar Selection (Scene 01)

Use **Cartoon UI animal icons** (Fox, Frog, Dog, Pig) as the avatars:

| Avatar | Icon Source | Background Color | Cartoon UI Circle |
|--------|-----------|-----------------|-------------------|
| Fox | `Icons/fox` | `#FF8A65` (warm orange) | `Circle Orange` |
| Frog | `Icons/frog` | `#81C784` (green) | `Circle Green` |
| Dog | `Icons/Dog` | `#90CAF9` (light blue) | `Circle Skyblue` |
| Pig | `Icons/Pig` | `#F48FB1` (pink) | `Circle Pink` |

**Selection states:**
- Unselected: Normal size, `Circle [Color]` sprite, no ring
- Hover: Scale 1.05×
- Selected: Scale 1.1×, gold ring border (`#FFD700`), gentle pulsing glow
- Tap animation: Bounce (1.0× → 1.2× → 0.95× → 1.1×), 0.3s with pop SFX

### Progress Bars

Use **Cartoon UI Progress Bar Type 1** sprites:
- Background: `Progress Bar Background`
- Fill: `Progress Bar Fill [Scene Accent Color]`
- Used in: Story Reader (page progress), Mission 3D Run (element collection), loading states

### Stars (Victory/Game Complete)

- Empty star: Use Cartoon UI `Star Off` icon
- Filled star: Use Cartoon UI `Star` icon (or gold-colored star)
- Animation: Each star spins in (360° rotation + scale 0→1), 0.4s staggered by 0.3s
- Glow: Filled stars get a gold outer glow (#FFD700 at 30% opacity, 8px blur)

---

## Typography

### Font Stack

| Priority | Font | Fallback |
|----------|------|----------|
| 1 | Fredoka Bold | — |
| 2 | Fredoka SemiBold | — |
| 3 | Fredoka Medium | — |
| 4 | Fredoka Regular | — |

### Type Scale

| Element | Font | Size | Weight | Color |
|---------|------|------|--------|-------|
| Scene title / Logo | Fredoka | 48–64px | Bold | `#0D47A1` or white |
| Section header | Fredoka | 28–32px | Bold | Scene accent or `#0D47A1` |
| Question text | Fredoka | 22–26px | Bold | `#0D47A1` |
| Body / story text | Fredoka | 18–20px | Regular | `#1A237E` |
| Button label | Fredoka | 18–22px | Bold | White or `#0D47A1` |
| Caption / label | Fredoka | 12–14px | Regular | `#546E7A` |
| Input text | Fredoka | 18px | Regular | `#0D47A1` |

### Text Treatment

- **On dark backgrounds**: White text with `textShadow: 0 2px 4px rgba(0,0,0,0.3)`
- **On light backgrounds**: Dark blue text (`#0D47A1`), no shadow needed
- **Over busy backgrounds**: Add a subtle semi-transparent backdrop behind text (8px padding, 8px border-radius, `rgba(0,0,0,0.15)` or `rgba(255,255,255,0.7)`)

---

## Animation System

### Entrance Animations (when scene loads)

Staggered entrance sequence for each scene:

| Order | Element | Animation | Delay | Duration |
|-------|---------|-----------|-------|----------|
| 1 | Sky/Background | Fade in | 0.0s | 0.5s |
| 2 | Mountains | Slide up + fade | 0.1s | 0.4s |
| 3 | Trees | Scale (0→1) from bottom | 0.2s | 0.3s |
| 4 | Snow ground | Slide up from bottom | 0.3s | 0.3s |
| 5 | Snow particles | Start falling | 0.4s | continuous |
| 6 | UI Panel | Scale bounce (0.8→1.05→1) + fade | 0.5s | 0.4s |
| 7 | UI Content | Staggered fade-in per element | 0.6s+ | 0.2s each |
| 8 | Character (if any) | Slide in from side + wave | 0.8s | 0.5s |

### Micro-Interactions

| Interaction | Animation | Duration |
|-------------|-----------|----------|
| Button tap | Scale down 0.95× → bounce back 1.08× → 1.0× | 0.25s |
| Avatar select | Pop (1.0→1.2→0.95→1.1), ring fade in | 0.3s |
| Wrong answer tap | Shake horizontal (±4px, 3 cycles), flash red | 0.4s |
| Correct answer | Bounce up + green glow + checkmark fly-in | 0.3s |
| Text appear (typewriter) | Letter by letter | 0.04s per char |
| Score count-up | Numbers roll, pitch-ascending tick sounds | 1.5s |
| Star earned | Spin 360° + scale 0→1.2→1.0 + gold burst | 0.5s |
| Panel open | Scale 0.8→1.05→1.0 + backdrop dim | 0.35s |
| Panel close | Scale 1.0→0.9 + fade out + backdrop clear | 0.2s |
| Page flip | Slide old page left, new page from right | 0.3s |

### Idle/Ambient Animations

| Element | Animation | Speed |
|---------|-----------|-------|
| Snow particles | Continuous fall + drift | 20–40px/s |
| Clouds | Drift right | 0.5px/s |
| Trees | Very subtle sway (±2°) | 3s per cycle |
| Ms. Lumi | Gentle breathing (scale Y 1.0↔1.02) | 2s per cycle |
| Primary button | Gentle pulse (scale 1.0↔1.03) | 1.5s per cycle |
| Stars (earned) | Soft glow pulse (opacity 0.7↔1.0) | 2s per cycle |
| Water/ice | Shimmer (opacity shift) | 4s per cycle |

### Parallax (Tilt-Based)

For mobile, use accelerometer data to create subtle parallax:

| Layer | Movement | Range |
|-------|----------|-------|
| Sky | None (fixed) | 0px |
| Distant mountains | Opposite to tilt | ±5px |
| Mid-ground trees | Opposite to tilt | ±12px |
| Snow ground | Slight opposite | ±3px |
| Foreground decorations | Opposite to tilt | ±20px |
| UI | Stays centered | 0px |

---

## Scene-by-Scene Environment Guide

### Scene 00 — Splash
- **Sky**: Dawn gradient (dark blue top → sky blue bottom), stars fading
- **Mountains**: 3 blue-gray silhouettes
- **Trees**: Dark pine silhouettes at edges
- **Snow**: Clean white curve
- **Special**: Logo center-screen with ice crystal burst animation
- **Particles**: Gentle snowfall + occasional sparkle

### Scene 01 — Name Entry
- **Sky**: Bright daytime blue with 2–3 white clouds
- **Mountains**: Light blue-gray, snow-capped
- **Trees**: Green Kenney pines (3 left, 2 right) with snow on branches
- **Snow**: White with sparkle dots, snowman on left side
- **Special**: Purple accent for UI panels (personalization mood)
- **Particles**: Medium snowfall
- **Character**: None (player hasn't met Ms. Lumi yet)

### Scene 02 — Teacher Welcome
- **Sky**: Clear blue with sun peeking from top-right
- **Mountains**: Same as Scene 01 for continuity
- **Trees**: Same Kenney pines
- **Snow**: White with animal footprints (from Ms. Lumi)
- **Special**: Ms. Lumi (Easy Chara "Hisa Teacher") enters from right, teal accent
- **Particles**: Light snowfall
- **Character**: Ms. Lumi center-right, speech bubble left

### Scene 03 — Level Select
- **Sky**: Warm blue transitioning to amber near horizon (sunset hint)
- **Mountains**: Warmer toned, amber highlights
- **Trees**: Mix of green pines and golden-leaved trees (Kenney)
- **Snow**: Light dusting, some grass showing through
- **Special**: 3 story cards as "trail markers" or "camp sites" along a snowy path
- **Particles**: Golden sparkles mixed with light snow
- **Character**: Ms. Lumi small in background, waving

### Scene 04 — Story Reader
- **Sky**: Soft blue-pink gradient (cozy reading light)
- **Environment**: Simplified — focus on reading. Use Cartoon UI `Panel Light` as a "book" frame
- **Trees**: Minimal, soft-focus at far edges
- **Snow**: Gentle, less prominent
- **Special**: Rose/pink accent. The story panel should look like an open storybook
- **Particles**: Floating page sparkles, very gentle snow

### Scene 05 — Mission Intro
- **Sky**: Dramatic — clouds thickening, slightly darker blue (adventure is coming!)
- **Mountains**: More prominent, closer
- **Trees**: Dense forest edges (Kenney pines packed tight)
- **Snow**: Deep, with footprints leading forward (toward the track)
- **Special**: Ms. Lumi in "coach" pose. Teal accent. Energy building.
- **Particles**: Snow picking up (more particles, slightly faster)
- **Character**: Ms. Lumi left side, large, animated gestures

### Scene 06 — 3D Run
- **Sky**: BOXOPHOBIC skybox (Blue Sky) with fog
- **Environment**: Full 3D — snowy track, Kenney 3D models, Trees Package trees
- **Special**: This is the only fully 3D scene. HUD uses Cartoon UI overlays
- **Particles**: Heavy snow (speed lines optional for sprint)
- **Mood**: Cold, exciting, urgent

### Scene 07 — Final Summary
- **Sky**: Clearing sky — clouds parting (the storm is over)
- **Mountains**: Visible again, lighter
- **Trees**: Sparse, calm
- **Snow**: Fresh, clean, undisturbed
- **Special**: Lavender accent. Reflective, calm mood. Focus on the summary panel.
- **Particles**: Very light snow, some sparkles

### Scene 08 — Victory
- **Sky**: Bright, golden-hour lighting. Warm blue + gold
- **Mountains**: Glowing with sunset light
- **Trees**: Full, healthy, swaying gently
- **Snow**: Sparkling intensely
- **Special**: Green accent. Confetti particles. Stars spinning in. Aurora borealis effect in sky.
- **Particles**: Confetti (gold, teal, pink) + sparkles + light snow
- **Character**: Ms. Lumi cheering, jumping animation

### Scene 09 — Game Complete
- **Sky**: Full aurora borealis — animated bands of green/purple/blue light
- **Mountains**: Silhouettes against the aurora
- **Trees**: Decorated (like winter festival — optional small lights)
- **Snow**: Maximum sparkle, golden tint
- **Special**: Gold accent everywhere. This is the celebration scene. Maximum particle effects.
- **Particles**: Heavy confetti rain + firework bursts + sparkles + snow
- **Character**: Ms. Lumi center, trophy/crown, biggest animation

---

## Asset Usage Map

### Cartoon UI Plugin — What to Use

| Asset Category | Specific Assets | Where Used |
|----------------|----------------|------------|
| **Buttons** | Long Round (all 10 colors) | Every scene's action buttons |
| **Buttons** | Circle / Circle Big (all colors) | Avatar selection, level select |
| **Panels** | Panel Light | Content cards, dialog boxes |
| **Panels** | Panel Brown | Secondary panels, settings |
| **Panels** | Title Bar (per-scene color) | Section headers |
| **Panels** | Victory Title Bar | Scene 08, 09 badges |
| **Panels** | Store Panel | Level select cards |
| **Icons** | fox, frog, Dog, Pig | Avatar selection (Scene 01) |
| **Icons** | Star, Star Off | Victory stars (Scene 08, 09) |
| **Icons** | Heart | Lives/health if needed |
| **Icons** | Trophy, Medal, Badge | Game Complete rewards |
| **Icons** | Gold Crown | Mastery indicator |
| **Icons** | Home, Settings | Navigation |
| **Icons** | Blue Book, Red Book, Yellow Book, Purple Book | Story/level icons |
| **White Icons** | Arrows, checkmarks, X, play, pause | HUD, navigation |
| **Progress Bars** | Type 1 (per-scene color) | Story progress, element collection |
| **Sliders** | Slider (any color) | Settings (volume, etc.) |
| **Toggles** | Toggle CheckMark or Dot | Settings (audio on/off) |
| **Customizable** | Custom Panel, Custom Button | Any themed variant |

### Kenney Nature Kit — What to Use

| Asset Category | Where Used |
|----------------|------------|
| Side-view trees (pine, snow-covered) | Scene backgrounds (layers 3, 5) |
| Side-view bushes, plants | Foreground decorations |
| Side-view houses/cabins | Scene 03 level markers |
| Side-view fences, signs | Scene decorations |
| Paths/trails | Scene 03 trail between levels |
| 3D tree models | Scene 06 (3D run track sides) |

### Trees Package Lite

| Asset | Where Used |
|-------|------------|
| 3D pine tree prefabs | Scene 06 track environment |
| 3D tree models | Scene backgrounds (3D rendered to 2D for parallax) |

### Easy Chara (Hisa Teacher = Ms. Lumi)

| Pose/State | Where Used |
|------------|------------|
| Idle | Scenes 02, 03 (background) |
| Wave | Scene 02 (greeting) |
| Talk | Scenes 02, 05 (speech) |
| Cheer/Jump | Scenes 08, 09 (celebration) |

### BOXOPHOBIC Skybox

| Asset | Where Used |
|-------|------------|
| Polyverse Skies - Blue Sky | Scene 06 (3D run) |
| Day/Night blend capability | Mood transitions |

### 2D Progress Bar Toolkit

| Asset | Where Used |
|-------|------------|
| `bar_02_candy` theme | Alternative fun progress bars |
| Circular progress | Loading states, timer displays |

---

## Recommended Additional Assets

### Must-Have (Free)

1. **DOTween (Free)** — Animation engine for all UI animations, replaces manual coroutines
   - Search: "DOTween" on Asset Store
   - Why: Easing functions, sequences, loops — makes every animation smoother with less code

2. **Snow/Winter Particle Pack** — Pre-made snowflake particle systems
   - Search: "Snow Particle" or "Winter VFX" on Asset Store
   - Why: Better than hand-built particle systems, includes wind, drift, accumulation

### Nice-to-Have (Free)

3. **Parallax Background System** — Script for layered background movement
   - Search: "2D Parallax" on Asset Store
   - Why: Handles tilt-based and scroll-based parallax automatically

4. **TextMesh Pro Animated Text** — For typewriter effects, wobbly text, rainbow text
   - Search: "Text Animator" or "Animated Text" on Asset Store
   - Why: Ms. Lumi's speech deserves personality. Letters can bounce, wave, shake.

---

## Technical Implementation Notes

### Color Theme ScriptableObject

Create `GameTheme.asset` (ScriptableObject) to centralize all colors:

```csharp
[CreateAssetMenu(fileName = "GameTheme", menuName = "SummaRace/Game Theme")]
public class GameTheme : ScriptableObject
{
    [Header("Primary Palette")]
    public Color skyDark = new Color(0.051f, 0.278f, 0.631f);    // #0D47A1
    public Color skyMid = new Color(0.259f, 0.647f, 0.961f);     // #42A5F5
    public Color skyLight = new Color(0.529f, 0.808f, 0.922f);   // #87CEEB
    public Color ice = new Color(0.878f, 0.941f, 1.0f);          // #E0F0FF
    public Color snow = Color.white;

    [Header("Feedback")]
    public Color correct = new Color(0.0f, 0.749f, 0.647f);     // #00BFA5
    public Color wrong = new Color(0.937f, 0.325f, 0.314f);      // #EF5350
    public Color highlight = new Color(1.0f, 0.843f, 0.0f);      // #FFD700

    [Header("Scene Accents")]
    public Color[] sceneAccents; // Index = scene build index
}
```

### Parallax Controller

Each 2D scene should have a `ParallaxController` that:
1. Reads accelerometer data (mobile) or mouse position (editor)
2. Moves each background layer at its designated speed
3. Handles smooth interpolation (no jitter)

### Snow Particle Prefab

Create a reusable `SnowParticles.prefab`:
- **Shape**: Box (wide, above camera)
- **Emission**: 10–30 per second (adjustable per scene)
- **Lifetime**: 5–8 seconds
- **Size**: Random 0.02–0.06
- **Speed**: Random 0.3–0.6 downward
- **Noise**: Strength 0.5, frequency 0.3 (drift effect)
- **Rotation**: Random, slow spin
- **Renderer**: Billboard, additive blending, snowflake sprite

---

## Scene Transition Spec

All scene transitions use a consistent pattern:

| Transition | Type | Duration | Details |
|------------|------|----------|---------|
| Scene → Scene | Fade through white | 0.6s total | 0.3s fade out + 0.3s fade in |
| Panel open | Scale + dim | 0.35s | Background dims to 50%, panel scales 0.8→1.0 |
| Panel close | Scale + undim | 0.2s | Reverse of open |
| Page flip | Slide | 0.3s | Old slides left, new from right |

---

## Quality Checklist (Per Scene)

Before marking any scene as "done," verify:

- [ ] Background has 5+ layers (sky, mountains, trees, snow, particles, foreground)
- [ ] All buttons use Cartoon UI sprites (no plain rectangles)
- [ ] All panels use Cartoon UI panel sprites
- [ ] Snow particles are present and falling
- [ ] Text uses Fredoka font with appropriate shadow/backdrop
- [ ] All tappable elements have bounce animation on tap
- [ ] Entrance animations are staggered (not everything at once)
- [ ] Scene accent color is applied to UI elements
- [ ] Touch targets are minimum 80×80px (kids need big targets)
- [ ] Disabled states are visually distinct (gray + 50% opacity)
- [ ] Audio feedback exists for every interaction (tap, select, confirm, error)
- [ ] Scene transitions are smooth (fade through white)

---

**End of Visual Theme Specification**
