# Part 20 — FPS combat

Branch: `pt20-fps-combat`. Previous: `pt19-raycast-gun`. Engine: `baa86a4417`.

Prowl has no health component and no crosshair. `Health` and `CombatHud` are scripts on this branch. The hostile uses `PhysicsWorld.Raycast`. The character controller is not a collider: a hit more than `0.6` m short of the aim point is a wall.

Side branch `side-ball-controller` is off Part 13. It is not in this checkout.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt20-fps-combat
```

## Files

- `Assets/Scripts/Health.cs` — search `TUTORIAL pt20`
- `Assets/Scripts/HostileShooter.cs`
- `Assets/Scripts/CombatHud.cs`
- `Assets/Scripts/Gun.cs` — `TakeDamage(1)`
- `Assets/Prefabs/Player.prefab`
- `Assets/Scenes/Game.scene` — **Hostile** at `(0, 0, 14)`

## Steps

1. **Project**: double-click `Assets/Prefabs/Player.prefab`.
2. Hierarchy: click **Player**.
3. Inspector: **Add Component → Health** if it is missing.
4. **Max Hit Points**: `5`. **Disable Object On Death**: off.
5. Inspector: **Add Component → Combat Hud** if it is missing.
6. Inspector header: **Apply** if it is enabled.
7. **Project**: double-click `Assets/Scenes/Game.scene`.
8. Hierarchy: click **Hostile**.
9. If it is missing: menu **GameObject → Empty Object**. Rename `Hostile`.
10. Inspector → **Transform** → **Position**: `0`, `0`, `14`.
11. Inspector: **Add Component → Health** if it is missing.
12. **Max Hit Points**: `8`. **Disable Object On Death**: on.
13. Inspector: **Add Component → Hostile Shooter** if it is missing.
14. **Range**: `16`. **Cooldown**: `1.1`. **Damage**: `1`.
15. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. A `+` is in the center. Under the ammo line: `HP 5/5`.
4. A dark red figure is at `(0, 0, 14)`.
5. Walk toward it in the open. About once a second the Console says `Hostile: hit`. `HP` counts down.
6. Stand behind a courtyard wall. Console: `Hostile: blocked`. `HP` holds.
7. Shoot the figure. Console counts its points down. At `0` the figure disappears.
8. Stand in the open until `HP` hits `0`.
9. The line says `Down`. The `+` is gone. WASD does nothing. Mouse still looks.
10. Toolbar: **Stop**.
