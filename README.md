# GameObject UI

**Video:** coming. Part 18 does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. A **Toggle** button sits at the bottom of the screen, with `Gate is shut` above it. Press **Escape** so the cursor is free, then click **Toggle**. The door swings and the line says `Gate is open`. Click again and it swings shut. The OnGui speed line from Part 17 is still in the corner.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin for the rest of the course.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen. A timer, then blocking `Scene.Load` |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Courtyard mesh and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |
| 13 | `pt13-navmesh-wander` | Baked navmesh, wander, and chase |
| 14 | `pt14-third-person` | Orbit camera on the player |
| 15 | `pt15-physics-joints` | A hinged door |
| 16 | `pt16-async-load` | `Scene.LoadAsync` and a loading line |
| 17 | `pt17-ongui` | Immediate-mode speed line |
| 18 | `pt18-game-ui` | This episode. Canvas, text, and a button |

Part 17 rebuilds a string every frame in `OnGui`. This part keeps GameObjects: `GameCanvas`, `RectTransform`, `TextComponent`, `UIImage`, `UIButton`, and one `EventSystem`. The canvas still draws if you delete the event system. It just stops taking clicks.

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt18-game-ui
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/GameMenu.cs` — search `TUTORIAL pt18`
- `Assets/Scenes/Game.scene` — empty **Game UI**
- `Assets/Scripts/PhysicsGate.cs` — `ToggleDoor()` is what the button calls. **E** still requires you to stand close.

`Start` builds the hierarchy and then `Scene.Add`s the canvas, which registers the children too.

## The canvas

1. **Game UI** is already in the scene. If you build it yourself: empty GameObject, **Add Component → Game Menu**. No fields.
2. The canvas object calls `EnsureRectTransform()` and then **Game Canvas**. **Event System** goes on the same object. One enabled event system for the scene.
3. The hint is a child. Anchors and pivot are bottom-center `(0.5, 0)`. **Size Delta** is `(360, 32)`. **Anchored Position** is `(0, 76)`. `TextComponent.Text` starts as `Gate is shut`. Alignment is `TextAlignment.CenterMiddle`. An empty font uses `FontAsset.LoadDefault()`.
4. The button is a sibling. **Size Delta** `(220, 44)`, **Anchored Position** `(0, 24)`. `UIImage.Sprite` is `Sprite.LoadDefault(DefaultSprite.UIPanel)`. `UIButton.TargetGraphic` is that image. `OnClick` is a C# event.
5. A caption child stretches to the button (`Anchor Min` zero, `Anchor Max` one, `Size Delta` zero) and says `Toggle`.
6. The click calls `PhysicsGate.ToggleDoor()`. That is the same motor flip as **E**, without the 3 metre check. The label reads `PhysicsGate.IsOpen`.

`PlayerLook` locks the cursor on Play. **Escape** unlocks it. A locked cursor keeps the pointer at the center, so the button at the bottom does not see the click. Click the Game view to lock the cursor again.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** **Toggle** and `Gate is shut` are on screen. The Part 17 speed line is still there.
- Press **Escape**. Click **Toggle**.
- **CHECK:** The door swings open. The line says `Gate is open`.
- Click again. **CHECK:** The door swings shut and the line follows.
- **CHECK:** **E** beside the gate still works.
- Stop Play.
