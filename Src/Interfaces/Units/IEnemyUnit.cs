using Godot;
using System;

public interface IEnemyUnit
{
	int PositionSlot
	{
		get; set;
	}
	
	bool UnitPlayed
	{
		get; set;
	}
}
