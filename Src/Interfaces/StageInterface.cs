using Godot;
using System;

public interface IStage
{	
	bool StageCompleted
	{
		get; set;
	}
}

public interface ICombatStage: IStage
{
	int RemainingUnits
	{
		get; set;
	}
	
	int RemainingEnemies
	{
		get; set;
	}
	
	bool CombatStageOver
	{
		get; set;
	}
	
	bool CombatVictory
	{
		get; set;
	}
}
