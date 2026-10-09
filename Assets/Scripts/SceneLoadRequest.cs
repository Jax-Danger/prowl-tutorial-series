using Prowl.Runtime;
using Prowl.Runtime.Resources;

public static class SceneLoadRequest
{
    // TUTORIAL pt7-01  AssetRef now only points at an Asset. A live Scene is not one.
    // The file on disk is a SceneAsset. Scene.Load(SceneAsset) builds the live scene.
    public static AssetRef<SceneAsset> Destination;
}
