using Godot;
using System;

public partial class PartyUnit : Units, IPartyUnit
{
	[Export] private Area2D area2D;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(area2D == null)
		{
			GD.Print("PartyUnit, unset collision box");
			return;
		}
		
		area2D.MouseEntered += OnMouseEntered;
		area2D.MouseExited += OnMouseExited;
		
		area2D.InputEvent += OnAreaInputEvent;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void OnAreaInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
		{
			GD.Print("CLICKED ", Name);
		}
	}
	
	public void OnMouseEntered()
	{
		GD.Print("MouseEntered");
		Input.SetDefaultCursorShape(Input.CursorShape.PointingHand);
	}
	
	public void OnMouseExited()
	{
		GD.Print("MouseExited");
		Input.SetDefaultCursorShape(Input.CursorShape.Arrow);
	}
}
