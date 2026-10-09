# Part 12 — Terrain

Branch: `pt12-terrain`. Previous: `pt11-lighting`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt12-terrain
```

## File

- `Assets/Scripts/TerrainSeed.cs` — search `TUTORIAL pt12`

No `.terraindata` is committed. The editor writes it when you add the object.

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Menu **GameObject → 3D Object → Terrain**.
3. Inspector → **Transform** → **Position**: `24`, `0`, `-20`.
4. Inspector → **Terrain** → **Settings** tab.
5. **Dimensions → Terrain Size**: `64`. **Terrain Height**: `24`.
6. **Resolutions → Heightmap**: `65`.
7. Dialog **Reset Heightmap?**: confirm.
8. Inspector: **Add Component → Terrain Seed**.
9. Inspector rail: click **Sculpt**.
10. Scene view toolbar: click **Raise**.
11. **Brush Size**: `5`.
12. Scene view: left-drag on the terrain.
13. Ctrl+S. Save the terrain data asset if a second dialog appears.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. Walk off the courtyard onto the terrain. The ground rises. You do not fall through.
4. Press **F**. Drive onto the terrain. The wheels stay on it.
5. Toolbar: **Stop**.
6. Scene view: **Raise** a ridge. **Play** again. The ridge is still there.
7. Toolbar: **Stop**.
