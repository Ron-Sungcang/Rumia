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

	public void ChangeState(Card_State.State state){
		foreach (var kvp in states)
		{
			GD.Print($"Key: {kvp.Key}, Value: {kvp.Value}");
		}
		current_state = states[state];
		current_state.Enter(state);
	}
	 
	public void OnInput(InputEvent @event){
	}

	public void OnGuiInput(InputEvent @event){
	}
}
