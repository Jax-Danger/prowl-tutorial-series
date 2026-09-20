# Lesson index

Search the scripts for `TUTORIAL ptN`.

## pt1-title-screen

Video: https://youtu.be/8oDvGU0EzT0  
Doc: `docs/pt1-title-screen.md`  
Script: `Scripts/TitleScreen.cs` (Play used to only hide `menuRoot`)

## pt2-change-scenes

Video: https://youtu.be/0omgv-6yawI  
Doc: `docs/pt2-change-scenes.md`  
`OnPlayClicked` loads `gameScene` via `AssetRef<Scene>`.

## pt3-loading-screen

Video: https://youtu.be/2zhuH4vjZ6M  
Doc: `docs/pt3-loading-screen.md`  
Adds `SceneLoadRequest` + `LoadingScreen`. Play sets destination to Game, then loads Loading.
