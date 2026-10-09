# Part 18 — GameObject UI

Branch: `pt18-game-ui`. Previous: `pt17-ongui`. Engine: `baa86a4417`.

The canvas is built at Play by `GameMenu`. It is not painted in the scene file.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt18-game-ui
```

## Files

- `Assets/Scripts/GameMenu.cs` — search `TUTORIAL pt18`
- `Assets/Scripts/PhysicsGate.cs` — `ToggleDoor`
- `Assets/Scenes/Game.scene` — **Game UI**

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: click **Game UI**.
3. If it is missing: menu **GameObject → Empty Object**. Rename `Game UI`.
4. Inspector: **Add Component → Game Menu** if it is missing.
5. **Game Menu** has no fields.
6. Hierarchy: click **Gate**. Inspector → **Physics Gate** fields stay at Part 15 values.
7. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. Bottom of the screen: button **Toggle**. Above it: `Gate is shut`.
4. The Part 17 speed line is still at the top left.
5. Press Escape.
6. Click **Toggle**. The door swings open. The line says `Gate is open`.
7. Click **Toggle**. The door swings shut. The line says `Gate is shut`.
8. Click the **Game** view. Walk within 3 m of the gate. Press **E**. The door still moves.
9. Toolbar: **Stop**.
