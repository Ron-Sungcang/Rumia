using Godot;
using System;

/*
* Script in charge of the Combat scene
*/
public partial class CombatManager : Node
{
	// For now a sample button, in the future we can simply include the combat UI to this manager
	[Export] public Sprite2D testUnitSprite;
	[Export] private Button endTurnButton;
	private CombatState state;
	private CombatState nextState;
	
	// For now transitioning between phases using a timer; Future implementation, transition after actions completed
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
		// TODO: Instantiate units involved in combat (Use GameManager to access party)
		StartCombat();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// TODO: Once multiple scenes established, add a root if that checks if GameManager.Instance.GetGameState() == GameState.Combat
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
		// Setting this game state should occur when enetering combat scene not here
		
		// Setting sprites here for now to test
		for (int i = 0; i < UnitManager.Instance.GetPartyList().Count; i++)
		{
			UnitManager.Instance.GetPartyList()[i].UnitSprite = testUnitSprite;
			UnitManager.Instance.GetPartyList()[i].UnitSprite.Visible = true;
		}
		
		for (int j = 0; j < UnitManager.Instance.GetEnemyList().Count; j++)
		{
			UnitManager.Instance.GetEnemyList()[j].UnitSprite = testUnitSprite;
			UnitManager.Instance.GetEnemyList()[j].UnitSprite.Visible = true;
		}
		
		GD.Print("Current game state: " + GameManager.Instance.GetGameState());
		
		GD.Print("Starting Combat");
		endTurnButton.Disabled = true;
		endTurnButton.Visible = false;
		
		//Setting the nodes to its positions in the scene
		SetUnitPositions();
		
		StartTransition(CombatState.StartTurn);
	}
	
	public void SetUnitPositions()
	{
		Vector3 position;
		// Seperate out player units and enemy units
		//Instantiate()
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
