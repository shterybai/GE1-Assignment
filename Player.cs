using Godot;
using System;

public class Player : KinematicBody
{
    // Physics Settings
    [Export]
    public int Speed = 5;
    [Export]
    public int FallAcceleration = 5;
    [Export]
    public int JumpForce = 10;
    
    // Camera Settings
    public float MinLookAngle = -90;
    public float MaxLookAngle = 90;
    public float MouseSensitivity = 5;

    // Vector Settings
    private Vector3 _velocity = Vector3.Zero;
    private Vector2 MouseDelta = Vector2.Zero;

    public override void _PhysicsProcess(float delta)
    {
        // We create a local variable to store the input direction.
        var direction = Vector3.Zero;

        // We check for each move input and update the direction accordingly
        if (Input.IsActionPressed("ui_right")) {
            direction.x += Speed;
        }
        if (Input.IsActionPressed("ui_left")) {
            direction.x -= Speed;
        }
        if (Input.IsActionPressed("ui_backward")) {
            direction.z += Speed;
        }
        if (Input.IsActionPressed("ui_forward")) {
            direction.z -= Speed;
        }
        if (direction != Vector3.Zero) {
            direction = direction.Normalized();
            // GetNode<Spatial>("Pivot").LookAt(Translation + direction, Vector3.Up);
        }

        MoveAndSlide(direction);
    }
}
