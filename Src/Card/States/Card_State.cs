using Godot;
using System;

[GlobalClass]
public partial class Card_State : Node
{
	public enum State {
		Idle,
		Hovering,
		Clicked,
		Used,
		Exited
	}

	[Export]
	public State currentstate {get; set;} = State.Idle;
	
	public Card cardUI {get; set;}
	
	
	public void Enter(State newState)
	{
		GD.Print("Enter Called");
		currentstate = newState;
		switch(newState)
		{
			case State.Idle:
				cardUI.SetScale(1f);
				break;
			case State.Hovering:
				cardUI.SetScale(1.2f);
				break;
			case State.Clicked:
				cardUI.SetScale(1.5f);
				//Show Enemies/Allies that can be targeted here
				break;
			case State.Exited:
				cardUI.SetScale(1f);
				break;
			case State.Used:
				cardUI.UseCards();
				cardUI.SetScale(1f);
				break;
		}
	}
}
