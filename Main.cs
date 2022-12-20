using Godot;
using System;

public class Main : Spatial
{
    bool SpaceshipControl = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if(SpaceshipControl == true) {
            var SpaceshipCam = (Camera)GetNode("Spaceship").FindNode("SpaceshipCam");
            SpaceshipCam.Current = true;
        }

        if(SpaceshipControl == false) {
            var PlayerCam = (Camera)GetNode("Player").FindNode("PlayerCam");
            PlayerCam.Current = true;
        }

        if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
			GD.Print("SpaceshipControl = " + SpaceshipControl);
		}
    }
}
