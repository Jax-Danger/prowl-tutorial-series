# Move the player

**Video:** coming. Part 4 does not have a public URL yet.

**Play CHECK:** After **Play Game** and the loading screen, WASD moves the player and Space jumps.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch and open it for the player-movement episode.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt4-player-movement
```

## What you open

This episode’s companion is `Assets/` under the project you already created: scripts, scenes, and prefabs. This branch does not include `My Prowl Game.prowl`, `Boot/`, or `Directory.Build.*`. The steps are in this README. There is no docs folder.

- `Assets/Scripts/` — `Player.cs` plus the title, loading, and scene-request scripts
- `Assets/Scenes/` — `TitleScreen`, `LoadingScreen`, `Game`
- `Assets/Prefabs/` — the title menu and **Player**

Open your Prowl project and use these `Assets` files, or open this folder in the editor. The folder contains `Assets/`, so the editor can treat it as a project and will create `ProjectSettings/` locally.

## Move the player

1. Open `Assets/Scenes/Game.scene`. It has a **Main Camera**, a **Directional Light**, a **Floor** with a mesh collider, and a **Player**.
2. **Player** has a **CharacterController** and the **Player** component (`Assets/Scripts/Player.cs`). A child named **Mesh** is the visible shape. The prefab is `Assets/Prefabs/Player.prefab`.
3. If you are building it from the end of Part 3: add a floor with a collider, create **Player** with a mesh child, add **CharacterController**, add **Player**, leave **MoveSpeed** at `6`, **JumpSpeed** at `8`, and **Gravity** at `-20`, keep rotation at `0, 0, 0`, aim the camera at the player, and drag **Player** into `Assets/Prefabs/`.
4. Save the **Game** scene.

`Player.Update` reads `Input.GetWASD()`, moves on X and Z with Right and Forward, jumps with Space while grounded, applies `Gravity` in the air, and calls `CharacterController.Move`.

Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, click **Play Game**, wait through loading, and use the Play CHECK at the top.
