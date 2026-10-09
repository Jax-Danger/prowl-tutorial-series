# Part 10 — Courtyard

Branch: `pt10-blender-map`. Previous: `pt9-vehicle`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt10-blender-map
```

## Files

- `Assets/Maps/Courtyard.gltf` and `Courtyard.bin`
- `Assets/Scripts/MapColliders.cs` — search `TUTORIAL pt10`
- `Assets/Scenes/Game.scene` — **Courtyard** already has **Map Colliders**

## Own mesh (skip if you use the file in the repo)

1. Blender: model in metres.
2. Select the level. **Ctrl+A → Apply → All Transforms**. Scale is `1`.
3. Menu **File → Export → glTF 2.0**.
4. Format: **glTF Separate**.
5. **Apply Modifiers**: on. Cameras and lights: off.
6. Save into the project `Assets/Maps/`.

## Import

1. **Project**: click `Courtyard.gltf`. Wait until the import finishes.
2. Inspector → **Model** → **Unit Scale**: `1`.
3. **Import Cameras**: off. **Import Lights**: off.
4. **Project**: double-click `Assets/Scenes/Game.scene`.
5. Drag the imported model onto Hierarchy **Courtyard**.
6. Inspector → **Transform** → **Local Position**: `0`, `0`, `0`. **Local Scale**: `1`, `1`, `1`.
7. If **Courtyard** is missing: menu **GameObject → Empty Object**. Rename `Courtyard`. Inspector: **Add Component → Map Colliders**. Parent the model under it.
8. Hierarchy: click **Floor**. Inspector: uncheck the enable box at the top.
9. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. You stand on the slab.
4. Walk into a wall. The capsule stops.
5. Press **F**. Drive into a wall. The car stops. Drive out a north or south gate.
6. The block near `(8, 0, 8)` stops the car.
7. Toolbar: **Stop**.
