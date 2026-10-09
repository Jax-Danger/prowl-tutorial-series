// Part 1–3 TitleScreen. Part 7 retargets the scene slots onto SceneAsset.
// Videos: https://youtu.be/8oDvGU0EzT0  https://youtu.be/0omgv-6yawI  https://youtu.be/2zhuH4vjZ6M

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class TitleScreen : MonoBehaviour
{
    public GameObject menuRoot = null!;

    // TUTORIAL pt7-02  These were AssetRef<Scene>. Scene is no longer an Asset, so the field
    // would not compile. Drag the same .scene files; the slot type is now SceneAsset.
    public AssetRef<SceneAsset> gameScene;
    public AssetRef<SceneAsset> loadingScene;

    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");

        SceneLoadRequest.Destination = gameScene;

        // TUTORIAL pt7-03  Res and EnsureLoaded are gone. Load() blocks and returns the asset,
        // or null when the slot is empty. IsMissing is a guid the database does not have.
        SceneAsset? loading = loadingScene.IsEmpty ? null : loadingScene.Load();
        if (loading.IsNotValid() || loading.IsMissing)
        {
            Debug.LogError("Loading scene not found");
            return;
        }

        Scene.Load(loading);
    }

    public void OnQuitClicked()
    {
        Debug.Log("Quit button clicked");

        if (Application.IsEditor)
        {
            Debug.Log("Quit ignored in the editor");
            return;
        }

        Game.Quit();
    }
}
