# Part 20 — FPS combat

Branch `pt20-fps-combat`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The gun hits crates and doors. It doesn’t hit a person, because Prowl has no health component and no crosshair. I’m adding both, plus a hostile that shoots back with the same raycast. A character controller is not a collider. If the hostile’s ray hits something more than 0.6 metres short of you, that’s a wall.

## Steps

### 1
Double-click `Assets/Prefabs/Player.prefab`.

### 2
Click Player.

### 3
Add Component, Health, if it isn’t there.

### 4
Max Hit Points 5. Disable Object On Death off. Off on purpose. Turning off the whole player object would take the camera with it. Death turns off Player and Gun, and leaves the look.

### 5
Add Component, Combat Hud, if it isn’t there.

### 6
Inspector header, Apply, if the button is enabled.

### 7
Double-click `Assets/Scenes/Game.scene`.

### 8
Click Hostile.

### 9
If it’s missing: menu GameObject, Empty Object. Rename it Hostile.

### 10
Position 0, 0, 14.

### 11
Add Component, Health, if it isn’t there.

### 12
Max Hit Points 8. Disable Object On Death on. This one can disappear. It doesn’t own the camera.

### 13
Add Component, Hostile Shooter, if it isn’t there.

### 14
Range 16. Cooldown 1.1. Damage 1. About one shot a second, one point each.

### 15
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
A plus is in the center. Under the ammo line: HP 5/5.

### 4
A dark red figure is at 0, 0, 14.

### 5
Walk toward it in the open. About once a second the Console says Hostile: hit. HP counts down.

### 6
Stand behind a courtyard wall. Console: Hostile: blocked. HP holds.

### 7
Shoot the figure. The Console counts its points down. At 0 the figure disappears.

### 8
Stand in the open until HP hits 0. You’ll want a fresh Play for this if you already spent the points. Death and the hostile going down are two different takes.

### 9
The line says Down. The plus is gone. WASD does nothing. The mouse still looks. Player and Gun are off. Player Look is not.

### 10
Stop.

## Code on screen

Drop these on the cuts where the new scripts are up. They are not extra README steps.

### Health
`MaxHitPoints` and `DisableObjectOnDeath`. Start sets `HitPoints` to the max. `TakeDamage` subtracts, clamps at zero, and logs the name and the fraction. Above zero, that’s it. At zero, `IsDead` goes true. If the flag is on, the whole GameObject disables. If it’s off, only Player and Gun disable. The camera stays because it’s a child of an object that’s still enabled, and look is still enabled.

### The figure
Hostile Shooter’s Start builds a static box, 0.6 by 1.8 by 0.6, local Y 0.9, dark red, a box collider, no rigidbody. A static collider is enough for your ray. The hostile’s own muzzle is placed in front of this box so it doesn’t shoot itself.

### The hostile shot
Skip if we’re dead, on cooldown, the player is disabled, or the player’s health is dead. Face them on Y with atan2 of X and Z. The ray origin is position plus 1.2 up, plus 0.7 along the flat forward. `Raycast` toward your chest. A hit whose distance is more than 0.6 short of the aim point is a wall, and we log Hostile: blocked. Anything else calls `TakeDamage` and logs Hostile: hit. We don’t expect the ray to hit the character controller. It isn’t a physics collider.

### The gun’s new line
After the crate check, we look for `Health` on the parent of the collider, or on the rigidbody, and call `TakeDamage(1)`. One round, one point. The crate path is still there.

### CombatHud
If we’re not dead and Player is disabled, return. That’s the car. If we’re alive, a box stretches to the full screen, text is a plus, middle center, and `IsNotInteractable` so the plus doesn’t eat the Part 18 button. `TextAlignment` has to be the Paper one. Scribe has a type with the same name, and an unqualified name doesn’t compile. The HP line sits at position 16, 80, under the ammo. At zero the plus goes away and the line says Down, in red.

## Outro

That’s the combat loop for this series. If it worked, a like helps, and subscribe if you want the next thing I record. The rolling ball is a side episode off Part 13. It is not the next episode on this line.
