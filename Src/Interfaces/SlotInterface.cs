using Godot;
using System;

public interface ISlot
{
	int SlotNumber
	{
		get;set;
	}
	
	bool SlotTaken
	{
		get; set;
	}
}

public interface IPlayerSlot: ISlot
{
	PartyUnit PUnit
	{
		get; set;
	}
}

public interface IEnemySlot: ISlot
{
	EnemyUnit EUnit
	{
		get; set;
	}
}
