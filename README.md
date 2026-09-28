# Player with camera

**Video:** coming. Part 6 does not have a public URL yet.

**Play CHECK:** After **Play Game** and the loading screen, WASD moves the player along the direction they face, Space still jumps, mouse left/right turns the whole player (body and camera together), and mouse up/down tilts only the view.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

Earlier episodes: [Part 1 title screen](https://youtu.be/8oDvGU0EzT0), [Part 2 change scenes](https://youtu.be/0omgv-6yawI), [Part 3 loading screen](https://youtu.be/2zhuH4vjZ6M). Part 4 on `main` is the player this episode builds on.

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt6-player-with-cam
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. The steps are in this README. There is no docs folder.

- `Assets/Scripts/Player.cs` — Part 4 movement (WASD, jump, gravity) on the **Player** parent
- `Assets/Scripts/PlayerLook.cs` — this episode. Search `TUTORIAL pt6`
- `Assets/Scenes/` — `TitleScreen`, `LoadingScreen`, `Game`
- `Assets/Prefabs/Player.prefab` — empty **Player** parent, **Mesh** child, **Camera** child

Open your Prowl project and use these `Assets` files, or open this folder in the editor. The editor creates `ProjectSettings/` and the `.csproj` files locally. Paths are case-sensitive: `Assets/Scripts/PlayerLook.cs`.

`Player.Update` reads `Input.GetWASD()`, moves on X and Z with `Transform.Right` and `Transform.Forward`, jumps with Space while grounded, and calls `CharacterController.Move`. `PlayerLook` yaws that same transform, so forward follows where the player is looking.

## Player hierarchy

The parent is an empty GameObject named **Player**. It holds the scripts and the **CharacterController**. It has no mesh renderer.

- Child **Mesh** — the visible body (a cube mesh renderer on this project)
- Child **Camera** — the **Camera** component, local position `0, 1.6, 0` (head height on the 1.8 tall controller)

`Game.scene` uses that camera. The old scene **Main Camera** is removed from `Game` so it does not draw over the player view. Title and Loading keep their own cameras.

This checkout already has that hierarchy saved. The steps below are how to build it in the editor, starting from the Part 4 player.

## Build it in the editor

1. Open `Assets/Scenes/Game.scene`.
2. In the Hierarchy, select **Player**. On Part 4 this object is already empty: **CharacterController** and **Player** are on it, and **Mesh** is a child. Confirm the Inspector shows those two components and no **MeshRenderer** on the parent.
3. When the mesh renderer is still on **Player** itself: select **Player**, use **GameObject → Empty Parent**, rename that new parent to **Player**, and rename the old object to **Mesh**. Move **CharacterController** and **Player** onto the empty parent. Leave the **MeshRenderer** on **Mesh**. Put the parent’s local rotation at `0, 0, 0`.
4. Select **Player**. **GameObject → Camera** creates **Camera** as a child when Player is the active object. If **Camera** lands on the scene root, drag it onto **Player**.
5. Select the **Camera** child. Set Local Position to `0, 1.6, 0`, Local Rotation to `0, 0, 0`, Local Scale to `1, 1, 1`. Leave Field of View at `60`.
6. Create `Assets/Scripts/PlayerLook.cs` (or use the file already on this branch). Wait until the Console is clear of script errors. `Update` and `Start` are `public override` — a plain `public void Update()` does not run.
7. Select the **Player** parent (the empty object, above **Mesh** and **Camera**). **Add Component → PlayerLook**.
8. Drag the **Camera** child into **ViewCamera**. Leave **Sensitivity** at `0.15`.
9. In the Hierarchy, delete the scene object named **Main Camera** (the camera that is a sibling of Player, Light, and Floor). The Game view should come from the player’s **Camera** child.
10. With **Player** selected, click **Apply** on the prefab header so `Assets/Prefabs/Player.prefab` stores the Camera child and **PlayerLook**. Save the **Game** scene.

`PlayerLook` reads `Input.MouseDelta`. Mouse X adds yaw and writes `Transform.LocalEulerAngles` on the **Player** parent, so the mesh, the camera, and WASD all turn together. Mouse Y writes pitch on the camera’s local X only, clamped from `-80` to `80`. `Input.LockCursor()` hides and pins the cursor when Play starts. Escape calls `Input.UnlockCursor()`. Click in the Game view to lock it again.

## Play

Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, and click the Game view so it has focus. Click **Play Game**, wait through loading, and use the Play CHECK at the top.

While the cursor is locked, mouse left/right turns the cube body and the view together. Mouse up looks up and mouse down looks down, and the body stays upright. WASD moves along that facing. Space still jumps. Escape shows the cursor.
