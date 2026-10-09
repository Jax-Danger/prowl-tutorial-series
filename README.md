# Vehicle

**Video:** coming. Part 9 does not have a public URL yet.

**Play CHECK:** Open **Title Screen**, press Play, then **Play Game**. The car drops onto its wheels on the grey plane. Walk up to it and press **F**. WASD drives, **Space** brakes, the camera sits behind the car. **F** again puts you on the right of the car and mouse look works. The Console has no exception from `CarDrive` or `VehicleRide`.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | This episode. WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Blender level and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |

Prerequisite: Part 8 plays (cube or character, mouse look, idle/walk if you imported clips).

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt9-vehicle
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

Prowl has a wheel collider. It is `WheelCollider` in `Prowl.Runtime/Components/Physics/WheelCollider.cs`, menu **Physics / Wheel Collider**. A wheel is a ray hanging from a mount. `MotorTorque`, `BrakeTorque`, and `SteerAngle` (radians) are what a script sets each frame. The sample `Samples/Runtime/VehicleShowcase/CarController.cs` is a full axle controller. This episode is the short version of that API: four wheels, one rigidbody, enter and exit.

Checkout already contains the car. If you are building it on camera, follow the editor steps anyway so the video matches.

- `Assets/Scripts/CarDrive.cs` — this episode. Search `TUTORIAL pt9`
- `Assets/Scripts/VehicleRide.cs` — **F** to enter and exit
- `Assets/Scripts/PlayerLook.cs` — `MatchYawToTransform` so mouse look does not snap after you get out
- `Assets/Prefabs/Car.prefab` — body, four wheels, **Seat**, **Chase**
- `Assets/Prefabs/Player.prefab` and `Assets/Scenes/Game.scene` — **VehicleRide** on **Player**, car placed at `(3, 1.5, 0)`

`Update` is `public override`. A plain `public void Update()` does not run.

The grey floor is the built-in plane, 10 metres across. Stay on it. Part 10 replaces it with a level.

## Build the car

1. Open `Assets/Scenes/Game.scene`.
2. **GameObject → Empty Object**. Name it `Car`.
3. Set **Position** to `3, 1.5, 0` so it is not inside the player. It will fall onto the plane when you press Play. That is the suspension settling.
4. With **Car** selected, **Add Component → Physics → Rigidbody**.
5. Set **Mass** to `1200`. Leave **Motion Type** on **Dynamic** and **Use Gravity** on. **Interpolation** can stay **Interpolate**.
6. **Add Component → Physics → Colliders → Box Collider**. **Size** `1.7, 0.5, 3.2`. **Center** `0, 0.55, 0`. The box is the chassis. The wheels are raycasts, not colliders.
7. **Add Component → Car Drive** (the script in this episode). **Torque** `1500`, **Brake Torque** `3000`, **Max Steer Degrees** `28`, **Controlled** off.

### Body

8. **GameObject → 3D Object → Cube**. Name it `Body`. Drag it onto **Car**.
9. Local position `0, 0.7, 0`. Local scale `1.7, 0.45, 3.2`.

### Wheels

The mount transform is the top of the suspension. The wheel hangs along the mount’s down axis (`-Up`). Do not put the cylinder on the same object as the **Wheel Collider**. `WheelCollider.Update` writes `VisualTransform` every frame: steer about Y, spin about X.

10. **GameObject → Empty Object**. Name it `FL`. Parent it to **Car**. Local position `-0.85, 0.55, 1.15`.
11. **Add Component → Physics → Wheel Collider**. Leave **Radius** `0.35` and **Suspension Distance** `0.3`.
12. **GameObject → Empty Child** while `FL` is selected. Name the child `Hub`. Local position `0, 0, 0`.
13. **GameObject → 3D Object → Cylinder**. Name it `Mesh`. Parent it to **Hub**.
14. The default cylinder stands on Y and is 2 units tall with radius 0.5. The collider spins the hub around local X, so the mesh’s axle has to be X. Local rotation of **Mesh** `0, 0, 90`. Local scale `0.125, 0.7, 0.7` (width 0.25, radius 0.35).
15. On `FL`’s **Wheel Collider**, drag **Hub** into **Visual Transform**. `CarDrive.Start` does this if the slot is empty and the child is named `Hub`.
16. Duplicate `FL` three times. Name them `FR`, `RL`, `RR`. Local positions:
    - `FR` `0.85, 0.55, 1.15`
    - `RL` `-0.85, 0.55, -1.15`
    - `RR` `0.85, 0.55, -1.15`

`CarDrive` steers only the objects named `FL` and `FR`. All four get motor torque.

### Seat and chase camera

17. **GameObject → Empty Child** on **Car**. Name it `Seat`. Local position `0, 0.9, 0.2`.
18. Another empty child. Name it `Chase`. Local position `0, 2.4, -6`. Local rotation `12, 0, 0`. Positive X looks slightly down. The camera looks along **+Z**, so Chase sits behind the car and looks forward.
19. Drag **Car** from the Hierarchy onto `Assets/Prefabs`. The drop label is **Drop to create Prefab**.

## Enter and exit

20. Select the **Player** prefab instance. **Add Component → Vehicle Ride**. **Enter Distance** `4`.
21. Open `VehicleRide.cs`. The key is `KeyCode.F`. It stays enabled while **Player**, **PlayerLook**, **PlayerAnimator**, and **Character Controller** are turned off.
22. **Apply All** on the Player instance (or right-click **Player** in the Hierarchy → **Apply Prefab Overrides**). Do the same for **Car** if you changed it after the drop. Save the scene.

## What the scripts do

`CarDrive.Update` reads WASD only while `Controlled` is true. **Space** sets `BrakeTorque`. While `Controlled` is false every wheel gets the full brake, so a parked car does not roll away. `SteerAngle` is `MaxSteerDegrees` converted with `π / 180`. The sample car in VehicleShowcase does the same conversion.

`VehicleRide` asks `Scene.Current.FindObjectsOfType<CarDrive>()` for the nearest car inside 4 metres. On enter it parents the player to **Seat**, parents the **Camera** to **Chase** with local position and rotation zero, and hides the player’s other children so the cube is not left standing in the cabin. On exit it unparents the player, `CharacterController.Teleport`s them to the car’s right, puts the camera back, and calls `PlayerLook.MatchYawToTransform`.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The car falls a short way and rests on four wheels. It does not creep across the plane.
- **CHECK:** Walk to it. **F** moves the view behind the car. WASD on foot does nothing while you are driving.
- **CHECK:** **W** drives forward, **S** reverses, **A** and **D** steer, **Space** brakes.
- **CHECK:** **F** drops you to the right of the car. Mouse look does not snap to your old facing. WASD walks again. **Space** jumps again.
- **CHECK:** With no car in the scene, **F** does nothing and the Console stays clear.
- Stop Play. Stay on the 10 metre plane. Driving off it falls forever until Part 10.
