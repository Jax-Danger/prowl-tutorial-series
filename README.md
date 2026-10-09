# Navmesh wander

**Video:** coming. Part 13 does not have a public URL yet.

**Play CHECK:** Bake the navmesh, then Play from **Title Screen** and **Play Game**. The cube at `(0, 0.2, 10)` walks to new points on the mesh. Walk within 6 metres and it follows you. Walk away and it picks a wander point again. With **Nav Mesh Data** empty, the cube stays where it is and the Console stays clear.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin for the rest of the course.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Courtyard mesh and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |
| 13 | `pt13-navmesh-wander` | This episode. Baked navmesh, wander, and chase |

Prerequisite: Part 12 plays, or at least a ground mesh from Part 10. The bake reads whatever render meshes and terrain are in `Game.scene` when you click the button.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt13-navmesh-wander
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

Prowl’s navigation is Recast and Detour through the `Prowl.Recast` package. The runtime types are `NavMeshSurface`, `NavMeshAgent`, and `NavMeshData` (a `.navmesh` asset). Path queries go through `NavMeshWorld` on the scene. This branch does not commit a `.navmesh` file. The bake depends on your courtyard and your painted terrain, so you bake it in the editor.

- `Assets/Scripts/NavWanderer.cs` — search `TUTORIAL pt13`
- `Assets/Scenes/Game.scene` — empty **NavMesh** with **NavMesh Surface**, and **Wanderer** (agent, script, cube)
- `Assets/Prefabs/Player.prefab` and `Car.prefab` — **NavMesh Modifier** with **Ignore From Build** on, so a bake does not stamp a hole where they stood

`Update` is `public override`.

## Bake

1. Open `Assets/Scenes/Game.scene`.
2. Parent the courtyard under **Courtyard** if you have not yet, and leave the **Terrain** where Part 12 put it (`24, 0, -20`). The bake only sees objects that exist when you click it. Move them, then bake again.
3. Select **NavMesh**. **Add Component → Navigation → NavMesh Surface** if this branch’s component is not already there.
4. **Agent Type** **Humanoid**. **Collect Objects** **All**. **Use Geometry** **Render Meshes**. Render meshes are what you see, including `MeshRenderer`s. Terrain is collected from its heightmap in either geometry mode (`NavMeshGeometryCollector`).
5. **Player** and **Car** already have **Navigation → NavMesh Modifier**, **Ignore From Build** on, **Apply To Children** on. An object with a **NavMesh Agent** is skipped on its own. The player and the car are not agents, so the modifier is what keeps them out of the voxelization.
6. In the **Baking** header, click **Bake NavMesh**. Edit mode runs the bake in the background and writes a `.navmesh` next to the scene, then assigns **Nav Mesh Data**. The status line counts up while it runs. **Clear** throws that asset reference away.
7. One enabled surface per agent type. A second Humanoid surface is ignored. The inspector says so.
8. Agent size for the bake is the Humanoid row, not the component’s Radius. **Edit → Project Settings...**, page **Navigation**. Humanoid defaults are radius `0.5`, height `2`, max slope `45`. The courtyard gates are wider than that.

During Play, the same **Bake NavMesh** button calls `NavMeshSurface.BuildNavMesh()` and keeps the result in memory only.

## The wanderer

9. **Wanderer** is already in the scene at `(0, 0.2, 10)`, with a cube child **Body**. If you build it yourself: **GameObject → 3D Object → Cube**, name the root `Wanderer`, **Add Component → Navigation → NavMesh Agent**, then **Add Component → Nav Wanderer**.
10. On the agent: **Speed** `2.2`, **Stopping Distance** `0.2`, **Update Position** and **Update Rotation** on. **Agent Type** **Humanoid**, the same type as the surface.
11. On **Nav Wanderer**: **Wander Radius** `16`, **Chase Distance** `6`, **Repath Seconds** `0.35`.

`SetRandomDestination` asks Detour for a random point within that radius that is connected to where the agent stands, then calls `SetDestination`. `HasArrived` stays true until the next destination. While you are inside **Chase Distance** on the ground plane, `SamplePosition` snaps your position onto the mesh and `SetDestination` follows it. `IsOnNavMesh` is false until a surface with tiles is enabled, and the script returns before any of those calls.

## Save and CHECK

- Save the scene after the bake finishes and **Nav Mesh Data** points at the new asset.
- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The cube walks, stops, and walks somewhere else. It does not cut through the courtyard walls.
- **CHECK:** If the terrain was in the scene at bake time, the cube can walk onto it.
- **CHECK:** Walk within 6 metres. The cube turns and follows. Walk away. It picks a wander point again.
- **CHECK:** Clear the navmesh, Play. The cube does not move and the Console stays clear.
- Stop Play.
