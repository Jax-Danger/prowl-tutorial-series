# Part 3 — Loading screen

Branch `pt3-loading-screen`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

Play dumps us straight into the game. I’m putting a loading scene in the middle. It waits a second and a half, then loads Game. This is a timer and a blocking `Scene.Load`. It is not async. We do the real async load much later.

## Steps

### 1
Open the Part 2 project.

### 2
Copy `SceneLoadRequest.cs`, `LoadingScreen.cs`, and `TitleScreen.cs` into the project Scripts folder.

### 3
Wait until the Console is clear. Three new types, and the title script now has a second scene slot.

### 4
Menu File, New Scene. This scene is only the loading screen.

### 5
Menu GameObject, UI, Canvas.

### 6
Menu GameObject, UI, Text. In the Inspector, set the text to Loading... That’s the only thing this scene needs to say.

### 7
Click the canvas. Add Component, Loading Screen. The script lives on the canvas so it runs while that text is up.

### 8
Min Display Seconds: 1.5. That’s the minimum time the words stay up, even if the next scene is already in memory.

### 9
Menu File, Save Scene As. Name it Loading Screen, and save it under Scenes.

### 10
Open `TitleScreen.cs` from this branch if it isn’t the one in the project. Play stores the game scene on `SceneLoadRequest.Destination`, then loads the loading scene. The title screen no longer loads Game itself.

### 11
Open the Title Screen, and click Menu Controller.

### 12
Inspector, Title Screen, Loading Scene: drag `Scenes/Loading Screen`.

### 13
Game Scene: drag `Scenes/Game`. Two slots. One is what we show now. One is where we go after the wait.

### 14
Ctrl+S.

## Play

### 1
Double-click `Scenes/Title Screen`.

### 2
Toolbar, Play.

### 3
Click Play Game.

### 4
Loading... stays about a second and a half, then the Game scene is current. The wait is `minDisplaySeconds`. The swap at the end is still `Scene.Load`.

### 5
If the Console says Loading scene not found, the Loading Scene slot is empty.

### 6
If it says the loading screen has no destination set, the Game Scene slot is empty. The title screen writes that destination before it loads the loading scene, so an empty slot means we never gave it a place to go.

### 7
Stop.

## Code on screen

Drop these on the cuts where the scripts are up. They are not extra README steps.

### SceneLoadRequest
A static `AssetRef<Scene> Destination`. The title screen writes it. The loading screen reads it. The two scenes don’t have to know about each other’s objects.

### TitleScreen.OnPlayClicked
It assigns `SceneLoadRequest.Destination = gameScene`, loads the loading scene asset, and calls `Scene.Load` on that. Game is not loaded here anymore.

### LoadingScreen.Update
`elapsed` climbs by `Time.DeltaTime`. Under 1.5 seconds, it returns. Then it loads `Destination`. A null destination logs the error, sets `done`, and stops. Otherwise `done` goes true and `Scene.Load` swaps to Game. `done` matters so we don’t call Load every frame after that.

## Outro

Like and subscribe if you want the next part in the feed. Next time we stop looking at menus and move a player.
