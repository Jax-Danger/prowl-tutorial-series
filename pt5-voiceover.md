# Part 5 — Spin a cube

Tag `pt5-rotating-cube`. This file is on `main` because Part 5 has no branch. The tag was not moved. Read this after the silent edit. Numbers match that tag’s README.

## Intro

The player moves. This episode is smaller on purpose. I’m rotating a cube ninety degrees a second, first in the editor, then from `dotnet run` with no editor in the way.

## Spin a cube in the editor

### 1
Open `Assets/Scenes/Game.scene`. Same scene as the player. The cube is an extra object in it.

### 2
Create a Cube. Any size is fine. The script turns the transform, not the mesh.

### 3
Add the Spin component from `Assets/Scripts/Spin.cs`. Leave degrees Per Second at 90. Ninety is one full turn every four seconds, which is slow enough to see that it’s Y and not a tumble.

### 4
Enter Play mode. The cube rotates around Y, 90 degrees each second. Stop when you’ve shown a full turn. The player can still be in this scene. Ignore them for this shot.

## Run it from the command line

### 1
Open the project in the editor once so it generates `My Prowl Game.Game.csproj`. Skip this if that file is already there. The editor writes the project file. We don’t hand-author the HintPaths.

### 2
From the project root, run `dotnet run --project "My Prowl Game.Game.csproj"`. That builds the exe and opens the spinning-cube scene. Same spin, no Play button.

## Code on screen

Drop these on the cuts where the scripts are up. They are not extra README steps.

### Spin
`degreesPerSecond` is the Inspector field, default 90. `Update` is an override, or it never runs. `Transform.Rotate` around `Float3.UnitY`, by degrees per second times `Time.DeltaTime`. Delta time keeps the speed in degrees per second instead of degrees per frame.

### MyProwlGame.Initialize
`Boot/MyProwlGame.cs` is the entry point, outside `Assets/Scripts`. `Main` runs the game at 1280 by 720. `Initialize` builds a scene from `RotatingCubeScene` and calls `Scene.Load`. The command-line run never opens Title Screen. It loads this scene directly.

### RotatingCubeScene
`Initialize` makes a scene named SpinningCube. It adds a directional light tilted to minus 50, 30, 0, a camera at 0, 1.5, minus 5 tagged Main Camera, and a cube with a unit mesh, the standard shader, and Spin on it. That’s the whole view the exe opens. The editor cube and this cube are two setups of the same component.

## Outro

Like and subscribe if both the editor and the exe turned the same way. Next time the mouse looks: the camera sits on the player, and left and right turn the body.
