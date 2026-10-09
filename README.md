# Part 14 — Third person

Branch: `pt14-third-person`. Previous: `pt13-navmesh-wander`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt14-third-person
```

## Files

- `Assets/Scripts/PlayerLook.cs` — search `TUTORIAL pt14`
- `Assets/Prefabs/Player.prefab`

## Steps

1. **Project**: double-click `Assets/Prefabs/Player.prefab`.
2. Hierarchy: click **Player**.
3. Inspector → **Player Look** → **Third Person**: on.
4. **Orbit Distance**: `4.5`.
5. **Min Orbit Distance**: `1.2`.
6. **Max Orbit Distance**: `8`.
7. **Pivot Height**: `1.45`.
8. **View Camera**: the **Camera** child.
9. **Sensitivity**: `0.15`.
10. Inspector header: **Apply** if it is enabled.
11. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. The camera starts behind the body. WASD follows the facing.
4. Mouse left/right turns the body. Mouse up/down orbits.
5. Mouse wheel stops at distance `1.2` and `8`.
6. Walk into a wall. The camera stays in front of the wall.
7. Press **V**. The camera is at the eye point. Press **V** again. The orbit returns.
8. Press **F** next to the car. The chase camera is on the car. Press **F**. The orbit returns.
9. Toolbar: **Stop**.
