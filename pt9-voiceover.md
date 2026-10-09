# Part 9 — Vehicle

Branch `pt9-vehicle`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

I’m building a car out of a rigidbody, a box, and four wheel colliders. F within four metres puts us in the seat and moves the camera to a chase point. F again drops us beside it. The checkout already has the prefab. These clicks are how you build it on camera.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Menu GameObject, Empty Object. Rename it Car.

### 3
Position 3, 1.5, 0. Up in the air on purpose, so we can see it drop onto the wheels.

### 4
Add Component, Physics, Rigidbody.

### 5
Mass 1200. Motion Type Dynamic. Use Gravity on. A rigidbody starts at one kilogram. A car that light bounces off the player.

### 6
Add Component, Physics, Colliders, Box Collider. This is the chassis, not the wheels.

### 7
Size 1.7, 0.5, 3.2. Center 0, 0.55, 0.

### 8
Add Component, Car Drive.

### 9
Torque 1500. Brake Torque 3000. Max Steer Degrees 28. Controlled off. While Controlled is off, the script holds the brakes so the car parks.

### 10
Menu GameObject, 3D Object, Cube. Rename it Body. Drag it onto Car. This cube is the visible body. The box collider is already on the parent.

### 11
Local Position 0, 0.7, 0. Local Scale 1.7, 0.45, 3.2.

### 12
Empty Object, rename FL, drag it onto Car.

### 13
Local Position minus 0.85, 0.55, 1.15. Front left.

### 14
Add Component, Physics, Wheel Collider.

### 15
Radius 0.35. Suspension Distance 0.3.

### 16
Click FL. Menu GameObject, Empty Child. Rename it Hub.

### 17
Local Position 0, 0, 0. The wheel collider poses this hub. The mesh spins under it.

### 18
3D Object, Cylinder. Rename it Mesh. Drag it onto Hub.

### 19
Local Rotation 0, 0, 90. Local Scale 0.125, 0.7, 0.7. The cylinder’s long axis has to lie along the axle, which is the hub’s X.

### 20
Click FL. On Wheel Collider, Visual Transform: drag Hub.

### 21
Click FL, Ctrl+D three times. Rename them FR, RL, and RR.

### 22
FR local position: 0.85, 0.55, 1.15.

### 23
RL: minus 0.85, 0.55, minus 1.15.

### 24
RR: 0.85, 0.55, minus 1.15. Front wheels are the ones named FL and FR. That’s how the script decides who steers.

### 25
Click Car. Empty Child, rename Seat.

### 26
Local Position 0, 0.9, 0.2. The player object sits here so we ride along.

### 27
Empty Child, rename Chase.

### 28
Local Position 0, 2.4, minus 6. Local Rotation 12, 0, 0. The camera gets parented here with a local identity, so this pose is the chase view.

### 29
Drag Car onto Project `Assets/Prefabs`. The drop label is Drop to create Prefab.

### 30
Click Player.

### 31
Add Component, Vehicle Ride.

### 32
Enter Distance 4.

### 33
Inspector header, Apply All.

### 34
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
The car drops and rests on its wheels. It does not creep. Controlled is off, so the brakes are held.

### 4
Walk to the car. Press F.

### 5
W drives forward. S reverses. A and D steer. Space brakes. WASD on foot does nothing, because Player is disabled in the seat. Vehicle Ride stays enabled. That’s why F is read there, not in Player.

### 6
Press F. You stand to the right of the car. Mouse look matches that facing. Space jumps.

### 7
Stop.

## Code on screen

Drop these on the cuts where `CarDrive.cs` and `VehicleRide.cs` are up. They are not extra README steps.

### CarDrive fields
Torque and brake are newton-metres on each driven wheel. `Controlled` is set by Vehicle Ride. Off means park.

### Start
If mass is still about 1, we set 1200. If there’s no center-of-mass override, we put it near the axles, Y 0.35. The default center is the origin, under the chassis, and the car feels like it wants to flip. Then we collect every Wheel Collider. FL and FR go in the front list. An empty Visual Transform gets the Hub child.

### Update
W and S are throttle. A and D are steer. Space, or not being controlled, is brake. `SteerAngle` is radians, so we convert Max Steer Degrees. Torque is shared across the wheels. Brake zeroes the motor and sets brake torque.

### VehicleRide.Update
F is `KeyCode.F`. If we already have a car, Exit. Otherwise TryEnter. Player.Update is not running in the seat, so this component has to own the key.

### Enter
`Controlled` goes true. Player, Player Look, the animator, and the character controller turn off. We remember the camera’s parent and local pose, parent it under Chase, and zero its local transform. The player object parents under Seat. HideBody turns off every child except the camera.

### Exit
`Controlled` goes false. We unparent, drop to the right of the car, put the camera back, teleport the controller, and call `MatchYawToTransform` before turning look back on. That copies the body’s yaw into the private look yaw, so the next mouse move doesn’t snap.

## Outro

Like and subscribe if the car stayed parked until you got in. Next time we put a real courtyard under it, and both of you have to stop at the walls.
