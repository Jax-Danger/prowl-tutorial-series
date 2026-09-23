# Move the player

**Video:** coming. There is no public Part 4 URL yet.

`main` is the latest finished episode, **Part 4**. You land in the Game scene after the loading screen and move. **WASD** walks. **Space** jumps. The player in this project is `Assets/Scripts/Player.cs` on the **Player** prefab, with a **CharacterController** and a **Floor** under it.

Engine download: https://github.com/ProwlEngine/Prowl (this series uses **1.0-preview-4**).

This clone is the Prowl project root. `Assets/Scenes`, `Assets/Prefabs`, and `Assets/Scripts` are the title, loading, and game work, plus the player.

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
```

Open this folder in the Prowl editor. The editor creates `ProjectSettings/`, `Library/`, and the `.csproj` files on your machine the first time you open it.

## Open the Game scene

1. In the project browser, confirm `Assets/Scenes`, `Assets/Prefabs`, and `Assets/Scripts` are there.
2. Double-click `Assets/Scenes/Game.scene`.

The scene contains a **Main Camera**, a **Directional Light**, a **Floor** (mesh plus mesh collider), and a **Player**.

## Player in the scene

3. Select **Player**. It has a **CharacterController** and a **Player** component. A child named **Mesh** is what you see.
4. The same object is saved as `Assets/Prefabs/Player.prefab`. If you are building it from the end of Part 3:
   - Add a floor object with a collider at the origin so the controller has something to stand on. This project names that object **Floor**.
   - Create **Player**. Give it a visible mesh child. Add a **CharacterController**. The script requires that component.
   - Set Local Rotation to `0, 0, 0` so Forward lines up with the world.
   - Add the **Player** component. Leave **MoveSpeed** at `6`, **JumpSpeed** at `8`, and **Gravity** at `-20`.
   - Aim the **Main Camera** so the player is in frame.
   - Drag **Player** from the Hierarchy into `Assets/Prefabs/` so the scene object is a prefab instance.
5. Press Ctrl+S and save the **Game** scene.

## Player script

6. `Assets/Scripts/Player.cs`:

```csharp
using Prowl.Runtime;
using Prowl.Vector;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public float JumpSpeed = 8f;
    public float Gravity = -20f;

    private CharacterController _controller = null!;
    private Float3 _velocity;

    public override void Start()
    {
        _controller = GetComponent<CharacterController>()!;
    }

    public override void Update()
    {
        Float2 wasd = Input.GetWASD();
        Float3 planar = Transform.Right * wasd.X + Transform.Forward * wasd.Y;
        _velocity.X = planar.X * MoveSpeed;
        _velocity.Z = planar.Z * MoveSpeed;

        if (_controller.IsGrounded && _velocity.Y <= 0f)
        {
            _velocity.Y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
                _velocity.Y = JumpSpeed;
        }
        else
        {
            _velocity.Y += Gravity * Time.DeltaTime;
        }

        _controller.Move(_velocity * Time.DeltaTime);
    }
}
```

`Update` is an override, so it runs every frame while Play mode is on. WASD comes from `Input.GetWASD()`. Horizontal speed is applied on X and Z with this object's Right and Forward. On the ground, vertical speed stays 0 until Space sets it to `JumpSpeed`. In the air, `Gravity` pulls Y down. `CharacterController.Move` applies the velocity.

## Check

7. Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, and click **Play Game**.
8. Wait through the loading screen (about 1.5 seconds) into **Game**.
9. **WASD** moves the player. **Space** jumps while the controller is grounded.

Stay in the Game scene for that check. On the title screen and on the loading screen there is nothing for WASD to move.
