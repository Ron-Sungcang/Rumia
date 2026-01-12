using Godot;
using System;

public partial class Events : Node
{
	[Signal]
	public delegate void CardAimStartedEventHandler(Card card);
	[Signal]
	public delegate void CardAimEndedEventHandler(Card card);
}
