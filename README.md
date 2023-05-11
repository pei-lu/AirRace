# AirRace

## 1. Race Track (30 Points)

- When loading the campus model, apply a scale factor of 0.0254 and select “Generate Colliders”

- The `TrackGenerator.cs` is used to generate the race track. It is attached to a GameObject named Track and include the following steps: 

  - ParseFile(); read the positions of waypoints from the provided file
  - GenerateWaypoints(); initialize the waypoint markers
  - GeneratePath(); generate the bezier path using waypoints as its control points
  - GenerateRoadSigns(); generate the arrows that show the way
  - InitPlayer(); initiate the player at the first waypoint, heading towards the second waypoint

- The waypoints are designed with a unique style:

  ![waypoint](https://drive.google.com/file/d/1-LJesojkIUYhJBI_2v_JeWHH49H2SIO4/view?usp=share_link)

  It mainly has three parts. The top is a dragon resting on a spinning ancient ring, roaring from time to time. The bottom is a spinning sci-fi station. The middle is a glowing transparent sphere with a 3D waypoint ID in it. 

## 2. Flight Controls (25 Points)

change velocity + 4 directions

- openness of left hand controls the value of velocity, direction of the palm determines its sign
- pinch gesture controls rotation, kind of like drag the airplane’s head to different orientations



## 3. Wayfinding & Motion sickness mitigation  (20 Points)

### 3.1 Wayfinding

Visual way of helping the player to know where to go next include the following:

1. The waypoint. It has unique artistic graphic design, animations, neon light effect, and a number in the center telling the current progress. [world coordinates]

2. There are road signs along the path (floating arrows  with neon effect). [world coordinates]

3. There is an arrow following the player and pointing to the next checkpoint. [head coordinates]

   `ArrowGuide.cs` attached to the camera is used for the guiding arrow which is a child of the camera, follows the gaze and points to the next waypoint.

### 3.2 Motion Sickness Mitigation

The aircraft has three cameras that allow the player to toggle between.

1. Nose view: the camera is placed at the nose of the plane, nearly with no visuals.
2. Cockpit view: the camera is placed in the cockpit (as the picture below).
3. Tail view: the camera is placed at the tail of the airplane so that the player can see the whole of it.

![](https://i.imgur.com/mis5Jwz.png)

## 4. Gameplay (25 Points)

- Collision:

  ![](https://i.imgur.com/octuauE.png)

  - how to detect

    - A check point is reached once the aircraft's origin gets within a fixed radius of 30 feet (9.144m) around the check point.

  - after collision:

    1. the glowing sphere and number disappears, waypoint number on the screen + 1
    2. visual & sound effect

    

## 5. Extra Credit (10 points)

- Track editor: build an editor to create waypoints for new race tracks, using the hand tracking.

- Audio

