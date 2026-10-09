// TUTORIAL pt17-01  New file: Assets/Scripts/PlayHud.cs
// Put this on the Player. OnGui runs every frame while the component is enabled.
// CHECK: the top-left line shows speed, the view mode, and the E prompt. It disappears in the car.

using Prowl.PaperUI;
using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Scribe;
using Prowl.Vector;

public class PlayHud : MonoBehaviour
{
    public override void OnGui(Paper paper)
    {
        // TUTORIAL pt17-02  VehicleRide disables Player. This component stays enabled, so hide the
        // line yourself while the character controller is not driving.
        Player? player = GetComponent<Player>();
        if (player.IsNotValid() || !player.Enabled)
            return;

        FontFile? font = FontAsset.LoadDefault().FontFile;
        if (font == null)
            return;

        PlayerLook? look = GetComponent<PlayerLook>();
        string view = look.IsValid() && look.ThirdPerson ? "orbit" : "eye";

        // TUTORIAL pt17-03  Same Paper.Box chain as the loading screen. A new string every frame is the point:
        // nothing is stored on a widget. Search the call by the id "hud".
        paper.Box("hud").Margin(16).Height(28)
            .Text($"Speed {player.PlanarSpeed:0.0}   View {view}   V camera   E gate", font)
            .FontSize(18)
            .TextColor(new Color(1f, 1f, 1f, 1f));
    }
}
