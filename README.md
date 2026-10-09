# Part 16 — Async load

Branch: `pt16-async-load`. Previous: `pt15-physics-joints`. Engine: `baa86a4417`.

Part 3 called `Scene.Load` after a timer. This part calls `Scene.LoadAsync`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt16-async-load
```

## File

- `Assets/Scripts/LoadingScreen.cs` — search `TUTORIAL pt16`

## Steps

1. Copy `Assets/Scripts/LoadingScreen.cs` into the project if it is not already there.
2. Wait until the Console has no script errors.
3. **Project**: double-click `Assets/Scenes/LoadingScreen.scene`.
4. Hierarchy: click the object with **Loading Screen**.
5. Inspector → **Loading Screen** → **Min Display Seconds**: `1.5`.
6. Ctrl+S.
7. **Project**: double-click `Assets/Prefabs/TitleScreen.prefab`.
8. Hierarchy: click the object with **Title Screen**.
9. Inspector → **Title Screen** → **Loading Scene**: `Assets/Scenes/LoadingScreen.scene`.
10. Inspector → **Title Screen** → **Game Scene**: `Assets/Scenes/Game.scene`.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**.
3. Click **Play Game**.
4. The loading scene stays at least 1.5 seconds. The text shows `Loading N%`.
5. The Game scene becomes current. Console does not say the destination is missing.
6. Toolbar: **Stop**.
