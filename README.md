# Create a Basic Title Screen in the Prowl Game Engine

**Watch the video:** https://youtu.be/8oDvGU0EzT0

Part 1. You build a title screen in the Prowl editor. **Play Game** hides the menu. **Quit Game** writes a log and leaves the editor open.

Engine download: https://github.com/ProwlEngine/Prowl (this series uses **1.0-preview-4**).

The script you end up with is `Scripts/TitleScreen.cs` on the `pt1-title-screen` branch.

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt1-title-screen
```

## Build the menu

1. Install Prowl 1.0-preview-4, or build the engine from the repo above, and open the editor.
2. Create a new project. Name it **My Prowl Game**.
3. In the viewport, right mouse looks around. Right mouse plus WASD flies. E and Q move up and down. F focuses the selection. Alt plus left mouse orbits.
4. Use **GameObject → UI → Canvas**. Name the canvas **Title Screen**. Drag it from the Hierarchy into the project panel so it becomes a prefab.
5. Add a child **Text**. Set the words to `My Cool Game` and the font size to about **60**.
6. Add a child **Button**. Set its label to `Play Game`, the text color to black, and the font size to about **35**.
7. Duplicate that button. Name the copy **Quit Button** and set the label to `Quit Game`.
8. Add a **UI Event System** so the buttons can receive clicks.
9. Create an empty GameObject named **Menu Controller**.

## TitleScreen script

10. Create a MonoBehaviour script named **TitleScreen** and use this:

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

11. Add **TitleScreen** to **Menu Controller**.
12. Drag the **Title Screen** canvas into the `menuRoot` field.
13. Select the **Play Game** button. In its OnClick list, choose **Menu Controller** and the method `OnPlayClicked`.
14. Select the **Quit Game** button. In its OnClick list, choose **Menu Controller** and the method `OnQuitClicked`.

## Check

Enter Play mode.

- Click **Play Game**. The console logs `Play button clicked` and the title canvas hides.
- Click **Quit Game**. The console logs `Quit button clicked` and `Quit ignored in the editor`. The editor stays open. `Game.Quit()` runs only when you are in a build, because `Application.IsEditor` is true inside the editor.
