using Godot;
using System;

public interface IUnit
{
	string UnitName{
		get; set;
	}
	
	int MaxHP
	{
		get; set;
	}
	
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
	
	Sprite2D UnitSprite
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
