using Godot;
using System;

public partial class StageManager : Node
{
	public static StageManager Instance { get; private set; }
	
	//Export for now for testing
	[Export] public CombatStageRes SelectedCombatRes{get; set;}
	[Export] public StageOverWorld[] OverWorldStages{get; set;}
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		GD.Print("Stage manager start");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
