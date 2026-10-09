# Hinge gate

**Video:** coming. Part 15 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. A wooden door stands at `(6, 0, 8)` on a vertical hinge. Walk within 3 metres and press **E**. It swings open and stops. **E** again swings it shut. The post does not move.

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
| 14 | `pt14-third-person` | Orbit camera on the player |
| 15 | `pt15-physics-joints` | This episode. A hinged door |

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt15-physics-joints
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

Prowl’s joints live under `Prowl.Runtime/Components/Physics/Constraints`. `HingeJoint` is a door hinge: a ball socket plus an angle limit, and an optional motor. An empty **Connected Body** anchors the pin to the world (`World.NullBody`), not to a second rigidbody.

- `Assets/Scripts/PhysicsGate.cs` — search `TUTORIAL pt15`
- `Assets/Scenes/Game.scene` — empty **Gate** at `(6, 0, 8)`

`Start` and `Update` are `public override`. The door is built on the first Play so the tutorial can show every field in code. The post is a mesh only. It has no collider and no body.

## The hinge

1. **Gate** is already in `Game.scene`. If you build it yourself: empty GameObject named `Gate`, **Add Component → Physics Gate**, move it to `(6, 0, 8)`.
2. **Open Speed** `2.2`, **Use Distance** `3`, **Min Angle** `-4`, **Max Angle** `95`.
3. The door is a dynamic `Rigidbody3D` with a `BoxCollider` the same size as `Mesh.CreateCube`. Mass `12`.
4. `HingeJoint` is added after the body. **Anchor** is the local `-Z` edge. **Axis** is local Y. **Has Motor** is on. **Motor Max Force** is `80`.
5. **E** (`KeyCode.E`) within **Use Distance** of the gate flips `MotorTargetVelocity` between `Open Speed` and `-Open Speed`. Within 3 degrees of the limit the speed goes back to `0`, so the motor does not grind on the limit.
6. The script ignores **E** while `Player` is disabled, which is while you are in the car.

Other joints in the same folder, not used here: `PrismaticJoint` (slider), `UniversalJoint`, `BallSocketConstraint`, `FixedAngleConstraint`, `DistanceLimitConstraint`.

## Save and CHECK

- Save the scene if you moved **Gate**.
- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The door and the grey post appear at the gate. The door does not fall over.
- **CHECK:** Farther than 3 metres, **E** does nothing.
- **CHECK:** Within 3 metres, **E** swings it open and it stops. **E** swings it shut.
- **CHECK:** The post stays put.
- Stop Play.
