# Part 2 — Change scenes

Branch `pt2-change-scenes`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

Play currently just hides the menu. I’m going to give it a second scene and load that scene from the button.

## Steps

### 1
Open the Part 1 project. We’re adding to it, not starting over.

### 2
Menu File, Save Scene As. Name it Title Screen. The menu we built last time needs a file of its own before we make a new scene.

### 3
File, New Scene, then File, Save Scene As, and name it Game. This empty scene is the one Play is going to open.

### 4
In the Project panel, make folders Scenes, Prefabs, and Scripts. I do this before the project turns into a pile of files on the root.

### 5
Drag the title scene, the title prefab, and the scripts into those folders.

### 6
Replace `Scripts/TitleScreen.cs` with the file from this branch. The new field is `gameScene`, an `AssetRef` of a scene.

### 7
Wait until the Console has no script errors. If it’s red, the slot in the Inspector won’t show up.

### 8
In the Hierarchy, click Menu Controller.

### 9
Inspector, Title Screen, Game Scene: drag Project `Scenes/Game` into that slot. That’s the scene Play will load. An empty slot is the bug we’re about to prove.

## Play

### 1
In the Project panel, double-click `Scenes/Title Screen`. Start from the menu, not from the empty Game scene.

### 2
Toolbar, Play.

### 3
In the Game view, click Play Game.

### 4
The Hierarchy title changes to the Game scene. That’s `Scene.Load`. The menu is gone because we left its scene.

### 5
If the Console says Game scene not found, the Game Scene slot is empty. Drag the scene in again. `EnsureLoaded` can’t invent a file you didn’t assign.

### 6
Stop.

## Code on screen

Drop these on the cuts where `TitleScreen.cs` is up. They are not extra README steps.

### gameScene
`AssetRef<Scene> gameScene` is the Inspector slot. It’s a reference to the scene asset, not a live scene yet.

### OnPlayClicked
`EnsureLoaded` pulls the asset in. `gameScene.Res` is the scene, or null. Null logs “Game scene not found” and returns. Otherwise we log the name and call `Scene.Load`. That call is what swaps the Hierarchy over to Game.

Quit is unchanged from Part 1. Editor clicks still refuse to close the editor.

## Outro

Like the video if the scene swap landed, and subscribe so the next one shows up. Next time Play doesn’t jump straight into the game. It sits on a loading screen first.
