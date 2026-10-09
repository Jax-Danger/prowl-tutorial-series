# Part 2 — Change scenes

Engine: Prowl 1.0-preview-4. Branch: `pt2-change-scenes`. Previous: `pt1-title-screen`. Video: https://youtu.be/0omgv-6yawI

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt2-change-scenes
```

## File

- `Scripts/TitleScreen.cs` — `gameScene` is `AssetRef<Scene>`

## Steps

1. Open the Part 1 project.
2. Menu **File → Save Scene As...**. Name: `Title Screen`.
3. Menu **File → New Scene**. Menu **File → Save Scene As...**. Name: `Game`.
4. **Project** panel: create folders `Scenes`, `Prefabs`, `Scripts`.
5. Drag the title scene, the title prefab, and scripts into those folders.
6. Replace `Scripts/TitleScreen.cs` with this branch’s file.
7. Wait until the Console has no script errors.
8. Hierarchy: click **Menu Controller**.
9. Inspector → **Title Screen** → **Game Scene**: drag **Project** `Scenes/Game`.

## Play

1. **Project**: double-click `Scenes/Title Screen`.
2. Toolbar: **Play**.
3. **Game** view: click **Play Game**.
4. Hierarchy title changes to the Game scene.
5. Empty **Game Scene** slot: Console `Game scene not found`. Drag the scene again.
6. Toolbar: **Stop**.
