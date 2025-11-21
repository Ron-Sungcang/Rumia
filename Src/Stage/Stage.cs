using Godot;
using System;

public partial class Stage : Node, IStage
{
	[Export] public int StageNumber{get; set;} = 0;
	[Export] public string StageName{get; set;} = "";
	[Export] private int currNumEnemies;
	[Export] public int NumEnemiesTotal{get; set;} = 0;
	[Export] public int NumEnemySlots{get; set;} = 0;
	[Export] public bool StageCompleted{get; set;} = false;
	[Export] public Stage PrevStage{get; set;} = null;
	[Export] public Stage NextStage{get; set;} = null;
	
	// Declare like this if there are more features than just get and set
	public int CurrNumberEnemies
	{
		get => currNumEnemies;
		set{
			currNumEnemies = value;
			if(currNumEnemies <= 0){
				StageCompleted = true;
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
