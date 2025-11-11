using Godot;
using System;
using System.Collections.Generic;

public partial class Card_State_Machine : Node
{
	private Card_State initial_state;
	private Card_State current_state;
	private Dictionary<Card_State.State, Card_State> states = new(); 
	
	public void Init(Card cardUI){
		var children = GetChildren();
		
		foreach (Node child in children){
			if(child is Card_State state){
				states[state.CurrentState] = state;
				
			}
		}
	}
	 
	public void OnInput(){}
}
