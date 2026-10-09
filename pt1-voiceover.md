# Part 1 — Title screen

Branch `pt1-title-screen`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

A game needs a front door before it needs a player. I’m building a title screen in Prowl: a canvas, a Play button, a Quit button, and one script that hides the menu.

## Steps

### 1
Open the Prowl 1.0-preview-4 editor. This whole part is that build. Later parts move the engine, so stay on preview-4 here.

### 2
In the project launcher, hit New. Name it My Prowl Game, and open it. That name is the project folder we’re going to live in.

### 3
Menu GameObject, UI, Canvas. A canvas is the root that UI lives under. Without it, text and buttons have nowhere to draw.

### 4
In the Hierarchy, rename that object to Title Screen. I name the root after the screen so the prefab is obvious later.

### 5
From the Hierarchy, drag Title Screen into the Project panel. That saves it as a prefab. The scene can be empty later and the menu still exists as an asset.

### 6
Click Title Screen in the Hierarchy so the next UI object parents under it.

### 7
Menu GameObject, UI, Text. This is the title, not a button.

### 8
In the Inspector, on Text, set the text to My Cool Game and the size to 60. Big on purpose. It’s the first thing on screen.

### 9
Menu GameObject, UI, Button. Prowl’s button comes with a child text object. That’s the label we’ll edit.

### 10
On that child Text, set the words to Play Game, size 35, and the color to black: R 0, G 0, B 0. Black on the default button reads cleanly.

### 11
Click the Play button in the Hierarchy and hit Ctrl+D. Duplicate is faster than building the second button from scratch, and the layout comes along.

### 12
Rename the copy Quit Button.

### 13
On its child Text, change the words to Quit Game. Leave the size and color. It’s the same button, different job.

### 14
Menu GameObject, UI, Event System. Buttons do nothing without this. I have stared at a perfect menu that ignored every click because I skipped the event system.

### 15
Menu GameObject, Empty Object. Rename it Menu Controller. This empty object is going to hold our script. I keep scripts off the canvas so the prefab stays a visual thing.

### 16
In the Inspector, Add Component, Title Screen. That’s `TitleScreen.cs` from this branch.

### 17
On Title Screen, Menu Root: drag the Hierarchy Title Screen into that slot. Play is going to turn that object off.

### 18
Click the Play button in the Hierarchy.

### 19
In the Inspector, Button, On Click, hit the plus. That adds a listener. Empty listeners do nothing, so we fill it next.

### 20
Drag Menu Controller into the object slot. The function list only shows scripts on the object you drop here.

### 21
Function: TitleScreen, OnPlayClicked. That’s the method that hides the menu.

### 22
Click Quit Button.

### 23
Button, On Click, plus again. Same wiring, different method.

### 24
Drag Menu Controller in, and pick TitleScreen, OnQuitClicked.

### 25
Ctrl+S. Save before Play. I’ve lost this wiring by hitting Play on a dirty scene.

## Play

### 1
Toolbar, Play.

### 2
In the Game view, click Play Game. The canvas hides. That’s Menu Root getting disabled, not a scene change. We don’t have a second scene yet.

### 3
Stop, then Play again, so the menu is back.

### 4
Click Quit Game. The Console says Quit ignored in the editor. The script sees we’re in the editor and refuses to close it. A build would actually quit.

### 5
Stop.

## Code on screen

Drop these on the cuts where `Scripts/TitleScreen.cs` is up. They are not extra README steps.

### OnPlayClicked
Play logs a line, then sets `menuRoot.Enabled` to false. That’s the whole Play button. Hiding the canvas is the stand-in until we can load a scene.

### OnQuitClicked
Quit logs, then checks `Application.IsEditor`. In the editor it logs “Quit ignored” and returns. Outside the editor it calls `Game.Quit()`. I do that so a test click doesn’t kill the editor out from under me.

## Outro

If this saved you a dead button, a like helps, and subscribe if you want the rest of the series. Next time we give Play a real scene to open.
