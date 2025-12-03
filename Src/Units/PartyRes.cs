using Godot;
using System;

public partial class PartyRes : Resource
{
	[Export] public string UnitName {get; set;}
	[Export] public int MaxHP {get; set;}
	
	[Export] public PackedScene UnitPrefab{get; set;}
}
