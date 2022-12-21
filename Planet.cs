using Godot;
using System;

public class Planet : Spatial
{
	float RotY = 10;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
		// Applies constant rotation to planets
		RotationDegrees += new Vector3(0, 1*delta*RotY, 0);
    }
}
