// TUTORIAL pt3-DONE  End of Part 3.
// Videos: https://youtu.be/8oDvGU0EzT0  https://youtu.be/0omgv-6yawI  https://youtu.be/2zhuH4vjZ6M
// NEXT episode not recorded yet (player movement is the natural pt4).

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class TitleScreen : MonoBehaviour
{
    public GameObject menuRoot;
    public AssetRef<Scene> gameScene;
    public AssetRef<Scene> loadingScene;

    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");

        SceneLoadRequest.Destination = gameScene;

        loadingScene.EnsureLoaded();
        Scene? loading = loadingScene.Res;
        if (loading == null)
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
