# Async scene load

**Video:** coming. Part 16 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and press **Play Game**. The loading scene stays up for at least 1.5 seconds and draws `Loading N%`. The game scene appears after the preload reports `1` and that minimum time has passed. The title screen is gone.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin for the rest of the course.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen. A timer, then blocking `Scene.Load` |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Courtyard mesh and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |
| 13 | `pt13-navmesh-wander` | Baked navmesh, wander, and chase |
| 14 | `pt14-third-person` | Orbit camera on the player |
| 15 | `pt15-physics-joints` | A hinged door |
| 16 | `pt16-async-load` | This episode. `Scene.LoadAsync` |

Part 3 is not async. `LoadingScreen` counted `minDisplaySeconds` and then called `Scene.Load(SceneAsset)`. `Scene.Load` runs `AssetDatabase.Preload` and `Wait()` on the main thread, then queues the swap for the end of the frame. The bar in the old episode was a timer, not load progress.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt16-async-load
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

`Scene.LoadAsync(SceneAsset)` is `Prowl.Runtime/Resources/Scene.cs`. It returns a `SceneLoad`. The current scene keeps running. The engine calls `Scene.ProcessPendingLoad` once a frame and swaps when `IsReady` is true: the preload group is done and `WaitForActivation` is off. `Allow()` clears the wait. `Progress` is `0..1` by asset size. `IsDone` becomes true only after `Activate`, so a loading screen that waits on `IsDone` never calls `Allow`.

- `Assets/Scripts/LoadingScreen.cs` — search `TUTORIAL pt16`
- The title button still writes `SceneLoadRequest.Destination`. That part did not change.

`Update` and `OnGui` are `public override`. `OnGui` receives a `Prowl.PaperUI.Paper`.

## The load

1. Open `Assets/Scripts/LoadingScreen.cs`. The destination is still `SceneLoadRequest.Destination.Load()`, the `SceneAsset` Part 7 switched to.
2. `Scene.LoadAsync(next)` starts the preload. `WaitForActivation = true` keeps this scene on screen after the assets are ready.
3. When `elapsed` reaches **Min Display Seconds** (`1.5`) and `Progress` is at least `1`, call `Allow()`. The swap happens at the end of that frame.
4. `OnGui` draws `Loading N%` with `paper.Box(...).Text(...)`. The font is `FontAsset.LoadDefault().FontFile`.

A second `LoadAsync` cancels the one in flight. Do not also call `Scene.Load` for the same click.

## Save and CHECK

- Play from **Title Screen**.
- Press **Play Game**.
- **CHECK:** The loading scene stays at least 1.5 seconds. The percent text updates. Then `Game` is current.
- **CHECK:** The Console does not say the destination is missing.
- Stop Play.
