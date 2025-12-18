using Godot;
using System;

public partial class EnemySlot : Node, ISlot
{
	[Export] public int SlotNumber{get; set;}
	[Export] public bool SlotTaken{get; set;} = false;
	private PackedScene unitScene;
	
	public PackedScene UnitScene
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
	
	public void AddScene(PackedScene newScene)
	{
		UnitScene = newScene;
	}
	
	public void ClearScene()
	{
		
	}
}
