# Spin a cube in the editor and from the command line

**Video:** coming. There is no public Part 5 URL yet.

Part 5. You open this repo as a Prowl project, spin a cube in the editor with `Spin`, and launch the game from the command line with `Boot/MyProwlGame.cs`.

Engine download: https://github.com/ProwlEngine/Prowl (this series uses **1.0-preview-4**).

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt5-rotating-cube
```

The folder you cloned is the project root. It contains `Assets/`, `Boot/`, `My Prowl Game.prowl`, `My Prowl Game.slnx`, `Directory.Build.props`, and `Directory.Build.targets`.

## Open the project

1. In the Prowl editor, open `My Prowl Game.prowl`.
2. The editor creates `ProjectSettings/`, `Library/`, and the `.csproj` files locally. Those stay on your machine. The `.csproj` HintPaths point at your Prowl install, so they are gitignored. `ProjectSettings/` is created on open; `Assets/` plus the `.prowl` file is enough to clone.

`Assets/Scenes` still has **TitleScreen**, **LoadingScreen**, and **Game**. `Assets/Prefabs` has the title menu and the **Player**. `Assets/Scripts` has the scripts from Parts 1–4 plus `Spin.cs`.

## Spin a cube in the editor

3. Open `Assets/Scenes/Game.scene` (or any scene you want the cube in).
4. Create a **Cube**.
5. `Assets/Scripts/Spin.cs` is already in the project. Add the **Spin** component to the cube. Leave `degreesPerSecond` at **90**.

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

6. Enter Play mode. The cube turns around Y. `Transform.Rotate` uses `Float3.UnitY` and `degreesPerSecond * Time.DeltaTime`, so 90 degrees per second is one full turn every 4 seconds.
7. Stop Play and save the scene if you want the cube to stay.

## Run from the command line

`Boot/MyProwlGame.cs` is the CLI entry. It lives next to `Assets/`, outside `Assets/Scripts`. `Main` starts the game window at 1280×720:

```csharp
using System;

using Prowl.Runtime;
using Prowl.Runtime.Rendering;
using Prowl.Runtime.Resources;
using Prowl.Vector;

using Scenes;

public sealed class MyProwlGame : Game
{
    public static int Main(string[] args)
    {
        new MyProwlGame().Run("My Prowl Game", 1280, 720);
        return Environment.ExitCode;
    }

    public override void Initialize()
    {
        var Scene = RotatingCubeScene.Initialize();

        Scene.Load(scene);
    }
}
```

`Directory.Build.targets` is already in the project root. You do not write that MSBuild yourself. For a project whose name ends in `.Game` it:

- sets `OutputType` to `Exe` and `StartupObject` to `MyProwlGame`
- compiles `Assets/Scripts/**/*.cs` and `Boot/MyProwlGame.cs`
- writes the build to `bin/play/`
- copies the engine's native libraries beside that output

`Directory.Build.props` is the Prowl template for package references. The editor rewrites `.csproj` files and leaves this file alone. `My Prowl Game.slnx` lists `My Prowl Game.Editor.csproj` and `My Prowl Game.Game.csproj`, which the editor generates.

8. Open the project in the editor once so it generates `My Prowl Game.Game.csproj`. If that file is already present, you can skip the wait.
9. From the project root:

```bash
dotnet run --project "My Prowl Game.Game.csproj"
```

## Check

In the editor, Play on the scene with the cube: it spins about Y.

From the shell, `dotnet run --project "My Prowl Game.Game.csproj"` builds the Game project as an executable and starts `MyProwlGame.Main`.
