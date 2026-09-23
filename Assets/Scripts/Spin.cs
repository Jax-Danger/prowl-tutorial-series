using Prowl.Runtime;
using Prowl.Vector;

public class Spin : MonoBehaviour 
{
    public float degreesPerSecond = 90f;

    public override void Update()
    {
        Transform.Rotate(Float3.UnitY, degreesPerSecond * Time.DeltaTime);
    }
}