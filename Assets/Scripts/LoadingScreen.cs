// TUTORIAL pt16-01  Part 3 waited on a timer, then called Scene.Load, which blocks on the preload.
// This file starts Scene.LoadAsync as soon as the destination is known and holds the swap
// with WaitForActivation until both the bar and the minimum time are done.

using Prowl.PaperUI;
using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Scribe;
using Prowl.Vector;

public class LoadingScreen : MonoBehaviour
{
    public float minDisplaySeconds = 1.5f;

    private float elapsed;
    private bool started;
    private SceneLoad? _load;

    public override void Update()
    {
        elapsed += Time.DeltaTime;
        if (started)
        {
            // TUTORIAL pt16-03  Progress is 0..1 from the preload group. IsDone stays false until
            // the engine calls Activate at the end of a frame, so the bar must not wait on IsDone.
            if (_load != null && elapsed >= minDisplaySeconds && _load.Progress >= 1f)
                _load.Allow();
            return;
        }

        SceneAsset? next = SceneLoadRequest.Destination.IsEmpty ? null : SceneLoadRequest.Destination.Load();
        if (next.IsNotValid() || next.IsMissing)
        {
            Debug.LogError("Loading screen has no destination set.");
            started = true;
            return;
        }

        // TUTORIAL pt16-02  LoadAsync preloads in the background and makes the scene current at the
        // end of the frame the load is allowed to finish on. A second LoadAsync cancels this one.
        _load = Scene.LoadAsync(next);
        _load.WaitForActivation = true;
        started = true;
    }

    public override void OnGui(Paper paper)
    {
        if (_load == null)
            return;

        FontFile? font = FontAsset.LoadDefault().FontFile;
        if (font == null)
            return;

        int pct = (int)(_load.Progress * 100f);
        if (pct > 100)
            pct = 100;

        // TUTORIAL pt16-04  Immediate mode. Paper.Box is rebuilt every call. Part 17 uses the same OnGui
        // for a gameplay readout. This one is only the loading line.
        paper.Box("load").Margin(40).Height(40)
            .Text($"Loading {pct}%", font)
            .FontSize(28)
            .TextColor(new Color(1f, 1f, 1f, 1f));
    }
}
