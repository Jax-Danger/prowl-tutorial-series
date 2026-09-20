# pt2 — Change scenes

Video: https://youtu.be/0omgv-6yawI  
Start: end of pt1.  
End: Play Game loads the **Game** scene.

## Shot list

- [ ] Ctrl+S save scene as **Title Screen** (pt1 never saved one)
- [ ] New scene **Game**
- [ ] Folders: `Scenes`, `Prefabs`, `Scripts` — move assets in
- [ ] Add `using Prowl.Runtime.Resources`
- [ ] Add `public AssetRef<Scene> gameScene`
- [ ] Replace hide-menu play path with `EnsureLoaded` + `Scene.Load`
- [ ] Menu Controller: assign Game scene to `gameScene`
- [ ] CHECK: Play → Play Game → you are in the Game scene (log `scene.Name` if needed)

## Gotcha from the video

If the inspector field is empty you get "Game scene not found". Assign **Game**, not a leftover untitled scene.
