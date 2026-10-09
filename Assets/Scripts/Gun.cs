// TUTORIAL pt19-01  New file: Assets/Scripts/Gun.cs
// Put this on the Player, next to Player Look. The camera child is the muzzle.
// CHECK: left click spends a round. A hit on the crate counts down. R reloads. The corner shows the count.

using Prowl.PaperUI;
using Prowl.PaperUI.LayoutEngine;
using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Scribe;
using Prowl.Vector;

public class Gun : MonoBehaviour
{
    public int MagazineSize = 12;
    public float FireCooldown = 0.12f;
    public float ReloadSeconds = 1f;
    public float Range = 50f;
    public float HitImpulse = 6f;

    int _ammo;
    float _cooldown;
    float _reload;

    public override void Start()
    {
        _ammo = MagazineSize;
    }

    public override void Update()
    {
        Player? player = GetComponent<Player>();
        if (player.IsValid() && !player.Enabled)
            return;

        if (_reload > 0f)
        {
            _reload -= Time.DeltaTime;
            if (_reload <= 0f)
                _ammo = MagazineSize;
            return;
        }

        // TUTORIAL pt19-02  KeyCode.R. A full magazine does not start another reload.
        if (Input.GetKeyDown(KeyCode.R) && _ammo < MagazineSize)
        {
            _reload = ReloadSeconds;
            return;
        }

        // A locked cursor is the aim. An unlocked cursor is for the Part 18 button.
        if (!Input.CursorLocked)
            return;

        _cooldown -= Time.DeltaTime;
        if (!Input.GetMouseButton(0) || _cooldown > 0f || _ammo <= 0)
            return;

        _cooldown = FireCooldown;
        _ammo--;
        Fire();
    }

    void Fire()
    {
        Camera? camera = GetComponentInChildren<Camera>(false);
        if (camera.IsNotValid() || GameObject.Scene.IsNotValid() || GameObject.Scene.Physics == null)
            return;

        // TUTORIAL pt19-03  PhysicsWorld.Raycast from the camera along Forward. Distance is the third
        // argument, then the hit. The direction does not have to be normalized.
        Float3 origin = camera.Transform.Position;
        Float3 direction = camera.Transform.Forward;
        if (!GameObject.Scene.Physics.Raycast(origin, direction, Range, out RaycastHit hit))
        {
            Debug.Log("Gun: miss");
            return;
        }

        string name = "surface";
        if (hit.Collider.IsValid())
            name = hit.Collider.GameObject.Name;
        else if (hit.Transform != null && hit.Transform.GameObject.IsValid())
            name = hit.Transform.GameObject.Name;

        PracticeCrate? crate = null;
        if (hit.Collider.IsValid())
            crate = hit.Collider.GetComponentInParent<PracticeCrate>();
        if (crate.IsNotValid() && hit.Rigidbody.IsValid())
            crate = hit.Rigidbody.GetComponentInParent<PracticeCrate>();
        if (crate.IsValid())
            crate.TakeHit();

        if (hit.Rigidbody.IsValid())
            hit.Rigidbody.AddForceAtPosition(direction * HitImpulse, hit.Point, ForceMode.Impulse);

        Debug.Log($"Gun: hit {name}");
    }

    public override void OnGui(Paper paper)
    {
        Player? player = GetComponent<Player>();
        if (player.IsValid() && !player.Enabled)
            return;

        FontFile? font = FontAsset.LoadDefault().FontFile;
        if (font == null)
            return;

        string label = _reload > 0f ? "Reloading" : $"{_ammo}/{MagazineSize}   R reload";
        paper.Box("ammo").PositionType(PositionType.SelfDirected).Position(16, 48).Size(320, 28)
            .Text(label, font)
            .FontSize(18)
            .TextColor(new Color(1f, 0.92f, 0.7f, 1f));
    }
}
