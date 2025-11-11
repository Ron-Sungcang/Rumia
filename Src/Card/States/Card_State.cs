using Godot;
using System;

[GlobalClass]
public partial class Card_State : Node
{
	protected State _currentstate = State.Idle;
	
	protected Card cardUI;
	
	public enum State {
		Idle,
		Clicked,
		Targeting,
		Used
	}

	public State CurrentState => _currentstate;
	
	public void transition_requested(State state){
		
	}
	
	public void enter(){}
	
	public void exit(){}
	
	public void On_Input(InputEvent @event){}
	
	public void On_GuiInput(InputEvent @event){}
}
