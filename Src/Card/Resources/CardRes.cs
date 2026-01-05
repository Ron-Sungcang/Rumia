using Godot;
using System;

[GlobalClass]
public partial class CardRes : Resource
{
	public enum Type 
	{
		Attack,
		Skill,
		Power
	}
	
	public enum Target 
	{
		Self,
		Enemy,
		AoE,
		Ally
	}
	
	[Export] public string Id {get; set;}
	[Export] public string Name {get; set;}
	[Export] public string Description {get; set;}
	[Export] public int Damage {get; set;}
	[Export] public int Stamina {get; set;}
	[Export] public Target target {get; set;}
	
	public bool isSingleTarget()
	{
		return target == Target.Enemy;
	}
}
