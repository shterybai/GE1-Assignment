using Godot;
using System;

public class Spaceship : Spatial
{
	Vector3 CurrentPosition;
	// Vector3 RotationDegrees;
	[Export] public float Amplitude = 0.25f;
	float Frequency = 1.1f;
	float TimeScale = 0.1f;
	float Theta;
	bool SpaceshipControl = false;

	float RotY = 5;
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if(SpaceshipControl == false) {
			Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
			float Angle = Amplitude * Mathf.Sin(Theta);
			CurrentPosition = Translation;
			CurrentPosition.y = Angle + 3.5f;
			CurrentPosition.y = Mathf.Lerp(Translation.y, CurrentPosition.y, TimeScale);

			RotationDegrees += new Vector3(Angle*0.2f, 1*delta*RotY, Angle*0.2f);
			Translation = CurrentPosition;
		}

		if(SpaceshipControl == true) {
			RotationDegrees = new Vector3(0, 1*delta*RotY, 0);
			CurrentPosition.y = 0;
			var SpaceshipCam = (Camera)FindNode("SpaceshipCam");
			SpaceshipCam.Current = true;
		}

		if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
			GD.Print("SpaceshipControl = " + SpaceshipControl);
		}
	}
}