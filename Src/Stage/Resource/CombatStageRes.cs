using Godot;
using System;

public partial class CombatStageRes : StageRes
{
	[Export] public int TotalEnemies{get; set;}
	[Export] public int EnemySlots{get; set;}
	
	[Export] public EnemyRes[] ListOfEnemies{get; set;}
}
