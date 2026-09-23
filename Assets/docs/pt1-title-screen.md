# pt1 — Title screen

Video: https://youtu.be/8oDvGU0EzT0  
Start: empty new Prowl project.  
End: Play Game hides the title canvas. Quit logs and only calls `Game.Quit()` when not in the editor.

## Shot list

- [ ] Install Prowl 1.0-preview-4 (or build from source)
- [ ] New project (example name: My Prowl Game)
- [ ] Viewport: RMB look, RMB+WASD fly, E/Q, F focus, Alt+LMB orbit
- [ ] GameObject → UI → Canvas → name **Title Screen** → make prefab
- [ ] Child Text: "My Cool Game", font ~60
- [ ] Child Button + text "Play Game" (black, font ~35)
- [ ] Duplicate → Quit Button / "Quit Game"
- [ ] Add UI Event System
- [ ] Empty **Menu Controller**
- [ ] Create MonoBehaviour script **TitleScreen**
- [ ] Attach script, drag Title Screen into `menuRoot`
- [ ] Play button OnClick → Menu Controller → `OnPlayClicked`
- [ ] Quit button OnClick → Menu Controller → `OnQuitClicked`
- [ ] CHECK: Play mode, click Play → menu hides. Click Quit → log, editor stays open.

## Code on this episode

`TitleScreen` with `menuRoot`, hide on play, guarded quit. Scene load comes in pt2.
