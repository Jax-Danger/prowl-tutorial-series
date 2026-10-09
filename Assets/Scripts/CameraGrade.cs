// TUTORIAL pt11-04  New file: Assets/Scripts/CameraGrade.cs
// Put this on the player Camera. It fills Camera.Effects when the list does not already have them.
// CHECK: the view is tonemapped. A bright spot blooms. Missing the camera does not throw.

using Prowl.Runtime;
using Prowl.Runtime.Rendering;

public class CameraGrade : MonoBehaviour
{
    public override void OnEnable()
    {
        Camera? camera = GetComponent<Camera>();
        if (camera.IsNotValid())
            return;

        // Bloom reads HDR values. The tonemapper then brings the image back to display range.
        camera.HDR = true;

        bool bloom = false;
        bool tonemap = false;
        foreach (ImageEffect effect in camera.Effects)
        {
            if (effect is BloomEffect)
                bloom = true;
            if (effect is TonemapperEffect)
                tonemap = true;
        }

        // TUTORIAL pt11-05  Order matters. Bloom runs on the HDR image. TonemapperEffect.TransformsToLDR
        // is true, so it stays last. Defaults: Bloom intensity 1.5, threshold 0.8. Tonemapper is AgX.
        if (!bloom)
            camera.Effects.Add(new BloomEffect());
        if (!tonemap)
            camera.Effects.Add(new TonemapperEffect());
    }
}
