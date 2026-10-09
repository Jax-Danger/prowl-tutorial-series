// TUTORIAL pt20-06  New file: Assets/Scripts/CombatHud.cs
// Put this on the Player, next to Health. OnGui draws the crosshair and the hit points.
// CHECK: a plus sits in the middle. The line under the ammo count shows HP. At 0 it says Down.

using Prowl.PaperUI;
using Prowl.PaperUI.LayoutEngine;
using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Scribe;
using Prowl.Vector;

public class CombatHud : MonoBehaviour
{
    public override void OnGui(Paper paper)
    {
        Health? health = GetComponent<Health>();
        if (health.IsNotValid())
            return;

        Player? player = GetComponent<Player>();
        bool dead = health.IsDead;
        if (!dead && (player.IsNotValid() || !player.Enabled))
            return;

        FontFile? font = FontAsset.LoadDefault().FontFile;
        if (font == null)
            return;

        if (!dead)
        {
            // TUTORIAL pt20-07  Stretch plus MiddleCenter, and IsNotInteractable so the plus does not
            // eat the Part 18 button. Prowl has no crosshair component. This is the whole thing.
            paper.Box("cross")
                .Width(UnitValue.Stretch())
                .Height(UnitValue.Stretch())
                .IsNotInteractable()
                .Text("+", font)
                .FontSize(22)
                .Alignment(Prowl.PaperUI.TextAlignment.MiddleCenter)
                .TextColor(new Color(1f, 1f, 1f, 1f));
        }

        string label = dead ? "Down" : $"HP {health.HitPoints}/{health.MaxHitPoints}";
        paper.Box("hp").PositionType(PositionType.SelfDirected).Position(16, 80).Size(320, 28)
            .Text(label, font)
            .FontSize(18)
            .TextColor(dead ? new Color(1f, 0.35f, 0.3f, 1f) : new Color(0.7f, 1f, 0.75f, 1f));
    }
}
