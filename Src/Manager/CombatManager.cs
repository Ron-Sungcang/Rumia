using Godot;
using System;

public partial class CombatManager : Node
{
	[Export] private Button endTurnButton;
	private CombatState state;
	private CombatState nextState;
	
	private float transitionTimer = 0f;
	private float transitionDelay = 1.5f;
	private bool isWaiting = false;
	private bool actionCompleted = false;
	
	private enum CombatState
	{
		StartTurn,
		PlayerTurn,
		EndTurn,
		EnemyTurn,
		Transition,
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		endTurnButton.Pressed += EndTurnPressed;
		// TODO: Instantiate units involved in combat
		StartCombat();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isWaiting)
		{
			transitionTimer += (float)delta;
			if (transitionTimer >= transitionDelay)
			{
				isWaiting = false;
				
				if (state == CombatState.Transition)
				{
					state = nextState;
					GD.Print("On state: " + state);
				}
			}
			return;
		}
		
		switch (state)
		{
			case CombatState.StartTurn:
				actionCompleted = false;
				StartTransition(CombatState.PlayerTurn);
				break;
			case CombatState.PlayerTurn:
				endTurnButton.Disabled = false;
				endTurnButton.Visible = true;
				
				if (actionCompleted)
				{
					StartTransition(CombatState.EndTurn);
					endTurnButton.Visible = false;
				}
				break;
			case CombatState.EndTurn:
				StartTransition(CombatState.EnemyTurn);
				break;
			case CombatState.EnemyTurn:
				StartTransition(CombatState.StartTurn);
				break;
		}
	}
	
	/*
	TODO
	This function will start the combat
	It should spawn the units involved in the Combat
	*/
	public void StartCombat()
	{
		GameManager.Instance.SetGameState(GameState.Combat);
		GD.Print("Current game state: " + GameManager.Instance.GetGameState());
		
		GD.Print("Starting Combat");
		endTurnButton.Disabled = true;
		endTurnButton.Visible = false;
		StartTransition(CombatState.StartTurn);
	}
	
	private void StartTransition(CombatState next)
	{
		GD.Print("Transitioning to: " + next);
		
		isWaiting = true;
		transitionTimer = 0f;
		nextState = next;
		state = CombatState.Transition;
	}
	
	public void EndTurnPressed()
	{
		endTurnButton.Disabled = true;
		actionCompleted = true;
	}
}
