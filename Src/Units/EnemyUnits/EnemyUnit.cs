using Godot;
using System;

public partial class EnemyUnit : Units, IEnemyUnit
{
	[Export] private int positionSlot;
	[Export] private bool unitPlayed = false;
	
	public int PositionSlot
	{
		get => positionSlot;
		set => positionSlot = value;
	}
	
	public bool UnitPlayed
	{
		get => unitPlayed;
		set => unitPlayed = value;
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
