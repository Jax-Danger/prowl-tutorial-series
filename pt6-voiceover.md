# Part 6 — Player with camera

Branch `pt6-player-with-cam`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The player can already walk. The mouse doesn’t look anywhere. I’m parenting a camera to the player and writing `PlayerLook`, so left and right turn the body and up and down tilt only the view.

## Steps

### 1
In the Project panel, double-click `Assets/Scenes/Game.scene`.

### 2
Click Player in the Hierarchy.

### 3
The Inspector should show a Character Controller and the Player script, and no Mesh Renderer on this object. The body mesh is a child. The parent stays a transform plus scripts.

### 4
If Mesh Renderer is still on Player, menu GameObject, Empty Parent. Rename that new parent Player, rename the old object Mesh, and move Character Controller and Player onto the empty parent. Leave the renderer on Mesh. I do it this way so yawing the parent turns the mesh without the camera fighting a renderer on the root.

### 5
On the parent Transform, Local Rotation 0, 0, 0. We start facing forward. The script stores that yaw in Start.

### 6
Click Player. Menu GameObject, Camera.

### 7
If Camera is not a child, drag it onto Player. Look has to be a child so it inherits the body’s yaw.

### 8
Click Camera.

### 9
Local Position 0, 1.6, 0. Local Rotation 0, 0, 0. Local Scale 1, 1, 1. 1.6 is eye height. Pitch is going to live on this local X, so it starts at zero.

### 10
On the Camera component, Field Of View 60.

### 11
Copy `Assets/Scripts/PlayerLook.cs` in if it isn’t there, and wait until the Console is clear.

### 12
Click Player, the parent, not the camera.

### 13
Add Component, Player Look.

### 14
View Camera: drag the Camera child into that slot. If you leave it empty, Start searches the children, but I like the slot filled so I can see it.

### 15
Sensitivity 0.15. That’s degrees per mouse pixel, the same number as Prowl’s first-person template.

### 16
Click Main Camera, the one that is a sibling of Player, not the child, and delete it. Two cameras and the game view gets confused about who is rendering.

### 17
Click Player. In the Inspector header, Apply. That writes the camera and the script back onto the prefab.

### 18
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`. We still enter through the menu.

### 2
Toolbar, Play.

### 3
Click the Game view once. That click is for the cursor. Look locks the mouse, and the editor needs the view focused.

### 4
Click Play Game, and wait through loading.

### 5
WASD moves along the facing. Space jumps. Movement reads this transform’s Forward and Right, so turning changes which way we walk.

### 6
Mouse left and right turns the body and the camera together. Mouse up and down tilts only the camera. The body stays upright. Pitch clamps around minus 80 to 80 so you can’t flip over the top.

### 7
Escape shows the cursor. Click the Game view to lock it again.

### 8
Stop.

## Code on screen

Drop these on the cuts where `PlayerLook.cs` and `Player.cs` are up. They are not extra README steps.

### PlayerLook fields
`Sensitivity` is the 0.15 from the Inspector. `ViewCamera` is the child we dragged in. `MinPitch` and `MaxPitch` are the clamp.

### Start
Lifecycle methods only run if they’re `override`. Start grabs a child camera when the slot is empty, stores the current yaw, stores the camera’s pitch, and calls `Input.LockCursor()`. That hides the cursor and pins it.

### Escape and the click
Escape calls `UnlockCursor`. If the cursor is free and you left-click, it locks again. If the cursor isn’t locked, Update returns, so looking doesn’t fight the UI.

### MouseDelta
`Input.MouseDelta` is the pixel delta this frame. X adds to yaw. Y adds to pitch, then we clamp it. Moving the mouse up looks up. Same sign as the editor camera.

### Writing the rotations
The player’s local Euler is X 0, yaw, Z 0. Pitch and roll stay zero so the capsule stays upright. The camera child gets pitch on X only. The mesh is a child, so it turns with the body.

### Player movement
WASD becomes `Transform.Right` times X plus `Transform.Forward` times Y. Because look already yawed this transform, walk follows the facing. Jump only happens when the controller is grounded.

## Outro

Like and subscribe if the look stuck. Next time we leave preview-4 and pin the engine to 1.0-preview.5, and a few of these calls have to change.
