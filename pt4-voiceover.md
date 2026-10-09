# Part 4 — Move the player

Tag `pt4-player-movement`. This file is on `main` because Part 4 has no branch. The tag was not moved. Read this after the silent edit. Numbers match **Move the player** in that tag’s README.

## Intro

The menu can open a scene. Nothing in that scene walks yet. I’m putting a character controller on a player, and WASD plus Space will move it.

## Move the player

### 1
Open `Assets/Scenes/Game.scene`. You should see a Main Camera, a Directional Light, a Floor with a mesh collider, and a Player. The floor is what we stand on. Without that collider, the controller falls forever.

### 2
Click Player. The Inspector has a Character Controller and the Player component from `Assets/Scripts/Player.cs`. The child named Mesh is the visible shape. The prefab is `Assets/Prefabs/Player.prefab`. The script stays on the parent. The mesh is only the picture.

### 3
Skip this if the scene already has that player. If you’re building it from the end of Part 3: add a floor with a collider, create Player with a mesh child, add Character Controller, add the Player component, and leave Move Speed at 6, Jump Speed at 8, and Gravity at minus 20. Keep rotation at 0, 0, 0. Aim the camera at the player, then drag Player into `Assets/Prefabs`. Those three numbers are the whole feel. I don’t tune them until the move is actually on the ground.

### 4
Save the Game scene.

## Play

The tag README doesn’t number these. They’re the Play CHECK and the last paragraph, in order.

### 1
Open `Assets/Scenes/TitleScreen.scene`. We still come in through the menu.

### 2
Enter Play mode.

### 3
Click Play Game.

### 4
Wait through the loading screen.

### 5
WASD moves the player. Space jumps. That’s the check. If you fall through the floor, the floor’s collider is missing, not the script.

## Code on screen

Drop these on the cuts where `Player.cs` is up. They are not extra README steps.

### Update
`Input.GetWASD()` is a 2D vector. X and Z come from this transform’s Right and Forward, times Move Speed. While the controller is grounded and we’re not already rising, Space sets Y to Jump Speed. In the air, Gravity times delta time pulls Y down. `CharacterController.Move` gets that velocity times delta time. Start just caches the controller. The attribute on the class requires one, so the component has to be on the same object.

## Outro

Like and subscribe if the jump landed. Next time a cube spins in the editor, and the same spin runs from the command line.
