using Godot;
using System;

public partial class Hand : Node
{
	private PackedScene _cardScene = (PackedScene)GD.Load("res://Entities/Card/card.tscn");
	private HBoxContainer _cardContainer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Starting hand");
		_cardContainer = GetNode<HBoxContainer>("hand");
		var combatManager = GetNode<CombatManager>("../..");
		
		//combatManager.Connect(CombatManager.SignalName.StartDraw,new Callable(this, nameof(OnStartDraw)));
		combatManager.Connect(CombatManager.SignalName.StartCombatSignal,new Callable(this, nameof(OnStartCombat)));
	}
	
	private void OnStartCombat(){
		GD.Print("Combat Start Draw");
		for(int i = 0; i < 5; i++){
			var card = _cardScene.Instantiate<Card>();
			_cardContainer.AddChild(card);
		}
	}

	
}
