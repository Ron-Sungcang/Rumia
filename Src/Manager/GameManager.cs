using Godot;
using System;

// Different scenes that could be active at anytime
public enum GameState
{
	StartScreen,
	OverWorld,
	Combat,
}

/*
* Game Manager that persists throughout the whole game
* Here we can put features such as party so that the party can be accessed by both overworld and combat
*/
public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }
	//To access GameManager values => GameManager.Instance.
	
	private GameState currentGameState;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		
		currentGameState = GameState.StartScreen;
		
		GD.Print("Game Manager started");
		GD.Print("Game current state: " + currentGameState);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	/*
	* Sets the current state of the game
	* P.S in the future, this script shouldn't be calling this function
	*
	* Usage (Anywhere): GameManager.Instance.SetGameState(GameState)
	*/
	public void SetGameState(GameState newState)
	{
		currentGameState = newState;
	}
	
	/*
	* Gets the current state of the game
	*
	* Usage (Anywhere): GameManager.Instance.GetGameState()
	*/
	public GameState GetGameState()
	{
		return currentGameState;
	}
}
