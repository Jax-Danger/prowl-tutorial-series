# Prowl Tutorial Series — pt4-player-movement

Work branch for **Part 4** (not tagged / not on `main` until the video is final).

**Play CHECK:** a GameObject moves with WASD/arrows in the Game scene.

**Engine pin:** Prowl **1.0-preview-4**  
**Engine source:** https://github.com/ProwlEngine/Prowl  
**Start from:** tag / branch `pt3-loading-screen`

Everything you follow for an episode lives under **`Assets/`** (same tree as the Prowl project):

- `Assets/Scripts/` — C# you type or paste
- `Assets/docs/` — editor shot lists

## How to use this with two monitors

- **Left (record):** Prowl editor only.
- **Right:** this branch / the episode PR checklist. Search `TUTORIAL pt4` and tick `Assets/docs/pt4-player-movement.md` (or the PR task list).
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

Open this folder as your Prowl project root (or keep `My Prowl Game` checked out on this branch). Edit scripts only under `Assets/Scripts/`.

## What this episode adds

```
Assets/Scripts/   PlayerMovement.cs   (plus unchanged TitleScreen, LoadingScreen, SceneLoadRequest)
Assets/Prefabs/   Player              (Cube + PlayerMovement — editor only; gitignored)
Assets/docs/      pt4-player-movement.md
```

Editor click-paths for the Player prefab live in `Assets/docs/pt4-player-movement.md` (create Cube → attach script → drag into `Assets/Prefabs/`).

## Next after this

Natural follow-up named in the DONE comment: `pt5-real-load-wait` (loading that waits on a real load, not only a timer).
