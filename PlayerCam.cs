using Godot;
using System;

public class PlayerCam : Camera
{

    KinematicBody player;
    // Physics Settings
    [Export]
    public int Speed = 5;
    [Export]
    public int Gravity = 5;
    
    // Camera Settings
    public bool PlayerControl = true;
    public float MouseSensitivity = 0.075f;

    // Vector Settings
    private Vector3 Velocity = Vector3.Zero;
    private Vector2 MouseDelta = Vector2.Zero;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetNode<KinematicBody>($"..");
    }
    
    public override void _Input(InputEvent inputEvent) {
        if(inputEvent is InputEventMouseMotion && PlayerControl == true) {
            var MouseDelta = inputEvent as InputEventMouseMotion;
            // Input.MouseMode(Input.MouseMode.Captured);

            Vector3 currentPitch = player.RotationDegrees;
            currentPitch.y -= MouseDelta.Relative.x * MouseSensitivity;
            // player.SetRotationDegrees(currentPitch);
            player.RotationDegrees = currentPitch;

            Vector3 currentTilt = RotationDegrees;//grab current rotation of camera.
            
            //change the current rotation by the relative mouse coor change on the y Axis
            currentTilt.x -= MouseDelta.Relative.y * MouseSensitivity;

            //clamp the rotation to -90 and 90 so that you cant become possessed.
            currentTilt.x = Mathf.Clamp(currentTilt.x, -90, 90);

            //sets the rotation of the camera to the new value                                                                                            
            // GetNode<Camera>("Camera").SetRotationDegrees(currentTilt);         
            
            //sets the rotation of the camera to the new value
            RotationDegrees = currentTilt;
        }
    }
}
