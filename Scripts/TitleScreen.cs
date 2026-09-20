// TUTORIAL pt1-DONE  End of Part 1.
// NEXT: branch pt2-change-scenes  Video: https://youtu.be/0omgv-6yawI

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
