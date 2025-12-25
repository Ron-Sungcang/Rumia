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
	
	private List<PackedScene> partyUnits;
	private List<PackedScene> enemyUnits;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		GD.Print("Starting UnitManager");
		
		partyUnits = new List<PackedScene>();
		enemyUnits = new List<PackedScene>();
		
		AddToPartyTeam();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void AddToPartyTeam()
	{
		for(int i = 0; i < partyRes.Length; i++)
		{
			//var pUnit = partyRes[i].UnitPrefab.Instantiate() as PartyUnit;
			partyUnits.Insert(i, partyRes[i].UnitPrefab);
			
			GD.Print("Added to party: "+ (i + 1));
		}
	}
	
	public void AddToEnemyTeam()
	{
		// For encounters that might have more than 4 enemies
		// Maybe in a Stage, have a total num of enemies
		//var test1 = unit;
		//
		//if(enemyUnits == null)
		//{
			//GD.Print("Enemy list is not initialized");
			//return;
		//}
		//else if(enemyUnits.Count >= 4)
		//{
			////Instead of a static 4, turn this to take the stage count
			//GD.Print("Enemy count exceeds list size");
			//return;
		//}
		//
		//enemyUnits.Insert(pos, unit);
		//
		////Testing enemy unit placement DELETE later
		//enemyUnits.Insert(1, test1);
		if(enemyRes == null)
		{
			return;
		}
		for(int i = 0; i < enemyRes.Length; i++)
		{
			GD.Print("Succesfully added enemby on index: " + i);
			//var eUnit = enemyRes[i].UnitPrefab.Instantiate() as EnemyUnit;
			enemyUnits.Insert(i, enemyRes[i].UnitPrefab);
		}
	}
	
	public List<PackedScene> GetPartyPrefabs()
	{
		return partyUnits;
	}
	
	public List<PackedScene> GetEnemyPrefabs()
	{
		return enemyUnits;
	}
	
	public void SetEnemyRes(EnemyRes[] res)
	{
		enemyRes = res;
		AddToEnemyTeam();
	}
	
	//public int GetRemainingPartyUnits()
	//{
		//var count = 0;
		//
		//for(int i = 0; i < GetPartyList().Count; i++)
		//{
			//if(GetPartyList()[i].IsAlive)
			//{
				//count++;
			//}
		//}
		//
		//return count;
	//}
}
