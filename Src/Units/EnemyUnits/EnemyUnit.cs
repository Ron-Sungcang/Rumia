using Godot;
using System;

public partial class EnemyUnit : Units, IEnemyUnit
{
	[Export] private Area2D area2D;
	[Export] private bool unitPlayed = false;
	
	public bool UnitPlayed
	{
		get => unitPlayed;
		set => unitPlayed = value;
	}
	
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
	
	public void Initialize(EnemyRes enemyRes)
	{
		UnitName = enemyRes.UnitName;
		MaxHP = enemyRes.MaxHP;
	}
	
	private void OnAreaInputEvent(Node viewport, InputEvent @event, long shapeIdx)
	{
		if (@event is InputEventMouseButton mouse && mouse.ButtonIndex == MouseButton.Left && mouse.Pressed)
		{
			UnitManager.SelectedPartyUnit = null;
			UnitManager.SelectedEnemyUnit = this;
			
			GD.Print("CLICKED ", UnitManager.SelectedEnemyUnit.UnitName);
			if(UnitManager.SelectedPartyUnit != null)
			{
				GD.Print("ERROR: Party Unit still selected");
			}
		}
	}
	
	//Party unit will also have Mouse entered and exited, possibly REFRACT unless there are different actions
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
