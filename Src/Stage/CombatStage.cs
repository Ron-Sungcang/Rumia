using Godot;
using System;

public partial class CombatStage : Stage, ICombatStage
{
	[Export] private int remainingUnits;
	[Export] private int remainingEnemies;
	[Export] public int NumEnemiesTotal{get; set;} = 0;
	[Export] public int NumEnemySlots{get; set;} = 0;
	[Export] public bool CombatStageOver{get; set;} = false;
	[Export] public bool CombatVictory{get; set;} = false;
	
	// Declare like this if there are more features than just get and set
	public int RemainingUnits
	{
		get => remainingUnits;
		set
		{
			//Perhaps go through the party list in the GameManager and check for living party units
			remainingUnits = value;
			if(remainingUnits <= 0)
			{
				//Play the ending animation in a combat
				CombatStageOver = true; 
				CombatVictory = false;
			}
		}
	}
	
	public int RemainingEnemies
	{
		get => remainingEnemies;
		set
		{
			remainingEnemies = value;
			if(remainingEnemies <= 0)
			{
				//Play the ending animation in a combat
				CombatStageOver = true;
				CombatVictory = true;
			}
		}
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RemainingUnits = UnitManager.Instance.GetRemainingPartyUnits();
		RemainingEnemies = NumEnemiesTotal;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
