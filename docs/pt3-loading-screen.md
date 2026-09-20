# pt3 — Loading screen

Video: https://youtu.be/2zhuH4vjZ6M  
Start: end of pt2.  
End: Title → Loading ("Loading...") for `minDisplaySeconds` → Game.

## Shot list

- [ ] New scene **Loading Screen**; delete default light / plane / cube
- [ ] UI: Canvas → Panel → Loading Text "Loading..." font ~60
- [ ] Plain C# class **SceneLoadRequest** (static, not MonoBehaviour)
- [ ] MonoBehaviour **LoadingScreen** with timer + load destination
- [ ] Empty object **Loading Screen** + add `LoadingScreen` (set min seconds, e.g. 1.5)
- [ ] TitleScreen: add `loadingScene`, set `SceneLoadRequest.Destination = gameScene`, load loading scene
- [ ] Menu Controller: assign Loading scene (keep Game as destination)
- [ ] CHECK: Play → Play Game → see Loading → after the delay, Game scene

## Later (not this episode)

Wait until the destination is actually loaded, then an extra beat, instead of only a timer.
