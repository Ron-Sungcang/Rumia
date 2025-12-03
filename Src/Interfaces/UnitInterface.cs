using Godot;
using System;

public interface IUnit
{
	int CurrentHP
	{
		get; set;
	}
	
	bool IsAlive
	{
		get; set;
	}
	
	int PositionSlot
	{
		get; set;
	}
	
	bool InCombat
	{
		get; set;
	}
	
	void TakeDamage(int damage);		//When unit takes damage
}

public interface IPartyUnit
{
	//This should have anything that is specific to party units that enemy units does not have
	//List for cards in action bar
	// If actions completed
}

public interface IEnemyUnit
{	
	bool UnitPlayed
	{
		get; set;
	}
}
