# Part 12 — Terrain

Branch `pt12-terrain`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The courtyard ends in empty space. I’m adding a terrain next to it, flat in the file, and a script that grows a few hills the first time you press Play. If you paint the heightmap, the script leaves it alone. No terrain data file is committed. The editor writes it when you add the object.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Menu GameObject, 3D Object, Terrain.

### 3
Position 24, 0, minus 20. That sits it beside the courtyard instead of under the player’s feet.

### 4
On the Terrain component, open the Settings tab.

### 5
Dimensions, Terrain Size 64. Terrain Height 24. Sixty-four metres on a side. Height 24 is the range the 0-to-1 heightmap maps into.

### 6
Resolutions, Heightmap 65.

### 7
The dialog Reset Heightmap: confirm it. Changing the resolution wipes the heights. That’s also the signal our script uses. A wiped map is all zeros.

### 8
Add Component, Terrain Seed.

### 9
On the Inspector rail, click Sculpt.

### 10
On the Scene view toolbar, click Raise.

### 11
Brush Size 5.

### 12
In the Scene view, left-drag on the terrain. You’re painting height. The seed script will see that and refuse to overwrite it.

### 13
Ctrl+S. If a second dialog asks to save the terrain data asset, save it. That `.terraindata` stays local. It isn’t in the repo.

## Play

### 1
Double-click the title scene.

### 2
Play. Click the Game view. Click Play Game.

### 3
Walk off the courtyard onto the terrain. The ground rises. You do not fall through. The terrain collider comes with the terrain object.

### 4
Press F. Drive onto the terrain. The wheels stay on it.

### 5
Stop.

### 6
In the Scene view, Raise a ridge. Play again. The ridge is still there. The seed saw a height above zero and returned.

### 7
Stop.

## Code on screen

Drop these on the cuts where `TerrainSeed.cs` is up. They are not extra README steps.

### The flat check
Start gets the `TerrainComponent` and its data. `GetHeight` is 0 to 1. We walk every sample. If any one is above a thousandth, we return. Resize Heightmap in the inspector wipes this to zero and asks you to confirm. We only stamp hills while every sample is still that flat.

### The stamp
A couple of sine waves plus a gaussian hill around U 0.35, V 0.62. Negative heights get clamped to zero. `SetHeight` writes each sample.

### Dirty
`SetHeight` already marks the map dirty. `SetHeightmapDirty` bumps the version the renderer watches, so the picture matches the collider.

## Outro

Like and subscribe if you didn’t fall through the hill. Next time we bake a navmesh over this and let a cube wander it, and chase you when you get close.
