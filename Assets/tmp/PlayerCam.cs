using System;

using Prowl.Runtime;
using Prowl.Vector;

public class PlayerCam : MonoBehaviour
{
    public float Sensitivity = 0.15f;
    public float MinPitch = -89f;
    public float MaxPitch = 89f;

    private float _pitch;

    public override void Start()
    {
        _pitch = -Transform.LocalEulerAngles.X;
    }

    public override void Update()
    {
        if (!Input.CursorLocked) return;

        // Pitch only tilts the camera; the parent Player handles yaw.
        _pitch = Math.Clamp(_pitch - Input.MouseDelta.Y * Sensitivity, MinPitch, MaxPitch);
        Transform.LocalEulerAngles = new Float3(-_pitch, 0f, 0f);
    }
}
