using Godot;
using System;

public partial class PartySlot : Node, IPartySlot
{
	[Export] public int SlotNumber{get;set;}
	[Export] public bool SlotTaken{get; set;} = false;
	private PartyUnit unitScene;
	//PackedScene as PartyUnit
	
	public PartyUnit UnitScene
	{
		get => unitScene;
		set => unitScene = value;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void AddPartyScene(PartyUnit newScene)
	{
		if(SlotTaken)
		{
			GD.Print("PartySlot, AddPartyScene, Party Slot: " + SlotNumber + " is not empty");
			return;
		}
		else if(GetChildCount() > 0)
		{
			GD.Print("PartySlot, AddPartyyScene, Party Slot: " + SlotNumber + " contains a child");
			return;
		}
		
		UnitScene = newScene;
		AddChild(UnitScene);
		
		UnitScene.InCombat = true;
		SlotTaken = true;
		
		GD.Print("Successfully added Party unit: " + UnitScene + " to slot: " + SlotNumber);
	}
	
	public void ClearScene()
	{
		if(!SlotTaken)
		{
			GD.Print("PartySlot, ClearScene, Party Slot: " + SlotNumber + " is empty");
			return;
		}
		else if(GetChildCount() <= 0)
		{
			GD.Print("PartySlot, ClearScene, Party Slot: " + SlotNumber + " doesnt contain a child");
			return;
		}
		
		UnitScene.QueueFree();
		UnitScene.InCombat = false;
		UnitScene = null;
		SlotTaken = false;
	}
}
