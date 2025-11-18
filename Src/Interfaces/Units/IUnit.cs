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
	
	Sprite2D UnitSprite
	{
		get; set;
	}
	
	void TakeDamage(int damage);		//When unit takes damage
}
