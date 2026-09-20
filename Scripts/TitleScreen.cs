// TUTORIAL pt2-DONE  End of Part 2.
// NEXT: branch pt3-loading-screen  Video: https://youtu.be/2zhuH4vjZ6M

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class TitleScreen : MonoBehaviour
{
    public GameObject menuRoot;
    public AssetRef<Scene> gameScene;

    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");

        gameScene.EnsureLoaded();
        Scene? scene = gameScene.Res;
        if (scene == null)
        {
            Debug.LogError("Game scene not found");
            return;
        }

        Debug.Log($"Game scene loaded {scene.Name}");
        Scene.Load(scene);
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
