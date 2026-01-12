using Godot;
using System;
using System.Collections.Generic;

public partial class Card_State_Machine : Node
{
	public Card_State initial_state;
	private Card_State current_state;
	private Dictionary<Card_State.State, Card_State> states = new(); 
	private Events events;
	
	public void Init(Card cardUI)
	{
		foreach (Node child in GetChildren())
		{
			if(child is Card_State){
				var state = (Card_State) child;
				states[state.currentstate] = state;
				state.cardUI = cardUI;
			}
		}
		events = GetNode<Events>("/root/Events");
		//connect to signals
		cardUI.Connect(Card.SignalName.CardClicked, Callable.From<Card>(OnCardClicked));
		cardUI.Connect(Card.SignalName.CardHovered, Callable.From<Card>(OnCardHovered));
		cardUI.Connect(Card.SignalName.CardExit, Callable.From<Card>(OnCardExited));
		cardUI.Connect(Card.SignalName.CardClickedOutside, Callable.From<Card>(OnCardIdle));
		
		if (initial_state != null)
		{
			initial_state.Enter(initial_state.currentstate);
			current_state = initial_state;
		}
	}

	private void OnCardClicked(Card card)
	{
		events.EmitSignal(Events.SignalName.CardAimStarted, card);
		ChangeState(Card_State.State.Clicked);
	}
	
	private void OnCardHovered(Card card)
	{
		ChangeState(Card_State.State.Hovering);
	}
	
	private void OnCardExited(Card card)
	{
		ChangeState(Card_State.State.Exited);
	}
	
	private void OnCardIdle(Card card)
	{
		ChangeState(Card_State.State.Idle);
	}

	public void ChangeState(Card_State.State state){
		
		if(current_state != null && current_state.currentstate == Card_State.State.Clicked &&
		 (state == Card_State.State.Hovering || state == Card_State.State.Exited)){
			GD.Print("Skipping hovered because current state is clicked");
			return;
		}
		
		current_state = states[state];
		current_state.Enter(state);
	}
	 
	public void OnInput(InputEvent @event){
	}

	public void OnGuiInput(InputEvent @event){
	}
}
