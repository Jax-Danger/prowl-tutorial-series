# Side — Rolling ball

Branch: `side-ball-controller`. Base: `pt13-navmesh-wander`. Engine: `baa86a4417`.

Not on the main line. Parts 14–20 do not contain this ball.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout side-ball-controller
```

## Files

- `Assets/Scripts/BallController.cs` — search `TUTORIAL side-ball`
- `Assets/Scenes/Game.scene` — **Ball** at `(4, 1.2, 2)`

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: click **Ball**.
3. If it is missing: menu **GameObject → Empty Object**. Rename `Ball`.
4. Inspector → **Transform** → **Position**: `4`, `1.2`, `2`.
5. Inspector: **Add Component → Ball Controller** if it is missing.
6. **Torque**: `18`.
7. **Jump Impulse**: `5`.
8. **Radius**: `0.45`.
9. **Enter Distance**: `4`.
10. **Camera Distance**: `5.5`.
11. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. A blue ball is on the ground at `(4, 1.2, 2)`.
4. Walk within 4 m. Press **B**. The body hides. The camera sits behind the ball.
5. WASD rolls along the camera. Mouse looks. **Space** hops once per landing.
6. Press **B**. You stand beside the ball. The eye camera is back.
7. Toolbar: **Stop**.
