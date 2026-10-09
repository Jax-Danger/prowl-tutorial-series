# Part 11 — Lighting

Branch `pt11-lighting`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The courtyard is lit by one sun that doesn’t move. I’m spinning that directional light, adding a lamp and a gate spot, setting the sky, and putting bloom and a tonemapper on the player camera. A directional light shines along local plus Z. Keep that in your head when the sun looks wrong.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Click Directional Light.

### 3
Cast Shadows on. Shadow Quality Soft.

### 4
Depth Bias 1. Normal Bias 1. Those two stop the courtyard from shadowing itself into a noisy mess.

### 5
Add Component, Day Night Cycle, if it isn’t there.

### 6
Day Length Seconds 90. Pitch 50. Ninety seconds is one full turn, slow enough to see on camera. Pitch holds the sun below the horizon line of that spin.

### 7
Menu GameObject, Light, Point Light. Rename it Lamp.

### 8
Position 8, 2.5, 8. That’s the block in the courtyard.

### 9
On Point Light: Range 8, Intensity 2, Cast Shadows on.

### 10
Color R 1, G 0.72, B 0.4. Warm, so it reads as a lamp and not a second sun.

### 11
Menu GameObject, Light, Spot Light. Rename it Gate Spot.

### 12
Position 0, 4, 16. Rotation 20, 180, 0. 180 on Y aims it back down the courtyard. Plus Z is forward, so without that yaw the spot points the wrong way.

### 13
Range 18. Spot Angle 40. Inner Spot Angle 25. Intensity 3. Color R 0.75, G 0.85, B 1. Cast Shadows on. A little blue, so it doesn’t match the lamp.

### 14
Menu Window, General, Environment.

### 15
Skybox tab, Mode Procedural.

### 16
Ambient tab, Mode Hemisphere, Strength 1. Hemisphere keeps the shadowed side from going pure black.

### 17
Fog tab: leave it off. Fog hides the thing we just built.

### 18
Expand Player and click Camera.

### 19
Add Component, Camera Grade, if it isn’t there. That script fills the camera’s effect list. You don’t assign bloom by hand.

### 20
Click Player. Inspector header, Apply All. The grade is on the camera child, so it has to go back to the prefab.

### 21
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Play. Click the Game view. Click Play Game.

### 3
The sun turns. Shadows move.

### 4
For a shorter night, Stop, set Day Length Seconds to 20 on the Directional Light, and Play again. I do this when 90 seconds is too long for the cut.

### 5
The lamp lights the block. The spot lights the gate.

### 6
Bright areas bloom. That’s the camera grade, not a light setting.

### 7
Stop.

## Code on screen

Drop these on the cuts where the scripts are up. They are not extra README steps.

### DayNightCycle
`DayLengthSeconds` is one full turn. `Pitch` is the tilt. Start grabs the Directional Light on this object, or the first one in the scene.

### The spin
Yaw is the fraction of the day times 360. We write local Euler as pitch, yaw, 0. The light shines along Forward, local plus Z. Intensity uses how much that forward points down. Pointing up, the sun dims and shifts blue. Pointing down, it’s warm and bright.

### CameraGrade
On Enable, HDR goes on. Bloom needs HDR values. The tonemapper brings the image back to display range. We only add a `BloomEffect` or a `TonemapperEffect` if the list doesn’t already have one. Order matters. Bloom runs on the HDR image. The tonemapper says it transforms to LDR, so it stays last. Defaults are bloom intensity 1.5, threshold 0.8, and an AgX tonemapper.

## Outro

Like and subscribe if the sun actually moved. Next time we add terrain beside the courtyard, and we only stamp hills if you haven’t painted any.
