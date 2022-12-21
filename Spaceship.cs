using Godot;
using System;

public class Spaceship : KinematicBody
{
	// Pedestal Animation
	Vector3 CurrentPosition;
	[Export] public float Amplitude = 0.25f;
	float Frequency = 1.1f;
	float TimeScale = 0.1f;
	float Theta;
	bool SpaceshipControl = false;
	float RotY = 5;

	// Physics Settings
    [Export]
    public int Speed = 10;
    [Export]
    public int Gravity = 1;

    // Vector Settings
    private Vector3 Velocity = Vector3.Zero;

	public override void _Ready()
	{
		// Resets position over pedestal
		if(SpaceshipControl == true) {
			RotationDegrees = new Vector3(0, 0, 0);
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		if(SpaceshipControl == false) {
			// Creates constant spinning in +y direction, as well as oscillation in x and z directions
			Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
			float Angle = Amplitude * Mathf.Sin(Theta);
			CurrentPosition.y = Angle + 3.5f;
			CurrentPosition.y = Mathf.Lerp(Translation.y, CurrentPosition.y, TimeScale);

			RotationDegrees += new Vector3(Angle*0.2f, 1*delta*RotY, Angle*0.2f);
			Translation = CurrentPosition;

			// Resets velocity
			Velocity.y = 0;
		}

		if(SpaceshipControl == true) {

			// Store direction, comes to zero at rest
			var direction = Vector3.Zero;

			// Directional inputs
			if (Input.IsActionPressed("ui_left")) {
				direction.x += Speed;
			}
			if (Input.IsActionPressed("ui_right")) {
				direction.x -= Speed;
			}
			if (Input.IsActionPressed("ui_forward")) {
				direction.z += Speed;
			}
			if (Input.IsActionPressed("ui_thrust")) {
				Velocity.y -= Speed*delta*0.5f;
			}
			if (Input.IsActionPressed("ui_backward")) {
				direction.z -= Speed;
			}
			if (direction != Vector3.Zero) {
				direction = direction.Normalized();
			}

			// Apply VTOL
			if (Input.IsActionPressed("ui_jetpack")) {
				Velocity.y += Gravity * delta * 6;
			}

			// Apply gravity
			// if(CurrentPosition.y >= 3) {
			// 	Velocity.y -= Gravity * delta;
			// }

			// Get possible directions
			var MovementRight = GlobalTransform.basis.x;
			var MovementForward = GlobalTransform.basis.z;

			// Set relative direction
			var RelativeDirection = (MovementForward * direction.z + MovementRight * direction.x);

			// Set velocity
			Velocity.x = RelativeDirection.x * Speed;
			Velocity.z = RelativeDirection.z * Speed;

			// Apply movement
			Velocity = MoveAndSlide(Velocity, Vector3.Up);
		}

		// Toggles control over player/spaceship when camera is switched
		if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
			GD.Print("SpaceshipControl = " + SpaceshipControl);
		}
	}
}