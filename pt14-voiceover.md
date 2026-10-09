# Part 14 — Third person

Branch `pt14-third-person`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

We’ve been looking out of the character’s eyes since Part 6. I’m turning on an orbit camera: behind the body, zoom on the wheel, and a raycast so the camera doesn’t sit inside a wall. V switches back to the eye point.

## Steps

### 1
Double-click `Assets/Prefabs/Player.prefab`.

### 2
Click Player.

### 3
On Player Look, Third Person on. That bool starts us behind the body. Off is the Part 6 eye point.

### 4
Orbit Distance 4.5. Metres from the pivot to the camera.

### 5
Min Orbit Distance 1.2.

### 6
Max Orbit Distance 8. The wheel clamps between these two. One notch can’t throw the camera across the map.

### 7
Pivot Height 1.45. That’s the point we orbit around, above the feet, not the eyes.

### 8
View Camera: the Camera child.

### 9
Sensitivity 0.15. Same as Part 6.

### 10
Inspector header, Apply, if the button is enabled.

### 11
Ctrl+S.

## Play

### 1
Double-click the title scene.

### 2
Play. Click the Game view. Click Play Game.

### 3
The camera starts behind the body. WASD follows the facing. Yaw is still on the player, so walk didn’t change.

### 4
Mouse left and right turns the body. Mouse up and down orbits. Mouse up looks up and drops the camera, same pitch sign as Part 6.

### 5
The mouse wheel stops at distance 1.2 and at 8.

### 6
Walk into a wall. The camera stays in front of the wall. That’s a ray from the pivot to where the camera wants to be.

### 7
Press V. The camera is at the eye point, local 0, 1.6, 0, the position we stored in Start. Press V again. The orbit returns.

### 8
Press F next to the car. The chase camera is on the car. Vehicle Ride disables Player Look while you’re driving, so the orbit doesn’t fight the chase cam. Press F. The orbit returns.

### 9
Stop.

## Code on screen

Drop these on the cuts where `PlayerLook.cs` is up. They are not extra README steps.

### The new fields
`ThirdPerson`, the orbit distance and its min and max, and `PivotHeight`. V toggles the bool.

### Start
We store the camera’s local position in `_eyeLocal`. On the prefab that’s 0, 1.6, 0. First person puts the camera back there. We still lock the cursor.

### V and the wheel
`KeyCode.V` flips `ThirdPerson`. This component is disabled in the car, so the chase cam is left alone. While we’re in third person, `MouseWheelDelta` changes the distance. I clamp the wheel to plus or minus 2 first, so a fast flick doesn’t teleport the camera.

### Placing the orbit
Yaw the body first, pitch and roll zero. Then set the camera’s pitch, and read Forward after that. The camera sits at the pivot plus forward times negative distance, so it’s behind the look direction. Positive pitch raises the view and drops the camera.

### PullIn
`PhysicsWorld.Raycast` from the pivot toward the desired point. Distance is the third argument, then the hit. A hit parks the camera a quarter metre in front of the wall, and never closer than the minimum orbit distance. The character controller is not a collider, so this ray is about walls, not about hitting yourself.

## Outro

Like and subscribe if the camera stayed out of the wall. Next time we hang a door on a hinge and swing it with E.
