// TUTORIAL pt12-01  New file: Assets/Scripts/TerrainSeed.cs
// Put this on the Terrain object, next to Terrain and Terrain Collider.
// CHECK: a flat heightmap grows a few hills on the first Play. A painted heightmap is left alone.

using System;

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Runtime.Terrain;

public class TerrainSeed : MonoBehaviour
{
    public override void Start()
    {
        TerrainComponent? terrain = GetComponent<TerrainComponent>();
        if (terrain.IsNotValid() || terrain.Data.IsNotValid())
            return;

        TerrainData data = terrain.Data;
        int res = data.HeightmapResolution;
        if (res < 2)
            return;

        // TUTORIAL pt12-02  GetHeight is 0..1. Resize Heightmap in the inspector wipes this to zero
        // and asks you to confirm. Only stamp hills while every sample is still that flat.
        for (int z = 0; z < res; z++)
        {
            for (int x = 0; x < res; x++)
            {
                if (data.GetHeight(x, z) > 0.001f)
                    return;
            }
        }

        for (int z = 0; z < res; z++)
        {
            float v = z / (float)(res - 1);
            for (int x = 0; x < res; x++)
            {
                float u = x / (float)(res - 1);
                float waves = 0.12f * MathF.Sin(u * MathF.PI * 3f) * MathF.Sin(v * MathF.PI * 2f);
                float dx = u - 0.35f;
                float dz = v - 0.62f;
                float hill = 0.28f * MathF.Exp(-(dx * dx + dz * dz) * 18f);
                float height = waves + hill;
                if (height < 0f)
                    height = 0f;
                data.SetHeight(x, z, height);
            }
        }

        // TUTORIAL pt12-03  SetHeight already marks the map dirty. This bumps the version the renderer watches.
        data.SetHeightmapDirty();
    }
}
