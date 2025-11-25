using Godot;
using System;

public partial class EnemySlot : Node
{
	[Export] public int SlotNumber{get; set;}
	private EnemyUnit eUnit;
	
	public EnemyUnit EUnit
	{
		get => eUnit;
		set => eUnit = value;
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
