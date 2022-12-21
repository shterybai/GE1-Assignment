using Godot;
using System;

public class Planet : Spatial
{
    Vector3 CurrentPosition;
	// Vector3 RotationDegrees;
	[Export] public float Amplitude = 0.25f;
	float Frequency = 1.1f;
	float TimeScale = 0.1f;
	float Theta;
	float RotY = 5;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        Theta = Time.GetTicksMsec() * (Frequency * TimeScale * delta);
		float Angle = Amplitude * Mathf.Sin(Theta);
		// CurrentPosition = Translation;

		RotationDegrees += new Vector3(CurrentPosition.x, 1*delta*RotY, CurrentPosition.z);
		// Translation = CurrentPosition;
    }
}
