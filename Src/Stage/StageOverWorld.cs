using Godot;
using System;

public partial class StageOverWorld : Node
{
	// Called when the node enters the scene tree for the first time.
	[Export] public StageRes StageResource{get; set;}
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
