// TUTORIAL pt9-06  New file: Assets/Scripts/VehicleRide.cs
// Put this on the Player, next to Player and PlayerLook. It stays enabled while those are off.
// CHECK: F within 4 m switches WASD to the car and moves the camera to Chase. F again drops you beside it.

using System.Collections.Generic;

using Prowl.Runtime;
using Prowl.Vector;

public class VehicleRide : MonoBehaviour
{
    public float EnterDistance = 4f;

    CarDrive? _car;
    Camera? _camera;
    GameObject? _cameraParent;
    Float3 _cameraLocalPos;
    Quaternion _cameraLocalRot;
    readonly List<GameObject> _hidden = new();

    Player? _player;
    PlayerLook? _look;
    PlayerAnimator? _anim;
    CharacterController? _body;

    public override void Start()
    {
        _player = GetComponent<Player>();
        _look = GetComponent<PlayerLook>();
        _anim = GetComponent<PlayerAnimator>();
        _body = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>(false);
    }

    public override void Update()
    {
        // TUTORIAL pt9-07  KeyCode.F. Read here, not in Player.Update — that component is disabled in the driver's seat.
        if (!Input.GetKeyDown(KeyCode.F))
            return;

        if (_car.IsValid())
            Exit();
        else
            TryEnter();
    }

    void TryEnter()
    {
        if (Prowl.Runtime.Resources.Scene.Current.IsNotValid())
            return;

        CarDrive? nearest = null;
        float best = EnterDistance;
        Float3 here = Transform.Position;
        foreach (CarDrive? car in Prowl.Runtime.Resources.Scene.Current.FindObjectsOfType<CarDrive>())
        {
            if (car.IsNotValid())
                continue;
            float distance = Float3.Distance(here, car.Transform.Position);
            if (distance < best)
            {
                best = distance;
                nearest = car;
            }
        }

        if (nearest.IsValid())
            Enter(nearest);
    }

    void Enter(CarDrive car)
    {
        _car = car;
        car.Controlled = true;

        if (_player.IsValid()) _player.Enabled = false;
        if (_look.IsValid()) _look.Enabled = false;
        if (_anim.IsValid()) _anim.Enabled = false;
        if (_body.IsValid()) _body.Enabled = false;

        // TUTORIAL pt9-08  Chase is an empty child on the car. The camera is parented there with local identity,
        // so its pose is the Chase pose. Seat is where the player object sits so it rides along.
        if (_camera.IsValid())
        {
            _cameraParent = _camera.GameObject.Parent;
            _cameraLocalPos = _camera.Transform.LocalPosition;
            _cameraLocalRot = _camera.Transform.LocalRotation;
            GameObject? chase = FindChild(car.GameObject, "Chase");
            GameObject cameraObject = _camera.GameObject;
            if (chase.IsValid())
            {
                cameraObject.SetParent(chase, false);
                cameraObject.Transform.LocalPosition = Float3.Zero;
                cameraObject.Transform.LocalRotation = Quaternion.Identity;
            }
            else
            {
                cameraObject.SetParent(car.GameObject, false);
                cameraObject.Transform.LocalPosition = new Float3(0f, 2.2f, -6f);
                cameraObject.Transform.LocalEulerAngles = new Float3(12f, 0f, 0f);
            }
        }

        HideBody();

        GameObject? seat = FindChild(car.GameObject, "Seat");
        GameObject.SetParent(seat.IsValid() ? seat : car.GameObject, false);
        Transform.LocalPosition = Float3.Zero;
        Transform.LocalRotation = Quaternion.Identity;
    }

    void Exit()
    {
        CarDrive car = _car!;
        car.Controlled = false;
        _car = null;

        GameObject.SetParent(null!, true);
        Float3 drop = car.Transform.Position + car.Transform.Right * 2.5f + new Float3(0f, 0.2f, 0f);

        if (_camera.IsValid() && _cameraParent.IsValid())
        {
            _camera.GameObject.SetParent(_cameraParent, false);
            _camera.Transform.LocalPosition = _cameraLocalPos;
            _camera.Transform.LocalRotation = _cameraLocalRot;
        }

        ShowBody();

        if (_body.IsValid())
        {
            _body.Enabled = true;
            _body.Teleport(drop);
        }
        else
        {
            Transform.Position = drop;
        }

        if (_look.IsValid())
        {
            _look.MatchYawToTransform();
            _look.Enabled = true;
        }
        if (_player.IsValid()) _player.Enabled = true;
        if (_anim.IsValid()) _anim.Enabled = true;
    }

    void HideBody()
    {
        _hidden.Clear();
        foreach (GameObject child in GameObject.Children)
        {
            if (!child.Enabled)
                continue;
            if (child.GetComponent<Camera>().IsValid())
                continue;
            child.Enabled = false;
            _hidden.Add(child);
        }
    }

    void ShowBody()
    {
        foreach (GameObject child in _hidden)
        {
            if (child.IsValid())
                child.Enabled = true;
        }
        _hidden.Clear();
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
