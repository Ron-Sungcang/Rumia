using Godot;
using System;

public partial class CursorManager : Node
{
	public Control CurrentUI{get; set;}
	public static CursorManager Instance { get; private set; }
	//To access CursorManager values => CursorManager.Instance.
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void PointerCursor()
	{
		//Change in future for different cursor textures
		CurrentUI.MouseDefaultCursorShape = Control.CursorShape.PointingHand;
		
	}
	
	public void DefaultCursor()
	{
		CurrentUI.MouseDefaultCursorShape = Control.CursorShape.Arrow;
	}
}
