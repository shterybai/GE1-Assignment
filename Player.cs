using Godot;
using System;

public class Player : KinematicBody
{
    // Physics Settings
    [Export]
    public int Speed = 3;
    [Export]
    public int Gravity = 5;
    
    // Camera Settings
    public bool PlayerControl = true;
    public float MinLookAngle = -90;
    public float MaxLookAngle = 90;
    public float MouseSensitivity = 0.075f;

    // Vector Settings
    private Vector3 Velocity = Vector3.Zero;
    private Vector2 MouseDelta = Vector2.Zero;

    public override void _Ready() {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _PhysicsProcess(float delta) {
        // We create a local variable to store the input direction.
        var direction = Vector3.Zero;

        // Apply gravity
        Velocity.y -= Gravity * delta;

        if(PlayerControl == true) {
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
            }

            // Apply jetpack
            if (Input.IsActionPressed("ui_jetpack")) {
                Velocity.y += Gravity * delta * 2;
            }

            // Get possible directions
            var MovementRight = GlobalTransform.basis.x;
            var MovementForward = GlobalTransform.basis.z;

            // Set relative direction
            var RelativeDirection = (MovementForward * direction.z + MovementRight * direction.x);

            // Set velocity
            Velocity.x = RelativeDirection.x * Speed;
            Velocity.z = RelativeDirection.z * Speed;
        }

        // Apply movement
        Velocity = MoveAndSlide(Velocity, Vector3.Up);

        if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			PlayerControl = !PlayerControl;
		}
    }
}
