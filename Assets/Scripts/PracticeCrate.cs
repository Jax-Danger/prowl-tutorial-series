// TUTORIAL pt19-04  New file: Assets/Scripts/PracticeCrate.cs
// Put this on an empty Crate object. Start builds a dynamic box you can shoot.
// CHECK: three hits and the box disables. The Console counts down.

using Prowl.Runtime;
using Prowl.Runtime.Resources;
using Prowl.Vector;

public class PracticeCrate : MonoBehaviour
{
    public int Hits = 3;

    bool _built;

    public override void Start()
    {
        if (_built || GameObject.Scene.IsNotValid())
            return;
        _built = true;

        Float3 size = new Float3(0.7f, 0.7f, 0.7f);
        var box = new GameObject("Crate");
        GameObject.Scene.Add(box);
        box.SetParent(GameObject, false);
        box.Transform.LocalPosition = new Float3(0f, 0.55f, 0f);

        var renderer = box.AddComponent<MeshRenderer>();
        renderer.Mesh = Mesh.CreateCube(size);
        var material = new Material(Shader.LoadDefault(DefaultShader.Standard));
        material.SetColor("_MainColor", new Color(0.75f, 0.15f, 0.12f, 1f));
        renderer.Material = material;

        box.AddComponent<BoxCollider>().Size = size;
        Rigidbody3D body = box.AddComponent<Rigidbody3D>();
        body.Mass = 4f;
    }

    public void TakeHit()
    {
        if (Hits <= 0)
            return;

        Hits--;
        Debug.Log(Hits > 0 ? $"Crate: {Hits} hits left" : "Crate: down");
        if (Hits <= 0)
            GameObject.Enabled = false;
    }
}
