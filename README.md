# Animation

**Video:** coming. Part 8 does not have a public URL yet.

**Play CHECK:** With no Mixamo files, the cube from Part 6 still moves and jumps, and the Console has no exception from `PlayerAnimator`. After you import a skinned character and assign Idle and Walk, standing plays idle and moving plays walk. Stopping returns to idle. The body does not slide out from under the camera.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 used **v1.0-preview-4**. Part 7 moved the course to **Prowl 1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main`. Stay on that pin. `Animator` and `AnimationClip` are not in the preview-4 tag.

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | Engine pin above |
| 8 | `pt8-animation` | This episode. Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Blender level and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |

Prerequisite: Part 7 plays (title, loading, game, mouse look).

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt8-animation
```

## Open it

This episode’s companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

- `Assets/Scripts/Player.cs` — now exposes `PlanarSpeed`
- `Assets/Scripts/PlayerAnimator.cs` — this episode. Search `TUTORIAL pt8`
- `Assets/Prefabs/Player.prefab` and `Assets/Scenes/Game.scene` — **PlayerAnimator** is already on **Player**. Idle and Walk start empty
- `Assets/Mixamo/` — you create this. It is gitignored. Do not commit the FBX files

Any skinned FBX or glTF with clips works. Mixamo is the example because the download dialog is the same for everyone. Prowl imports `.fbx`, `.gltf`, `.glb`, and `.obj` (`EditorModelImporter`).

Paths are case-sensitive: `Assets/Scripts/PlayerAnimator.cs`.

`Update` is `public override`. A plain `public void Update()` does not run.

## Download a character

On [Mixamo](https://www.mixamo.com), pick a character (Y Bot is fine) and download it:

- Format: **FBX Binary (.fbx)**
- Skin: **With Skin**
- Pose: **T-Pose**
- Frames per Second: **30**

Then download two animations, one idle and one walk:

- Format: **FBX Binary (.fbx)**
- Skin: **Without Skin** (the clip uses the character’s skeleton instead of shipping a second mesh)
- Frames per Second: **30**
- Keyframe Reduction: **none**

Those labels are Mixamo’s. Prowl does not read them. They match what the importer expects: a skinned mesh, clips on that skeleton, sampled at 30 fps (`ModelImporterSettings.AnimationSampleRate` defaults to 30).

Put the three files in `Assets/Mixamo/` inside your game project. That folder is in `.gitignore` on this branch. Adobe’s license does not allow this repo to ship the files.

## Import

1. Open `Assets/Scenes/Game.scene`.
2. If the editor has not imported the FBX files yet, click one in the Project panel and wait until the Console is quiet.
3. Select the **With Skin** character. The Inspector is the model importer, with tabs **Model**, **Animation**, and **Materials**.
4. On **Model**, leave **Unit Scale** at `1`. Mixamo’s FBX is often in centimetres, so the mesh comes in about 100 times too tall. If the preview is huge, set **Unit Scale** to `0.01` and wait for the reimport.
5. On **Animation**, set **Rig Type** to **Humanoid**. Leave **Import Animations** on, **Loop Animations** on, and **Sample Rate (fps)** at `30`. Humanoid maps the bones onto a body, which is what lets a Without Skin clip play on this character (`ModelRigType.Humanoid` in `Prowl.Runtime/AssetImporting/ModelImporter.cs`).
6. If the Inspector says the auto mapper could not recognise a humanoid, click **Open Avatar Editor** and assign the missing bones (hips, spine, head). Until that maps, the model plays as a generic rig and the separate clips will not retarget.
7. Repeat step 5 on the idle FBX and the walk FBX. They have no mesh. Their clip is a sub-asset.
8. In the Project panel, expand each FBX. The character’s main asset is a prefab. Under the animation files you will see an **AnimationClip**.

The importer builds that prefab with a `SkinnedMeshRenderer` and an `Animator` on the root, and it fills `Animator.Clips` and `Animator.Avatar` (`ClayBackedImporter`). Leave **Graph** empty. This episode plays clips directly. An `AnimationGraph` is a separate asset for blend trees and state machines. You do not need one here.

## Put it on the player

The parent **Player** stays the empty object from Part 6: **CharacterController**, **Player**, **PlayerLook**, and now **PlayerAnimator**. The camera stays a child. The visible body becomes the imported character.

1. Drag the character prefab from the Project panel onto **Player** in the Hierarchy so it is a child. Rename that child **Character**.
2. Set **Character** local position to `0, 0, 0`, local rotation to `0, 0, 0`, local scale to `1, 1, 1`. If the feet sink into the floor or float, nudge local Y until the soles sit on the floor. Do not scale the **Player** parent. That would scale the camera and the controller.
3. Select **Character**. Confirm **Animator** is on it. **Avatar** is set. **Apply Root Motion** is off. `PlayerAnimator` also forces it off at Play, because `Player` already moves the capsule with `CharacterController.Move`. Root motion would move the transform a second time.
4. Select the old **Mesh** child (the cube). Uncheck the enable box at the top of the Inspector so the cube stops drawing. Leave the object in the hierarchy. If you have no FBX yet, leave **Mesh** enabled.
5. Select **Player**. **PlayerAnimator** is already on this branch. If you are building the component yourself: **Add Component → PlayerAnimator**.
6. Expand the idle FBX and drag its clip into **Idle**. Drag the walk clip into **Walk**. Leave **Walk Speed** at `0.2` and **Fade Seconds** at `0.2`.
7. If the character moonwalks (the mesh faces the wrong way while WASD is correct), set **Character** local rotation Y to `180`. The importer keeps a model facing +Z as it was authored. `Player` moves along `Transform.Forward` of the parent, not of the mesh.
8. With **Player** selected, click **Apply** on the prefab header so `Assets/Prefabs/Player.prefab` stores **PlayerAnimator** and the **Character** child. Save the **Game** scene.

`Player.PlanarSpeed` is the horizontal speed after `MoveSpeed`, in metres per second. `PlayerAnimator` plays **Idle** at or below **Walk Speed**, and **Walk** above it, with `Animator.CrossFade`. If a slot is empty it uses the other clip. If both are empty it does nothing.

## Play

Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, and click the Game view so it has focus. Click **Play Game**, wait through loading, and use the Play CHECK at the top.

Without the FBX, you still see the cube and it still moves. With the clips assigned, standing loops idle and WASD blends to walk. Space still jumps. The camera stays on the parent, so the view does not bob with the hips unless you parent the camera to a head bone yourself. This episode does not do that.
