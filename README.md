# OnGui readout

**Video:** coming. Part 17 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. The top-left line shows speed, `orbit` or `eye`, and the **V** / **E** hints. Walk and the speed number moves. **V** flips the view word. **F** into the car hides the line. **F** again shows it.

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
| 16 | `pt16-async-load` | `Scene.LoadAsync` and a loading line |
| 17 | `pt17-ongui` | This episode. Immediate-mode HUD |

`MonoBehaviour.OnGui(Paper)` is the immediate-mode hook. The scene calls it from `Scene.OnGui`. There is no widget left alive between frames. Part 16 already used it for `Loading N%`. This part is the gameplay line. Part 18 is the other UI: GameObjects with `GameCanvas`, `TextComponent`, and `UIButton`.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt17-ongui
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/PlayHud.cs` — search `TUTORIAL pt17`
- `Assets/Prefabs/Player.prefab` — **Play Hud** on the player

`OnGui` is `public override`. The argument is `Prowl.PaperUI.Paper`. Text takes a `Prowl.Scribe.FontFile` from `FontAsset.LoadDefault().FontFile`.

## The line

1. **Play Hud** is already on the **Player** prefab. If you add it yourself: **Add Component → Play Hud**. No fields.
2. The method reads `Player.PlanarSpeed` and `PlayerLook.ThirdPerson` and builds one string.
3. `paper.Box("hud").Margin(16).Height(28).Text(...).FontSize(18).TextColor(...)` is the whole widget. The id `hud` is how you find it in the call.
4. `VehicleRide` does not disable this component. The script returns while `Player` is disabled, so the line is absent in the car.

Do not cache the `Paper` or the box. Build them again next frame.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The white line is at the top left. Standing still shows speed `0.0`.
- **CHECK:** Walk. The number climbs. **V** changes `orbit` and `eye`.
- **CHECK:** **F** into the car. The line is gone. **F** again. It is back.
- Stop Play.
