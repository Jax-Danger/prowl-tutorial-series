# Part 3 — Loading screen

Engine: Prowl 1.0-preview-4. Branch: `pt3-loading-screen`. Previous: `pt2-change-scenes`. Video: https://youtu.be/2zhuH4vjZ6M

Part 3 waits `minDisplaySeconds`, then calls `Scene.Load`. It does not call `Scene.LoadAsync`.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt3-loading-screen
```

## Files

- `Scripts/SceneLoadRequest.cs`
- `Scripts/LoadingScreen.cs`
- `Scripts/TitleScreen.cs`

## Steps

1. Open the Part 2 project.
2. Copy the three scripts into the project `Scripts` folder.
3. Wait until the Console has no script errors.
4. Menu **File → New Scene**.
5. Menu **GameObject → UI → Canvas**.
6. Menu **GameObject → UI → Text**. Inspector → **Text** → **Text**: `Loading...`.
7. Hierarchy: click the canvas. Inspector: **Add Component → Loading Screen**.
8. Inspector → **Loading Screen** → **Min Display Seconds**: `1.5`.
9. Menu **File → Save Scene As...**. Name: `Loading Screen`. Save it under `Scenes`.
10. Open `Scripts/TitleScreen.cs` from this branch (Play stores `gameScene` on `SceneLoadRequest.Destination`, then loads `loadingScene`).
11. Hierarchy: open **Title Screen**. Click **Menu Controller**.
12. Inspector → **Title Screen** → **Loading Scene**: drag `Scenes/Loading Screen`.
13. Inspector → **Title Screen** → **Game Scene**: drag `Scenes/Game`.
14. Ctrl+S.

## Play

1. **Project**: double-click `Scenes/Title Screen`.
2. Toolbar: **Play**.
3. Click **Play Game**.
4. `Loading...` stays about 1.5 seconds, then the Game scene is current.
5. Console `Loading scene not found`: **Loading Scene** is empty.
6. Console `Loading screen has no destination set.`: **Game Scene** is empty.
7. Toolbar: **Stop**.
