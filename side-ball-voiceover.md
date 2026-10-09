# Side — Rolling ball

Branch `side-ball-controller`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

This one is off the main line. It branches from Part 13. Parts 14 through 20 do not have this ball. I’m possessing a physics sphere with B: torque from the camera, a hop, and the camera sitting behind it instead of on your head. B again puts you back on your feet.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Click Ball.

### 3
If it’s missing: menu GameObject, Empty Object. Rename it Ball. Start builds the sphere if there isn’t a renderer yet, so the marker can stay empty.

### 4
Position 4, 1.2, 2.

### 5
Add Component, Ball Controller, if it isn’t there.

### 6
Torque 18.

### 7
Jump Impulse 5.

### 8
Radius 0.45.

### 9
Enter Distance 4. Same idea as the car. Too far, B does nothing.

### 10
Camera Distance 5.5.

### 11
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
A blue ball is on the ground at 4, 1.2, 2.

### 4
Walk within 4 metres. Press B. The body hides. The camera sits behind the ball.

### 5
WASD rolls along the camera. Mouse looks. Space hops once per landing.

### 6
Press B. You stand beside the ball. The eye camera is back.

### 7
Stop.

## Code on screen

Drop these on the cuts where `BallController.cs` is up. They are not extra README steps.

### Start
If there’s no mesh renderer, we add a sphere of the given radius and a blue material. If there’s no sphere collider, we add one. If there’s no rigidbody, we add one, mass 1.2, a little damping. The marker in the scene can be empty. Play fills it in.

### B
`KeyCode.B`. If we’re driving, Exit. Otherwise TryEnter. We ignore B while Player is disabled, which is the car from Part 9. You don’t possess a ball from the driver’s seat.

### TryEnter
Inside Enter Distance, we turn off look, the animator, the character controller, and Player. We remember the camera’s parent and local pose, unparent the camera, and hide every child of the player except the camera. The camera is not a child of the ball. The ball’s spin must not roll the view.

### Torque
FixedUpdate, not Update. We take the camera’s forward and right, flatten them, and `AddTorque` about those axes. `ForceMode.Acceleration` ignores mass, so the 1.2 kilograms doesn’t make the feel mushy. W rolls forward along the view. A and D roll sideways.

### Camera and hop
Yaw around world Y, then pitch around world X, and we place the camera at a pivot above the ball, back along its forward by Camera Distance. Space adds an upward impulse only if a short ray under the sphere hits ground. That ray starts just outside the radius, so we don’t hit ourselves and decide we’re always grounded.

### Exit
We put the camera back on the player, teleport the character controller beside the ball, call `MatchYawToTransform` so look matches the facing, and turn the player components back on.

## Outro

Like and subscribe if the ball actually rolled the way you were looking. Back on the main line, the next episode after Part 13 is the third-person orbit. This ball does not show up there.
