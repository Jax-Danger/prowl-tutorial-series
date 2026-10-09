// TUTORIAL pt8-01  New file: Assets/Scripts/PlayerAnimator.cs
// NEXT FILE: stay here — then do the EDITOR steps. The cube still moves if no FBX is imported.
// CHECK: standing plays Idle. Walking plays Walk. Missing clips do not throw.

using Prowl.Runtime;
using Prowl.Runtime.Resources;

public class PlayerAnimator : MonoBehaviour
{
    // TUTORIAL pt8-02  Drag the clip sub-assets from the imported FBX. Empty is fine.
    // AssetRef is a soft reference: a missing Mixamo file does not break the prefab.
    public AssetRef<AnimationClip> Idle;
    public AssetRef<AnimationClip> Walk;

    // Metres per second from Player.PlanarSpeed. At or below this, play Idle.
    public float WalkSpeed = 0.2f;

    public float FadeSeconds = 0.2f;

    Animator? _animator;
    AnimationClip? _playing;
    Player? _player;

    public override void Start()
    {
        _player = GetComponent<Player>();
        // TUTORIAL pt8-03  The importer puts Animator on the model root, which is a child of Player.
        _animator = GetComponentInChildren<Animator>(false);
        if (_animator.IsNotValid())
            _animator = GetComponent<Animator>();

        // CharacterController already moves the body. Root motion would slide it a second time.
        if (_animator.IsValid())
            _animator.ApplyRootMotion = false;
    }

    public override void Update()
    {
        if (_animator.IsNotValid())
            return;

        float speed = _player.IsValid() ? _player.PlanarSpeed : 0f;
        AnimationClip? idle = Clip(Idle);
        AnimationClip? walk = Clip(Walk);
        AnimationClip? want = speed > WalkSpeed ? walk ?? idle : idle ?? walk;
        if (want.IsNotValid() || ReferenceEquals(want, _playing))
            return;

        // TUTORIAL pt8-04  Play starts a clip. CrossFade blends from whatever is playing.
        // Both live on Animator (Prowl.Runtime/Animation/Animator.cs). No graph required.
        if (_playing.IsNotValid())
            _animator.Play(want);
        else
            _animator.CrossFade(want, FadeSeconds);

        _playing = want;
    }

    static AnimationClip? Clip(AssetRef<AnimationClip> reference)
    {
        if (reference.IsEmpty)
            return null;

        AnimationClip? clip = reference.Load();
        if (clip.IsNotValid() || clip.IsMissing)
            return null;

        return clip;
    }
}

// TUTORIAL pt8-DONE  End of Part 8.
// CHECK: no FBX — the cube still walks and the Console has no exception from this script.
// CHECK: with Idle and Walk assigned — still plays Idle, moving plays Walk, stopping returns to Idle.
