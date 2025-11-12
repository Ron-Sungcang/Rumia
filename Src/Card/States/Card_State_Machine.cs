using Godot;
using System;
using System.Collections.Generic;

public partial class Card_State_Machine : Node
{
	public Card_State initial_state;
	private Card_State current_state;
	private Dictionary<Card_State.State, Card_State> states = new(); 
	
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
		//connect to signals
		cardUI.Connect(Card.SignalName.CardClicked, Callable.From<Card>(OnCardClicked));
		cardUI.Connect(Card.SignalName.CardHovered, Callable.From<Card>(OnCardHovered));
		cardUI.Connect(Card.SignalName.CardExit, Callable.From<Card>(OnCardExited));
		
		if (initial_state != null)
		{
			initial_state.Enter(initial_state.currentstate);
			current_state = initial_state;
		}
	}

	private void OnCardClicked(Card card)
	{
		GD.Print("OnCard clicked called");
		ChangeState(Card_State.State.Clicked);
	}
	
	private void OnCardHovered(Card card)
	{
		GD.Print("OnCard hovered called");
		ChangeState(Card_State.State.Hovering);
	}
	
	private void OnCardExited(Card card)
	{
		ChangeState(Card_State.State.Exited);
	}

	public void ChangeState(Card_State.State state){
		foreach (var kvp in states)
		{
			GD.Print($"Key: {kvp.Key}, Value: {kvp.Value}");
		}
		
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
