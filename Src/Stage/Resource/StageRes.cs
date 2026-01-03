using Godot;
using System;

public partial class StageRes : Resource
{
	[Export] public float StageNumber{get; set;}
	[Export] public string StageName{get; set;}
	[Export] public StageRes PrevStage{get; set;}
	[Export] public StageRes NextStage{get; set;}
	
	[Export] public PackedScene StagePrefab{get; set;}
}
