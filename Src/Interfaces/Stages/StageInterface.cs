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
	
	int CurrNumberEnemies
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
}
