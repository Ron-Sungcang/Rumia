using Godot;
using System;

/*
* Script in charge of the Combat scene
*/
public partial class CombatManager : Node
{	
	// This chould be selected from the overworld -> sent to Game Manager, where the combat scene should be able to pull from
	[Export] public PackedScene testPacked; // Only here for testing, test combat stage
	private CombatStage testSelectedStage; //Remove later, game manager should track the instance of selected stage
	
	[Export] private Control ui;
	[Export] private Button endTurnButton;
	
	[Export] private PartySlot[] playerSlots;
	[Export] private EnemySlot[] enemySlots;
	
	private CombatState state;
	
	[Signal]
	public delegate void StartDrawEventHandler();
	[Signal]
	public delegate void StartCombatSignalEventHandler();
	
	public enum CombatState
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
		testSelectedStage = testPacked.Instantiate<CombatStage>();
		SetProcess(false);
		StartCombat();
	}
	
	public void SetState(CombatState newState)
	{
		GD.Print("From: " + state + "To: " + newState);
			
		state = newState;
		CombatStateEntered(state);
	}


	private async void CombatStateEntered(CombatState newState)
	{	
		if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
		{
			switch (newState)
			{
				case CombatState.StartTurn:
					StartTransition(CombatState.PlayerTurn);
					break;
				case CombatState.PlayerTurn:
					endTurnButton.Disabled = false;
					endTurnButton.Visible = true;
					EmitSignal(SignalName.StartDraw);
					break;
				case CombatState.EndTurn:
					StartTransition(CombatState.EnemyTurn);
					break;
				case CombatState.EnemyTurn:
					if(testSelectedStage != null && (!testSelectedStage.CombatStageOver))
					{
						GD.Print("Remaining units: ", testSelectedStage.RemainingUnits);
					}
					await ToSignal(GetTree().CreateTimer(1.5f), "timeout");
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
		CursorManager.Instance.CurrentUI = ui;
		
		ClearEnemySlots();
		ClearPlayerSlots();
		
		LoadCombatStageRes();
		
		SetProcess(true);
		
		GD.Print("Current game state: " + GameManager.Instance.GetGameState());
		
		GD.Print("Starting Combat");
		endTurnButton.Disabled = true;
		endTurnButton.Visible = false;
		
		//Setting the nodes to its positions in the scene
		SetPartyPositions();
		SetEnemyPositions();
		
		EmitSignal(SignalName.StartCombatSignal);
		
		StartTransition(CombatState.StartTurn);
	}
	
	private void LoadCombatStageRes()
	{
		//From a stage manager, get the selected stage
		if(StageManager.Instance.SelectedCombatRes.EnemySlots > 6)
		{
			GD.Print("Invalid number of enemy slots");
		}
		
		testSelectedStage = StageManager.Instance.SelectedCombatRes.StagePrefab.Instantiate() as CombatStage;
		testSelectedStage.Initialize(StageManager.Instance.SelectedCombatRes);
	}
	
	private void SetPartyPositions()
	{
		var partyList = UnitManager.Instance.GetPartyList();
		if(partyList == null)
		{
			GD.Print("Party list is null");
			return;
		}
		
		var currSlot = 1;
		for(int i = 0; i < partyList.Count && currSlot < playerSlots.Length; i++)
		{
			if(partyList[i].IsAlive && (!playerSlots[currSlot - 1].SlotTaken))
			{
				partyList[i].PositionSlot = currSlot;
				
				SpawnCharacter(partyList[i], playerSlots[partyList[i].PositionSlot - 1]);
				currSlot++;
			}
		}
	}
	
	private void SpawnCharacter(PartyUnit unit, PartySlot pSlot)
	{
		// After spawning unit.InCombat = true
		pSlot.AddPartyScene(unit);
	}
	
	private void SetEnemyPositions()
	{
		GD.Print("SetEnemy called");
		var enemyList = UnitManager.Instance.GetEnemyList();
		if(enemyList == null)
		{
			GD.Print("Enemy list is null");
			return;
		}
		
		var currSlot = 1;
		for(int i = 0; i < enemyList.Count && currSlot < enemySlots.Length; i++)
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
		eSlot.AddEnemyScene(unit);
	}
	
	private void StartTransition(CombatState next)
	{
		GD.Print("Transitioning to: " + next);
		
		SetState(next);
	}
	
	public void ClearEnemySlots()
	{
		for(int i = 0; i < enemySlots.Length; i++)
		{
			enemySlots[i].ClearScene();
		}
	}
	
	public void ClearPlayerSlots()
	{
		for(int i = 0; i < playerSlots.Length; i++)
		{
			playerSlots[i].ClearScene();
		}
	}
	
	public void EndTurnPressed()
	{
		endTurnButton.Disabled = true;
		SetState(CombatState.EndTurn);
	}
}
