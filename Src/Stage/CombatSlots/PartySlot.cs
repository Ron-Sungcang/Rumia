using Godot;
using System;

public partial class PartySlot : Node
{
	[Export] public int SlotNumber{get;set;}
	private PartyUnit pUnit;
	
	public PartyUnit PUnit
	{
		get => pUnit;
		set => pUnit = value;
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
