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
	
	public void Initialize(PartyRes partyRes)
	{
		UnitName = partyRes.UnitName;
		MaxHP = partyRes.MaxHP;
	}
	
	private void OnAreaInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
		{
			UnitManager.SelectedEnemyUnit = null;
			UnitManager.SelectedPartyUnit = this;
			
			GD.Print("CLICKED ", UnitManager.SelectedPartyUnit.UnitName);
			if(UnitManager.SelectedEnemyUnit != null)
			{
				GD.Print("ERROR: Enemy Unit still selected");
			}
		}
	}
	
	//Enemy unit will also have Mouse entered and exited, possibly REFRACT unless there are different actions
	public void OnMouseEntered()
	{
		GD.Print("MouseEntered");
		CursorManager.Instance.PointerCursor();
	}
	
	public void OnMouseExited()
	{
		GD.Print("MouseExited");
		CursorManager.Instance.DefaultCursor();
	}
}
