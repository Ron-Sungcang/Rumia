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
	
	PackedScene UnitScene
	{
		get; set;
	}
	
	void AddScene(PackedScene newScene);
	void ClearScene();
}
