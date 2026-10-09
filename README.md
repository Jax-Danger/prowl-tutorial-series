# Terrain

**Video:** coming. Part 12 does not have a public URL yet.

**Play CHECK:** After the editor steps, Play from **Title Screen**, then **Play Game**. Walk off the courtyard onto the terrain. The ground rises under you. The car rolls on it. Paint a hill, Play again, and that paint is still there. With no **Terrain** in the scene, nothing in this episode throws.

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
| 12 | `pt12-terrain` | This episode. Heightmap terrain |

Prerequisite: Part 11 plays (sun turns, you can walk).

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt12-terrain
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

Prowl has a terrain system. It is not a stand-in mesh. `TerrainComponent` (`Prowl.Runtime/Components/Terrain/TerrainComponent.cs`, menu **Terrain / Terrain**) reads a `TerrainData` asset (`.terraindata`). `TerrainCollider` (`Prowl.Runtime/Components/Physics/TerrainCollider.cs`) samples that same heightmap. The corner of the terrain is its local origin. Size extends along **+X** and **+Z**.

This branch does not commit a `.terraindata` file. The editor creates that asset when you add the object. `TerrainSeed` does nothing until that asset exists, and it does nothing if any sample is already above zero.

- `Assets/Scripts/TerrainSeed.cs` — search `TUTORIAL pt12`

`Start` is `public override`.

## Create the terrain

1. Open `Assets/Scenes/Game.scene`.
2. **GameObject → 3D Object → Terrain**.
3. That creates a **Terrain** component, assigns the built-in terrain material, adds a **Terrain Collider**, and writes `New Terrain Data.terraindata` under Assets.
4. The new object sits on the origin, which is the courtyard. Move it to `24, 0, -20`. Local `(0, 0, 0)` is a corner, not the centre. From there a size of 64 covers `x = 24..88` and `z = -20..44`, beside the 40 m court.
5. Select the **Terrain Data** asset (or the **Settings** tab on the Terrain inspector).
6. **Dimensions → Terrain Size** `64`. **Terrain Height** `24`.
7. **Resolutions → Heightmap** `65`. The dialog is **Reset Heightmap?** and it says changing the resolution resets all height data. Confirm it. Do this before you paint.
8. **Add Component → Terrain Seed**.

## Paint

9. Select the Terrain. The inspector rail is **Sculpt**, **Paint**, **Holes**, **Details**, **Trees**, **Settings**. Sculpt is the Height tab.
10. The scene-view tools are **Raise**, **Lower**, **Flatten**, **Smooth**. Raise is the arrow up.
11. Left-drag on the terrain in the scene view. The brush raises the heightmap. **Brush Size** starts at `5`.
12. Save the scene and the terrain data asset.

## What the script does

`TerrainSeed.Start` returns if `Data` is missing. It returns if any `GetHeight` sample is above `0.001`. Otherwise it writes a low wave and one hill with `SetHeight` (values are `0..1`, multiplied by **Terrain Height** in the world) and calls `SetHeightmapDirty`. A later Play after you have painted does not stamp over your work. Resizing the heightmap allocates a new zeroed map, so the next Play seeds again.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The terrain beside the court is not a flat sheet. A hill sits toward the middle of it.
- **CHECK:** Walk onto it. The capsule follows the slope. You do not fall through.
- **CHECK:** **F**, drive onto it. The wheels stay on the surface.
- **CHECK:** Stop Play. Raise a ridge with the brush. Play again. The ridge is still there, and you did not get a second copy of the scripted hill on top of it.
- **CHECK:** Delete the Terrain object. Play. The courtyard (or the plane) is unchanged and the Console stays clear.
- Stop Play.
