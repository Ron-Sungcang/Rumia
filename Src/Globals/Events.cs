using Godot;
using System;

public partial class Events : Node
{
	[Signal]
	public delegate void CardAimStartedEventHandler(CardRes card);
	[Signal]
	public delegate void CardAimEndedEventHandler(CardRes card);
}
