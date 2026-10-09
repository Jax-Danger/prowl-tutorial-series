# Part 13 — Navmesh wander

Branch: `pt13-navmesh-wander`. Previous: `pt12-terrain`. Engine: `baa86a4417`.

No `.navmesh` file is committed. Bake it in the editor.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt13-navmesh-wander
```

## Files

- `Assets/Scripts/NavWanderer.cs` — search `TUTORIAL pt13`
- `Assets/Scenes/Game.scene` — **NavMesh**, **Wanderer** at `(0, 0.2, 10)`
- `Assets/Prefabs/Player.prefab` and `Car.prefab` — **Nav Mesh Modifier**

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: parent the courtyard model under **Courtyard** if it is not already.
3. Hierarchy: click **Terrain**. Inspector → **Position**: `24`, `0`, `-20`.
4. Hierarchy: click **NavMesh**.
5. Inspector: **Add Component → Navigation → NavMesh Surface** if it is missing.
6. **Agent Type**: **Humanoid**. **Collect Objects**: **All**. **Use Geometry**: **Render Meshes**.
7. Hierarchy: click **Player**.
8. Inspector → **Nav Mesh Modifier** → **Ignore From Build**: on. **Apply To Children**: on.
9. Hierarchy: click **Car**. Same two checkboxes on.
10. Menu **Edit → Project Settings...**. Page **Navigation**.
11. Humanoid row: radius `0.5`, height `2`, max slope `45`. Close the window.
12. Hierarchy: click **NavMesh**.
13. Inspector → **Baking**: click **Bake NavMesh**. Wait until **Nav Mesh Data** points at a `.navmesh` asset.
14. Hierarchy: click **Wanderer**.
15. Inspector → **Nav Mesh Agent** → **Speed**: `2.2`. **Stopping Distance**: `0.2`.
16. **Update Position**: on. **Update Rotation**: on. **Agent Type**: **Humanoid**.
17. Inspector → **Nav Wanderer** → **Wander Radius**: `16`. **Chase Distance**: `6`. **Repath Seconds**: `0.35`.
18. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. The cube at `(0, 0.2, 10)` walks, stops, and picks another point. It does not pass through walls.
4. Walk within 6 m. The cube follows. Walk away. It wanders again.
5. Toolbar: **Stop**.
6. Hierarchy: click **NavMesh**. Inspector → **Baking**: click **Clear**.
7. Toolbar: **Play**. Click **Play Game**. The cube stays put. Console stays clear.
8. Toolbar: **Stop**.
