# Loading Screens in the Prowl Game Engine

**Watch the video:** https://youtu.be/2zhuH4vjZ6M

**Play CHECK:** Click **Play Game**, see `Loading...` for about 1.5 seconds, then the Game scene.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch and follow the episode in the project you already have from Part 2.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt3-loading-screen
```

## What you open

This episode’s companion is the scripts in `Scripts/`, for the Prowl project you already created. This branch is not a full project folder: there is no `Assets/` tree and no `.prowl` file. You save the loading scene inside your project. The steps are in this README. There is no docs folder.

- `Scripts/SceneLoadRequest.cs` — where Play stores the destination scene
- `Scripts/LoadingScreen.cs` — waits `minDisplaySeconds` (1.5), then loads that scene
- `Scripts/TitleScreen.cs` — Play loads the loading scene instead of Game

## Add the loading screen

1. Create a scene named **Loading Screen** with UI text `Loading...`.
2. Add `SceneLoadRequest` and `LoadingScreen` to the project’s Scripts folder.
3. Add **LoadingScreen** to an object in that scene. Leave `minDisplaySeconds` at **1.5**. Save the scene.
4. Change **TitleScreen** so Play sets `SceneLoadRequest.Destination` to `gameScene`, then loads `loadingScene`.
5. On **Menu Controller**, assign the **Loading Screen** scene to `loadingScene` and keep `gameScene` on **Game**.

```csharp
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
```

`LoadingScreen.Update` waits until `elapsed` passes 1.5 seconds, then `Scene.Load`s `SceneLoadRequest.Destination`. The full files are in `Scripts/`.

Open **Title Screen**, enter Play mode, and use the Play CHECK at the top. `Loading scene not found` means `loadingScene` is empty. `Loading screen has no destination set.` means `gameScene` is empty.
