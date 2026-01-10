using Godot;
using System;

[GlobalClass]
public partial class Card_State : Node
{
	private bool positionInitialized = false;

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
	
	public void SetState(State newState)
	{
		Enter(newState);
		
	}
	
	
	public void Enter(State newState)
	{

		if (!positionInitialized&& cardUI != null)
		{
			cardUI.PivotOffset = cardUI.Size / 2f;
			positionInitialized = true;
		}
		currentstate = newState;
		switch(newState)
		{
			case State.Idle:
				cardUI.Scale = Vector2.One;
				break;
			case State.Hovering:
				cardUI.Scale = new Vector2(1.2f, 1.2f);;
				break;
			case State.Clicked:
				cardUI.Scale = new Vector2(1.2f, 1.2f);
				break;
			case State.Exited:
				cardUI.Scale = Vector2.One;
				break;
			case State.Used:
				cardUI.UseCards();
				cardUI.Scale = Vector2.One;
				break;
		}
	}
}
