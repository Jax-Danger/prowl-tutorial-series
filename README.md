# Part 9 — Vehicle

Branch: `pt9-vehicle`. Previous: `pt8-animation`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt9-vehicle
```

## Files

- `Assets/Scripts/CarDrive.cs` — search `TUTORIAL pt9`
- `Assets/Scripts/VehicleRide.cs`
- `Assets/Scripts/PlayerLook.cs` — `MatchYawToTransform`
- `Assets/Prefabs/Car.prefab`
- `Assets/Scenes/Game.scene` — car at `(3, 1.5, 0)`

The checkout already has the car. Build it with these clicks if you are doing it on camera.

## Steps

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. Menu **GameObject → Empty Object**. Rename `Car`.
3. Inspector → **Transform** → **Position**: `3`, `1.5`, `0`.
4. Inspector: **Add Component → Physics → Rigidbody**.
5. **Mass**: `1200`. **Motion Type**: **Dynamic**. **Use Gravity**: on.
6. Inspector: **Add Component → Physics → Colliders → Box Collider**.
7. **Size**: `1.7`, `0.5`, `3.2`. **Center**: `0`, `0.55`, `0`.
8. Inspector: **Add Component → Car Drive**.
9. **Torque**: `1500`. **Brake Torque**: `3000`. **Max Steer Degrees**: `28`. **Controlled**: off.
10. Menu **GameObject → 3D Object → Cube**. Rename `Body`. Drag it onto **Car**.
11. **Local Position**: `0`, `0.7`, `0`. **Local Scale**: `1.7`, `0.45`, `3.2`.
12. Menu **GameObject → Empty Object**. Rename `FL`. Drag onto **Car**.
13. **Local Position**: `-0.85`, `0.55`, `1.15`.
14. Inspector: **Add Component → Physics → Wheel Collider**.
15. **Radius**: `0.35`. **Suspension Distance**: `0.3`.
16. Hierarchy: click **FL**. Menu **GameObject → Empty Child**. Rename `Hub`.
17. **Local Position**: `0`, `0`, `0`.
18. Menu **GameObject → 3D Object → Cylinder**. Rename `Mesh`. Drag onto **Hub**.
19. **Local Rotation**: `0`, `0`, `90`. **Local Scale**: `0.125`, `0.7`, `0.7`.
20. Hierarchy: click **FL**. Inspector → **Wheel Collider** → **Visual Transform**: drag **Hub**.
21. Hierarchy: click **FL**. Ctrl+D three times. Rename `FR`, `RL`, `RR`.
22. **FR** local position: `0.85`, `0.55`, `1.15`.
23. **RL** local position: `-0.85`, `0.55`, `-1.15`.
24. **RR** local position: `0.85`, `0.55`, `-1.15`.
25. Hierarchy: click **Car**. Menu **GameObject → Empty Child**. Rename `Seat`.
26. **Local Position**: `0`, `0.9`, `0.2`.
27. Menu **GameObject → Empty Child**. Rename `Chase`.
28. **Local Position**: `0`, `2.4`, `-6`. **Local Rotation**: `12`, `0`, `0`.
29. Drag Hierarchy **Car** onto **Project** `Assets/Prefabs`. Drop label: **Drop to create Prefab**.
30. Hierarchy: click **Player**.
31. Inspector: **Add Component → Vehicle Ride**.
32. **Enter Distance**: `4`.
33. Inspector header: **Apply All**.
34. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**. **Game** view: click once. Click **Play Game**.
3. The car drops and rests on its wheels. It does not creep.
4. Walk to the car. Press **F**.
5. **W** drives forward. **S** reverses. **A** / **D** steer. **Space** brakes. WASD on foot does nothing.
6. Press **F**. You stand to the right of the car. Mouse look matches that facing. Space jumps.
7. Toolbar: **Stop**.
