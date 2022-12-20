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
	bool PlayerControl = false;

	float RotY = 5;
	public override void _Ready()
	{

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(float delta)
	{
		if(PlayerControl == false) {
			Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
			float Angle = Amplitude * Mathf.Sin(Theta);
			CurrentPosition = Translation;
			CurrentPosition.y = Angle + 3.5f;
			CurrentPosition.y = Mathf.Lerp(Translation.y, CurrentPosition.y, TimeScale);

			RotationDegrees += new Vector3(Angle*0.2f, 1*delta*RotY, Angle*0.2f);
			Translation = CurrentPosition;
		}
	}
}