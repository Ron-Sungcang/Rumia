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
}
