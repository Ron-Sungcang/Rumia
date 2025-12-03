using Godot;
using System;
using System.Collections.Generic;

/*
* For now this manager will also handle the party, if this manager does too much.
* We can refactor it later and make a separate manager for the party
*/
public partial class UnitManager : Node
{
	public static UnitManager Instance { get; private set; }
	// For now these are just Units
	private List<PartyUnit> partyUnits;
	private List<EnemyUnit> enemyUnits;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		GD.Print("Starting UnitManager");
		PartyUnit character = new PartyUnit();
		EnemyUnit enemy = new EnemyUnit();
		
		//character.UnitName = "Sample Player";
		//character.MaxHP = 10;
		//character.CurrentHP = character.MaxHP;
		//character.IsAlive = true;
		//
		//enemy.UnitName = "Sample Enemy";
		//enemy.MaxHP = 10;
		//enemy.CurrentHP = enemy.MaxHP;
		//enemy.IsAlive = true;
		
		partyUnits = new List<PartyUnit>();
		enemyUnits = new List<EnemyUnit>();
		
		AddToPartyTeam(0, character);
		AddToEnemyTeam(0, enemy);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void AddToPartyTeam(int pos, PartyUnit unit)
	{
		var test1 = unit; var test2 = unit; var test3 = unit;
		
		if(partyUnits == null)
		{
			GD.Print("Party list is not initialized");
			return;
		}
		else if(partyUnits.Count >= 4)
		{
			GD.Print("Party is full, cant add anymore");
			return;
		}
		
		partyUnits.Insert(pos, unit);
		
		//Test units in party DELETE later
		partyUnits.Insert(1, test1);
		partyUnits.Insert(2, test2);
		partyUnits.Insert(3, test3);
	}
	
	public void AddToEnemyTeam(int pos, EnemyUnit unit)
	{
		// For encounters that might have more than 4 enemies
		// Maybe in a Stage, have a total num of enemies
		var test1 = unit;
		
		if(enemyUnits == null)
		{
			GD.Print("Enemy list is not initialized");
			return;
		}
		else if(enemyUnits.Count >= 4)
		{
			//Instead of a static 4, turn this to take the stage count
			GD.Print("Enemy count exceeds list size");
			return;
		}
		
		enemyUnits.Insert(pos, unit);
		
		//Testing enemy unit placement DELETE later
		enemyUnits.Insert(1, test1);
	}
	
	public List<PartyUnit> GetPartyList()
	{
		return partyUnits;
	}
	
	public List<EnemyUnit> GetEnemyList()
	{
		return enemyUnits;
	}
	
	public int GetRemainingPartyUnits()
	{
		var count = 0;
		
		for(int i = 0; i < GetPartyList().Count; i++)
		{
			if(GetPartyList()[i].IsAlive)
			{
				count++;
			}
		}
		
		return count;
	}
}
