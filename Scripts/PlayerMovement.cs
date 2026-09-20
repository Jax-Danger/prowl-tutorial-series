// TUTORIAL pt4-01  New file: Scripts/PlayerMovement.cs (copy into your Prowl project's Scripts folder).
// NEXT FILE: stay here — fill in the class, then jump to the editor shot list.
// EDITOR: docs/pt4-player-movement.md (create Player, attach this script, assign nothing else).
// CHECK: Title → Loading → Game, then WASD or arrow keys move the Player in the Game scene.

using Prowl.Runtime;
using Prowl.Vector;

public class PlayerMovement : MonoBehaviour
{
    // TUTORIAL pt4-02  Inspector: moveSpeed. Leave at 5 for the video; raise it if the cube feels sluggish.
    public float moveSpeed = 5f;

    // TUTORIAL pt4-03  Update runs every rendered frame while Play mode is on.
    public void Update()
    {
        // TUTORIAL pt4-04  Real Prowl helpers from Input.cs (preview-4): normalised stick from keys.
        // SAY: "GetWASD and GetArrowKeys already normalise diagonals. We add both so either scheme works."
        Float2 wasd = Input.GetWASD();
        Float2 arrows = Input.GetArrowKeys();
        Float2 input = wasd + arrows;

        float magnitude = Maths.Sqrt(input.X * input.X + input.Y * input.Y);
        if (magnitude > 1f)
            input /= magnitude;

        if (magnitude < 0.0001f)
            return;

        // TUTORIAL pt4-05  Move on XZ using this object's Right (+X) and Forward (+Z). No physics yet.
        // SAY: "Transform.Position is world space. Multiply by moveSpeed and Time.DeltaTime."
        Float3 wish = Transform.Right * input.X + Transform.Forward * input.Y;
        Transform.Position += wish * moveSpeed * Time.DeltaTime;
    }
}

// TUTORIAL pt4-DONE  End of Part 4.
// NEXT branch name: pt5-real-load-wait
