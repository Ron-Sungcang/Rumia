using Godot;
using System;

public partial class Hand : Node
{
	[Export]
	private CardRes[] startingDeck;
	private CardRes cardRes;
	private PackedScene _cardScene = (PackedScene)GD.Load("res://Entities/Card/card.tscn");
	private HBoxContainer _cardContainer;
	private int cards_hand, index;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Starting hand");
		_cardContainer = GetNode<HBoxContainer>("hand");
		var combatManager = GetNode<CombatManager>("../../");
		
		combatManager.Connect(CombatManager.SignalName.StartDraw,new Callable(this, nameof(OnStartDraw)));
		combatManager.Connect(CombatManager.SignalName.StartCombatSignal,new Callable(this, nameof(OnStartCombat)));
	}
	
	private void OnStartCombat(){
		GD.Print("Combat Start Draw");
		for(int i = 0; i < 4; i++){
			DrawCard();
		}
	}
	
	private void OnStartDraw(){
		DrawCard();
	}
	
	private void DrawCard()
	{
		if(cards_hand >= 6)
		{
			return;
		}
		
		cardRes = DrawCardFromDeck();
		if (cardRes == null)
		{
			return;
		}
		var card = _cardScene.Instantiate<Card>();
		_cardContainer.AddChild(card);
		card.SetData(cardRes);
		cards_hand++;
	}
	
	private CardRes DrawCardFromDeck()
	{
		if (startingDeck.Length == 0)
		{
			GD.Print("Have to reshuffle the deck");
			return null;
		}
		index = (int)(GD.Randi() % (uint)startingDeck.Length);
		GD.Print("length: " + startingDeck.Length + "index: " + index);
		return startingDeck[index];
	}
}
