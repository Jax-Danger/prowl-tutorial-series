# Raycast gun

**Video:** coming. Part 19 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. The corner under the speed line shows `12/12`. Hold the left mouse button. The count falls and the Console logs hits. Shoot the red crate at `(3, 0, 4)`. It shoves, the Console counts down, and on the third hit the crate disables. **R** fills the magazine after one second. The door takes a shove too. **Escape** and the button still clicks without firing.

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
| 17 | `pt17-ongui` | Immediate-mode speed line |
| 18 | `pt18-game-ui` | Canvas, text, and a button |
| 19 | `pt19-raycast-gun` | This episode. Hitscan gun, ammo, reload |

This is the gun episode and the FPS slice of the course: a camera ray, a magazine, a reload, and a target that takes hits. It stays on the player from Part 14, so **V** still switches the muzzle between the orbit camera and the eye point.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt19-raycast-gun
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/Gun.cs` — search `TUTORIAL pt19`
- `Assets/Scripts/PracticeCrate.cs` — the box that counts hits
- `Assets/Prefabs/Player.prefab` — **Gun**
- `Assets/Scenes/Game.scene` — empty **Crate** at `(3, 0, 4)`

`PhysicsWorld.Raycast(origin, direction, maxDistance, out hit)` is the cast. `RaycastHit` carries `Point`, `Distance`, `Normal`, `Rigidbody`, `Collider`, and `Transform`. `AddForceAtPosition` with `ForceMode.Impulse` is the shove.

## The gun

1. **Gun** is on the **Player** prefab. **Magazine Size** `12`, **Fire Cooldown** `0.12`, **Reload Seconds** `1`, **Range** `50`, **Hit Impulse** `6`.
2. The ray starts at the camera child’s position and runs along `Transform.Forward` for **Range** metres. Third person and first person both use that camera, so the muzzle follows **V**.
3. Hold the left mouse button while the cursor is locked. Each shot subtracts one round and waits **Fire Cooldown**. At `0` the gun waits for **R**.
4. **R** (`KeyCode.R`) starts the reload only when the magazine is not full. `OnGui` says `Reloading` until the timer ends, then the count is full again.
5. A hit with a `Rigidbody3D` gets an impulse along the ray at `hit.Point`. The door from Part 15 is one of those bodies.
6. `PracticeCrate` on the parent of the box handles `TakeHit`. Three hits disable the object. The collider is on the child, so the gun uses `GetComponentInParent`.
7. The ammo line is a second `OnGui`, placed at `(16, 48)` so it sits under the Part 17 speed line. It hides while `Player` is disabled in the car.
8. The cursor has to be locked. **Escape** unlocks it for the Part 18 button, and the gun does not fire on that click.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** `12/12` is under the speed line.
- Hold fire at the red crate. **CHECK:** it moves, the Console counts `2`, `1`, `down`, and the crate disappears. The ammo count drops.
- **CHECK:** Empty the magazine. Fire does nothing. **R** shows `Reloading`, then `12/12`.
- Shoot the door. **CHECK:** it shoves, and the Console names the hit.
- **Escape**, click **Toggle**. **CHECK:** the door still toggles and the gun does not spend a round on that click.
- Stop Play.
