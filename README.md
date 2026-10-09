# Third-person orbit

**Video:** coming. Part 14 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. The camera starts behind the body. Mouse orbits. The wheel zooms. **V** snaps back to the Part 6 eye point and **V** again returns to the orbit. Walk up to a wall and the camera stops in front of it. **F** still enters the car, and the car keeps its chase camera.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin for the rest of the course.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen (timer, then `Scene.Load`) |
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
| 14 | `pt14-third-person` | This episode. Orbit camera on the player |

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt14-third-person
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

`Update` is `public override`. The orbit lives in `PlayerLook`, the same component as Part 6. There is no second camera.

- `Assets/Scripts/PlayerLook.cs` — search `TUTORIAL pt14`
- `Assets/Prefabs/Player.prefab` — **Third Person** on, orbit distance `4.5`

## The orbit

1. Open the **Player** prefab. **Player Look** already has the Part 6 fields. **Third Person** is on. **Orbit Distance** `4.5`, **Min** `1.2`, **Max** `8`, **Pivot Height** `1.45`.
2. **Pivot Height** is metres above the feet. The camera child stays the view. Its local position `(0, 1.6, 0)` is the first-person eye, stored in `Start`.
3. Yaw is still the player’s Y rotation. Pitch is still the camera’s local X, about `-80` to `80`, and mouse-up still looks up.
4. With **Third Person** on, the camera is placed at `pivot - Forward * Orbit Distance` after that pitch is applied. `Transform.Forward` is the look direction, so the body stays in frame.
5. `Scene.Physics.Raycast` runs from the pivot to that point. `PhysicsWorld.Raycast` normalizes the direction. A hit pulls the camera to `hit.Distance - 0.25`, and never closer than **Min Orbit Distance**.
6. `Input.MouseWheelDelta` changes the distance while the cursor is locked. The delta is clamped to `±2` before it is applied.
7. **V** (`KeyCode.V`) flips **Third Person**. First person writes the stored eye local position back.

`VehicleRide` disables `PlayerLook` while you are in the car, so this orbit does not fight the chase mount. Climbing out calls `MatchYawToTransform` and the orbit starts from the facing you had.

## Save and CHECK

- Save the prefab if you changed a field.
- Play from **Title Screen**, then **Play Game**.
- **CHECK:** You see the body. WASD still moves along the facing. Mouse left/right turns the body. Mouse up/down orbits.
- **CHECK:** The wheel moves in and out, and it stops at `1.2` and `8`.
- **CHECK:** Walk against a courtyard wall. The camera stays in front of the wall.
- **CHECK:** **V** is the Part 6 view. **V** again is the orbit.
- **CHECK:** **F** near the car uses the chase camera. **F** again drops you back into the orbit.
- Stop Play.
