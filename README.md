# Lighting

**Video:** coming. Part 11 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen**, then **Play Game**. The sun turns. Shadows move with it. The view is brighter in the day and dim and blue when the sun points up. The lamp at `(8, 2.5, 8)` and the spot at the gate stay on. Bright spots bloom. The Console has no exception from `DayNightCycle` or `CameraGrade`.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Courtyard mesh and a mesh collider |
| 11 | `pt11-lighting` | This episode. Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |

Prerequisite: Part 10 plays, or at least the plane from Part 9 if you have not parented the courtyard yet.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt11-lighting
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

A directional light shines along **+Forward** (local **+Z**). That changed in the Part 7 migration. `DepthBias` and `NormalBias` are the shadow offsets. The old names were `ShadowBias` and `ShadowNormalBias`.

Checkout already has the sun script, a point light, a spot, and **Camera Grade** on the player camera. Follow the clicks so the video matches.

- `Assets/Scripts/DayNightCycle.cs` — search `TUTORIAL pt11`
- `Assets/Scripts/CameraGrade.cs` — bloom, then AgX tonemap
- `Assets/Scenes/Game.scene` — **Day Night Cycle** on **Directional Light**, **Lamp**, **Gate Spot**
- `Assets/Prefabs/Player.prefab` — **Camera Grade** on the **Camera** child

`Update` and `OnEnable` are `public override`.

## Sun

1. Open `Assets/Scenes/Game.scene`.
2. Select **Directional Light**. **Cast Shadows** is on. **Shadow Quality** is **Soft**. **Depth Bias** `1`, **Normal Bias** `1`.
3. **Add Component → Day Night Cycle**. **Day Length Seconds** `90`. **Pitch** `50`.
4. The script sets local Euler to `(Pitch, yaw, 0)`. Yaw comes from `Time.TimeSinceStartup`. Intensity uses how far **Forward** points down. When the light points up, intensity falls to `0.05` and the color goes blue.

## Point and spot

5. **GameObject → Light → Point Light**. Name it `Lamp`. Position `8, 2.5, 8` (over the courtyard block). **Range** `8`. Color a warm orange. **Intensity** `2`. **Cast Shadows** on.
6. **GameObject → Light → Spot Light**. The menu aims it down. Name it `Gate Spot`. Position `0, 4, 16`. Rotation `20, 180, 0` so **+Z** points back into the court and slightly down. **Range** `18`. **Spot Angle** `40`. **Inner Spot Angle** `25`. **Intensity** `3`. **Cast Shadows** on.

## Sky and ambient

These are scene settings, not components. `Scene.Skybox` and `Scene.Ambient` in `Prowl.Runtime/Resources/Scene.cs`.

7. **Window → General → Environment**.
8. **Skybox** tab. **Mode** **Procedural**. The hint on that mode is “Sun direction set automatically from Directional Light.” Switch to **Gradient** if you want a fixed top and bottom color. **Solid Color** and **Material** are the other modes.
9. **Ambient** tab. **Mode** **Hemisphere** (sky color and ground color) or **Uniform**. **Strength** around `1`.
10. **Fog** is the third tab. Leave it off unless you want it. Save the scene.

## Camera post

11. Select the player’s **Camera** child. **Add Component → Camera Grade**.
12. **Apply All** on the Player prefab instance.
13. The script sets `Camera.HDR` on and, if they are missing, appends `BloomEffect` then `TonemapperEffect`. Bloom’s defaults are intensity `1.5`, threshold `0.8`, iterations `6`. The tonemapper defaults to **AgX**, contrast `1.1`, saturation `1.1`. Tonemapper is last because `TransformsToLDR` is true.
14. The same list is `Camera.Effects` in the Inspector if you want to add FXAA, SMAA, TAA, GTAO, motion blur, or the other effects under `Prowl.Runtime/Rendering/Image Effects` by hand. This episode only adds bloom and the tonemapper.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The sun moves. Your shadow moves with it.
- **CHECK:** After a while the scene dims. Wait out the `90` seconds or lower **Day Length Seconds** to `20` for the take.
- **CHECK:** The lamp lights the block. The spot lights the gate. Both cast shadows.
- **CHECK:** A bright area blooms. The picture is not a flat unmapped HDR blowout.
- **CHECK:** Disable **Day Night Cycle**. The sun stays where you left it and the Console stays clear.
- Stop Play.
