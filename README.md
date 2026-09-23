# How to change scenes in the Prowl Game Engine

**Watch the video:** https://youtu.be/0omgv-6yawI

Part 2. You make **Play Game** load the Game scene. In Part 1 that button only hid the menu.

Engine download: https://github.com/ProwlEngine/Prowl (this series uses **1.0-preview-4**).

The script you end up with is `Scripts/TitleScreen.cs` on the `pt2-change-scenes` branch. Start from the title screen you built in Part 1.

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt2-change-scenes
```

## Save the title scene and add a game scene

1. Press Ctrl+S and save the current scene as **Title Screen**. Part 1 never saved a scene file.
2. Create a new scene named **Game**.
3. In the project panel, make folders named `Scenes`, `Prefabs`, and `Scripts`. Move the title scene, the title prefab, and your scripts into those folders.

## Load the Game scene from Play

4. Open `TitleScreen` and add `using Prowl.Runtime.Resources`.
5. Add a field `public AssetRef<Scene> gameScene`.
6. Replace the hide-menu body of `OnPlayClicked` with `EnsureLoaded` and `Scene.Load`. The class looks like this:

```csharp
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
```

7. Select **Menu Controller**. Assign the **Game** scene to `gameScene`. Leave `menuRoot` pointing at the title canvas. Quit stays wired to `OnQuitClicked`.

If `gameScene` is empty, Play logs `Game scene not found`. Assign the **Game** scene you just saved, which is the scene asset in `Scenes`, and leave any leftover untitled scene unassigned.

## Check

Open the **Title Screen** scene, enter Play mode, and click **Play Game**.

The console logs `Play button clicked` and `Game scene loaded`, then you are in the **Game** scene. The log line includes `scene.Name` so you can see which scene loaded.
