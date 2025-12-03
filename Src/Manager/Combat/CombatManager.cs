using Godot;
using System;

/*
* Script in charge of the Combat scene
*/
public partial class CombatManager : Node
{
	// For now a sample button, in the future we can simply include the combat UI to this manager
	//[Export] public Sprite2D testUnitSprite;
	
	// This chould be selected from the overworld -> sent to Game Manager, where the combat scene should be able to pull from
	[Export] public CombatStage testSelectedStage; //Remove later
	
	[Export] private Button endTurnButton;
	
	[Export] private PartySlot[] playerSlots;
	[Export] private EnemySlot[] enemySlots;
	
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
		SetProcess(false);
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
		
		if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
		{
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
						if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
						{
							GD.Print("Remaining enemies: ", testSelectedStage.RemainingEnemies);
						}
						StartTransition(CombatState.EndTurn);
						endTurnButton.Visible = false;
					}
					break;
				case CombatState.EndTurn:
					StartTransition(CombatState.EnemyTurn);
					break;
				case CombatState.EnemyTurn:
					if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
					{
						GD.Print("Remaining units: ", testSelectedStage.RemainingUnits);
					}
					StartTransition(CombatState.StartTurn);
					break;
			}
		}
		else if(testSelectedStage != null && (testSelectedStage.CombatStageOver))
		{
			//Check if Rem.PartyUnits <= 0 or Rem.EnemyUnits <= 0 or if winning conditions met
			//Do ending animations
			
			//Some stage might have combat lose for stage completion
			switch (testSelectedStage.CombatVictory)
			{
				case true:
					GD.Print("Victors!");
					break;
				case false:
					GD.Print("Loser!");
					break;
			}
			
			GD.Print("Combat over!!!!!!!");
			
			SetProcess(false);
			//Return to overworld
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
		SetProcess(true);
		// Setting this game state should occur when enetering combat scene not here
		
		//Gotta do a check if a stage is selected for combat scene
		if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
		{
			GD.Print("Number of enemies: ", testSelectedStage.NumEnemiesTotal);
		}
		
		//// Setting sprites here for now to test
		//if(UnitManager.Instance.GetPartyList() != null)
		//{
			//GD.Print("Number of party members: ", UnitManager.Instance.GetPartyList().Count);
			//for (int i = 0; i < UnitManager.Instance.GetPartyList().Count; i++)
			//{
				//UnitManager.Instance.GetPartyList()[i].UnitSprite = testUnitSprite;
				//UnitManager.Instance.GetPartyList()[i].UnitSprite.Visible = true;
			//}
		//}
		//else
		//{
			//GD.Print("Party list null");
		//}
		//
		//if(UnitManager.Instance.GetEnemyList() != null)
		//{
			//for (int j = 0; j < UnitManager.Instance.GetEnemyList().Count; j++)
			//{
				//UnitManager.Instance.GetEnemyList()[j].UnitSprite = testUnitSprite;
				//UnitManager.Instance.GetEnemyList()[j].UnitSprite.Visible = true;
			//}
		//}
		//else
		//{
			//GD.Print("Enemy list null");
		//}
		
		GD.Print("Current game state: " + GameManager.Instance.GetGameState());
		
		GD.Print("Starting Combat");
		endTurnButton.Disabled = true;
		endTurnButton.Visible = false;
		
		//Setting the nodes to its positions in the scene
		SetPartyPositions();
		
		StartTransition(CombatState.StartTurn);
	}
	
	private void SetPartyPositions()
	{
		// Seperate out player units and enemy units
		// Party units will not need party slots since we are at a fixed number (4)
		// Enemies will need party slots for encounters where there are more enemies than slots
		var partyList = UnitManager.Instance.GetPartyList();
		if(partyList == null)
		{
			GD.Print("Party list is null");
			return;
		}
		
		var currSlot = 1;
		for(int i = 0; i < partyList.Count && currSlot < playerSlots.Length + 1; i++)
		{	
			if(partyList[i].IsAlive && (!playerSlots[currSlot - 1].SlotTaken))
			{
				//Should party position be set here?
				partyList[i].PositionSlot = currSlot;
				
				//Prolly can just do i, just checking to see if proper slot is taken
				SpawnCharacter(partyList[i], playerSlots[partyList[i].PositionSlot - 1]);
				currSlot++;
			}
		}
	}
	
	private void SpawnCharacter(PartyUnit unit, PartySlot pSlot)
	{
		
		// After spawning unit.InCombat = true
	}
	
	private void SetEnemyPositions()
	{
		var enemyList = UnitManager.Instance.GetEnemyList();
		if(enemyList == null)
		{
			GD.Print("Enemy list is null");
			return;
		}
		
		var currSlot = 1;
		for(int i = 0; i < enemyList.Count && currSlot < enemySlots.Length + 1; i++)
		{	
			if(enemyList[i].IsAlive && (!enemySlots[currSlot - 1].SlotTaken))
			{
				enemyList[i].PositionSlot = currSlot;
				
				SpawnEnemy(enemyList[i], enemySlots[enemyList[i].PositionSlot - 1]);
				currSlot++;
			}
		}
	}
	
	private void SpawnEnemy(EnemyUnit unit, EnemySlot eSlot)
	{
		
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
