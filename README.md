# Rolling ball (side episode)

**Video:** coming. This side episode does not have a public URL yet.

**Play CHECK:** Play from **Title Screen** and **Play Game**. A blue ball sits at `(4, 1.2, 2)`. Walk within 4 metres and press **B**. WASD rolls it along the camera. Mouse looks. **Space** hops while it is on the ground. **B** again drops you beside it and the first-person camera is back. This branch is not on the main stack.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

This is a **side episode** branched from `pt13-navmesh-wander`. It is not part of the main line. Parts 14–19 (orbit camera, hinge, async load, OnGui, GameObject UI, raycast gun) do not contain this ball, and this branch does not contain them.

Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin.

| Part | Branch | What you add |
| --- | --- | --- |
| 13 | `pt13-navmesh-wander` | Base of this side episode |
| side | `side-ball-controller` | This episode. Possess a physics ball |

The main line continues at `pt14-third-person` from Part 13, without this branch.

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout side-ball-controller
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/BallController.cs` — search `TUTORIAL side-ball`
- `Assets/Scenes/Game.scene` — empty **Ball** at `(4, 1.2, 2)`

`Start` adds `MeshRenderer`, `SphereCollider`, and `Rigidbody3D` when they are missing. The camera stays the player’s camera. It is unparented while you drive so the ball’s spin does not roll the view.

## Drive it

1. **Ball** is already in the scene. **Torque** `18`, **Jump Impulse** `5`, **Radius** `0.45`, **Enter Distance** `4`, **Camera Distance** `5.5`.
2. **B** (`KeyCode.B`) within **Enter Distance** disables `Player`, `PlayerLook`, `PlayerAnimator`, and `CharacterController`, hides the body children, and takes the camera.
3. Mouse yaw and pitch use the same `0.15` degrees per pixel and the same pitch sign as Part 6. The pose is `Quaternion.AxisAngle` around world Y, then around world X.
4. `FixedUpdate` applies `AddTorque` in `ForceMode.Acceleration` around the camera’s flattened right and forward, so mass does not change the feel.
5. **Space** raycasts down from just under the sphere. The ray starts outside the collider so it does not hit the ball. A hit within `0.35` m is the ground, and the jump is `AddForce` with `ForceMode.Impulse`.
6. **B** again parents the camera back, teleports the character with `CharacterController.Teleport`, and calls `PlayerLook.MatchYawToTransform`.
7. **B** does nothing while `Player` is disabled. That is you, in the car.

## Save and CHECK

- Play from **Title Screen**, then **Play Game**.
- **CHECK:** The blue ball is on the ground near `(4, 1.2, 2)`.
- Walk up to it. **B**. **CHECK:** the body hides and the camera sits behind the ball.
- **CHECK:** WASD rolls the ball the way the camera faces. Mouse looks around. **Space** hops once per landing.
- **B** again. **CHECK:** you stand beside the ball and the eye camera is back.
- Stop Play.
