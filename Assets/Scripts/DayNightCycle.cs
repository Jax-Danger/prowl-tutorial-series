// TUTORIAL pt11-01  New file: Assets/Scripts/DayNightCycle.cs
// Put this on the Directional Light in Game.scene. It is the sun.
// CHECK: the sun turns. Intensity drops when it shines upward. Shadows follow it.

using System;

using Prowl.Runtime;
using Prowl.Vector;

public class DayNightCycle : MonoBehaviour
{
    // TUTORIAL pt11-02  One full turn, in seconds. 90 is slow enough to watch in a recording.
    public float DayLengthSeconds = 90f;
    public float Pitch = 50f;

    DirectionalLight? _sun;

    public override void Start()
    {
        _sun = GetComponent<DirectionalLight>();
        if (_sun.IsValid())
            return;
        if (Prowl.Runtime.Resources.Scene.Current.IsNotValid())
            return;
        foreach (DirectionalLight? light in Prowl.Runtime.Resources.Scene.Current.FindObjectsOfType<DirectionalLight>())
        {
            if (light.IsNotValid())
                continue;
            _sun = light;
            break;
        }
    }

    public override void Update()
    {
        if (_sun.IsNotValid() || DayLengthSeconds <= 0.01f)
            return;

        // TUTORIAL pt11-03  A directional light shines along +Forward (local +Z), not backward.
        // Pitch holds the sun below the horizon line of the spin. Yaw is the time of day.
        float turns = Time.TimeSinceStartup / DayLengthSeconds;
        float yaw = (turns - MathF.Floor(turns)) * 360f;
        _sun.Transform.LocalEulerAngles = new Float3(Pitch, yaw, 0f);

        float shiningDown = Math.Clamp(-_sun.Transform.Forward.Y, 0f, 1f);
        _sun.Intensity = 0.05f + 1.15f * shiningDown;
        _sun.Color = shiningDown > 0.2f
            ? new Color(1f, 0.96f, 0.88f, 1f)
            : new Color(0.35f, 0.45f, 0.75f, 1f);
    }
}
