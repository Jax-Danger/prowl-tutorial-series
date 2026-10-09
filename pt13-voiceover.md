# Part 13 — Navmesh wander

Branch `pt13-navmesh-wander`. Read this after the silent edit. Numbers match `README.md` on that branch.

## Intro

The courtyard and the terrain are scenery. I’m baking a navmesh over them and putting a cube on it that picks random points, and follows you when you walk inside six metres. No navmesh file is committed. You bake it in the editor.

## Steps

### 1
Double-click `Assets/Scenes/Game.scene`.

### 2
Parent the courtyard model under Courtyard if it isn’t already. The bake collects render meshes. The model has to be in the scene, under the object that isn’t ignored.

### 3
Click Terrain. Position 24, 0, minus 20. Same spot as last time, so the bake includes it.

### 4
Click NavMesh.

### 5
Add Component, Navigation, NavMesh Surface, if it isn’t there.

### 6
Agent Type Humanoid. Collect Objects All. Use Geometry Render Meshes. Render meshes, because the courtyard’s physics mesh is added at Play. The bake runs in edit mode and needs the visible geometry.

### 7
Click Player.

### 8
On Nav Mesh Modifier, Ignore From Build on, Apply To Children on. The player is not part of the walkable floor. If we bake them in, the agent paths across the capsule.

### 9
Click Car. Same two checkboxes. The car isn’t a sidewalk either.

### 10
Menu Edit, Project Settings. Page Navigation.

### 11
Humanoid row: radius 0.5, height 2, max slope 45. Close the window. Radius 0.5 matches the kind of body we’re walking. A bigger radius and the agent won’t fit the gates.

### 12
Click NavMesh again.

### 13
Inspector, Baking, click Bake NavMesh. Wait until Nav Mesh Data points at a `.navmesh` asset. That asset is local. The script is fine if it isn’t there. The cube just stays put.

### 14
Click Wanderer.

### 15
On Nav Mesh Agent: Speed 2.2, Stopping Distance 0.2.

### 16
Update Position on. Update Rotation on. Agent Type Humanoid. Same type as the surface, or the agent won’t stand on that mesh.

### 17
On Nav Wanderer: Wander Radius 16, Chase Distance 6, Repath Seconds 0.35.

### 18
Ctrl+S.

## Play

### 1
Double-click the title scene.

### 2
Play. Click the Game view. Click Play Game.

### 3
The cube at 0, 0.2, 10 walks, stops, and picks another point. It does not pass through walls. The mesh was baked around them.

### 4
Walk within 6 metres. The cube follows. Walk away. It wanders again.

### 5
Stop.

### 6
Click NavMesh. Baking, click Clear.

### 7
Play, Play Game. The cube stays put. The Console stays clear. `IsOnNavMesh` is false, so Update returns.

### 8
Stop.

## Code on screen

Drop these on the cuts where `NavWanderer.cs` is up. They are not extra README steps.

### Fields
Wander Radius is metres around the agent. Chase Distance is how close you have to be. Repath Seconds is how often we update the chase path, so we don’t query every frame.

### Wander
If the agent isn’t on a navmesh, we do nothing. `HasArrived` stays true until the next destination. `PathPending` means the crowd hasn’t finished the path, so we don’t replace it mid-query. `SetRandomDestination` picks a point on the mesh inside the radius. If it fails, we wait half a second and try again.

### Chase
Horizontal distance only. Inside the radius, `SamplePosition` maps the player onto the navmesh within 2 metres. `SetDestination` gets that point. If the sample fails, the agent keeps its last path. We return true so the wander block doesn’t steal the chase.

## Outro

Like and subscribe if the cube actually went around the wall. Next time the camera leaves your eyes and orbits behind you. There’s also a side episode off this part, a rolling ball, and it is not on the main line.
