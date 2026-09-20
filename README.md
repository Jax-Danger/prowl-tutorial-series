# Prowl Tutorial Series

Companion repo for **[Jax's Development Den](https://www.youtube.com/@Jax)** Prowl Game Engine videos.

This is **not** a full Prowl project export. Prowl scenes and prefabs live in your editor project. This repo holds the C# that those videos build, editor checklists, and `// TUTORIAL` waypoints so the next episode can be recorded against a known end state.

**Engine pin:** Prowl **1.0-preview-4** (or the tag named in Part 1).  
**Engine source:** https://github.com/ProwlEngine/Prowl

## How to use this with two monitors

- **Left (record):** Prowl editor only.
- **Right:** this repo. Search `TUTORIAL ptN` and tick the shot list in `docs/`.
- Do not skip a waypoint. Play when a comment says `CHECK`.

## Episodes

| Part | Branch (work) | Tag when video is final | Video | End state |
|------|----------------|-------------------------|-------|-----------|
| 1 Title screen | `pt1-title-screen` | `pt1-title-screen` | https://youtu.be/8oDvGU0EzT0 | Menu UI, Play hides menu, Quit does not kill the editor |
| 2 Change scenes | `pt2-change-scenes` | `pt2-change-scenes` | https://youtu.be/0omgv-6yawI | Play loads the Game scene |
| 3 Loading screen | `pt3-loading-screen` | `pt3-loading-screen` | https://youtu.be/2zhuH4vjZ6M | Title → Loading (~1.5s) → Game |

`main` tracks the **latest finished episode** (currently end of Part 3).

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt3-loading-screen
```

Copy `Scripts/` into your Prowl project's `Scripts` folder (or keep this repo beside the project and copy after each episode).

## Recording workflow

1. Start from the **previous** episode tag in Prowl (your editor project).
2. Open the matching branch here on the right monitor.
3. Follow `docs/ptN-*.md` and `// TUTORIAL ptN-##` in order.
4. When the take is the one you will upload: commit the branch, then tag the same name. **Do not move the tag.**
5. Merge or fast-forward `main` to that commit.

## What this repo cannot store

Prowl scene/prefab binaries from your machine. Recreate those with the editor steps in `docs/`. After Part 3 your project folders should look like:

```
Scenes/    Title Screen, Game, Loading Screen
Prefabs/   Title Screen
Scripts/   TitleScreen.cs, LoadingScreen.cs, SceneLoadRequest.cs
```

## Next episode

Not recorded yet. Natural follow-ups you already mentioned on camera: player movement in the Game scene, then a loading screen that waits on real load instead of only a timer.
