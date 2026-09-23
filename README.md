# Spin a cube in the editor and from the command line

**Video:** coming. Part 5 does not have a public URL yet.

**Play CHECK:** In Play mode the cube turns about Y; `dotnet run --project "My Prowl Game.Game.csproj"` opens that same spinning-cube scene.

This repo is the companion project for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone a branch, open it, and follow that episode.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt5-rotating-cube
```

## Open it as a Prowl project

This checkout is the project root. In the Prowl editor, open `My Prowl Game.prowl`.

```
My Prowl Game.prowl
My Prowl Game.slnx
Directory.Build.props
Directory.Build.targets
Boot/MyProwlGame.cs
Boot/scenes/RotatingCubeScene.cs
Assets/Scripts/     Parts 1–4, plus Spin.cs
Assets/Scenes/      TitleScreen, LoadingScreen, Game
Assets/Prefabs/     title menu and Player
```

There is no `Builds/` folder and no docs folder. The steps are in this README. The editor creates `ProjectSettings/`, `Library/`, and the `.csproj` files on your machine. `Assets/` plus the `.prowl` file is enough to open. Those `.csproj` files stay untracked because their HintPaths point at your Prowl install.

`Directory.Build.props` is the Prowl package file. The editor does not overwrite it. `Directory.Build.targets` is already here so you do not write that MSBuild yourself. For the `*.Game` project it builds an exe, sets the startup object to `MyProwlGame`, and compiles `Assets/Scripts/**/*.cs` and `Boot/**/*.cs`.

## Spin a cube in the editor

1. Open `Assets/Scenes/Game.scene`.
2. Create a **Cube**.
3. Add the **Spin** component from `Assets/Scripts/Spin.cs`. Leave `degreesPerSecond` at **90**.

```csharp
using Prowl.Runtime;
using Prowl.Vector;

public class Spin : MonoBehaviour
{
    public float degreesPerSecond = 90f;

    public override void Update()
    {
        Transform.Rotate(Float3.UnitY, degreesPerSecond * Time.DeltaTime);
    }
}
```

4. Enter Play mode. The cube rotates around Y, 90 degrees each second.

## Run it from the command line

`Boot/MyProwlGame.cs` is the entry point. It is outside `Assets/Scripts`. `Initialize` asks `RotatingCubeScene` for a scene and loads it:

```csharp
public override void Initialize()
{
    Scene scene = new RotatingCubeScene().Initialize();
    Scene.Load(scene);
}
```

`Boot/scenes/RotatingCubeScene.cs` builds that scene: a directional light, a camera, and a cube with **Spin** on it.

1. Open the project in the editor once so it generates `My Prowl Game.Game.csproj`. Skip this if that file is already there.
2. From the project root:

```bash
dotnet run --project "My Prowl Game.Game.csproj"
```
