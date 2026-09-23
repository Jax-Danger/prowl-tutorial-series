# pt3 — Loading screen

Video: https://youtu.be/2zhuH4vjZ6M  
Start: end of pt2 (Play loads Game directly).  
End: Title → Loading (~1.5s) → Game.

**Play CHECK:** Play Game shows the Loading Screen for about 1.5 seconds, then the Game scene.

## Shot list

- [ ] New scene **Loading Screen** (simple UI text "Loading..." is enough)
- [ ] Add `SceneLoadRequest.cs` (static Destination)
- [ ] Add `LoadingScreen.cs` with `minDisplaySeconds = 1.5`
- [ ] Attach LoadingScreen to an object in the Loading Screen scene
- [ ] Update TitleScreen: set `SceneLoadRequest.Destination = gameScene`, then `Scene.Load(loading)`
- [ ] Menu Controller: assign `loadingScene` and keep `gameScene`
- [ ] CHECK: Title → Loading (~1.5s) → Game

## Code on this episode

`SceneLoadRequest` + `LoadingScreen`. Play sets destination to Game, then loads Loading.
