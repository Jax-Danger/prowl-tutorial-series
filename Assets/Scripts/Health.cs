// TUTORIAL pt20-01  New file: Assets/Scripts/Health.cs
// Prowl has no health, weapon, or crosshair type. This is the hit-point counter.
// Put it on the Player (Disable Object On Death off) and on the Hostile (that flag on).
// CHECK: the corner shows 5/5. The hostile's shots count down. At 0 the player stops moving.

using Prowl.Runtime;

public class Health : MonoBehaviour
{
    public int MaxHitPoints = 5;

    // TUTORIAL pt20-02  The hostile sets this. The player does not: disabling the whole object
    // would take the camera with it. Death on the player only turns off Player and Gun.
    public bool DisableObjectOnDeath;

    public int HitPoints { get; private set; }
    public bool IsDead { get; private set; }

    public override void Start()
    {
        HitPoints = MaxHitPoints;
    }

    public void TakeDamage(int amount)
    {
        if (IsDead || amount <= 0)
            return;

        HitPoints -= amount;
        if (HitPoints < 0)
            HitPoints = 0;

        Debug.Log($"{GameObject.Name}: {HitPoints}/{MaxHitPoints}");
        if (HitPoints > 0)
            return;

        IsDead = true;
        if (DisableObjectOnDeath)
        {
            GameObject.Enabled = false;
            return;
        }

        Player? player = GetComponent<Player>();
        if (player.IsValid())
            player.Enabled = false;

        Gun? gun = GetComponent<Gun>();
        if (gun.IsValid())
            gun.Enabled = false;
    }
}
