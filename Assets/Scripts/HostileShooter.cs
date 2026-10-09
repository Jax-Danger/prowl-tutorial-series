// TUTORIAL pt20-03  New file: Assets/Scripts/HostileShooter.cs
// Put this on an empty Hostile, with Health. Start builds a static figure the gun can hit.
// CHECK: inside range, with a clear line, your health falls. A wall stops the shot. Shoot it until it disables.

using System;

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Vector;

public class HostileShooter : MonoBehaviour
{
    public float Range = 16f;
    public float Cooldown = 1.1f;
    public int Damage = 1;

    float _cooldown;
    bool _built;

    public override void Start()
    {
        if (_built || GameObject.Scene.IsNotValid())
            return;
        _built = true;

        // TUTORIAL pt20-04  No Rigidbody3D. A static BoxCollider is enough for the player's ray.
        // The muzzle point is placed in front of this box so the shot does not hit itself.
        Float3 size = new Float3(0.6f, 1.8f, 0.6f);
        var body = new GameObject("Body");
        GameObject.Scene.Add(body);
        body.SetParent(GameObject, false);
        body.Transform.LocalPosition = new Float3(0f, 0.9f, 0f);

        var renderer = body.AddComponent<MeshRenderer>();
        renderer.Mesh = Mesh.CreateCube(size);
        var material = new Material(Shader.LoadDefault(DefaultShader.Standard));
        material.SetColor("_MainColor", new Color(0.55f, 0.08f, 0.1f, 1f));
        renderer.Material = material;
        body.AddComponent<BoxCollider>().Size = size;
    }

    public override void Update()
    {
        Health? self = GetComponent<Health>();
        if (self.IsValid() && self.IsDead)
            return;

        _cooldown -= Time.DeltaTime;
        if (_cooldown > 0f)
            return;

        Player? player = FindPlayer();
        if (player.IsNotValid() || !player.Enabled)
            return;

        Health? health = player.GetComponent<Health>();
        if (health.IsNotValid() || health.IsDead)
            return;

        Float3 aim = player.Transform.Position + new Float3(0f, 1f, 0f);
        Float3 to = aim - Transform.Position;
        to.Y = 0f;
        float flat = MathF.Sqrt(to.X * to.X + to.Z * to.Z);
        if (flat < 0.05f || flat > Range)
            return;

        // Face the player on Y. The ray itself uses the aim point, not this rotation.
        float yaw = MathF.Atan2(to.X, to.Z) * (180f / MathF.PI);
        Transform.LocalEulerAngles = new Float3(0f, yaw, 0f);

        Float3 forward = new Float3(to.X / flat, 0f, to.Z / flat);
        Float3 origin = Transform.Position + new Float3(0f, 1.2f, 0f) + forward * 0.7f;
        Float3 delta = aim - origin;
        float dist = MathF.Sqrt(delta.X * delta.X + delta.Y * delta.Y + delta.Z * delta.Z);
        if (dist < 0.05f || GameObject.Scene.IsNotValid() || GameObject.Scene.Physics == null)
            return;

        _cooldown = Cooldown;

        // TUTORIAL pt20-05  The character controller is not a physics collider, so the ray is not
        // expected to hit the player. A hit well short of the aim point is a wall. Anything else lands.
        bool blocked = GameObject.Scene.Physics.Raycast(origin, delta, dist, out RaycastHit hit)
            && hit.Distance < dist - 0.6f;
        if (blocked)
        {
            Debug.Log("Hostile: blocked");
            return;
        }

        health.TakeDamage(Damage);
        Debug.Log("Hostile: hit");
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
