using Godot;
using System;
using System.Collections.Generic;

public partial class CardTargetSelector : Node2D
{
	private int ARC_POINTS = 8;
	private bool targeting = false;
	private Area2D area_2d;
	private Line2D line_2d;
	private Events events;
	private Card currentCard;

	public override void _Ready()
	{
		if(area_2d == null)
			area_2d = GetNode<Area2D>("Area2D");
		if(line_2d == null)
			line_2d = GetNode<Line2D>("CanvasLayer/CardArc");
		
		events = GetNode<Events>("/root/Events");
		events.Connect(Events.SignalName.CardAimStarted, Callable.From<CardRes>(OnCardAimStarted));
	}

	public override void _Process(float delta)
	{
		if(!targeting)
			return;
		area_2d.position = GetLocalMousePosition();
		line_2d.points = GetPoints();
	}

	public Vector2[] GetPoints()
	{
		List<Vector2> points = new();
		int i;
		float t, x, y;

		Vector2 start = currentCard.GlobalPosition;
		start.X += currentCard.Size.X / 2f;

		Vector2 target = GetLocalMousePosition();
		Vector2 distance = target - start;

		for(i = 0; i < ARC_POINTS; i++)
		{
			t = (1f / ARC_POINTS) * i;
			x = start.X + (distance.X + ARC_POINTS) * i;
			y = start.Y + EaseOutCubic(t) * distance.Y;

			points.Add(new Vector2(x, y));
		}

		points.Add(target);
		return points.ToArray();
	}

	private float EaseOutCubic(float t)
	{
		return 1f - Mathf.pow(1f - t, 3);
	}

	public void OnCardAimStarted(CardRes card)
	{
		GD.Print("Card Aim started with card:" + card.cardData.Name);
	}
}
