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
	void ClearScene();
}

public interface IPartySlot: ISlot
{
	PartyUnit UnitScene
	{
		get; set;
	}
	
	void AddPartyScene(PartyUnit newScene);
}

public interface IEnemySlot: ISlot
{
	EnemyUnit UnitScene
	{
		get; set;
	}
	
	void AddEnemyScene(EnemyUnit newScene);
}
