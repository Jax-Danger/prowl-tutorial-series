# Update Prowl

**Video:** coming. Part 7 does not have a public URL yet.

**Play CHECK:** After the engine update and the script fix, Play Game still loads, WASD moves along the facing, Space jumps, and the mouse look from Part 6 still works. The sun still lights the floor from above.

This repo is the companion for [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen) Prowl tutorials. You clone this branch, open it, and follow the steps below.

## Where this fits

Each branch stacks on the one before it. Parts 1–6 were written against the tag **v1.0-preview-4**. Part 7 moves the course to **Prowl 1.0-preview.5**, and every later part stays on that pin.

The latest GitHub release is still `v1.0-preview-4` (30 Aug 2026). There is no `v1.0-preview-5` tag. The engine's own version constant on `main` is already `1.0-preview.5` (`Project.CurrentVersion` in `Prowl.Editor/Projects/Project.cs`). Part 8 needs `Animator` and `AnimationClip`, which landed on `main` after preview-4 (commit `4b1b336e`, 28 Sep 2026). That is why the pin is a `main` commit and not the latest tag.

**Engine pin for the rest of the course:** `1.0-preview.5` at `baa86a4417f63c3a6dd98c513963c6ab22693601` on `main` (9 Oct 2026).

| Part | Branch | What you add |
| --- | --- | --- |
| 1 | tag `pt1-title-screen` | Title screen |
| 2 | tag `pt2-change-scenes` | Change scenes |
| 3 | tag `pt3-loading-screen` | Loading screen |
| 4 | tag `pt4-player-movement` (also `main`) | WASD, jump, gravity |
| 5 | tag `pt5-rotating-cube` | Rotating cube |
| 6 | `pt6-player-with-cam` | Mouse look, camera on the player |
| 7 | `pt7-update-prowl` | This episode. Engine pin above |
| 8 | `pt8-animation` | Skinned idle / walk |
| 9 | `pt9-vehicle` | WheelCollider car, enter and exit |
| 10 | `pt10-blender-map` | Blender level and a mesh collider |
| 11 | `pt11-lighting` | Sun, point, spot, sky, post, day/night |
| 12 | `pt12-terrain` | Heightmap terrain |

Prerequisite: a project that already plays Part 6 (title, loading, game, player with a camera child).

Earlier videos: [Part 1](https://youtu.be/8oDvGU0EzT0), [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).

## Clone this branch

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt7-update-prowl
```

## Update the engine

Prowl lives in its own clone, next to this repo. The game project only holds `Assets/`. These steps check out the pin and build it. `External/jitterphysics2` is a submodule. Runtime does not compile without it.

```bash
# First time:
git clone https://github.com/ProwlEngine/Prowl.git ~/src/Prowl

cd ~/src/Prowl
git fetch origin
git checkout baa86a4417f63c3a6dd98c513963c6ab22693601
git submodule update --init --recursive
dotnet build Prowl.Runtime/Prowl.Runtime.csproj -c Release
dotnet build Prowl.Editor/Prowl.Editor.csproj -c Release
```

Open `~/src/Prowl/Prowl.slnx` in Rider and run the **Prowl.Editor** project. That is the editor. Linux paths are case-sensitive.

If `~/src/Prowl` was already on `v1.0-preview-4`, the same `git checkout` and `git submodule update` move it. Rebuild both projects. Do not keep using the preview-4 editor binary with these scripts.

## Open the game and let it migrate

1. Launch the editor you just built.
2. On the project launcher, open the game project you used for Part 6. Its `.prowl` file still says preview-4 (or "old" if it has no version).
3. A dialog titled **Migrate Project** appears. The body names the saved version and `1.0-preview.5`, and says a backup goes in the project's **Backups** folder. Confirm it.
4. The editor then opens the project. Do not keep working in the preview-4 editor after this. That editor cannot open the migrated project.

What that migration rewrites, from `Prowl.Editor/Migration/Releases/Release_1_0_Preview5.cs`:

- Asset references change from `{ "AssetID": "<guid>" }` to `{ "$asset": "<guid>" }`.
- Every **Directional Light** turns 180° around its local up axis. On preview-4 a directional light shone along **-Forward**. On preview-5 it shines along **Forward**, same as a spot light. The turn keeps the sunlight coming from the same world direction.
- This project has no custom shaders and no joints, so the other two migration steps do nothing here.

Do this migration **before** you copy this branch's `Assets` over your project. This branch is already in the preview-5 shape, including the turned sun. If you copy it first and then migrate, the sun turns a second time. If that happens, select **Directional Light** and rotate it back by 180° around Y.

## Copy the scripts

This episode's companion is `Assets/` under the project you already created. This branch does not include `My Prowl Game.prowl` or `Boot/`. There is no docs folder.

Copy this branch's `Assets/Scripts/` over your project's `Assets/Scripts/`, and use this branch's scenes and prefabs if you have been following the repo files rather than your own copies.

- `Assets/Scripts/TitleScreen.cs` — scene slots are `AssetRef<SceneAsset>`. Search `TUTORIAL pt7`
- `Assets/Scripts/LoadingScreen.cs` — loads that `SceneAsset`
- `Assets/Scripts/SceneLoadRequest.cs` — holds the destination
- `Assets/Scripts/Player.cs` — `Move` still moves the capsule. It now returns `CollisionFlags`
- `Assets/Prefabs/TitleScreen.prefab` — **Game Scene** and **Loading Scene** stored as `$assetRef`

Paths are case-sensitive: `Assets/Scripts/TitleScreen.cs`.

Wait until the Console is clear of script errors. `Update` on `LoadingScreen` and `Player` stays `public override`. A plain `public void Update()` does not run.

## What broke in our scripts

These are the changes that stop Part 6 from compiling, and the ones that change how the saved project reads. Source files below are in the Prowl checkout.

**`AssetRef<Scene>` does not compile.** `AssetRef<T>` is now constrained to `Asset` (`Prowl.Runtime/AssetRef.cs`). A live `Scene` is an `EngineObject`, not an `Asset`. The file you drag is a `SceneAsset` (`Prowl.Runtime/Resources/Scene.cs`). `TitleScreen`, `LoadingScreen`, and `SceneLoadRequest` use `AssetRef<SceneAsset>`.

**`Res` and `EnsureLoaded()` are gone.** The new struct has `Load()` (blocks, returns the asset or null) and `IsEmpty`. A guid the database does not know becomes a missing asset (`Asset.IsMissing`), so the scripts check that before `Scene.Load`.

**Call `Scene.Load` with the asset.** `Scene.Load(Scene scene)` still exists. `Scene.Load(SceneAsset asset)` is the one that reads the `.scene` file and queues the swap for the end of the frame. Both screens call that overload.

**Re-assign the two scene slots if they come up empty.** `AssetRef` serializes as `{ "$assetRef": "<guid>" }`. The project migration rewrites every old `{ "AssetID" }` stub to `{ "$asset" }`, which is the hard reference used by meshes and materials, and `AssetRef` does not read that key. On **TitleScreen** in `Assets/Prefabs/TitleScreen.prefab` (and the copy in the Title scene), drag `Assets/Scenes/Game.scene` into **Game Scene** and `Assets/Scenes/LoadingScreen.scene` into **Loading Scene**. This branch's prefab is already `$assetRef` with those two guids. If you use this branch's prefab, the slots are filled. If migration rewrote your own prefab, drag them again.

**`CharacterController.Move` returns `CollisionFlags`.** `Prowl.Runtime/Components/Physics/CharacterController.cs`. The flags are `None`, `Sides`, `Above`, and `Below`. `Player` ignores the return, which still compiles. `IsGrounded` is unchanged.

**Light shadow fields were renamed.** `Light.ShadowBias` is now `DepthBias`, and `ShadowNormalBias` is now `NormalBias` (`Prowl.Runtime/Components/Lights/Light.cs`). The unit is shadow-map texels, and the default is `1`. The migration does not rename the old fields, so a light you saved in preview-4 keeps `ShadowBias` in the file and the new field falls back to `1`. Select **Directional Light** and set **Depth Bias** and **Normal Bias** if the shadows look wrong. **Cast Shadows** is still the checkbox. This branch's scenes already store `DepthBias` and `NormalBias` at `1`.

**These did not break.** `Input.GetWASD`, `Input.MouseDelta`, `Input.LockCursor`, `Input.UnlockCursor`, `Input.CursorLocked`, `KeyCode`, `Time.DeltaTime`, `Transform.LocalEulerAngles`, `Transform.Forward`, `Transform.Right`, `Application.IsEditor`, and `Game.Quit` are the same calls as Part 6.

## Play

Open `Assets/Scenes/TitleScreen.scene`, enter Play mode, and click the Game view so it has focus. Click **Play Game**, wait through loading, and use the Play CHECK at the top.

If Play Game logs "Loading scene not found", the **Loading Scene** slot is empty. Drag the scene assets as in the section above and try again.
