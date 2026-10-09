# Part 8 — Animation

Branch `pt8-animation`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The player is still a capsule with a cube. I’m importing a Mixamo character and playing idle or walk from the speed we already have. No animation graph. The Animator just plays a clip.

## Download

This is on mixamo.com, not in the editor.

### 1
Pick a character and download it.

### 2
Format FBX Binary. Skin, With Skin. Pose, T-Pose. Frames per second, 30.

### 3
Download an idle. FBX Binary, Without Skin, 30 frames a second, keyframe reduction none. Without Skin, because the character file already has the mesh. Two skins fight each other.

### 4
Download a walk with those same four settings.

### 5
Put the three files in the project folder `Assets/Mixamo`. That folder is gitignored. Don’t commit the FBX files. The script is fine with the slots empty, so the repo still runs without them.

## Import

### 1
In the Project panel, click the With Skin FBX. Wait until the Console is quiet.

### 2
Inspector, Model, Unit Scale 1.

### 3
If the preview is huge, set Unit Scale to 0.01 and wait for the reimport. Mixamo sometimes exports in centimeters. I check the preview before I parent it, because a 100-times-tall character makes the camera look broken.

### 4
Animation, Rig Type Humanoid.

### 5
Import Animations on. Loop Animations on. Sample Rate 30. Loop matters or idle plays once and freezes.

### 6
If the inspector says the auto mapper failed, open the Avatar Editor and assign hips, spine, and head. Humanoid needs those or the clip won’t play on this mesh.

### 7
Click the idle FBX and repeat the rig, import, loop, and sample rate.

### 8
Same for the walk FBX.

### 9
Expand each FBX. The character is a prefab. Each animation file has an Animation Clip under it. Those clips are what we drag onto the script.

## Player

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Drag the character prefab onto Hierarchy Player.

### 3
Rename that child Character.

### 4
Local Position 0, 0, 0. Local Rotation 0, 0, 0. Local Scale 1, 1, 1. Don’t scale Player. The character controller’s size is already tuned.

### 5
If the feet are in the floor, change Local Position Y until the soles sit on the floor.

### 6
Click Character.

### 7
On Animator, Apply Root Motion off. Avatar is filled. Graph stays empty. Root motion would slide the body a second time. The character controller is already moving us.

### 8
Click Mesh and uncheck the enable box at the top. That’s the old cube. Leave it in the prefab so we can turn it back on.

### 9
No FBX yet: leave Mesh checked and skip steps 2 through 8. The cube still walks. The script is written to survive missing clips.

### 10
Click Player.

### 11
Add Component, Player Animator, if it isn’t there.

### 12
Expand the idle FBX and drag the clip onto Player Animator, Idle.

### 13
Drag the walk clip onto Walk.

### 14
Walk Speed 0.2. Fade Seconds 0.2. Under 0.2 metres a second we stay in idle. The fade is the blend between the two clips.

### 15
If the mesh faces backward while WASD is correct, set Character’s Local Rotation Y to 180. The movement is right. The art is looking the wrong way. Don’t “fix” it in the movement code.

### 16
Click Player and Apply.

### 17
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Play.

### 3
Click the Game view, then Play Game.

### 4
No clips assigned: the cube still moves, and the Console has no PlayerAnimator exception.

### 5
Clips assigned: standing plays idle. WASD plays walk. Stop, and idle comes back. Space still jumps. Jump speed is vertical, so it doesn’t count as walking.

### 6
Stop.

## Code on screen

Drop these on the cuts where the scripts are up. They are not extra README steps.

### PlanarSpeed
On Player, after we write X and Z velocity, `PlanarSpeed` is the length of that horizontal vector. Jumping doesn’t change it. PlayerAnimator reads this number.

### Idle and Walk slots
`AssetRef<AnimationClip>`. A soft reference. A missing Mixamo file does not break the prefab. `Clip` returns null when the slot is empty, invalid, or missing.

### Start
The importer puts Animator on the model root, a child of Player, so we use `GetComponentInChildren`. Then `ApplyRootMotion = false`.

### Update
Speed above Walk Speed wants the walk clip, otherwise idle. If the one we want is missing, we fall back to the other. If it’s already playing, we return. First clip calls `Animator.Play`. After that, `CrossFade` over Fade Seconds. Both live on Animator. No graph.

## Outro

Like and subscribe if the walk cycle landed. Next time that character gets in a car.
