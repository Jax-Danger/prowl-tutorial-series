# Getting started with Prowl

Standalone video. Branch: `getting-started-prowl`.

Engine pin: **1.0-preview.5** at `baa86a4417f63c3a6dd98c513963c6ab22693601`. There is no `v1.0-preview.5` tag. Last release tag is `v1.0-preview-4`. Later numbered parts stay on this commit.

The script for the last step is `Assets/Scripts/Spin.cs`. The other files under `Assets/` are the series project already on `main`. This video creates a new project in the launcher.

Channel: [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen). Next episode: [Part 1 — Title screen](https://youtu.be/8oDvGU0EzT0).

## 1. Prerequisites

There is no `global.json`. `Prowl.Runtime.csproj` and `Prowl.Editor.csproj` set `<TargetFramework>net10.0</TargetFramework>`. With the .NET 10 SDK that resolves `LangVersion` to **14.0**.

### Linux

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (`10.0.x`). Check: `dotnet --version`.
2. Install git.
3. IDE: Rider, Visual Studio, or VS Code with the C# Dev Kit. This pin ships `.vscode/launch.json` (`Prowl.Editor (Debug)`, `Prowl.Editor (Release)`).
4. The editor window is OpenGL through Silk.NET. `Prowl.Runtime/Window.cs` tries a forward-compatible core context at **4.6**, then **4.5**, **4.3**, then **4.1**.
5. The engine README and `.github/workflows/release.yml` install the .NET 10 SDK only. They list no apt packages. The release job checks out with `submodules: true` and publishes `Prowl.Editor`.

### Windows

1. Same .NET 10 SDK and git.
2. The engine README lists Visual Studio 17.8+, VS Code, and Rider.
3. OpenGL fallback is the same 4.6 → 4.1 list.

### macOS

1. Same .NET 10 SDK and git.
2. OpenGL stops at **4.1**, forward-compatible core (`Window.cs`).
3. A published `Prowl.app` from the release workflow is unsigned. Gatekeeper asks for a right-click **Open** the first time.

## 2. Build from source

### Clone the pin

```bash
git clone https://github.com/ProwlEngine/Prowl.git
cd Prowl
git checkout baa86a4417f63c3a6dd98c513963c6ab22693601
git submodule update --init --recursive
```

`External/jitterphysics2` is the only submodule (`.gitmodules`). URL: https://github.com/notgiven688/jitterphysics2.git. This pin records commit `aa6c705a92dc5f8e5c81363dca11c4428817e1a9`. `Prowl.Runtime.csproj` references `External/jitterphysics2/src/Jitter2/Jitter2.csproj`.

### Follow `main` instead

The series stays on the pin above. To build current `main`:

```bash
git checkout main
git pull origin main
git submodule update --init --recursive
```

### Build

The solution file is `Prowl.slnx`. There is no `.sln`.

```bash
dotnet build Prowl.Runtime/Prowl.Runtime.csproj
dotnet build Prowl.Editor/Prowl.Editor.csproj
```

Debug output:

- `Build/Runtime/Debug/net10.0/Prowl.Runtime.dll`
- `Build/Editor/Debug/net10.0/Prowl.Editor.dll`

Release is the same paths with `Release` in place of `Debug` (`-c Release`).

### Run the editor

```bash
dotnet run --project Prowl.Editor/Prowl.Editor.csproj
```

Skip the launcher and open a project folder:

```bash
dotnet run --project Prowl.Editor/Prowl.Editor.csproj -- --project "/path/to/Your Project"
```

`--help` lists `--project`, `--buildmode`, and `--output`.

### Rider

1. Open `Prowl.slnx`.
2. Set the startup project to **Prowl.Editor**.
3. Run.

VS Code: Run and Debug → **Prowl.Editor (Debug)**. That launch config builds `Prowl.Editor.csproj` and starts `Build/Editor/Debug/net10.0/Prowl.Editor.dll`.

The header version chip reads `v1.0-preview-4`. That string is `<Version>` in `Prowl.Editor.csproj`. New projects are written as **1.0-preview.5** (`Project.CurrentVersion` in `Prowl.Editor/Projects/Project.cs`).

### Errors

1. **Missing submodule.** `warning MSB9008: The referenced project ../External/jitterphysics2/src/Jitter2/Jitter2.csproj does not exist.` After that, Jitter types (`JVector`, `RigidBody`) fail to resolve. Fix: `git submodule update --init --recursive` from the Prowl repo root, then build again.
2. **Wrong SDK.** Both projects target `net10.0`. An older SDK cannot build them. `dotnet --version` must be 10.0.x.
3. **Linux path case.** A project folder must contain `Assets/` with that exact casing. `Project.Open` throws `Not a valid Prowl project: missing Assets/ folder`.
4. **OpenGL.** If the driver cannot create a context, the log is `Could not create an OpenGL X.Y context, trying an older one`. The last try is 4.1 (macOS only tries 4.1).
5. **`Update` with no `override`.** `SceneDispatcher` calls `Update` only when the script type overrides `MonoBehaviour.Update`. Use `public override void Update()`. The new-script template does.
6. **Script compile.** Toast **Compile Failed** / `See the console for the errors.` Console also logs `[Scripts] Compilation failed.`

## 3. New project

The first window is the project launcher (`Prowl.Editor/GUI/ProjectLauncher.cs`).

1. Header tabs: **Recent** and **New Project**. Click **New Project**.
2. **Choose a Template**. Click **Blank** (`Start from scratch`). The other cards are empty.
3. **CONFIGURE**. **Name:** `My Prowl Game` (the field starts as `Untitled`). **Path:** defaults to `Documents/Prowl Projects`. The folder icon browses.
4. Click **Create Project**.

That writes `My Prowl Game/Assets/`, `My Prowl Game.prowl`, and `Directory.Build.props`. The editor then loads the default scene. Console: `Created default scene.`

**Recent** lists previous projects. **Open** (folder icon, right of the search box) picks a folder. A project from another engine version shows **Migrate Project**. Confirm it. A backup lands in that project's `Backups` folder.

## 4. Editor tour

Default layout (`EditorApplication.CreateDefaultLayout`): left column is **Scene** (with a **Game** tab) over **Project** and **Console**. Right column is **Hierarchy** over **Inspector**.

A first-run guide spotlights the same five panels, then the theme button. **Skip tour** closes it. Bring a closed panel back from the menu below.

Header, center pill (`DrawPlayPill`): green play icon, pause icon, step icon. While playing, the play icon is a red stop icon. Pause turns amber while paused.

Header, right: FPS chip, version chip (`v1.0-preview-4` on this pin), project name, gear. The gear opens **Project Settings**.

### Panels

1. **Hierarchy** — already open, top right. Menu **Window → General → Hierarchy**. `Prowl.Editor/GUI/Panels/HierarchyPanel.cs`. Click a row to select it. The **+** on the scene header (tooltip **Create**) opens the **GameObject** menu. Right-click a row for **Rename**, **Duplicate**, **Delete**.
2. **Inspector** — already open, bottom right. **Window → General → Inspector**. `Prowl.Editor/GUI/Panels/InspectorPanel.cs`. Shows the selection. **Add Component** is the button at the bottom.
3. **Scene** — already open, large view on the left. **Window → General → Scene**. `Prowl.Editor/GUI/Panels/SceneViewPanel.cs`. Click the **Scene** tab if **Game** is in front.
4. **Game** — tab next to **Scene** in that same dock. **Window → General → Game**. `Prowl.Editor/GUI/Panels/GameViewPanel.cs`. Gear on the panel header: **Resolution** (`Free`, `16:9`, `16:10`, `4:3`, `5:4`, `21:9`, `1:1`, `1920x1080`, `1280x720`, `960x540`, `640x480`, `800x600`) and **Show Stats**.
5. **Project** — bottom left. **Window → General → Project**. `Prowl.Editor/GUI/Panels/ProjectPanel.cs`. This is the asset browser. Breadcrumb starts at **Assets**. Right-click empty space for **Create**.
6. **Console** — bottom, next to **Project**. **Window → General → Console**. `Prowl.Editor/GUI/Panels/ConsolePanel.cs`. **Clear**, **Collapse**, **Filter...**.
7. **Environment** — **Window → General → Environment**. `Prowl.Editor/GUI/Panels/EnvironmentPanel.cs`. Sidebar: **Skybox**, **Fog**, **Ambient**, **Lightmapping**.
8. **Preferences** — **Window → General → Preferences**, or **Edit → Preferences...**. `Prowl.Editor/GUI/Panels/PreferencesPanel.cs`. Tabs: **General**, **Theme**, **Shortcuts**.
9. **Project Settings** — **Window → General → Project Settings**, or **Edit → Project Settings...**, or the header gear. `Prowl.Editor/GUI/Panels/ProjectSettingsPanel.cs`. Pages: **General**, **Editor**, **Tags & Layers**, **Physics**, **Navigation**, **Time**, **Audio**, **Assets**, **XR**, **Build**.
10. **Build Project** — **File → Build Project...**. `Prowl.Editor/GUI/Panels/BuildSettingsPanel.cs`. **Scenes in Build**, **Platform**, **Configuration**, **Output Directory**, **Build**, **Build & Run**.
11. **Asset Database** — **Window → Debug → Asset Database**. `Prowl.Editor/GUI/Panels/AssetDatabasePanel.cs`.
12. **Sprite Editor** — **Window → Tools → Sprite Editor**. `Prowl.Editor/GUI/SpriteEditor/SpriteEditorWindow.cs`.
13. **Ragdoll Generator** — **Window → Tools → Ragdoll Generator**. `Prowl.Editor/GUI/RagdollGenerator/RagdollGeneratorWindow.cs`.

### Scene view

Toolbar, top left of the view: **Move**, **Rotate**, **Scale**, **Universal (Move, Rotate, Scale)**. Keys **W**, **E**, **R**, **T**.

Orientation cube, top right of the view. Click an axis to snap the camera. Click the cube body to swap perspective / orthographic.

Navigation (hover the Scene view):

1. **Alt** + left drag: orbit.
2. **Alt** + right drag: dolly.
3. Middle mouse drag: pan.
4. Mouse wheel: dolly. While right-click flying, the wheel changes fly speed.
5. Hold right mouse: fly. **WASD** moves. **Shift** boosts. **E** or **Space** up. **Q** down.
6. **F**: frame the selection.
7. Hold **Ctrl** while dragging a gizmo: grid snap.

### Menus

**File:** **New Scene**, **Open Scene**, **Save Scene** (Ctrl+S), **Save Scene As...** (Ctrl+Shift+S), **Build Project...**, **Exit**.

**Edit:** **Undo** (Ctrl+Z), **Redo** (Ctrl+Y), **Project Settings...**, **Save Layout**, **Preferences...**.

**Assets:** **Create** → **Folder**, **Prefab From Selection**, **Shader**, **Compute Shader**, **C# Script**, **Assembly Definition**. Then **Refresh**, **Reimport All**, **Import Package...**.

**GameObject:** **Empty Object**, **Empty Child**, **Empty Parent**, **3D Object** (**Cube**, **Sphere**, **Cylinder**, **Plane**, **Text Mesh**, **Terrain**), **Light** (**Directional Light**, **Point Light**, **Spot Light**), **Effects** (**Fog** → **Global** / **Box** / **Sphere** / **Cylinder** / **Cone**, **Particle System**), **Audio** (**Audio Source**, **Audio Listener**), **UI** (**Canvas**, **Text**, **Image**, **Button**, **Panel**, **Slider**, **Scroll View**, **Toggle**, **Rect Mask**, **Input Field**, **Dropdown**, **Event System**), **Camera**.

**Window → General:** **Console**, **Game**, **Hierarchy**, **Inspector**, **Project**, **Scene**, **Environment**, **Preferences**, **Project Settings**.

**Window → Debug:** **Asset Database**. **Window → Tools:** **Sprite Editor**, **Ragdoll Generator**.

## 5. First scene

A new project already has this scene (`EditorSceneManager.CreateDefaultScene`). Hierarchy:

- **Main Camera** — tag `Main Camera`, position `(0, 5, -15)`
- **Directional Light**
- **Floor**
- **Cube** at `(0, 0.5, 0)`
- **Cube (1)**

**File → New Scene** builds that same scene again. Console: `Created default scene.`

Add another of each from the menu when you want one:

1. **GameObject → 3D Object → Cube**.
2. **GameObject → Light → Directional Light**.
3. **GameObject → Camera**.

### Spin

1. **Project**: right-click empty space → **Create → Folder**. Name it `Scripts`. Open it.
2. Right-click empty space → **Create → C# Script**. Same item: **Assets → Create → C# Script**.
3. Dialog title **Create C# Script**. Left list: **Rotator** (`Continuously rotates the GameObject on a configurable axis`). Name: `Spin`. The hint reads `Will create Spin.cs`. Path preview: `Assets/Scripts`. Click **Create**.
4. That file matches `Assets/Scripts/Spin.cs` on this branch. Copying this file into the project's `Assets/Scripts/` is the same script.
5. Wait for the toast **Scripts Reloaded**. **Compile Failed** means read the **Console**.
6. Hierarchy: click **Cube**.
7. Inspector: **Add Component**. Search `Spin`. Click **Spin**.
8. **Axis** stays `(0, 1, 0)`. **DegreesPerSecond** stays `90`.
9. Header: green play icon.
10. Click the **Game** tab. The cube turns on Y.
11. Red stop icon.

`public override void Update()` is required. A plain `void Update()` compiles and never runs.

## 6. Next

1. [Part 1 — Title screen](https://youtu.be/8oDvGU0EzT0). Companion branch: `pt1-title-screen`.
2. The rest of the series is on [Jax's Development Den](https://www.youtube.com/@JaxsDevelopmentDen). Published follow-ups on `main`'s README: [Part 2](https://youtu.be/0omgv-6yawI), [Part 3](https://youtu.be/2zhuH4vjZ6M).
3. Engine: https://github.com/ProwlEngine/Prowl
