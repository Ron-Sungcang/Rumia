using Godot;
using System;

/*
* This class is the base class for all units in the game
* There should be more classes that inherits this class
*/
public partial class Units : Node, IUnit
{
	[Export] public string UnitName{get;set;} = "";
	[Export] public int MaxHP{get;set;} = 1;
	[Export] private int currHP;
	[Export] public bool IsAlive{get;set;} = false;
	[Export] public Sprite2D UnitSprite{get;set;}
	
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
