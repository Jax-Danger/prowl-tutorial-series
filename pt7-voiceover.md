# Part 7 — Update Prowl

Branch `pt7-update-prowl`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

Preview-4 is behind us. I’m pinning Prowl to 1.0-preview.5 at commit `baa86a4417`, migrating the project, and fixing the scene slots. There is no `v1.0-preview-5` tag. Later parts stay on this commit.

## Engine

Say this over the terminal cut. It is the command block in the README, before the numbered clicks.

Clone Prowl, check out `baa86a4417`, update the submodules, and build Runtime and the Editor in Release. We’re running the editor we just compiled, not the old preview-4 one.

### 1
Open `~/src/Prowl/Prowl.slnx`.

### 2
Run the Prowl.Editor project. That’s the editor this series uses from here on.

## Migrate, then copy Assets

Do these before you copy this branch’s Assets over the project. If you copy first and migrate second, the directional light turns a second time and the sun ends up backwards.

### 1
In the project launcher, open the Part 6 project.

### 2
The Migrate Project dialog: confirm it. A backup lands under the project’s Backups folder. I keep that. Migration rewrites asset files, and I want the old ones if a slot comes back empty.

### 3
Close the editor if the preview-4 editor is still open. Use the editor you just built.

### 4
Copy this branch’s `Assets/Scripts`, `Assets/Scenes`, and `Assets/Prefabs` over the project.

### 5
Wait until the Console has no script errors. If TitleScreen is still talking about `AssetRef<Scene>`, you’re on the old file. Scene is no longer an asset.

## Scene slots and the sun

### 1
Double-click `Assets/Prefabs/TitleScreen.prefab`.

### 2
Click the object that has the Title Screen component.

### 3
Game Scene: drag `Assets/Scenes/Game.scene`.

### 4
Loading Scene: drag `Assets/Scenes/LoadingScreen.scene`.

### 5
Skip 3 and 4 if both slots already show those scenes. This branch’s prefab stores `$assetRef`. A migrated prefab stores `$asset`, and Asset Ref does not read that. That’s why a slot can look assigned in the file and empty in the Inspector. Re-drag it.

### 6
Double-click `Assets/Scenes/Game.scene`.

### 7
Click Directional Light.

### 8
Depth Bias 1, Normal Bias 1, Cast Shadows on. The old field names were Shadow Bias and Shadow Normal Bias. Preview-5 renamed them.

### 9
If the sun comes from the wrong side, add 180 to Rotation Y. A directional light shines along local plus Z now, not back along it. Migrating twice rotates it twice. That’s the “copy after migrate” rule from a minute ago.

### 10
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play.

### 3
Click the Game view once.

### 4
Click Play Game.

### 5
WASD still moves along the facing. Space jumps. Mouse look still works. The floor is lit from above. If the light is coming from underneath, go back and add that 180.

### 6
If the Console says Loading scene not found, the slots are empty. Repeat steps 3 and 4.

### 7
Stop.

## Code on screen

Drop these on the cuts where the scripts are up. They are not extra README steps.

### SceneLoadRequest
`Destination` is now `AssetRef<SceneAsset>`. A live scene is not an asset anymore. The file on disk is a `SceneAsset`. `Scene.Load` builds the live scene from that file.

### Title screen slots
`gameScene` and `loadingScene` changed the same way. Drag the same `.scene` files. The slot type is what changed.

### Load
`Res` and `EnsureLoaded` are gone. `Load()` blocks and returns the asset, or we pass null when `IsEmpty`. `IsMissing` means the guid isn’t in the database. Then `Scene.Load` queues the swap for the end of the frame.

### CharacterController.Move
`Move` now returns collision flags. Below means we ended on the ground. Sides means a wall stopped the step. The call in Player is the same line as before. We don’t have to read the flags for walking to work.

## Outro

Like and subscribe if the migrate didn’t eat your scenes. Next time we put a skinned character on this player and play idle and walk from how fast we’re moving.
