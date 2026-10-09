# Part 1 — Title screen

Engine: Prowl 1.0-preview-4. Branch: `pt1-title-screen`. Video: https://youtu.be/8oDvGU0EzT0

This branch is the script only. Create the project in the editor.

## Clone

```bash
git clone https://github.com/Jax-Danger/prowl-tutorial-series.git
cd prowl-tutorial-series
git checkout pt1-title-screen
```

## File

- `Scripts/TitleScreen.cs`

## Steps

1. Open the Prowl 1.0-preview-4 editor.
2. Project launcher: **New**. Name: `My Prowl Game`. Open it.
3. Menu **GameObject → UI → Canvas**.
4. Hierarchy: rename the new object to `Title Screen`.
5. **Project** panel: drag Hierarchy **Title Screen** into the assets area.
6. Hierarchy: click **Title Screen**.
7. Menu **GameObject → UI → Text**.
8. Inspector → **Text** → **Text**: `My Cool Game`. **Size**: `60`.
9. Menu **GameObject → UI → Button**.
10. Inspector → child **Text** → **Text**: `Play Game`. **Size**: `35`. **Color**: R `0`, G `0`, B `0`.
11. Hierarchy: click that button. Ctrl+D.
12. Rename the copy `Quit Button`.
13. Inspector → child **Text** → **Text**: `Quit Game`.
14. Menu **GameObject → UI → Event System**.
15. Menu **GameObject → Empty Object**. Rename `Menu Controller`.
16. Inspector: **Add Component → Title Screen**.
17. Inspector → **Title Screen** → **Menu Root**: drag Hierarchy **Title Screen**.
18. Hierarchy: click the Play button.
19. Inspector → **Button** → **On Click ()**: click **+**.
20. Object slot: drag Hierarchy **Menu Controller**.
21. Function: **TitleScreen → OnPlayClicked**.
22. Hierarchy: click **Quit Button**.
23. Inspector → **Button** → **On Click ()**: click **+**.
24. Object slot: drag **Menu Controller**. Function: **TitleScreen → OnQuitClicked**.
25. Ctrl+S.

## Play

1. Toolbar: **Play**.
2. **Game** view: click **Play Game**. The canvas hides.
3. Toolbar: **Stop**. **Play** again.
4. Click **Quit Game**. Console: `Quit ignored in the editor`.
5. Toolbar: **Stop**.
