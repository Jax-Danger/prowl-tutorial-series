// TUTORIAL pt3  Plain static class — do not attach this to a GameObject.
// Holds which scene the loading screen should open after the timer.
// NEXT FILE: Scripts/LoadingScreen.cs

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public static class SceneLoadRequest
{
    public static AssetRef<Scene> Destination;
}
