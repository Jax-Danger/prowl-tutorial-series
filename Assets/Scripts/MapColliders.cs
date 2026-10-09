// TUTORIAL pt10-01  New file: Assets/Scripts/MapColliders.cs
// Put this on the imported level. It adds a concave MeshCollider to every child mesh that does not have one.
// CHECK: with the courtyard parented here, the player and the car stop at the walls. An empty object does not throw.

using Prowl.Runtime;
using Prowl.Runtime.Resources;

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

            // TUTORIAL pt10-02  MeshRenderer.Mesh is the imported mesh. MeshCollider.Mesh is the physics copy.
            // Convex stays off. A courtyard is concave. Convex would wrap it in a hull and fill the gate.
            Mesh? mesh = renderer.Mesh;
            if (mesh.IsNotValid())
                continue;

            MeshCollider collider = renderer.GameObject.AddComponent<MeshCollider>();
            collider.Convex = false;
            collider.Mesh = mesh;
        }
    }
}
