using Godot;
using System;
using System.Collections.Generic;

public partial class Card_State_Machine : Node
{
	public Card_State initial_state;
	private Card_State current_state;
	private Dictionary<Card_State.State, Card_State> states = new(); 
	
	public void Init(Card cardUI){		
		foreach (Node child in GetChildren()){
			if(child is Card_State){
				var state = (Card_State) child;
				states[state.currentstate] = state;
				state.cardUI = cardUI;
			}
		} if (initial_state != null){
			initial_state.Enter(initial_state.currentstate);
			current_state = initial_state;
		}
	}

	public void OnTransitionRequested(Card_State.State state){

	}
	 
	public void OnInput(InputEvent @event){
	}

	public void OnGuiInput(InputEvent @event){
	}
}
