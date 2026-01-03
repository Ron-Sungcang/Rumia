using Godot;
using System;

/*
* This class is the base class for all units in the game
* There should be more classes that inherits this class
*/
public partial class Units : Node2D, IUnit
{	
	public string UnitName{get; set;}
	public int MaxHP{get; set;}
	
	[Export] private int currHP;
	[Export] public bool IsAlive{get;set;} = false;
	[Export] public int PositionSlot{get; set;}
	[Export] public bool InCombat{get;set;} = false;
	
	public int CurrentHP
	{
		get => currHP;
		set{
			currHP = value;
			
			if(currHP <= 0)
			{
				GD.Print("Super dead");
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//CurrentHP = MaxHP;
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
