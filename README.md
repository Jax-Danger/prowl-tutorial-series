# Blender map

**Video:** coming. Part 10 does not have a public URL yet.

**Play CHECK:** `Assets/Maps/Courtyard.gltf` is already in the project. Drag it onto the **Courtyard** object (the one with **Map Colliders**), disable **Floor**, then Play from **Title Screen**. You stand on the slab. Walking and driving stop at the walls. The gates on the north and south sides let the car out. With nothing parented under **Courtyard**, **Map Colliders** does nothing and the old plane still holds you.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin.

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
| 10 | `pt10-blender-map` | This episode. A level mesh and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |

Prerequisite: Part 9 plays (walk, **F** to drive, **F** to get out).

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt10-blender-map
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Maps/Courtyard.gltf` and `Courtyard.bin` — a 40 m courtyard made for this episode. Gates face **+Z** and **-Z**. A block sits inside
- `Assets/Scripts/MapColliders.cs` — search `TUTORIAL pt10`
- `Assets/Scenes/Game.scene` — empty **Courtyard** with **Map Colliders**. **Floor** is still enabled until you turn it off

Prowl imports `.gltf`, `.glb`, `.fbx`, and `.obj` (`EditorModelImporter`). The importer’s game preset converts the file into left-handed, Y-up, **+Z** forward (`PostProcessFlags.ConvertCoordinateSystem` in Clay). glTF is already Y-up and right-handed, which is the format that conversion expects. glTF UVs are flipped on import. FBX and OBJ UVs are not.

`Update` is not used here. `Start` is `public override`.

## Export from Blender

Skip this if you are using the committed courtyard. Come back when you want your own level.

1. Model in metres. A wall of 3 is 3 metres.
2. Select the level. **Ctrl+A → Apply → All Transforms**. Scale must be 1 before export, or the collider and the mesh disagree.
3. **File → Export → glTF 2.0 (.gltf/.glb)**.
4. Format: **glTF Separate** (`.gltf` + `.bin`) or **glTF Binary** (`.glb`). Both import.
5. Include the mesh. Turn off cameras and lights in the exporter if it offers that. Prowl’s importer can also drop them.
6. **Apply Modifiers** on.
7. The glTF exporter writes **+Y up**. You do not flip the axis yourself. Blender’s Z-up is converted by the exporter.
8. Save into `Assets/Maps/`.

FBX works too: **File → Export → FBX**, **Apply Transform** on, scale 1. Prefer glTF for this episode so the axis story matches the file in the repo.

## Import

1. Open the project. Wait until `Courtyard.gltf` finishes importing.
2. Select it. On the **Model** tab set **Unit Scale** to `1`. Turn **Import Cameras** off and **Import Lights** off.
3. Open `Assets/Scenes/Game.scene`.
4. Drag the imported model onto **Courtyard** in the Hierarchy. Local position `0, 0, 0`. Local scale `1, 1, 1`.
5. **Courtyard** already has **Map Colliders**. If you built the object yourself: **GameObject → Empty Object**, name it `Courtyard`, **Add Component → Map Colliders**, then parent the model under it.
6. Select **Floor** and disable it (the checkbox at the top of the Inspector). The slab’s top is `y = 0`, the same height as the old plane. Leaving both on z-fights.
7. Save the scene.

## What the script does

`MapColliders.Start` walks child `MeshRenderer`s. If that object has no `MeshCollider`, it adds one and assigns `MeshRenderer.Mesh`. **Convex** stays off. A convex hull would seal the gates. A concave mesh on a moving rigidbody logs a warning and approximates inertia. This level has no rigidbody, so the triangles stay triangles.

A missing mesh is skipped. An empty **Courtyard** does not throw.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** You stand on the courtyard, not on a falling void.
- **CHECK:** Walk into a wall. The capsule stops.
- **CHECK:** **F**, drive into a wall. The car stops. Drive out a gate. Both ends of the court have a gap, so a mirrored import still has an exit.
- **CHECK:** The block near `(8, 0, 8)` stops the car.
- **CHECK:** Clear the model from **Courtyard**, turn **Floor** back on, Play. You are on the plane again and the Console stays clear.
- Stop Play.
