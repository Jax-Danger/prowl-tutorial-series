// TUTORIAL side-ball-01  New file: Assets/Scripts/BallController.cs
// Side episode. It does not replace the main player stack. Put this on an empty Ball.
// CHECK: B within 4 m rolls the ball from the camera. Space hops. B again drops you beside it.

using System;
using System.Collections.Generic;

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Vector;

public class BallController : MonoBehaviour
{
    public float Torque = 18f;
    public float JumpImpulse = 5f;
    public float Radius = 0.45f;
    public float EnterDistance = 4f;
    public float CameraDistance = 5.5f;

    Rigidbody3D? _body;
    bool _built;
    bool _driving;
    float _yaw;
    float _pitch;
    Float2 _wish;

    Camera? _camera;
    GameObject? _cameraParent;
    Float3 _cameraLocalPos;
    Quaternion _cameraLocalRot;

    Player? _player;
    PlayerLook? _look;
    PlayerAnimator? _anim;
    CharacterController? _character;
    readonly List<GameObject> _hidden = new();

    public override void Start()
    {
        if (_built || GameObject.Scene.IsNotValid())
            return;
        _built = true;

        if (GetComponent<MeshRenderer>().IsNotValid())
        {
            MeshRenderer renderer = AddComponent<MeshRenderer>();
            renderer.Mesh = Mesh.CreateSphere(Radius, 12, 18);
            var material = new Material(Shader.LoadDefault(DefaultShader.Standard));
            material.SetColor("_MainColor", new Color(0.15f, 0.45f, 0.85f, 1f));
            renderer.Material = material;
        }

        if (GetComponent<SphereCollider>().IsNotValid())
            AddComponent<SphereCollider>().Radius = Radius;

        _body = GetComponent<Rigidbody3D>();
        if (_body.IsNotValid())
            _body = AddComponent<Rigidbody3D>();
        _body.Mass = 1.2f;
        _body.LinearDamping = 0.2f;
        _body.AngularDamping = 0.4f;
    }

    public override void Update()
    {
        // TUTORIAL side-ball-02  KeyCode.B. Ignored while Player is disabled, which is the car from Part 9.
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (_driving)
                Exit();
            else
                TryEnter();
        }

        if (!_driving || _body.IsNotValid())
            return;

        if (Input.CursorLocked)
        {
            Float2 delta = Input.MouseDelta;
            _yaw += delta.X * 0.15f;
            _pitch = Math.Clamp(_pitch + delta.Y * 0.15f, -80f, 80f);
        }

        PlaceCamera();
        _wish = Input.GetWASD();

        if (Input.GetKeyDown(KeyCode.Space) && Grounded())
            _body.AddForce(new Float3(0f, JumpImpulse, 0f), ForceMode.Impulse);
    }

    public override void FixedUpdate()
    {
        if (!_driving || _body.IsNotValid() || _camera.IsNotValid())
            return;

        // TUTORIAL side-ball-03  Torque about the camera's flattened axes. ForceMode.Acceleration
        // ignores mass. Positive mouse-up pitch matches PlayerLook.
        Float3 forward = Flat(_camera.Transform.Forward);
        Float3 right = Flat(_camera.Transform.Right);
        _body.AddTorque(right * (-_wish.Y * Torque) + forward * (_wish.X * Torque), ForceMode.Acceleration);
    }

    void TryEnter()
    {
        Player? player = FindPlayer();
        if (player.IsNotValid() || !player.Enabled)
            return;
        if (Float3.Distance(Transform.Position, player.Transform.Position) > EnterDistance)
            return;

        _player = player;
        _look = player.GetComponent<PlayerLook>();
        _anim = player.GetComponent<PlayerAnimator>();
        _character = player.GetComponent<CharacterController>();
        _camera = player.GetComponentInChildren<Camera>(false);
        if (_camera.IsNotValid())
            return;

        _driving = true;
        _yaw = player.Transform.LocalEulerAngles.Y;
        _pitch = 12f;
        _wish = Float2.Zero;

        if (_look.IsValid()) _look.Enabled = false;
        if (_anim.IsValid()) _anim.Enabled = false;
        if (_character.IsValid()) _character.Enabled = false;
        player.Enabled = false;

        _cameraParent = _camera.GameObject.Parent;
        _cameraLocalPos = _camera.Transform.LocalPosition;
        _cameraLocalRot = _camera.Transform.LocalRotation;
        _camera.GameObject.SetParent(null!, true);
        HideBody(player.GameObject);
        PlaceCamera();
    }

    void Exit()
    {
        _driving = false;
        _wish = Float2.Zero;

        Float3 drop = Transform.Position + new Float3(1.6f, 0.2f, 0f);
        if (_camera.IsValid())
            drop = Transform.Position + Flat(_camera.Transform.Right) * 1.6f + new Float3(0f, 0.2f, 0f);

        if (_player.IsValid())
            ShowBody();

        if (_camera.IsValid() && _cameraParent.IsValid())
        {
            _camera.GameObject.SetParent(_cameraParent, false);
            _camera.Transform.LocalPosition = _cameraLocalPos;
            _camera.Transform.LocalRotation = _cameraLocalRot;
        }

        if (_character.IsValid())
        {
            _character.Enabled = true;
            _character.Teleport(drop);
        }
        else if (_player.IsValid())
        {
            _player.Transform.Position = drop;
        }

        if (_look.IsValid())
        {
            _look.MatchYawToTransform();
            _look.Enabled = true;
        }
        if (_anim.IsValid()) _anim.Enabled = true;
        if (_player.IsValid()) _player.Enabled = true;
        _player = null;
    }

    void PlaceCamera()
    {
        if (_camera.IsNotValid())
            return;

        // TUTORIAL side-ball-04  Yaw around world Y, then pitch around world X. The camera is not a
        // child of the ball, so the ball's spin does not roll the view.
        float yawRad = _yaw * (MathF.PI / 180f);
        float pitchRad = _pitch * (MathF.PI / 180f);
        Quaternion rotation = Quaternion.AxisAngle(new Float3(0f, 1f, 0f), yawRad)
            * Quaternion.AxisAngle(new Float3(1f, 0f, 0f), pitchRad);
        _camera.Transform.Rotation = rotation;

        Float3 pivot = Transform.Position + new Float3(0f, Radius + 0.35f, 0f);
        _camera.Transform.Position = pivot + _camera.Transform.Forward * (-CameraDistance);
    }

    bool Grounded()
    {
        if (GameObject.Scene.IsNotValid() || GameObject.Scene.Physics == null)
            return false;

        Float3 origin = Transform.Position + new Float3(0f, -(Radius + 0.08f), 0f);
        return GameObject.Scene.Physics.Raycast(origin, new Float3(0f, -1f, 0f), 0.35f, out RaycastHit _);
    }

    static Float3 Flat(Float3 v)
    {
        v.Y = 0f;
        float len = MathF.Sqrt(v.X * v.X + v.Z * v.Z);
        if (len < 0.0001f)
            return new Float3(0f, 0f, 1f);
        return v * (1f / len);
    }

    void HideBody(GameObject player)
    {
        _hidden.Clear();
        foreach (GameObject child in player.Children)
        {
            if (!child.Enabled)
                continue;
            if (child.GetComponent<Camera>().IsValid())
                continue;
            child.Enabled = false;
            _hidden.Add(child);
        }
    }

    void ShowBody()
    {
        foreach (GameObject child in _hidden)
        {
            if (child.IsValid())
                child.Enabled = true;
        }
        _hidden.Clear();
    }

    static Player? FindPlayer()
    {
        if (Prowl.Runtime.Resources.Scene.Current.IsNotValid())
            return null;

        foreach (Player? player in Prowl.Runtime.Resources.Scene.Current.FindObjectsOfType<Player>())
        {
            if (player.IsValid())
                return player;
        }
        return null;
    }
}
