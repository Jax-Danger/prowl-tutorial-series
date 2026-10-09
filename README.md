# Part 15 — Hinge

Branch: `pt15-physics-joints`. Previous: `pt14-third-person`. Engine: `baa86a4417`.

`HingeJoint` menu: **Physics → Joints → Hinge Joint**. This episode’s script adds the joint at Play. An empty **Connected Body** pins the hinge to the world.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt15-physics-joints
```

## Files

- `Assets/Scripts/PhysicsGate.cs` — search `TUTORIAL pt15`
- `Assets/Scenes/Game.scene` — **Gate** at `(6, 0, 8)`

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: click **Gate**.
3. If it is missing: menu **GameObject → Empty Object**. Rename `Gate`.
4. Inspector → **Transform** → **Position**: `6`, `0`, `8`.
5. Inspector: **Add Component → Physics Gate** if it is missing.
6. **Open Speed**: `2.2`.
7. **Use Distance**: `3`.
8. **Min Angle**: `-4`.
9. **Max Angle**: `95`.
10. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. A door and a grey post appear at the gate. The door stays upright. The post does not move.
4. Stand more than 3 m away. Press **E**. The door does not move.
5. Stand within 3 m. Press **E**. The door swings open and stops.
6. Press **E**. The door swings shut and stops.
7. Toolbar: **Stop**.
