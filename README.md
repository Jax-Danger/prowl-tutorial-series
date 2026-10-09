# Part 8 — Animation

Branch: `pt8-animation`. Previous: `pt7-update-prowl`. Engine: `baa86a4417`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt8-animation
```

## Files

- `Assets/Scripts/PlayerAnimator.cs` — search `TUTORIAL pt8`
- `Assets/Scripts/Player.cs` — `PlanarSpeed`
- `Assets/Prefabs/Player.prefab` — **Player Animator** is on **Player**. **Idle** and **Walk** start empty.

`Assets/Mixamo/` is gitignored. Do not commit the FBX files.

## Download

On https://www.mixamo.com :

1. Pick a character. Download.
2. Format: **FBX Binary (.fbx)**. Skin: **With Skin**. Pose: **T-Pose**. Frames per Second: `30`.
3. Download an idle. Format: **FBX Binary (.fbx)**. Skin: **Without Skin**. Frames per Second: `30`. Keyframe Reduction: **none**.
4. Download a walk with the same four settings.
5. Put the three files in the project folder `Assets/Mixamo/`.

## Import

1. **Project**: click the With Skin FBX. Wait until the Console is quiet.
2. Inspector → **Model** → **Unit Scale**: `1`.
3. If the preview is huge, **Unit Scale**: `0.01`. Wait for the reimport.
4. Inspector → **Animation** → **Rig Type**: **Humanoid**.
5. **Import Animations**: on. **Loop Animations**: on. **Sample Rate (fps)**: `30`.
6. If the inspector says the auto mapper failed: click **Open Avatar Editor**. Assign hips, spine, head.
7. **Project**: click the idle FBX. Repeat steps 4–5.
8. **Project**: click the walk FBX. Repeat steps 4–5.
9. **Project**: expand each FBX. The character asset is a prefab. Each animation file has an **Animation Clip** under it.

## Player

1. **Project**: double-click `Assets/Scenes/Game.scene`.
2. **Project**: drag the character prefab onto Hierarchy **Player**.
3. Rename that child `Character`.
4. Inspector → **Transform** → **Local Position**: `0`, `0`, `0`. **Local Rotation**: `0`, `0`, `0`. **Local Scale**: `1`, `1`, `1`.
5. If the feet are in the floor, change **Local Position Y** until the soles sit on the floor. Do not scale **Player**.
6. Hierarchy: click **Character**.
7. Inspector → **Animator** → **Apply Root Motion**: off. **Avatar** is filled. **Graph** stays empty.
8. Hierarchy: click **Mesh**. Inspector: uncheck the enable box at the top.
9. No FBX yet: leave **Mesh** checked. Skip steps 2–8.
10. Hierarchy: click **Player**.
11. Inspector: **Add Component → Player Animator** if it is missing.
12. **Project**: expand the idle FBX. Drag the clip onto Inspector → **Player Animator** → **Idle**.
13. Drag the walk clip onto **Walk**.
14. **Walk Speed**: `0.2`. **Fade Seconds**: `0.2`.
15. If the mesh faces backward while WASD is correct: Hierarchy **Character** → **Local Rotation Y**: `180`.
16. Hierarchy: click **Player**. Inspector header: **Apply**.
17. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**.
3. **Game** view: click once. Click **Play Game**.
4. No clips assigned: the cube still moves. Console has no `PlayerAnimator` exception.
5. Clips assigned: standing plays idle. WASD plays walk. Stop returns to idle. Space still jumps.
6. Toolbar: **Stop**.
