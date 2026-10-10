// TUTORIAL side-blender-01  New file: Assets/Scripts/MapColliders.cs
// Put this on the imported level root. Start adds a concave MeshCollider to every child mesh that does not have one.
// CHECK: Floor, Wall_Front, Wall_A, Wall_B, Ramp, Stair_1..4, and Platform each have a MeshCollider. Convex is off.

using Prowl.Runtime;
using Prowl.Runtime.Resources;

[AddComponentMenu("Physics/Map Colliders")]
public class MapColliders : MonoBehaviour
{
    public override void Start()
    {
        foreach (MeshRenderer renderer in GetComponentsInChildren<MeshRenderer>())
        {
            if (renderer.IsNotValid())
                continue;
            if (renderer.GetComponent<MeshCollider>().IsValid())
                continue;

            // TUTORIAL side-blender-02  MeshRenderer.Mesh is the imported mesh. MeshCollider.Mesh is the physics copy.
            // Convex stays off. Off builds one triangle per face, so the ramp slope and the stair treads stay walkable.
            Mesh? mesh = renderer.Mesh;
            if (mesh.IsNotValid())
                continue;

            MeshCollider collider = renderer.GameObject.AddComponent<MeshCollider>();
            collider.Convex = false;
            collider.Mesh = mesh;
        }
    }
}
