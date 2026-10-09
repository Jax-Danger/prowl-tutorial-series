# FPS combat

**Video:** coming. Part 20 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. A white plus is in the middle of the view. Under the ammo line, `HP 5/5`. A dark red figure stands at `(0, 0, 14)`. Walk toward it. The Console says `Hostile: hit` and the HP line counts down about once a second. Step behind a courtyard wall and the Console says `Hostile: blocked`. Shoot the figure. Each hit logs its remaining points. At 0 it disappears. Stand in the open until your HP hits 0. The line says `Down`, the plus goes away, and WASD no longer moves you. The camera still looks.

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
| 19 | `pt19-raycast-gun` | Hitscan gun, ammo, reload |
| 20 | `pt20-fps-combat` | This episode. Health, a hostile, a crosshair |
| side | `side-ball-controller` | Off Part 13. A rolling ball. Not on this line |

Prowl has no health component, no crosshair, and no hitscan weapon. Part 19 is the gun: `PhysicsWorld.Raycast` and a magazine. This part is the fight around that gun. `Health` and `CombatHud` are scripts in this repo. The hostile uses the same raycast.

The ball stays a side episode on `side-ball-controller`. It is not in this branch.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt20-fps-combat
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/Health.cs` — search `TUTORIAL pt20`
- `Assets/Scripts/HostileShooter.cs` — the figure that shoots back
- `Assets/Scripts/CombatHud.cs` — plus and HP line
- `Assets/Scripts/Gun.cs` — a hit calls `Health.TakeDamage(1)`
- `Assets/Prefabs/Player.prefab` — **Health** (5) and **Combat Hud**
- `Assets/Scenes/Game.scene` — **Hostile** at `(0, 0, 14)`

`OnGui` is `public override`. The plus is a `Paper` box stretched over the view with `TextAlignment.MiddleCenter`. `IsNotInteractable` keeps it from taking the Part 18 click.

## The fight

1. **Health** on the player: **Max Hit Points** `5`, **Disable Object On Death** off. At 0 it disables `Player` and `Gun`. The camera and `PlayerLook` stay, so you can still look.
2. **Combat Hud** on the same object. No fields. While you are alive it draws `+` and `HP n/5` under the ammo line. In the car (`Player` disabled, not dead) both hide. At 0 the plus is gone and the line says `Down`.
3. **Hostile** is at `(0, 0, 14)`, in front of the spawn at the origin. **Health** **Max Hit Points** `8`, **Disable Object On Death** on. **Hostile Shooter** **Range** `16`, **Cooldown** `1.1`, **Damage** `1`.
4. `Start` builds a 1.8 m static box. There is no `Rigidbody3D`, so a round does not shove it. The collider is what your gun hits.
5. Each cooldown the hostile aims at your chest. `PhysicsWorld.Raycast` runs from a point in front of its body to that aim point. The character controller is not a collider, so a connecting shot usually hits the ground or nothing near you. A hit more than `0.6` m short of the aim point is treated as a wall. Otherwise `Health.TakeDamage` runs.
6. It does not fire while `Player` is disabled, which is the car and also your downed state.
7. Your gun already shoves rigidbodies and ticks the crate. It now also calls `TakeDamage(1)` on a `Health` in the hit's parents. Eight hits and the hostile disables.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The plus is centered. `HP 5/5` is under the ammo line. The figure is down the Z axis.
- Walk into range in the open. **CHECK:** about once a second the Console says `Hostile: hit` and HP falls.
- Put a courtyard wall between you. **CHECK:** `Hostile: blocked`, and HP holds.
- Shoot the figure. **CHECK:** the Console counts its points down. At 0 the figure is gone.
- Let it finish you in the open. **CHECK:** `Down`, no plus, WASD does nothing, the mouse still looks.
- Stop Play.
