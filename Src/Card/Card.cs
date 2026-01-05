using Godot;
using System;

public partial class Card : Control
{
	private CardRes cardData;

	[Export] public ColorRect ColorRectNode { get; set; }
	[Export] public Label StateLabel { get; set; }

	public Card_State_Machine stateMachine{ get;set;}
	
	
	[Signal]
	public delegate void CardClickedEventHandler(Card card);
	[Signal]
	public delegate void CardHoveredEventHandler(Card card);
	[Signal]
	public delegate void CardExitEventHandler(Card card);
	[Signal]
	public delegate void CardClickedOutsideEventHandler(Card card);

	public void SetScale(float scaleVal)
	{
		this.Scale = new Vector2(scaleVal,scaleVal);

	}
	
	public void SetData(CardRes newCardData)
	{
		cardData = newCardData;
		StateLabel.Text = cardData.Name;
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
		stateMachine = GetNode<Card_State_Machine>("CardStateMachine");
		stateMachine.Init(this);
		
		this.MouseEntered += OnMouseEntered;
		this.MouseExited += OnMouseExited;
	}

	public override void _GuiInput(InputEvent @event)
	{
		if(@event is InputEventMouseButton mouseButtonEvent)
		{
			if(mouseButtonEvent.Pressed && mouseButtonEvent.ButtonIndex == MouseButton.Left)
			{
				GD.Print("Pressed card");
				EmitSignal(SignalName.CardClicked, this);
			}
		}
	}
	
	private void OnMouseEntered()
	{
		GD.Print("Card Hovered");
		EmitSignal(SignalName.CardHovered,this);
	}
	
	private void OnMouseExited()
	{
		GD.Print("Card Exited");
		EmitSignal(SignalName.CardExit,this);
	}
	
}
