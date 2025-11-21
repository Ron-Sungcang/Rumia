using Godot;
using System;

public partial class Stage : Node, IStage
{
	[Export] private int stageNumber;
	[Export] private string stageName;
	[Export] private int currNumEnemies;
	[Export] private int numEnemiesTotal;
	[Export] private int numEnemySlots;
	
	public int StageNumber
	{
		get => stageNumber;
		set => stageNumber = value;
	}
	
	public string StageName
	{
		get => stageName;
		set => stageName = value;
	}
	
	public int CurrNumberEnemies
	{
		get => currNumEnemies;
		set => currNumEnemies = value;
	}
	
	public int NumEnemiesTotal
	{
		get => numEnemiesTotal;
		set => numEnemiesTotal = value;
	}
	
	public int NumEnemySlots
	{
		get => numEnemySlots;
		set => numEnemySlots = value;
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
