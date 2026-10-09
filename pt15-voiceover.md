# Part 15 — Hinge

Branch `pt15-physics-joints`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The courtyard gate is a hole. I’m putting a door on a hinge joint. The script builds the door at Play, so the scene file doesn’t have to serialize the joint. E within three metres swings it. E again shuts it. An empty Connected Body pins the hinge to the world.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Click Gate.

### 3
If it’s missing: menu GameObject, Empty Object. Rename it Gate. This empty object is the marker. The door is created next to it when you press Play.

### 4
Position 6, 0, 8.

### 5
Add Component, Physics Gate, if it isn’t there. The menu path for a hand-placed joint is Physics, Joints, Hinge Joint. We don’t add that component. The script does, after the rigidbody, because the joint looks up its body when it enables.

### 6
Open Speed 2.2. That’s the motor’s target velocity, in radians.

### 7
Use Distance 3. Farther than this, E does nothing.

### 8
Min Angle minus 4. A few degrees of slack so the door sits against the closed stop instead of buzzing on zero.

### 9
Max Angle 95. Almost flat open, not a full swing through the frame.

### 10
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
A door and a grey post appear at the gate. The door stays upright. The post does not move. The post has no collider and no rigidbody. It’s a picture of the pin.

### 4
Stand more than 3 metres away. Press E. The door does not move.

### 5
Stand within 3 metres. Press E. The door swings open and stops.

### 6
Press E. The door swings shut and stops.

### 7
Stop.

## Code on screen

Drop these on the cuts where `PhysicsGate.cs` is up. They are not extra README steps.

### The door
Start builds a thin box: 0.12 on X, 2.2 on Y, 1.1 on Z. The hinge pin is the minus Z edge. Cube mesh, a brown material, a box collider of that same size.

### Rigidbody first
Mass 12, a little linear and angular damping. The hinge’s OnEnable looks up the body on the same object. Add the rigidbody before the joint or the joint grabs nothing.

### The hinge
Connected Body stays empty, so the pin anchors to the world, `World.NullBody`. Anchor is the local minus Z edge. Axis is local Y. Min and max are the Inspector degrees. The motor is on, max force 80, target velocity 0 until E.

### The post
A grey cube, no collider. It doesn’t take part in the physics. It’s there so you can see where the pin is.

### E
We read `CurrentAngleDegrees`. Within 3 degrees of the open or closed limit, motor velocity goes to zero. A motor left running into the limit fights the limit and the door jitters. E only counts if the player is enabled and inside Use Distance. Then we flip open and set the motor positive or negative Open Speed.

## Outro

Like and subscribe if the door stopped at the end of the swing. Next time the loading screen stops blocking. We load the game in the background and hold the swap until the bar and the timer are both done.
