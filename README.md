# Side — Blender scene

YouTube: https://www.youtube.com/watch?v=VIDEO_ID

CHECK:

1. Walk into **Wall_Front**. The capsule stops.
2. Walk up the ramp toward **+Z**. You stay on the slope.
3. Stairs on your left (**−X**) step up. No jump.
4. Platform on your right (**+X**). **Space** lands on the top.
5. You do not fall through the floor.

Branch: `side-blender-scene`. Base: `pt7-update-prowl`. Not on the main line. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout side-blender-scene
```

Use the Part 7 editor (`baa86a4417f63c3a6dd98c513963c6ab22693601`). Copy `Assets/Maps/` and `Assets/Scripts/MapColliders.cs` into that project if the editor is already open on Part 7.

## Files

- `Assets/Maps/BlenderLevel.glb` — the level from the steps below. Skip sections 1 and 2 if you are not in Blender.
- `Assets/Scripts/MapColliders.cs` — search `TUTORIAL side-blender`

## 1. Blender

Blender **4.5 LTS**. The same export labels are in the 4.5 manual. On 4.2 the Transform checkbox is **+Y Up**.

1 Blender unit = 1 metre.

1. Properties → **Scene** → **Units**. **Unit System**: Metric. **Unit Scale**: `1`. **Length**: Meters.
2. **Shift+S** → **Cursor to World Origin**. **N** → **View** → **3D Cursor** Location `0`, `0`, `0`.
3. Shift-click **Cube**, **Light**, and **Camera**. **X** → **Delete**.

### Floor

1. **Shift+A** → **Mesh** → **Plane**.
2. Outliner: double-click `Plane`. Rename `Floor`.
3. **N** → **Item**. Location `0`, `0`, `0`. Scale `10`, `10`, `1`.
4. **Ctrl+A** → **All Transforms**. Scale is `1`, `1`, `1`. Dimensions are `20`, `20`, `0`.
5. **Tab**. **A**. **E**, **Z**, `-0.2`, Enter. **Tab**.
6. The top is still Z = `0`. The slab is 0.2 m thick.

### Walls

Bottom of each wall is Z = `0`. Location Z is half the height.

1. **Shift+A** → **Mesh** → **Cube**. Rename `Wall_Front`.
2. **N** → **Item**. Dimensions `7`, `0.4`, `3`. Location `0`, `-8.2`, `1.5`.
3. **Shift+A** → **Mesh** → **Cube**. Rename `Wall_A`.
4. Dimensions `0.4`, `11`, `2.5`. Location `7.8`, `-1.5`, `1.25`.
5. **Shift+A** → **Mesh** → **Cube**. Rename `Wall_B`.
6. Dimensions `0.4`, `8`, `2.5`. Location `-7.8`, `-2`, `1.25`.

### Ramp

A wedge. Low edge on the floor at Y = `-1.5`. High edge at Y = `-5.5`, Z = `1.2` (about 17°). Flat top back to Y = `-6.8`.

1. **Shift+A** → **Mesh** → **Cube**. Rename `Ramp`.
2. **N** → **Item**. Location `0`, `0`, `0`. Rotation `0`, `0`, `0`. Scale `1`, `1`, `1`.
3. **Tab**. Header: **Vertex** select (or press `1`). **Alt+Z** (X-Ray).
4. Click one corner. **N** → **Item** shows that corner. Type the new X Y Z. Repeat for all eight.

| Now | Set to |
| --- | --- |
| `-1, -1, -1` | `-1.5, -1.5, 0` |
| `1, -1, -1` | `1.5, -1.5, 0` |
| `-1, -1, 1` | `-1.5, -5.5, 1.2` |
| `1, -1, 1` | `1.5, -5.5, 1.2` |
| `-1, 1, 1` | `-1.5, -6.8, 1.2` |
| `1, 1, 1` | `1.5, -6.8, 1.2` |
| `-1, 1, -1` | `-1.5, -6.8, 0` |
| `1, 1, -1` | `1.5, -6.8, 0` |

5. **Tab**.

### Stairs

Each rise is 0.25 m. Tread is 0.6 m. The top step is 1.0 m deep. Bottom of each box is Z = `0`.

1. **Shift+A** → **Mesh** → **Cube**. Rename `Stair_1`. Dimensions `3`, `0.6`, `0.25`. Location `5`, `-1.8`, `0.125`.
2. **Shift+A** → **Mesh** → **Cube**. Rename `Stair_2`. Dimensions `3`, `0.6`, `0.5`. Location `5`, `-2.4`, `0.25`.
3. **Shift+A** → **Mesh** → **Cube**. Rename `Stair_3`. Dimensions `3`, `0.6`, `0.75`. Location `5`, `-3`, `0.375`.
4. **Shift+A** → **Mesh** → **Cube**. Rename `Stair_4`. Dimensions `3`, `1`, `1`. Location `5`, `-3.8`, `0.5`.

### Platform

1. **Shift+A** → **Mesh** → **Cube**. Rename `Platform`.
2. Dimensions `3`, `2.4`, `0.9`. Location `-5`, `-3`, `0.45`.
3. The top is at Z = `0.9`.

### Materials

1. Hold **Z** → **Material Preview**.
2. Click **Floor**. Properties → **Material** (red sphere) → **New**. Rename `Floor`.
3. **Base Color** → **Hex** `7A8A72`. **Metallic** `0`. **Roughness** `0.85`.
4. Click **Wall_Front**. **New**. Rename `Wall`. Hex `C46A5C`. Metallic `0`. Roughness `0.85`.
5. Click **Wall_A**. Material → the ball to the left of **New** → `Wall`.
6. Click **Wall_B**. Same. Pick `Wall`.
7. Click **Ramp**. **New**. Rename `Ramp`. Hex `5B94C4`. Metallic `0`. Roughness `0.85`.
8. Click **Stair_1**. **New**. Rename `Stair`. Hex `E0B44A`. Metallic `0`. Roughness `0.85`.
9. **Stair_2**, **Stair_3**, **Stair_4**: pick `Stair`.
10. Click **Platform**. **New**. Rename `Platform`. Hex `9A62C2`. Metallic `0`. Roughness `0.85`.
11. Leave **Backface Culling** off.

### Apply and origin

1. Viewport: **A** (every mesh).
2. **Ctrl+A** → **All Transforms**.
3. **N** → **Item**. Rotation `0`, `0`, `0`. Scale `1`, `1`, `1`. Locations stay.
4. **Floor** Location is still `0`, `0`, `0`. That is the level origin.
5. Do not use **Object → Set Origin → Origin to 3D Cursor**.

## 2. Export

Use **glTF Binary (.glb)**. Prowl imports `.gltf`, `.glb`, `.obj`, and `.fbx` through the same model importer. glTF is metres and Y-up. `.glb` is one file, and images pack into it. Blender FBX is centimeters, and only two axis setups are converted cleanly. This level does not need FBX.

1. Viewport: **A**.
2. **File → Import/Export → glTF 2.0 (.glb, .gltf)**.
3. Folder: the project `Assets/Maps/`. Name: `BlenderLevel.glb`.
4. **Format**: glTF Binary (`.glb`).
5. **Include → Selected Objects**: on.
6. **Include → Visible Objects**: on.
7. **Include → Cameras**: off.
8. **Include → Punctual Lights**: off.
9. **Transform → Y Up**: on. (4.2 label: **+Y Up**.)
10. **Data → Mesh → Apply Modifiers**: on.
11. **Data → Mesh → UVs**: on. **Normals**: on.
12. **Data → Material → Materials**: Export.
13. **Data → Material → Images**: Automatic.
14. **Data → Compression**: off. No Draco.
15. **Animation → Animations**: off.
16. **Export glTF 2.0**.

## 3. Prowl import

Clay turns the file from right-handed Y-up into left-handed Y-up, **+Z** forward, by negating X. Blender **+X** lands on Prowl **−X**. **+Z** in Prowl is Blender **−Y** (the way the ramp climbs).

After import, in metres:

| Object | Where it sits |
| --- | --- |
| Floor | 20×20, top at Y = 0, centered on the origin |
| Wall_Front | Z = 8.0 to 8.4, 3 m tall |
| Wall_A | your left, X = −8 to −7.6 |
| Wall_B | your right, X = 7.6 to 8 |
| Ramp | X = −1.5 to 1.5, slope from Z = 1.5 at the floor up to Z = 5.5 at Y = 1.2, flat top to Z = 6.8 |
| Stair_1..4 | your left, X = −6.5 to −3.5, tops at 0.25, 0.50, 0.75, 1.0 |
| Platform | your right, X = 3.5 to 6.5, Z = 1.8 to 4.2, top at 0.9 |

1. **Project**: click `Assets/Maps/BlenderLevel.glb`. Wait until the import finishes.
2. Inspector → **Model**. **Unit Scale**: `1`.
3. **Import Cameras**: off. **Import Lights**: off.
4. **Merge Sibling Meshes**: off.
5. If **Apply** is showing, click **Apply**.
6. Expand the file. One mesh and one material per object.
7. **Project**: double-click `Assets/Scenes/Game.scene`.
8. Drag `BlenderLevel.glb` into the Hierarchy.
9. Click **BlenderLevel**. Inspector → **Transform**. **Local Position** `0`, `0`, `0`. **Local Rotation** `0`, `0`, `0`. **Local Scale** `1`, `1`, `1`.
10. Children: `Floor`, `Wall_Front`, `Wall_A`, `Wall_B`, `Ramp`, `Stair_1`, `Stair_2`, `Stair_3`, `Stair_4`, `Platform`.
11. Hierarchy: click the **Floor** that is not under **BlenderLevel**. Inspector: uncheck the enable box at the top.
12. Ctrl+S.

## 4. Mesh collider

Do the clicks **or** the script. The script skips a mesh that already has one.

Triangles are one-sided. **Convex** off uses those triangles, so the slope you see is the surface you stand on. **Convex** on wraps a hull around the mesh. A hull on one ramp is close to the ramp. A hull on a whole level fills the space you walk in.

The player capsule walks a slope up to **55°**. This ramp is about **17°**. Stairs are **0.25 m**. The step height is **0.3 m**, so they step up. The platform is **0.9 m**, so it does not. **Space** uses jump speed `8` and gravity `-20`, which clears about **1.6 m**.

### Each mesh

1. Expand **BlenderLevel**.
2. Click a child (`Floor`, then each wall, `Ramp`, each stair, `Platform`).
3. Inspector → **Add Component → Physics → Colliders → Mesh Collider**.
4. **Mesh** fills from the **Mesh Renderer** on that object. If the slot is empty, you clicked **BlenderLevel**. Click a child.
5. **Convex**: off.
6. **Center** `0`, `0`, `0`. **Rotation** `0`, `0`, `0`.
7. Repeat for all 10 children.
8. Ctrl+S.

### Or one component

1. Click **BlenderLevel**.
2. Inspector → **Add Component → Physics → Map Colliders**.
3. Ctrl+S.
4. The colliders are added when **Play** starts.

## 5. Play

1. Hierarchy: if **Player** is missing, drag `Assets/Prefabs/Player.prefab` in.
2. Click **Player**. **Transform** Position `0`, `0.2`, `0`.
3. Ctrl+S.
4. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
5. Toolbar: **Play**.
6. **Game** view: click once.
7. Click **Play Game**.
8. WASD. Walk forward into **Wall_Front**. You stop.
9. Walk up the blue ramp, toward **+Z**.
10. Turn left. Walk up the yellow stairs. No jump.
11. Turn right. **Space** onto the purple platform.
12. Toolbar: **Stop**.

The CHECK at the top passes.

## 6. Troubleshooting

1. **Huge or tiny.** **N** → Scale is not `1`. **Ctrl+A → All Transforms**, export again. Inspector **Unit Scale** stays `1`, then **Apply**. glTF is metres. FBX from Blender is centimeters, and the importer already scales that by `0.01`. Do not set **Unit Scale** to `0.01` on an FBX on top of that. This video uses glTF.
2. **On its side.** **Y Up** was off. Clay treats every glTF as Y-up. Blender is Z-up, so the floor stands up. Export again with **Y Up** on.
3. **Left and right swapped.** Expected. The import negates X. **Wall_A** (Blender +X) is on your left. A 90° turn is section 2, not this.
4. **Faces missing.** Edit Mode, **A**, **Shift+N** (**Mesh → Normals → Recalculate Outside**). Export again. Backface Culling on in Blender writes a single-sided material, and Prowl draws that with the single-sided Standard shader. Culling off (the default) draws both sides, so a flipped floor can still be visible.
5. **Fall through.** The collider is missing, it is on **BlenderLevel** (that object has no mesh; Console: `MeshCollider: no mesh assigned.`), **Convex** is on, or the normals point the wrong way. Triangle colliders reject the back face, so a floor whose normals point down is a hole even when the material draws both sides. **Shift+N**, **Convex** off, collider on each mesh child. The old **Floor** must be disabled or you are standing on that instead.
6. **Textures missing or import fails.** This file is base color only. No png. An Image Texture exported as glTF Separate needs that image under `Assets/` next to the `.gltf`. `.glb` with **Images: Automatic** packs it. Console: `[Clay] Failed to load external texture`. Draco or meshopt compression is refused. **Data → Compression** off, export again.
