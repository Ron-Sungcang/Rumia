using Godot;
using System;

public partial class EnemySlot : Node, IEnemySlot
{
	[Export] public int SlotNumber{get; set;}
	[Export] public bool SlotTaken{get; set;} = false;
	private EnemyUnit unitScene;
	
	public EnemyUnit UnitScene
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
	
	public void AddEnemyScene(EnemyUnit newScene)
	{
		if(SlotTaken)
		{
			GD.Print("EnemySlot, AddEnemyScene, Enemy Slot: " + SlotNumber + " is not empty");
			return;
		}
		else if(GetChildCount() > 0)
		{
			GD.Print("EnemySlot, AddEnemyScene, Enemy Slot: " + SlotNumber + " contains a child");
			return;
		}
		
		UnitScene = newScene;
		AddChild(UnitScene);
		SlotTaken = true;
	}
	
	public void ClearScene()
	{
		if(!SlotTaken)
		{
			GD.Print("EnemySlot, ClearScene, Enemy Slot: " + SlotNumber + "is empty");
			return;
		}
		else if(GetChildCount() <= 0)
		{
			GD.Print("EnemySlot, ClearScene, Enemy Slot: " + SlotNumber + " doesnt contain a child");
			return;
		}
		
		UnitScene.QueueFree();
		UnitScene = null;
		SlotTaken = false;
	}
}
