using Godot;
using System;

[GlobalClass]
public partial class CombatStage : Stage, ICombatStage
{
	private CombatStageRes resource;
	
	[Export] private int remainingUnits;
	[Export] private int remainingEnemies;
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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	//TODO: Instead of Ready(), create a Initialize function
	public void Initialize(CombatStageRes res)
	{
		resource = res;
		
		RemainingEnemies = resource.TotalEnemies;
		RemainingUnits = UnitManager.Instance.GetRemainingPartyUnits();
	}
}
