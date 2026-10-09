using System;

using Prowl.Runtime;
using Prowl.Vector;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public float MoveSpeed = 6f;
    public float JumpSpeed = 8f;
    public float Gravity = -20f;

    // TUTORIAL pt8-01  Horizontal speed in metres per second, after MoveSpeed is applied.
    // PlayerAnimator reads this. Jumping does not count.
    public float PlanarSpeed { get; private set; }

    private CharacterController _controller = null!;
    private Float3 _velocity;

    public override void Start()
    {
        _controller = GetComponent<CharacterController>()!;
    }

    public override void Update()
    {
        Float2 wasd = Input.GetWASD();
        // TUTORIAL pt6-move  PlayerLook yaws this transform. Right and Forward follow that facing.
        Float3 planar = Transform.Right * wasd.X + Transform.Forward * wasd.Y;
        _velocity.X = planar.X * MoveSpeed;
        _velocity.Z = planar.Z * MoveSpeed;
        PlanarSpeed = MathF.Sqrt(_velocity.X * _velocity.X + _velocity.Z * _velocity.Z);

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

        // TUTORIAL pt7-05  CharacterController.Move now returns CollisionFlags. The call is the same.
        // Below means the capsule ended on the ground. Sides means a wall stopped the step.
        _controller.Move(_velocity * Time.DeltaTime);
    }
}
