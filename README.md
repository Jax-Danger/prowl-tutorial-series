# Prowl Tutorial Series — pt4-player-movement

Work branch for **Part 4** (not tagged / not on `main` until the video is final).

**Play CHECK:** a GameObject moves with WASD/arrows in the Game scene.

**Engine pin:** Prowl **1.0-preview-4**  
**Engine source:** https://github.com/ProwlEngine/Prowl  
**Start from:** tag / branch `pt3-loading-screen`

## How to use this with two monitors

- **Left (record):** Prowl editor only.
- **Right:** this branch. Search `TUTORIAL pt4` and tick `docs/pt4-player-movement.md`.
- Do not skip a waypoint. Play when a comment says `CHECK`.

## Episodes

| Part | Branch (work) | Tag when video is final | Video | End state |
|------|----------------|-------------------------|-------|-----------|
| 1 Title screen | `pt1-title-screen` | `pt1-title-screen` | https://youtu.be/8oDvGU0EzT0 | Menu UI, Play hides menu, Quit does not kill the editor |
| 2 Change scenes | `pt2-change-scenes` | `pt2-change-scenes` | https://youtu.be/0omgv-6yawI | Play loads the Game scene |
| 3 Loading screen | `pt3-loading-screen` | `pt3-loading-screen` | https://youtu.be/2zhuH4vjZ6M | Title → Loading (~1.5s) → Game |
| 4 Player movement | `pt4-player-movement` | `pt4-player-movement` | *(TBD)* | WASD/arrows move Player in Game |

`main` still tracks **Part 3** until Part 4 is recorded and tagged.

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt4-player-movement
```

Copy `Scripts/` into your Prowl project's `Scripts` folder.

## What this episode adds

```
Scripts/   PlayerMovement.cs   (plus unchanged TitleScreen, LoadingScreen, SceneLoadRequest)
Prefabs/   Player              (Cube + PlayerMovement — created in the editor; not stored in this repo)
docs/      pt4-player-movement.md
```

Editor click-paths for the Player prefab live in `docs/pt4-player-movement.md` (create Cube → attach script → drag into `Prefabs/`).

## Next after this

Natural follow-up named in the DONE comment: `pt5-real-load-wait` (loading that waits on a real load, not only a timer).
