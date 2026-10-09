// TUTORIAL pt15-01  New file: Assets/Scripts/PhysicsGate.cs
// Put this on an empty Gate object. Start builds the door on the first Play.
// CHECK: the door hangs on a vertical hinge. E within 3 m swings it open. E again swings it shut.

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Vector;

public class PhysicsGate : MonoBehaviour
{
    public float OpenSpeed = 2.2f;
    public float UseDistance = 3f;
    public float MinAngle = -4f;
    public float MaxAngle = 95f;

    HingeJoint? _hinge;
    bool _open;
    bool _built;

    public override void Start()
    {
        if (_built)
            return;
        if (GameObject.Scene.IsNotValid())
            return;
        _built = true;

        // TUTORIAL pt15-02  Thin on X, tall on Y, wide on Z. The hinge pin is the -Z edge.
        Float3 size = new Float3(0.12f, 2.2f, 1.1f);

        var door = new GameObject("Door");
        GameObject.Scene.Add(door);
        door.Transform.Position = Transform.Position + new Float3(0f, 1.25f, size.Z * 0.5f);

        var renderer = door.AddComponent<MeshRenderer>();
        renderer.Mesh = Mesh.CreateCube(size);
        var material = new Material(Shader.LoadDefault(DefaultShader.Standard));
        material.SetColor("_MainColor", new Color(0.45f, 0.28f, 0.14f, 1f));
        renderer.Material = material;

        door.AddComponent<BoxCollider>().Size = size;

        // TUTORIAL pt15-03  Rigidbody3D before the joint. HingeJoint.OnEnable looks up the parent body.
        Rigidbody3D body = door.AddComponent<Rigidbody3D>();
        body.Mass = 12f;
        body.LinearDamping = 0.2f;
        body.AngularDamping = 0.6f;

        // TUTORIAL pt15-04  ConnectedBody stays empty, so the pin anchors to the world (World.NullBody).
        // Axis is local Y. Angle limits are degrees.
        HingeJoint hinge = door.AddComponent<HingeJoint>();
        hinge.Anchor = new Float3(0f, 0f, -size.Z * 0.5f);
        hinge.Axis = new Float3(0f, 1f, 0f);
        hinge.MinAngle = MinAngle;
        hinge.MaxAngle = MaxAngle;
        hinge.HasMotor = true;
        hinge.MotorMaxForce = 80f;
        hinge.MotorTargetVelocity = 0f;
        _hinge = hinge;

        var post = new GameObject("Hinge Post");
        GameObject.Scene.Add(post);
        post.Transform.Position = Transform.Position + new Float3(0f, 1.25f, 0f);
        var postRenderer = post.AddComponent<MeshRenderer>();
        postRenderer.Mesh = Mesh.CreateCube(new Float3(0.16f, 2.4f, 0.16f));
        var postMaterial = new Material(Shader.LoadDefault(DefaultShader.Standard));
        postMaterial.SetColor("_MainColor", new Color(0.25f, 0.25f, 0.28f, 1f));
        postRenderer.Material = postMaterial;
    }

    public override void Update()
    {
        if (_hinge.IsNotValid())
            return;

        // TUTORIAL pt15-05  A motor left running into the angle limit fights the limit. Stop at the end.
        float angle = _hinge.CurrentAngleDegrees;
        if (_open && angle >= MaxAngle - 3f)
            _hinge.MotorTargetVelocity = 0f;
        else if (!_open && angle <= MinAngle + 3f)
            _hinge.MotorTargetVelocity = 0f;

        if (!Input.GetKeyDown(KeyCode.E))
            return;

        Player? player = FindPlayer();
        if (player.IsNotValid() || !player.Enabled)
            return;
        if (Float3.Distance(player.Transform.Position, Transform.Position) > UseDistance)
            return;

        _open = !_open;
        _hinge.MotorTargetVelocity = _open ? OpenSpeed : -OpenSpeed;
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
