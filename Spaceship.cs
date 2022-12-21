using Godot;
using System;

public class Spaceship : KinematicBody
{
	Vector3 CurrentPosition;
	// Vector3 RotationDegrees;
	[Export] public float Amplitude = 0.25f;
	float Frequency = 1.1f;
	float TimeScale = 0.1f;
	float Theta;
	bool SpaceshipControl = false;
	float RotY = 5;

	// Physics Settings
    [Export]
    public int Speed = 6;
    [Export]
    public int Gravity = 1;
    
    // Camera Settings
    public float MinLookAngle = -90;
    public float MaxLookAngle = 90;
    public float MouseSensitivity = 0.075f;

    // Vector Settings
    private Vector3 Velocity = Vector3.Zero;
    private Vector2 MouseDelta = Vector2.Zero;

	public override void _Ready()
	{
		if(SpaceshipControl == true) {
			RotationDegrees = new Vector3(0, 0, 0);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if(SpaceshipControl == false) {
			Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
			float Angle = Amplitude * Mathf.Sin(Theta);
			// CurrentPosition = Translation;
			CurrentPosition.y = Angle + 3.5f;
			CurrentPosition.y = Mathf.Lerp(Translation.y, CurrentPosition.y, TimeScale);

			RotationDegrees += new Vector3(Angle*0.2f, 1*delta*RotY, Angle*0.2f);
			Translation = CurrentPosition;

			Velocity.y = 0;
		}

		if(SpaceshipControl == true) {
			// RotationDegrees = new Vector3(0, 1*delta*RotY, 0);
			// CurrentPosition.y = 0;

			// We create a local variable to store the input direction.
			var direction = Vector3.Zero;

			// We check for each move input and update the direction accordingly
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
				direction.z += Speed;
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
			if(CurrentPosition.y >= 3) {
				Velocity.y -= Gravity * delta;
			}

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

		if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
			GD.Print("SpaceshipControl = " + SpaceshipControl);
		}
	}

	public override void _Input(InputEvent inputEvent) {
        if(inputEvent is InputEventMouseMotion && SpaceshipControl == true) {
            var MouseDelta = inputEvent as InputEventMouseMotion;
            // Input.MouseMode(Input.MouseMode.Captured);

            Vector3 currentPitch = RotationDegrees;
            currentPitch.y -= MouseDelta.Relative.x * MouseSensitivity;
            // player.SetRotationDegrees(currentPitch);
            RotationDegrees = currentPitch;

            Vector3 currentTilt = RotationDegrees;//grab current rotation of camera.
            
            //change the current rotation by the relative mouse coor change on the y Axis
            currentTilt.x += MouseDelta.Relative.y * MouseSensitivity;

            //clamp the rotation to -90 and 90 so that you cant become possessed.
            currentTilt.x = Mathf.Clamp(currentTilt.x, -90, 90);

            //sets the rotation of the camera to the new value                                                                                            
            // GetNode<Camera>("Camera").SetRotationDegrees(currentTilt);         
            
            //sets the rotation of the camera to the new value
            RotationDegrees = currentTilt;
        }
    }
}