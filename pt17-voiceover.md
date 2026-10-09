# Part 17 — OnGui

Branch `pt17-ongui`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The loading screen already draws with OnGui. I’m putting the same immediate-mode UI on the player: speed, whether the camera is orbiting or at the eye, and the two keys we keep forgetting. Nothing is stored on a widget. The string is new every frame.

## Steps

### 1
Double-click `Assets/Prefabs/Player.prefab`.

### 2
Click Player.

### 3
Add Component, Play Hud, if it isn’t there.

### 4
Play Hud has no fields. There is nothing to type. The line is built in code.

### 5
Inspector header, Apply, if the button is enabled.

### 6
Ctrl+S.

## Play

### 1
Double-click the title scene.

### 2
Play. Click the Game view. Click Play Game.

### 3
Top left: speed at 0.0, the word orbit or eye, then V camera and E gate.

### 4
Walk. The speed number rises. That’s planar speed, metres a second, the same number the animator uses. Jumping doesn’t add to it.

### 5
Press V. The word switches between orbit and eye.

### 6
Press F at the car. The line hides. Play Hud stays enabled. Player does not, and the script returns while Player is disabled. Press F. The line returns.

### 7
Stop.

## Code on screen

Drop these on the cuts where `PlayHud.cs` is up. They are not extra README steps.

### OnGui
The method is `OnGui(Paper paper)`. It runs every frame while the component is enabled. We get Player. If it’s missing or disabled, we return. That’s the car. Vehicle Ride turns Player off and leaves this component on, so we hide the line ourselves.

### The line
Default font, then `paper.Box` with the id hud, a margin of 16, height 28. The text is speed to one decimal, orbit or eye from `PlayerLook.ThirdPerson`, and the key hints. Font size 18, white. Search the call by the id if you need to find it. A new string every frame is the point. Nothing is stored on a widget.

## Outro

Like and subscribe if the number tracked your walk. Next time we build a real canvas and a button, the kind that stays in the scene instead of being redrawn every frame.
