# Part 19 — Raycast gun

Branch: `pt19-raycast-gun`. Previous: `pt18-game-ui`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt19-raycast-gun
```

## Files

- `Assets/Scripts/Gun.cs` — search `TUTORIAL pt19`
- `Assets/Scripts/PracticeCrate.cs`
- `Assets/Prefabs/Player.prefab`
- `Assets/Scenes/Game.scene` — **Crate** at `(3, 0, 4)`

## Steps

1. **Project**: double-click `Assets/Prefabs/Player.prefab`.
2. Hierarchy: click **Player**.
3. Inspector: **Add Component → Gun** if it is missing.
4. **Magazine Size**: `12`.
5. **Fire Cooldown**: `0.12`.
6. **Reload Seconds**: `1`.
7. **Range**: `50`.
8. **Hit Impulse**: `6`.
9. Inspector header: **Apply** if it is enabled.
10. **Project**: double-click `Assets/Scenes/Game.scene`.
11. Hierarchy: click **Crate**.
12. If it is missing: menu **GameObject → Empty Object**. Rename `Crate`.
13. Inspector → **Transform** → **Position**: `3`, `0`, `4`.
14. Inspector: **Add Component → Practice Crate** if it is missing.
15. **Hits**: `3`.
16. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. Under the speed line: `12/12`.
4. Hold the left mouse button on the red crate at `(3, 0, 4)`.
5. The crate moves. Console counts down. On the third hit the crate disappears. The ammo count drops.
6. Hold fire until the count is `0`. Fire does nothing.
7. Press **R**. The line says `Reloading`, then `12/12`.
8. Shoot the door. Console names the hit. The door shoves.
9. Press Escape. Click **Toggle**. The door toggles. The ammo count does not drop.
10. Toolbar: **Stop**.
