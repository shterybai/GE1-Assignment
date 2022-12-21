using Godot;
using System;

public class Main : Spatial
{
    bool SpaceshipControl = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Captures mouse when game runs
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Switches to SpaceshipCam when toggled
        if(SpaceshipControl == true) {
            var SpaceshipCam = (Camera)GetNode("Spaceship").FindNode("SpaceshipCam");
            SpaceshipCam.Current = true;
        }

        // Switches to PlayerCam when toggled
        if(SpaceshipControl == false) {
            var PlayerCam = (Camera)GetNode("Player").FindNode("PlayerCam");
            PlayerCam.Current = true;
        }

        // Toggles control over player/spaceship when camera is switched
        if(Input.IsActionJustPressed("toggle_spaceship_view")) {
			SpaceshipControl = !SpaceshipControl;
		}
    }
}
