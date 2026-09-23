# Create a Basic Title Screen in the Prowl Game Engine

**Watch the video:** https://youtu.be/8oDvGU0EzT0

**Play CHECK:** Click **Play Game** and the title hides; click **Quit Game** and the editor stays open.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, copy the script into the project you make in the video, and follow the episode.

Engine: **Prowl 1.0-preview-4** — https://github.com/ProwlEngine/Prowl

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt1-title-screen
```

## What you open

This episode’s companion is the script under `Scripts/`, for the project you create in the editor. This branch is not a full Prowl project: there is no `Assets/` folder and no `.prowl` file. The written steps are in this README. There is no docs folder.

Create a new project in the editor and name it **My Prowl Game**. Put `Scripts/TitleScreen.cs` in that project’s Scripts folder, or type it while you watch.

## Build the menu

1. Install Prowl 1.0-preview-4, or build it from the engine repo, and open the editor.
2. Create the project.
3. In the viewport, right mouse looks around. Right mouse plus WASD flies. E and Q move up and down. F focuses the selection. Alt plus left mouse orbits.
4. **GameObject → UI → Canvas**. Name it **Title Screen**. Drag it into the project panel so it becomes a prefab.
5. Add a child **Text**: `My Cool Game`, font size about **60**.
6. Add a child **Button**: label `Play Game`, black text, font size about **35**.
7. Duplicate it. Name the copy **Quit Button** and set the label to `Quit Game`.
8. Add a **UI Event System**.
9. Create an empty **Menu Controller**. Add **TitleScreen**. Drag the **Title Screen** canvas into `menuRoot`.
10. **Play Game** OnClick → **Menu Controller** → `OnPlayClicked`. **Quit Game** OnClick → **Menu Controller** → `OnQuitClicked`.

```csharp
using Prowl.Runtime;

public class TitleScreen : MonoBehaviour
{
    public GameObject menuRoot;

    public void OnPlayClicked()
    {
        Debug.Log("Play button clicked");

        if (menuRoot != null)
            menuRoot.Enabled = false;
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

Enter Play mode and use the Play CHECK at the top. Quit logs `Quit ignored in the editor` and calls `Game.Quit()` only outside the editor.
