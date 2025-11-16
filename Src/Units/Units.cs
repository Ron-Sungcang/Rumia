using Godot;
using System;

public partial class Units : Node, IUnit
{
	[Export] private string unitName;
	[Export] private int maxHP;
	[Export] private int currHP;
	
	public string UnitName
	{
		get => unitName;
		set => unitName = value;
	}
	public int MaxHP
	{
		get => maxHP;
		set => maxHP = value;
	}
	
	public int CurrentHP
	{
		get => currHP;
		set => currHP = value;
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
