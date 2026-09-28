using System;

using Prowl.Runtime;
using Prowl.Vector;

public class PlayerCam : MonoBehaviour
{
    public float Sensitivity = 0.15f;
    public Camera? ViewCamera;
    public float MinPitch = -89f;
    public float MaxPitch = 89f;

    private float _yaw;
    private float _pitch;

    public override void Start()
    {
        if (ViewCamera.IsNotValid())
            ViewCamera = GetComponentInChildren<Camera>(false);
        
        _yaw = Transform.LocalEulerAngles.Y;

        if (ViewCamera.IsValid() && ViewCamera.GameObject != GameObject)
            _pitch = ViewCamera.Transform.LocalEulerAngles.X;
        

        Input.LockCursor();
    }

    public override void Update()
    {
        if (!Input.CursorLocked) return;

        Float2 delta = Input.MouseDelta;
        _yaw += delta.X * Sensitivity;
        _pitch = Math.Clamp(_pitch - delta.Y * Sensitivity, MinPitch, MaxPitch);

        // Rotates the player(left/right)
        Transform.LocalEulerAngles = new Float3(0f, _yaw, 0f);

        // Rotates the camera (up/down)
        ViewCamera.Transform.LocalEulerAngles = new Float3(-_pitch, 0f, 0f);
    }
}
