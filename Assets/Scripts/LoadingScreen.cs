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

        SceneLoadRequest.Destination.EnsureLoaded();
        Scene? next = SceneLoadRequest.Destination.Res;
        if (next == null)
        {
            Debug.LogError("Loading screen has no destination set.");
            done = true;
            return;
        }

        done = true;
        Scene.Load(next);
    }
}
