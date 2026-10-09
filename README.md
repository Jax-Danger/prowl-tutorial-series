# Part 6 — Player with camera

Engine: Prowl 1.0-preview-4. Branch: `pt6-player-with-cam`. Previous: tag `pt5-rotating-cube`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt6-player-with-cam
```

## Files

- `Assets/Scripts/PlayerLook.cs` — search `TUTORIAL pt6`
- `Assets/Scripts/Player.cs`
- `Assets/Prefabs/Player.prefab`
- `Assets/Scenes/Game.scene`

Copy `Assets/` into the project from Part 5. This branch has no `.prowl` file.

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: click **Player**.
3. Inspector shows **Character Controller** and **Player**. No **Mesh Renderer** on this object.
4. If **Mesh Renderer** is still on **Player**: menu **GameObject → Empty Parent**. Rename the new parent `Player`. Rename the old object `Mesh`. Move **Character Controller** and **Player** onto the empty parent. Leave **Mesh Renderer** on **Mesh**.
5. Inspector → **Transform** → **Local Rotation**: `0`, `0`, `0`.
6. Hierarchy: click **Player**. Menu **GameObject → Camera**.
7. If **Camera** is not a child, drag it onto **Player**.
8. Hierarchy: click **Camera**.
9. Inspector → **Transform** → **Local Position**: `0`, `1.6`, `0`. **Local Rotation**: `0`, `0`, `0`. **Local Scale**: `1`, `1`, `1`.
10. Inspector → **Camera** → **Field Of View**: `60`.
11. Copy `Assets/Scripts/PlayerLook.cs` if it is not already in the project. Wait until the Console is clear.
12. Hierarchy: click **Player** (the parent).
13. Inspector: **Add Component → Player Look**.
14. Inspector → **Player Look** → **View Camera**: drag Hierarchy **Camera**.
15. Inspector → **Player Look** → **Sensitivity**: `0.15`.
16. Hierarchy: click **Main Camera** (sibling of Player, not the child). Delete.
17. Hierarchy: click **Player**. Inspector header: **Apply**.
18. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**.
3. **Game** view: click once.
4. Click **Play Game**. Wait through loading.
5. WASD moves along the facing. Space jumps.
6. Mouse left/right turns the body and the camera. Mouse up/down tilts only the camera.
7. Escape shows the cursor. Click the **Game** view to lock it again.
8. Toolbar: **Stop**.
