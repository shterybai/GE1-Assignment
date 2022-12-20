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
    public int JumpForce = 5;

    private Vector3 _velocity = Vector3.Zero;

    public override void _PhysicsProcess(float delta)
    {
        // We create a local variable to store the input direction.
        var direction = Vector3.Zero;

        // We check for each move input and update the direction accordingly
        if (Input.IsActionPressed("ui_right"))
        {
            direction.x += Speed;
        }
        if (Input.IsActionPressed("ui_left"))
        {
            direction.x -= Speed;
        }
        if (Input.IsActionPressed("ui_backward"))
        {
            // Notice how we are working with the vector's x and z axes.
            // In 3D, the XZ plane is the ground plane.
            direction.z += Speed;
        }
        if (Input.IsActionPressed("ui_forward"))
        {
            direction.z -= Speed;
        }

        MoveAndSlide(direction);
    }
}
