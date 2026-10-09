# Part 11 — Lighting

Branch: `pt11-lighting`. Previous: `pt10-blender-map`. Engine: `baa86a4417`.

A directional light shines along local **+Z**.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt11-lighting
```

## Files

- `Assets/Scripts/DayNightCycle.cs` — search `TUTORIAL pt11`
- `Assets/Scripts/CameraGrade.cs`
- `Assets/Scenes/Game.scene`
- `Assets/Prefabs/Player.prefab` — **Camera Grade** on the **Camera** child

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Hierarchy: click **Directional Light**.
3. Inspector → **Directional Light** → **Cast Shadows**: on. **Shadow Quality**: **Soft**.
4. **Depth Bias**: `1`. **Normal Bias**: `1`.
5. Inspector: **Add Component → Day Night Cycle** if it is missing.
6. **Day Length Seconds**: `90`. **Pitch**: `50`.
7. Menu **GameObject → Light → Point Light**. Rename `Lamp`.
8. **Position**: `8`, `2.5`, `8`.
9. Inspector → **Point Light** → **Range**: `8`. **Intensity**: `2`. **Cast Shadows**: on.
10. **Color**: R `1`, G `0.72`, B `0.4`.
11. Menu **GameObject → Light → Spot Light**. Rename `Gate Spot`.
12. **Position**: `0`, `4`, `16`. **Rotation**: `20`, `180`, `0`.
13. Inspector → **Spot Light** → **Range**: `18`. **Spot Angle**: `40`. **Inner Spot Angle**: `25`. **Intensity**: `3`. **Color**: R `0.75`, G `0.85`, B `1`. **Cast Shadows**: on.
14. Menu **Window → General → Environment**.
15. **Skybox** tab → **Mode**: **Procedural**.
16. **Ambient** tab → **Mode**: **Hemisphere**. **Strength**: `1`.
17. **Fog** tab: leave off.
18. Hierarchy: expand **Player**. Click **Camera**.
19. Inspector: **Add Component → Camera Grade** if it is missing.
20. Hierarchy: click **Player**. Inspector header: **Apply All**.
21. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. The sun turns. Shadows move.
4. For a shorter night, Toolbar: **Stop**. Hierarchy **Directional Light** → **Day Length Seconds**: `20`. **Play** again.
5. The lamp lights the block. The spot lights the gate.
6. Bright areas bloom.
7. Toolbar: **Stop**.
