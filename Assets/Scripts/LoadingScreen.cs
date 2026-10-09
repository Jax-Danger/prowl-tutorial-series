using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class LoadingScreen : MonoBehaviour
{
    public float minDisplaySeconds = 1.5f;

    private float elapsed;
    private bool done;

    public override void Update()
    {
        if (done)
            return;

        elapsed += Time.DeltaTime;

        if (elapsed < minDisplaySeconds)
            return;

        // TUTORIAL pt7-04  Same load path as the title screen. Scene.Load(SceneAsset) queues
        // the swap for the end of the frame.
        SceneAsset? next = SceneLoadRequest.Destination.IsEmpty ? null : SceneLoadRequest.Destination.Load();
        if (next.IsNotValid() || next.IsMissing)
        {
            Debug.LogError("Loading screen has no destination set.");
            done = true;
            return;
        }

        done = true;
        Scene.Load(next);
    }
}
