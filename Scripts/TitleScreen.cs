// TUTORIAL: companion script for Jax's Development Den Prowl series.
// Current state: END OF pt3-loading-screen
// Videos: pt1 https://youtu.be/8oDvGU0EzT0
//         pt2 https://youtu.be/0omgv-6yawI
//         pt3 https://youtu.be/2zhuH4vjZ6M
//
// EDITOR: put this on the Menu Controller in the Title Screen scene/prefab.
// Assign menuRoot, gameScene, and loadingScene in the inspector.
// Wire UI Button on-click to OnPlayClicked / OnQuitClicked.
// CHECK: Play Game goes Title -> Loading -> Game.

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class TitleScreen : MonoBehaviour
{
    // TUTORIAL pt1-01  Drag the Title Screen canvas root here.
    public GameObject menuRoot;

    // TUTORIAL pt2-01  Assign the Game scene asset.
    public AssetRef<Scene> gameScene;

    // TUTORIAL pt3-01  Assign the Loading Screen scene asset.
    public AssetRef<Scene> loadingScene;

    // TUTORIAL pt1-02  Hook this from the Play button.
    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");

        // TUTORIAL pt3-02  Tell the loading screen where to go next.
        SceneLoadRequest.Destination = gameScene;

        // TUTORIAL pt3-03  Load the loading scene (not Game directly — that was pt2).
        loadingScene.EnsureLoaded();
        Scene? loading = loadingScene.Res;
        if (loading == null)
        {
            Debug.LogError("Loading scene not found");
            return;
        }

        Scene.Load(loading);
    }

    // TUTORIAL pt1-03  Hook this from the Quit button.
    public void OnQuitClicked()
    {
        Debug.Log("Quit button clicked");

        // TUTORIAL pt1-04  Game.Quit() also closes the editor. Only quit in a player build.
        if (Application.IsEditor)
        {
            Debug.Log("Quit ignored in the editor");
            return;
        }

        Game.Quit();
    }
}
