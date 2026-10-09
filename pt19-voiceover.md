# Part 19 — Raycast gun

Branch `pt19-raycast-gun`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

No weapon type in Prowl. I’m putting a gun script on the player that fires a ray from the camera, spends ammo, and shoves whatever rigidbody it hits. A crate counts three hits and disappears. R reloads. The button from last time still works, and it must not spend a round.

## Steps

### 1
Double-click `Assets/Prefabs/Player.prefab`.

### 2
Click Player.

### 3
Add Component, Gun, if it isn’t there.

### 4
Magazine Size 12.

### 5
Fire Cooldown 0.12. That’s the gap between shots while you hold the button. Twelve rounds go fast if you don’t notice this.

### 6
Reload Seconds 1.

### 7
Range 50.

### 8
Hit Impulse 6. That’s the shove on a rigidbody. The door and the crate both have one.

### 9
Inspector header, Apply, if the button is enabled.

### 10
Double-click `Assets/Scenes/Game.scene`.

### 11
Click Crate.

### 12
If it’s missing: menu GameObject, Empty Object. Rename it Crate. Same pattern as the gate. The visible box is built at Play.

### 13
Position 3, 0, 4.

### 14
Add Component, Practice Crate, if it isn’t there.

### 15
Hits 3.

### 16
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
Under the speed line: 12/12.

### 4
Hold the left mouse button on the red crate at 3, 0, 4.

### 5
The crate moves. The Console counts down. On the third hit the crate disappears. The ammo count drops.

### 6
Hold fire until the count is 0. Fire does nothing.

### 7
Press R. The line says Reloading, then 12/12.

### 8
Shoot the door. The Console names the hit. The door shoves. It’s a rigidbody on a hinge, so the impulse has something to push.

### 9
Press Escape. Click Toggle. The door toggles. The ammo count does not drop. An unlocked cursor is for the button. The gun refuses to fire while the cursor is free.

### 10
Stop.

## Code on screen

Drop these on the cuts where `Gun.cs` and `PracticeCrate.cs` are up. They are not extra README steps.

### Ammo and reload
Start fills the magazine. Update bails if Player is disabled, which is the car. While a reload timer is running, we wait, then refill, and we don’t also shoot. R starts that timer only if the magazine isn’t already full.

### The shot
A locked cursor is the aim. If it isn’t locked, we return. Hold left mouse, cooldown finished, ammo above zero: spend one, reset the cooldown, call Fire.

### Raycast
Origin is the camera position. Direction is the camera Forward. `PhysicsWorld.Raycast` takes origin, direction, distance, then the hit. The direction does not have to be normalized. A miss logs “Gun: miss”. A hit looks up `PracticeCrate` on the parent and calls `TakeHit`. If the hit has a rigidbody, `AddForceAtPosition` with `ForceMode.Impulse` shoves it along the shot.

### The ammo line
OnGui again. The box id is ammo, self-directed, position 16, 48, so it sits under the speed line. Reloading replaces the count.

### PracticeCrate
Start builds a 0.7 cube, red, a box collider, and a rigidbody of mass 4, parented to the marker so the Inspector hits field stays on the object you placed. `TakeHit` decrements, logs the remaining hits, and at zero disables the parent. The child goes with it.

## Outro

Like and subscribe if the crate actually fell over. Next time those hits mean something. Health on you, health on a hostile, and a plus in the middle of the screen.
