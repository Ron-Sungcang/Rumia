using Godot;
using System;

public partial class CardTargetSelector : Node2D
{
	private int ARC_POINTS = 8;
	private Area2D area_2d;
	private Line2D line_2d;
	private Events events;

	public override void _Ready()
	{
		if(area_2d == null)
			area_2d = GetNode<Area2D>("Area2D");
		if(line_2d == null)
			line_2d = GetNode<Line2D>("CanvasLayer/CardArc");
		
		events = GetNode<Events>("/root/Events");
		events.Connect(Events.SignalName.CardAimStarted, Callable.From<CardRes>(OnCardAimStarted));
	}

	public void OnCardAimStarted(CardRes card)
	{
		GD.Print("Card Aim started with card:" + card.Name);
	}
}
