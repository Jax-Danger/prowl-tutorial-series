# Loading Screens in the Prowl Game Engine

**Watch the video:** https://youtu.be/2zhuH4vjZ6M

Part 3. You put a basic text loading screen between the title and the game. Play goes Title, then Loading for about 1.5 seconds, then Game. At the end of Part 2, Play loaded Game directly.

Engine download: https://github.com/ProwlEngine/Prowl (this series uses **1.0-preview-4**).

Finished scripts on the `pt3-loading-screen` branch:

- `Scripts/SceneLoadRequest.cs`
- `Scripts/LoadingScreen.cs`
- `Scripts/TitleScreen.cs`

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt3-loading-screen
```

## Loading scene

1. Create a new scene named **Loading Screen**.
2. Add UI text that says `Loading...`. That is the whole screen.

## Remember which scene comes next

3. Add `Scripts/SceneLoadRequest.cs`. It holds the scene Play is trying to reach:

```csharp
using Prowl.Runtime;
using Prowl.Runtime.Resources;

public static class SceneLoadRequest
{
    public static AssetRef<Scene> Destination;
}
```

4. Add `Scripts/LoadingScreen.cs`. `minDisplaySeconds` stays at **1.5**:

```csharp
using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class LoadingScreen : MonoBehaviour
{
    public float minDisplaySeconds = 1.5f;

    private float elapsed;
    private bool done;

    public void Update()
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
```

5. Put an object in the **Loading Screen** scene and add the **LoadingScreen** component. Leave `minDisplaySeconds` at 1.5.
6. Save the scene.

## Send Play through that scene

7. Change `TitleScreen.OnPlayClicked` so it stores the Game scene on `SceneLoadRequest.Destination`, then loads the loading scene:

```csharp
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
```

8. On **Menu Controller**, assign the **Loading Screen** scene to `loadingScene`. Keep `gameScene` assigned to **Game**, and keep `menuRoot` on the title canvas.

## Check

Open **Title Screen**, enter Play mode, and click **Play Game**.

You see the loading text for about 1.5 seconds, then the **Game** scene. If the console says `Loading scene not found`, assign `loadingScene`. If it says `Loading screen has no destination set.`, assign `gameScene` before you click Play.
