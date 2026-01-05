using Godot;
using System;
using System.Collections.Generic;


public partial class Hand : Node
{
	[Export]
	private CardRes[] startingDeck;
	private List<CardRes> drawPile;
	private CardRes cardRes, drawnCard;
	private PackedScene _cardScene = (PackedScene)GD.Load("res://Entities/Card/card.tscn");
	private HBoxContainer _cardContainer;
	private int cards_hand, index;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("Starting hand");
		_cardContainer = GetNode<HBoxContainer>("hand");
		var combatManager = GetNode<CombatManager>("../../");
		drawPile = new List<CardRes>(startingDeck);
		
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
		if (drawPile.Count == 0)
		{
			GD.Print("Have to reshuffle the deck");
			drawPile = new List<CardRes>(startingDeck);
		}
		index = (int)(GD.Randi() % (uint)drawPile.Count);
		GD.Print("length: " + drawPile.Count + "index: " + index);
		drawnCard = drawPile[index];
		drawPile.RemoveAt(index);
		return drawnCard;
	}
}
