using System;

using Prowl.Runtime;
using Prowl.Runtime.Rendering;
using Prowl.Runtime.Resources;
using Prowl.Vector;

using Scenes;

public sealed class MyProwlGame : Game
{
    public static int Main(string[] args)
    {
        new MyProwlGame().Run("My Prowl Game", 1280, 720);
        return Environment.ExitCode;
    }

    public override void Initialize()
    {
        Scene scene = new RotatingCubeScene().Initialize();
        Scene.Load(scene);
    }
}