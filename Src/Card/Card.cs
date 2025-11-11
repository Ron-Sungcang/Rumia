using Godot;
using System;

public partial class Card : Control, ICardInfo
{
	[Export] private Units cardOwner;
	[Export] private int damage;
	[Export] private Units target;
	[Export] private string cardName;
	[Export] private string cardEffect;
	[Export] private bool cardSelected;
	[Export] private bool cardPlayed;
	[Export] private bool cardUsed;
	[Export] public ColorRect ColorRectNode { get; set; }
	[Export] public Label StateLabel { get; set; }

	public Card_State_Machine stateMachine{ get;set;}
	
	public Units CardOwner 
	{
		get => cardOwner;
		set => cardOwner = value;
	}
	
	public int Damage 
	{
		get => damage;
		set => damage = value;
	}
	
	public Units Targets 
	{
		get => target;
		set => target = value;
	}
	
	public string CardName 
	{
		get => cardName;
		set => cardName = value;
	}
	
	public string CardEffect 
	{
		get => cardEffect;
		set => cardEffect = value;
	}
	
	public bool CardSelected 
	{
		get => cardSelected;
		set => cardSelected = value;
	}
	
	public bool CardPlayed 
	{
		get => cardPlayed;
		set => cardPlayed = value;
	}
	
	public bool CardUsed 
	{
		get => cardUsed;
		set => cardUsed = value;
	}


	public void SetScale(float scaleVal)
	{
		this.Scale = new Vector2(scaleVal,scaleVal);

	}	

	public void ShowTargets()
	{
		GD.Print("Show targetable enemies here");	
	}
	
	public void UseCards()
	{
		GD.Print("Dealt damage");
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (ColorRectNode == null)
			ColorRectNode = GetNode<ColorRect>("Color");
		if (StateLabel == null)
			StateLabel = GetNode<Label>("State");
	}

	public override void _GuiInput(InputEvent @event){
		if(@event is InputEventMouseButton mouseButtonEvent){
			GD.Print("Clicked Card");
		}
	}

}
