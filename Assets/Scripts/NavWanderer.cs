// TUTORIAL pt13-01  New file: Assets/Scripts/NavWanderer.cs
// Put this on the same object as a NavMesh Agent. Bake a NavMesh Surface first.
// CHECK: the cube walks to random points on the mesh. Inside Chase Distance it follows the player.
//        With no baked navmesh it stays put and the Console stays clear.

using System;

using Prowl.Runtime;
using Prowl.Vector;

[RequireComponent(typeof(NavMeshAgent))]
public class NavWanderer : MonoBehaviour
{
    // TUTORIAL pt13-02  Inspector. Wander Radius is metres around the agent, and the point is
    // one it can actually walk to (NavMeshAgent.SetRandomDestination).
    public float WanderRadius = 16f;
    public float ChaseDistance = 6f;
    public float RepathSeconds = 0.35f;

    NavMeshAgent? _agent;
    Player? _player;
    bool _chasing;
    float _repath;
    float _retry;

    public override void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindPlayer();
    }

    public override void Update()
    {
        if (_agent.IsNotValid() || !_agent.IsOnNavMesh)
            return;

        if (_player.IsNotValid())
            _player = FindPlayer();

        if (TryChase())
            return;

        // TUTORIAL pt13-03  HasArrived stays true until the next destination. PathPending means
        // the crowd has not finished the path yet, so do not replace it mid-query.
        bool needPoint = _chasing || (!_agent.PathPending && (_agent.HasArrived || !_agent.HasPath));
        if (!needPoint || WanderRadius <= 0f)
            return;

        if (_retry > 0f)
        {
            _retry -= Time.DeltaTime;
            return;
        }

        if (_agent.SetRandomDestination(WanderRadius))
            _chasing = false;
        else
            _retry = 0.5f;
    }

    bool TryChase()
    {
        if (_player.IsNotValid() || ChaseDistance <= 0f || _agent.IsNotValid())
            return false;

        Float3 from = Transform.Position;
        Float3 to = _player.Transform.Position;
        float dx = from.X - to.X;
        float dz = from.Z - to.Z;
        if (dx * dx + dz * dz > ChaseDistance * ChaseDistance)
            return false;

        _chasing = true;
        _repath -= Time.DeltaTime;
        if (_repath > 0f)
            return true;

        _repath = RepathSeconds;
        // TUTORIAL pt13-04  SamplePosition maps the player onto the navmesh. SetDestination
        // returns false when the point cannot be mapped, and the agent keeps its last path.
        if (_agent.SamplePosition(to, 2f, out NavMeshHit hit))
            _agent.SetDestination(hit.Position);
        return true;
    }

    static Player? FindPlayer()
    {
        if (Prowl.Runtime.Resources.Scene.Current.IsNotValid())
            return null;

        foreach (Player? player in Prowl.Runtime.Resources.Scene.Current.FindObjectsOfType<Player>())
        {
            if (player.IsValid())
                return player;
        }
        return null;
    }
}
