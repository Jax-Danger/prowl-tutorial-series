// TUTORIAL pt9-01  New file: Assets/Scripts/CarDrive.cs
// NEXT FILE: Assets/Scripts/VehicleRide.cs — then do the EDITOR steps for the car prefab.
// CHECK: WASD drives only while Controlled is on. Space brakes. With Controlled off the wheels hold the car.

using System;
using System.Collections.Generic;

using Prowl.Runtime;
using Prowl.Vector;

[RequireComponent(typeof(Rigidbody3D))]
public class CarDrive : MonoBehaviour
{
    // TUTORIAL pt9-02  Inspector on the Car prefab. Torque and brake are newton-metres on each driven wheel.
    public float Torque = 1500f;
    public float BrakeTorque = 3000f;
    public float MaxSteerDegrees = 28f;

    // TUTORIAL pt9-03  VehicleRide sets this. While it is off, Update holds the brakes so the car parks.
    public bool Controlled;

    readonly List<WheelCollider> _wheels = new();
    readonly List<WheelCollider> _front = new();

    public override void Start()
    {
        Rigidbody3D body = GetComponent<Rigidbody3D>()!;
        // A new Rigidbody3D starts at 1 kg. A car that light will bounce off the player.
        if (body.Mass <= 1.01f)
            body.Mass = 1200f;
        // Default centre of mass is the origin, under the chassis. Sit it near the axles.
        if (!body.CenterOfMassOverride.HasValue)
            body.CenterOfMassOverride = new Float3(0f, 0.35f, 0f);

        _wheels.Clear();
        _front.Clear();
        foreach (WheelCollider wheel in GetComponentsInChildren<WheelCollider>(false))
        {
            if (wheel.IsNotValid())
                continue;
            _wheels.Add(wheel);
            // TUTORIAL pt9-04  WheelCollider.Update poses VisualTransform. The mount stays put.
            // Hub is a child of the wheel. The cylinder mesh is a child of Hub, axle along Hub's X.
            if (wheel.VisualTransform == null)
            {
                GameObject? hub = FindChild(wheel.GameObject, "Hub");
                if (hub.IsValid())
                    wheel.VisualTransform = hub.Transform;
            }

            string name = wheel.GameObject.Name;
            if (name == "FL" || name == "FR")
                _front.Add(wheel);
        }
    }

    public override void Update()
    {
        float throttle = 0f;
        float steer = 0f;
        bool brake = !Controlled;
        if (Controlled)
        {
            if (Input.GetKey(KeyCode.W)) throttle += 1f;
            if (Input.GetKey(KeyCode.S)) throttle -= 1f;
            if (Input.GetKey(KeyCode.D)) steer += 1f;
            if (Input.GetKey(KeyCode.A)) steer -= 1f;
            if (Input.GetKey(KeyCode.Space)) brake = true;
        }

        // TUTORIAL pt9-05  SteerAngle is radians, positive toward the wheel's right. MaxSteerDegrees is the inspector number.
        float steerRad = steer * MaxSteerDegrees * (MathF.PI / 180f);
        float share = _wheels.Count > 0 ? throttle * Torque / _wheels.Count : 0f;
        foreach (WheelCollider wheel in _wheels)
        {
            wheel.SteerAngle = _front.Contains(wheel) ? steerRad : 0f;
            wheel.MotorTorque = brake ? 0f : share;
            wheel.BrakeTorque = brake ? BrakeTorque : 0f;
        }
    }

    static GameObject? FindChild(GameObject root, string name)
    {
        foreach (GameObject child in root.Children)
        {
            if (child.Name == name)
                return child;
            GameObject? nested = FindChild(child, name);
            if (nested.IsValid())
                return nested;
        }
        return null;
    }
}
