# Part 16 — Async load

Branch `pt16-async-load`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

Part 3 waited on a timer, then called `Scene.Load`, and that call blocks. I’m switching the loading screen to `Scene.LoadAsync`. The scene preloads in the background, the text shows a percent, and we don’t swap until at least a second and a half has passed and the preload is finished.

## Steps

### 1
Copy `Assets/Scripts/LoadingScreen.cs` into the project if it isn’t already there.

### 2
Wait until the Console has no script errors. This file pulls in Paper and Scribe for the percent line.

### 3
Double-click `Assets/Scenes/LoadingScreen.scene`.

### 4
Click the object with the Loading Screen component.

### 5
Min Display Seconds 1.5. Same floor as Part 3. The difference is we can start the load immediately and hold the activation.

### 6
Ctrl+S.

### 7
Double-click `Assets/Prefabs/TitleScreen.prefab`.

### 8
Click the object with Title Screen.

### 9
Loading Scene: `Assets/Scenes/LoadingScreen.scene`.

### 10
Game Scene: `Assets/Scenes/Game.scene`. The title screen still writes the destination. The loading screen is what changed.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play.

### 3
Click Play Game.

### 4
The loading scene stays at least 1.5 seconds. The text shows Loading and a percent.

### 5
The Game scene becomes current. The Console does not say the destination is missing.

### 6
Stop.

## Code on screen

Drop these on the cuts where `LoadingScreen.cs` is up. They are not extra README steps.

### LoadAsync
Once we have a destination, `Scene.LoadAsync` starts the preload and returns a `SceneLoad`. `WaitForActivation` is true, so the engine will not swap the scene until we allow it. A second `LoadAsync` would cancel this one.

### Allow
`Progress` is 0 to 1 from the preload group. `IsDone` stays false until the engine calls Activate at the end of a frame. If you wait on `IsDone` before `Allow`, you wait forever. We call `Allow` when the elapsed time is at least the minimum and progress is at least 1.

### OnGui
`OnGui` gets a Paper context. `paper.Box` is rebuilt every call. We print `Loading` and the percent from progress. The font is the default font asset. Part 17 uses this same `OnGui` for a gameplay line. This one is only the loading text.

## Outro

Like and subscribe if the percent actually moved. Next time that same OnGui draws a speed readout while you play.
