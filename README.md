# How to change scenes in the Prowl Game Engine

**Watch the video:** https://youtu.be/0omgv-6yawI

**Play CHECK:** Click **Play Game** and you are in the Game scene.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch and follow the episode in the project you already started in Part 1.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt2-change-scenes
```

## What you open

This episode’s companion is `Scripts/TitleScreen.cs`, for the Prowl project you already created. This branch is not a full project folder: there is no `Assets/` tree and no `.prowl` file. Scenes live in that project after you save them. The steps are in this README. There is no docs folder.

## Make Play load the Game scene

1. Press Ctrl+S and save the open scene as **Title Screen**.
2. Create a new scene named **Game**.
3. Make project folders `Scenes`, `Prefabs`, and `Scripts`, and move the title scene, the title prefab, and your scripts into them.
4. Replace `OnPlayClicked` so it loads `gameScene` instead of hiding the menu. The finished script is `Scripts/TitleScreen.cs`:

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

5. On **Menu Controller**, assign the **Game** scene asset to `gameScene`.

If that field is empty, Play logs `Game scene not found`. Assign the **Game** scene you saved, and leave any untitled scene unassigned.

Open **Title Screen**, enter Play mode, and use the Play CHECK at the top. The log includes `scene.Name`.
