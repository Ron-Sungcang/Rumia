using Godot;
using System;

/*
* This class is the base class for all units in the game
* There should be more classes that inherits this class
*/
public partial class Units : Node, IUnit
{
	[Export] private string unitName;
	[Export] private int maxHP;
	[Export] private int currHP;
	[Export] private bool isAlive;
	
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
	
	public bool IsAlive
	{
		get => isAlive;
		set => isAlive = value;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void TakeDamage(int damage)
	{
		currHP = currHP - damage;
		
		if(currHP <= 0)
		{
			IsAlive = false;
			//Destroy
		}
	}
}
