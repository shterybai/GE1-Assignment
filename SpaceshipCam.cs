using Godot;
using System;

public class SpaceshipCam : Camera
{
    KinematicBody player;
    
    // Camera Settings
    public bool SpaceshipControl = false;
    public float MouseSensitivity = 0.075f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetNode<KinematicBody>($"..");
    }
    
    public override void _Input(InputEvent inputEvent) {
        if(inputEvent is InputEventMouseMotion && SpaceshipControl == true) {
            // Capture mouse
            var MouseDelta = inputEvent as InputEventMouseMotion;

            Vector3 currentPitch = player.RotationDegrees;
            currentPitch.y -= MouseDelta.Relative.x * MouseSensitivity;
            player.RotationDegrees = currentPitch;

            // Sets current rotation of camera
            Vector3 currentTilt = RotationDegrees;
            
            // Changes the current rotation by how much the relative mouse coordinates on the Y-axis change
            currentTilt.x -= MouseDelta.Relative.y * MouseSensitivity;

            // Clamps the rotation to -90 and 90
            currentTilt.x = Mathf.Clamp(currentTilt.x, -90, 90);        
            
            // Sets the rotation of the camera to the new value
            RotationDegrees = currentTilt;
        }
        
        // Toggles control over player/spaceship when camera is switched
        if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
		}
    }
}
