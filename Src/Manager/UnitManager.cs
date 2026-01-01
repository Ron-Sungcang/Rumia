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
	[Export] private PartyRes[] partyRes;
	[Export] private EnemyRes[] enemyRes;
	
	private List<PartyUnit> partyUnits;
	private List<EnemyUnit> enemyUnits;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		GD.Print("Starting UnitManager");
		
		partyUnits = new List<PartyUnit>();
		enemyUnits = new List<EnemyUnit>();
		
		AddToPartyTeam();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void AddToPartyTeam()
	{
		for (int i = 0; i < partyRes.Length; i++)
		{
			var pUnit = partyRes[i].UnitPrefab.Instantiate() as PartyUnit;
			partyUnits.Insert(i, pUnit);
			
			GD.Print("Added to party: "+ (i + 1));
		}
	}
	
	public void AddToEnemyTeam()
	{
		if (enemyRes == null)
		{
			return;
		}
		for (int i = 0; i < enemyRes.Length; i++)
		{
			GD.Print("Succesfully added enemy on index: " + i);
			var eUnit = enemyRes[i].UnitPrefab.Instantiate() as EnemyUnit;
			enemyUnits.Insert(i, eUnit);
		}
	}
	
	public List<PartyUnit> GetPartyList()
	{
		return partyUnits;
	}
	
	public List<EnemyUnit> GetEnemyList()
	{
		return enemyUnits;
	}
	
	public void SetEnemyRes(EnemyRes[] res)
	{
		enemyRes = res;
		AddToEnemyTeam();
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
