// TUTORIAL pt6-01  New file: Assets/Scripts/PlayerLook.cs
// NEXT FILE: stay here — type the class, then do the EDITOR prefab steps before Play.
// EDITOR: parent Player stays empty (scripts only). Child Mesh is the body. Child Camera is the view.
// CHECK: mouse left/right turns the whole Player. Mouse up/down pitches only the camera, about -80 to 80.

using System;

using Prowl.Runtime;
using Prowl.Vector;

public class PlayerLook : MonoBehaviour
{
    // TUTORIAL pt6-02  Inspector on the Player prefab. 0.15 is Prowl's first-person template (degrees per mouse pixel).
    public float Sensitivity = 0.15f;

    // TUTORIAL pt6-03  Drag the Camera child here. Start finds a Camera on a child when this is empty.
    public Camera ViewCamera;

    // Pitch stays in this range so the camera cannot flip over the top or bottom.
    const float MinPitch = -80f;
    const float MaxPitch = 80f;

    float _yaw;
    float _pitch;

    // TUTORIAL pt6-04  Start runs once when Play begins. Lifecycle methods run only when declared override.
    public override void Start()
    {
        if (ViewCamera.IsNotValid())
            ViewCamera = GetComponentInChildren<Camera>(false);

        _yaw = Transform.LocalEulerAngles.Y;

        if (ViewCamera.IsValid() && ViewCamera.GameObject != GameObject)
            _pitch = ViewCamera.Transform.LocalEulerAngles.X;

        // TUTORIAL pt6-05  LockCursor hides the cursor and pins it (CursorLockMode.Locked).
        // SAY: "Escape shows the cursor again. Click in the Game view to lock it."
        Input.LockCursor();
    }

    // TUTORIAL pt6-06  Update runs every rendered frame while Play mode is on.
    public override void Update()
    {
        // TUTORIAL pt6-07  Escape unlocks. A left click locks again. The editor also releases the cursor on Escape.
        if (Input.GetKeyDown(KeyCode.Escape))
            Input.UnlockCursor();
        else if (!Input.CursorLocked && Input.GetMouseButtonDown(0))
            Input.LockCursor();

        if (!Input.CursorLocked)
            return;

        // TUTORIAL pt6-08  Input.MouseDelta is the pixel delta this frame (Prowl.Runtime.Input, preview-4).
        // X yaws the parent. Y pitches the camera. Subtract Y so moving the mouse up looks up,
        // the same sign as Prowl's NewFirstPersonCamera template.
        Float2 delta = Input.MouseDelta;
        _yaw += delta.X * Sensitivity;
        _pitch = Math.Clamp(_pitch - delta.Y * Sensitivity, MinPitch, MaxPitch);

        // TUTORIAL pt6-09  Yaw the whole player. Local pitch and roll stay 0 so the body stays upright.
        // SAY: "The mesh is a child, so it turns with us. Player movement reads this transform's Forward and Right."
        Transform.LocalEulerAngles = new Float3(0f, _yaw, 0f);

        // TUTORIAL pt6-10  Pitch lives on the camera child only, clamped to about -80..80 degrees.
        if (ViewCamera.IsValid() && ViewCamera.GameObject != GameObject)
            ViewCamera.Transform.LocalEulerAngles = new Float3(_pitch, 0f, 0f);
    }
}

// TUTORIAL pt6-DONE  End of Part 6.
// CHECK: WASD moves along the facing. Mouse left/right turns body and camera. Mouse up/down tilts only the view.
