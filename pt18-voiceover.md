# Part 18 — GameObject UI

Branch `pt18-game-ui`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

OnGui redraws a string. This time I’m building a canvas, a text line, and a button out of GameObjects. The script does it at Play. You won’t see them painted in the scene file. The button toggles the gate. E still works.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Click Game UI.

### 3
If it’s missing: menu GameObject, Empty Object. Rename it Game UI. This empty object is going to hold the script. The canvas is created from code, not from the UI menu.

### 4
Add Component, Game Menu, if it isn’t there.

### 5
Game Menu has no fields.

### 6
Click Gate. The Physics Gate fields stay at the Part 15 values. Open speed 2.2, use distance 3, min minus 4, max 95. The button calls the same toggle E uses, without the distance check.

### 7
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
Bottom of the screen: a button that says Toggle. Above it: Gate is shut.

### 4
The Part 17 speed line is still at the top left. Immediate mode and this canvas are on screen together.

### 5
Press Escape. A locked cursor misses the button. Escape unlocks it. I learned that the first time I tried to click and nothing happened, because the cursor was still locked.

### 6
Click Toggle. The door swings open. The line says Gate is open.

### 7
Click Toggle. The door swings shut. The line says Gate is shut.

### 8
Click the Game view. Walk within 3 metres of the gate. Press E. The door still moves. The button didn’t replace the key.

### 9
Stop.

## Code on screen

Drop these on the cuts where `GameMenu.cs` and the new gate method are up. They are not extra README steps.

### Canvas and event system
Start makes a GameObject named Canvas, gives it a RectTransform, a `GameCanvas`, and an `EventSystem`. Game Canvas lays out the rects and draws without an event system. The event system is what turns a click into `UIButton.OnClick`. One enabled event system per scene.

### The label
A child named Hint, anchored to the bottom center, size 360 by 32, sitting at Y 76. `TextComponent` says Gate is shut, size 22, centered, white.

### The button
A child named Toggle, 220 by 44, at Y 24. `UIImage` uses `Sprite.LoadDefault` of the UI panel, tinted blue. `UIButton.TargetGraphic` is that image. `OnClick` is a C# event. We add `Toggle`. A caption child stretches to the button and says Toggle.

### ToggleDoor
The button finds the `PhysicsGate` and calls `ToggleDoor`. That flips `_open` and sets the hinge motor. `IsOpen` updates the label. E still goes through the distance check in Update, and then it calls this same method. The button skips the distance. You can shut the door from across the courtyard.

## Outro

Like and subscribe if the button and the key both moved the door. Next time we shoot. A ray from the camera, a magazine, and a crate that counts hits.
