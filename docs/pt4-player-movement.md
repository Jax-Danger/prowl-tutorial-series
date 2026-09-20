# pt4 — Player movement

Video: *(not recorded yet)*  
Start: end of pt3 (Title → Loading → Game).  
End: a GameObject in the **Game** scene moves with WASD or arrow keys.

**Play CHECK:** After Play → Play Game → loading finishes, WASD/arrows move the Player in the Game scene.

## Shot list

- [ ] Open the **Game** scene (from pt2/pt3)
- [ ] Hierarchy → Create empty (or 3D Cube if you have a mesh) → name it **Player**
- [ ] Place Player in front of the camera (example Local Position `0, 0.5, 0` for a cube sitting on the ground)
- [ ] Copy `Scripts/PlayerMovement.cs` into the project's `Scripts` folder (or create the script in-editor and paste)
- [ ] Wait for script compile
- [ ] Select **Player** → Add Component → **PlayerMovement**
- [ ] Inspector: leave `moveSpeed` at `5` for the take
- [ ] Optional: Frame the Player (F) so movement is obvious on camera
- [ ] Save the Game scene (Ctrl+S)
- [ ] Open **Title Screen**, enter Play mode, click **Play Game**
- [ ] CHECK: after the loading screen, WASD **or** arrow keys move the Player. Diagonals should not be faster than cardinals.

## Inspector wiring

| Object | Component | Field | Assign |
|--------|-----------|-------|--------|
| Player | PlayerMovement | moveSpeed | `5` (default) |

No button on-click targets in this episode. Title / Loading wiring from pt3 stays as-is.

## Gotchas

- If nothing moves, you are still in the Title or Loading scene — finish the Play flow into **Game**.
- If only one key scheme works, you typed only one of `GetWASD` / `GetArrowKeys` — the finished script adds both.
- Do **not** add a Rigidbody3D in this episode. Movement is transform-only so the CHECK stays one feature.
- Facing: movement uses the Player's local Forward/Right. Keep Player rotation at identity unless you intentionally rotate it.

## Code on this episode

`PlayerMovement` with `moveSpeed`, `Input.GetWASD` + `Input.GetArrowKeys`, `Transform.Position` += wish * speed * `Time.DeltaTime`.
