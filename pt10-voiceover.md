# Part 10 — Courtyard

Branch `pt10-blender-map`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The floor is a cube and the car drives through where the walls should be. I’m importing a glTF courtyard and adding a mesh collider to every mesh that doesn’t have one. Concave, on purpose. A convex hull would fill the gates.

## Own mesh (skip if you use the file in the repo)

Skip this block if you’re using the file already in the repo.

### 1
In Blender, model in metres.

### 2
Select the level. Ctrl+A, Apply, All Transforms. Scale is 1. If you skip this, the collider and the picture disagree about how big the level is.

### 3
File, Export, glTF 2.0.

### 4
Format, glTF Separate. We get a `.gltf` and a `.bin`. Both are in the repo.

### 5
Apply Modifiers on. Cameras and lights off. Prowl is going to light this. We don’t want Blender’s lights in the import.

### 6
Save into the project `Assets/Maps`.

## Import

### 1
In the Project panel, click `Courtyard.gltf`. Wait until the import finishes.

### 2
Model, Unit Scale 1.

### 3
Import Cameras off. Import Lights off. Same reason as the export.

### 4
Double-click `Assets/Scenes/Game.scene`.

### 5
Drag the imported model onto Hierarchy Courtyard.

### 6
Local Position 0, 0, 0. Local Scale 1, 1, 1.

### 7
If Courtyard is missing: Empty Object, rename it Courtyard, Add Component Map Colliders, and parent the model under it. The script walks child mesh renderers. The model has to be under the object that has the script.

### 8
Click Floor and uncheck the enable box. That’s the old slab. The courtyard slab replaces it. Leave the object, in case you want the cube back.

### 9
Ctrl+S.

## Play

### 1
Double-click `Assets/Scenes/TitleScreen.scene`.

### 2
Toolbar, Play. Click the Game view once. Click Play Game.

### 3
You stand on the slab.

### 4
Walk into a wall. The capsule stops.

### 5
Press F. Drive into a wall. The car stops. Drive out a north or south gate. Those openings are why the collider stays concave.

### 6
The block near 8, 0, 8 stops the car.

### 7
Stop.

## Code on screen

Drop these on the cuts where `MapColliders.cs` is up. They are not extra README steps.

### Start
We loop every `MeshRenderer` in the children. Skip a missing renderer, and skip anything that already has a `MeshCollider`.

### The collider
`MeshRenderer.Mesh` is the imported mesh. We add a `MeshCollider` and assign that mesh to `MeshCollider.Mesh`. `Convex` stays false. A courtyard is concave. Convex would wrap it in a hull and fill the gate, and the car would never leave.

An empty object doesn’t throw. The loop just doesn’t find any renderers.

## Outro

Like and subscribe if the wall actually stopped you. Next time we light this courtyard: a sun that turns, a lamp, a spot, and a bit of bloom.
