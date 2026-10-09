# Part 17 — OnGui

Branch: `pt17-ongui`. Previous: `pt16-async-load`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt17-ongui
```

## Files

- `Assets/Scripts/PlayHud.cs` — search `TUTORIAL pt17`
- `Assets/Prefabs/Player.prefab`

## Steps

1. **Project**: double-click `Assets/Prefabs/Player.prefab`.
2. Hierarchy: click **Player**.
3. Inspector: **Add Component → Play Hud** if it is missing.
4. **Play Hud** has no fields.
5. Inspector header: **Apply** if it is enabled.
6. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. Top left: `Speed 0.0`, `orbit` or `eye`, `V camera`, `E gate`.
4. Walk. The speed number rises.
5. Press **V**. The word switches between `orbit` and `eye`.
6. Press **F** at the car. The line hides. Press **F**. The line returns.
7. Toolbar: **Stop**.
