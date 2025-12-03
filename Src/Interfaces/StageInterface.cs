using Godot;
using System;

public interface IStage
{
	int StageNumber
	{
		get; set;
	}
	
	string StageName
	{
		get; set;
	}
	
	bool StageCompleted
	{
		get; set;
	}
	
	// If prev stage != null and prev stage isCompleted => Becomes visible
	Stage PrevStage
	{
		get; set;
	}
	
	Stage NextStage
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
	
	int NumEnemiesTotal
	{
		get; set;
	}
	
	int NumEnemySlots
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
	
	EnemyRes[] ListOfEnemies
	{
		get; set;
	}
}
