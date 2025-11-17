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
	
	void TakeDamage(int damage);		//When unit takes damage
	Sprite2D GetSprite();				//Gets the units sprite
}
