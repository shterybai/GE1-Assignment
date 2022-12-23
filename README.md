# GE1-Assignment
Name: Andrew Kennan

Student Number: C19429514

## Description of the Assignment
This website is a depiction of 1970's sci-fi space exploration, take inspiration from various forms of media from the time period. Inspirations include the Thunderbirds, specifically Thunderbird 2, and also Star Trek's space exploration. This assignment gives the user the option to switch between controlling a humanoid player, and a spaceship.

## Player Controls
- W - Move forward
- S - Move Backward
- A - Move Left
- D - Move Right
- Spacebar(Hold) - Jump/Engage jetpack
- F - Enter spaceship

## Spaceship Controls
- W - Move forward
- S - Move Backward
- A - Move Left
- D - Move Right
- Spacebar(Hold) - Vertical thrust/ascend
- Shift(Hold) - Descend
- F - Exit spaceship

## How it Works
This was created using the Godot game engine, as opposed to Unity. This is because I found Godot more intuitive, and more user friendly than Unity. Also, it is a much more lightweight game engine, and doesn't require the intense loading times of Unity.

When the game is loaded, the user starts off as a moveable player that can use their jetpack to fly around. The first thing the user will see is their spaceship, which is floating and spinning in place over a pedestal. The user can fly around the spaceship and inspect it. If the user presses the "F" key, they will be transported into the spaceship. This spaceship moves much faster, and can easily visit the nearby planets in the environment.

This program uses background music that I created myself.

## Envronment Development
The environement consists of a very large rectangle mesh that makes up the ground. This mesh uses a bitmap texuture to add variety, however the overall color is green. The environment also contains a dark-coloured pedestal that holds the spaceship. There is also a skybox that uses a large-resolution image of the night sky containing stars. Lastly, I added many planets to the environemnt, all with their own colours and sizes and rotations, that the player can explore. Each planet rotates using a script that simply increments the positive-y direction.

## Entity Movement
To create the movement of the player and the spaceship, I created a script that mapped the button inputs as described above to increment/decrement the corresponding direction by a set value, "Speed". Jumping and gravity were added by incrementing the entity velocity in either the postive-Y or negative-Y direction. Some values and buttons were changed depending on if the player or spaceship was in control; for instance, gravity was disabled for the spaceship. Camera movement was created in a different script, and referenced the camera directly as opposed to the entire entity.

## VR
I tried to implement VR into the project, however without a VR headset of my own, I was unable to test if this worked. This may be worth experimenting with for those who own VR headsets.

## Video of Submission
https://youtu.be/eR4F8bW0_50

Unfortunately, the video is incredibly choppy, entirely due to OBS. This is not at all visible on my machine, which can handle the program very well. This has been stated in an email I sent about these technical difficulties.