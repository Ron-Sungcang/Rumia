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
	private List<Units> partyUnits;
	private List<Units> enemyUnits;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Units character = new Units();
		Units enemy = new Units();
		
		character.UnitName = "Sample Player";
		character.MaxHP = 10;
		character.CurrentHP = character.MaxHP;
		character.IsAlive = true;
		
		enemy.UnitName = "Sample Enemy";
		enemy.MaxHP = 10;
		enemy.CurrentHP = enemy.MaxHP;
		enemy.IsAlive = true;
		
		partyUnits = new List<Units>();
		enemyUnits = new List<Units>();
		
		AddToPartyTeam(0, character);
		AddToEnemyTeam(0, enemy);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void AddToPartyTeam(int pos, Units unit)
	{
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
	}
	
	public void AddToEnemyTeam(int pos, Units unit)
	{
		// For encounters that might have more than 4 enemies
		// Maybe in a Stage, have a total num of enemies
		
		if(enemyUnits == null)
		{
			GD.Print("Enemy list is not initialized");
			return;
		}
		else if(enemyUnits.Count >= 4){
			GD.Print("Enemy count exceeds list size");
			return;
		}
		
		enemyUnits.Insert(pos, unit);
	}
	
	public List<Units> GetPartyList()
	{
		return partyUnits;
	}
	
	public List<Units> GetEnemyList()
	{
		return enemyUnits;
	}
}
