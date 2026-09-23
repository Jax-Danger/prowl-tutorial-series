using System;

using Prowl.Runtime;
using Prowl.Runtime.Rendering;
using Prowl.Runtime.Resources;
using Prowl.Vector;

namespace Scenes;

public class RotatingCubeScene
{
    public Scene Initialize()
    {
        Scene scene = new() { Name = "SpinningCube" };

        GameObject light = new("Directional Light");
        light.AddComponent<DirectionalLight>();
        light.Transform.LocalEulerAngles = new Float3(-50f, 30f, 0f);
        scene.Add(light);

        GameObject camera = new("Main Camera");
        camera.Tag = "Main Camera";
        camera.Transform.Position = new Float3(0f, 1.5f, -5f);
        Camera cam = camera.AddComponent<Camera>();
        scene.Add(camera);

        GameObject cube = new("Spinning Cube");
        MeshRenderer renderer = cube.AddComponent<MeshRenderer>();
        renderer.Mesh = Mesh.CreateCube(Float3.One);
        renderer.Material = new Material(Shader.LoadDefault(DefaultShader.Standard));
        cube.AddComponent<Spin>();
        scene.Add(cube);

        return scene;
    }
}
