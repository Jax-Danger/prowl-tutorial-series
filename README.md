# Move the player

**Video:** coming. Part 4 does not have a public URL yet.

**Play CHECK:** After **Play Game** and the loading screen, WASD moves the player and Space jumps.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. `main` is the latest finished episode, Part 4. You clone it, open it, and play the project.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

Earlier episodes: [Part 1 title screen](https://youtu.be/8oDvGU0EzT0), [Part 2 change scenes](https://youtu.be/0omgv-6yawI), [Part 3 loading screen](https://youtu.be/2zhuH4vjZ6M).

## Clone main

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
```

## Open it

`main` is the Part 4 project under `Assets/`. Open this folder in the Prowl editor. The steps for this episode are in this README. There is no docs folder.

- `Assets/Scripts/` — `Player.cs`, `TitleScreen.cs`, `LoadingScreen.cs`, `SceneLoadRequest.cs`
- `Assets/Scenes/` — `TitleScreen`, `LoadingScreen`, `Game`
- `Assets/Prefabs/` — the title menu and **Player**

The editor creates `ProjectSettings/` and the `.csproj` files locally when you open the folder.

## Full project layout

Branch `pt5-rotating-cube` is the full project root. That checkout adds:

- `My Prowl Game.prowl` — open this in the editor
- `My Prowl Game.slnx`
- `Directory.Build.props` and `Directory.Build.targets`
- `Boot/MyProwlGame.cs` and `Boot/scenes/RotatingCubeScene.cs`
- the same `Assets/` tree, including `Spin.cs`

That branch does not track `Builds/`. `ProjectSettings/` and `*.csproj` stay on your machine.

## Move the player

1. Open `Assets/Scenes/Game.scene`. It has a **Main Camera**, a **Directional Light**, a **Floor** with a mesh collider, and a **Player**.
2. **Player** uses **CharacterController** and `Assets/Scripts/Player.cs`. **MoveSpeed** is `6`, **JumpSpeed** is `8`, **Gravity** is `-20`. The prefab is `Assets/Prefabs/Player.prefab`.
3. Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, click **Play Game**, wait about 1.5 seconds on `Loading...`, then use the Play CHECK at the top.
