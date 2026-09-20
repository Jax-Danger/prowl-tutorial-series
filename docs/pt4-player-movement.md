# pt4 — Player movement

Video: *(not recorded yet)*  
Start: end of pt3 (Title → Loading → Game).  
End: a **Player** prefab in the Game scene moves with WASD or arrow keys.

**Play CHECK:** After Play → Play Game → loading finishes, WASD/arrows move the Player instance in the Game scene.

## Shot list

### Project folders

- [ ] Project browser: confirm `Scenes/`, `Prefabs/`, `Scripts/` exist (from pt2). If `Prefabs/` is missing, create it.
- [ ] Open the **Game** scene (double-click `Scenes/Game` — or whatever you named it in pt2)

### Build the Player object

- [ ] Hierarchy → Create → 3D Object → **Cube** (or Empty + add a Mesh if you prefer). Name it **Player**
- [ ] SAY: "This is the thing we will move. Keep it simple — one cube is enough for Part 4."
- [ ] Inspector Transform: Local Position about `0, 0.5, 0` so it sits on the ground plane; Local Rotation `0, 0, 0`; Local Scale `1, 1, 1`
- [ ] Select the Main Camera (or your Game camera). Aim it so the Player is clearly in frame (F to focus the Player, then back the camera off a little)
- [ ] Optional: Hierarchy → Create → 3D Object → **Plane** named **Ground** at `0, 0, 0` so movement reads on camera — skip if the Game scene already has a floor

### Script on the Player

- [ ] Copy `Scripts/PlayerMovement.cs` into the project's `Scripts/` folder (or Create → C# Script named **PlayerMovement** and paste the full file)
- [ ] Wait for compile (Console clear of script errors)
- [ ] Select **Player** in the Hierarchy
- [ ] Inspector → Add Component → **PlayerMovement**
- [ ] Leave `moveSpeed` at `5` for the take
- [ ] SAY: "No other fields to assign — this episode has no AssetRefs or button hooks."

### Make it a prefab (same habit as Title Screen in pt1)

- [ ] Project browser: open the **Prefabs** folder
- [ ] Drag **Player** from the Hierarchy into `Prefabs/`
- [ ] Confirm a **Player** prefab asset appears under Prefabs (blue / prefab icon)
- [ ] Confirm the Hierarchy **Player** is now a prefab instance (linked to that asset — not a one-off scene object)
- [ ] SAY: "Same workflow as the Title Screen prefab — scene instance points at Prefabs/Player."
- [ ] If you tweak `moveSpeed` or the mesh later: change it on the prefab asset (or Apply overrides) so every instance stays consistent

### Save and CHECK

- [ ] Ctrl+S save the **Game** scene (Player instance must live in this scene)
- [ ] Open **Title Screen**, enter Play mode, click **Play Game**
- [ ] Wait through the loading screen into Game
- [ ] CHECK: WASD **or** arrow keys move the Player. Diagonals should not be faster than cardinals.
- [ ] Stop Play. If the Player drifted, Revert the instance or reset Transform from the prefab so the next take starts clean

## Inspector wiring

| Object / asset | Component | Field | Assign |
|----------------|-----------|-------|--------|
| Prefabs/Player (and the Game scene instance) | PlayerMovement | moveSpeed | `5` (default) |

No button on-click targets. Title / Loading wiring from pt3 stays as-is.

## Prefab layout after this episode

```
Prefabs/
  Title Screen     (from pt1)
  Player           (this episode — Cube + PlayerMovement)
Scenes/
  Title Screen
  Loading Screen
  Game             (contains a Player prefab instance)
Scripts/
  TitleScreen.cs
  LoadingScreen.cs
  SceneLoadRequest.cs
  PlayerMovement.cs
```

## Gotchas

- If nothing moves, you are still in Title or Loading — finish Play into **Game**.
- If the Hierarchy Player is **not** a prefab instance, you skipped the drag into `Prefabs/`. Do that before you call the take done.
- Do **not** add Rigidbody3D here. Transform-only movement keeps the CHECK to one feature.
- Movement uses local Forward/Right. Keep Player rotation at identity unless you mean to change facing.
- Edits made only on the scene instance while Play is running are discarded when you stop — tweak the prefab or Apply after Stop.

## Code on this episode

`PlayerMovement` with `moveSpeed`, `Input.GetWASD` + `Input.GetArrowKeys`, `Transform.Position` += wish * speed * `Time.DeltaTime`.
