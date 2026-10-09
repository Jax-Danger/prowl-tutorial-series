# Part 7 — Update Prowl

Branch: `pt7-update-prowl`. Previous: `pt6-player-with-cam`.

Engine pin: `1.0-preview.5` at `baa86a4417f63c3a6dd98c513963c6ab22693601`. There is no `v1.0-preview-5` tag. Later parts stay on this commit.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt7-update-prowl
```

## Files

- `Assets/Scripts/TitleScreen.cs` — search `TUTORIAL pt7`
- `Assets/Scripts/LoadingScreen.cs`
- `Assets/Scripts/SceneLoadRequest.cs`
- `Assets/Scripts/Player.cs`
- `Assets/Prefabs/TitleScreen.prefab`

## Engine

```bash
git clone https://github.com/ProwlEngine/Prowl.git ~/src/Prowl
cd ~/src/Prowl
git fetch origin
git checkout baa86a4417f63c3a6dd98c513963c6ab22693601
git submodule update --init --recursive
dotnet build Prowl.Runtime/Prowl.Runtime.csproj -c Release
dotnet build Prowl.Editor/Prowl.Editor.csproj -c Release
```

1. Open `~/src/Prowl/Prowl.slnx`.
2. Run the **Prowl.Editor** project.

## Migrate, then copy Assets

Do these clicks before you copy this branch’s `Assets` over the project. Copying first, then migrating, turns **Directional Light** a second time.

1. Project launcher: open the Part 6 project.
2. Dialog **Migrate Project**: confirm. A backup is written under the project **Backups** folder.
3. Close the editor if you still have the preview-4 editor open. Use the editor you just built.
4. Copy this branch’s `Assets/Scripts/`, `Assets/Scenes/`, and `Assets/Prefabs/` over the project.
5. Wait until the Console has no script errors.

## Scene slots and the sun

1. **Project**: double-click `Assets/Prefabs/TitleScreen.prefab`.
2. Hierarchy: click the object with **Title Screen**.
3. Inspector → **Title Screen** → **Game Scene**: drag `Assets/Scenes/Game.scene`.
4. Inspector → **Title Screen** → **Loading Scene**: drag `Assets/Scenes/LoadingScreen.scene`.
5. Skip 3–4 if both slots already show those scenes. This branch’s prefab stores `$assetRef`. A migrated prefab stores `$asset`, which **Asset Ref** does not read.
6. **Project**: double-click `Assets/Scenes/Game.scene`.
7. Hierarchy: click **Directional Light**.
8. Inspector → **Directional Light** → **Depth Bias**: `1`. **Normal Bias**: `1`. **Cast Shadows**: on.
9. If the sun comes from the wrong side, Inspector → **Transform**: add `180` to **Rotation Y**.
10. Ctrl+S.

## Play

1. **Project**: double-click `Assets/Scenes/TitleScreen.scene`.
2. Toolbar: **Play**.
3. **Game** view: click once.
4. Click **Play Game**.
5. WASD moves along the facing. Space jumps. Mouse look still works. The floor is lit from above.
6. Console `Loading scene not found`: repeat steps 3–4.
7. Toolbar: **Stop**.
