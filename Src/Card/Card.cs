using Godot;
using System;

public partial class Card : Node, ICardInfo
{
	[Export] private Units CardOwner;
	[Export] private int Damage;
	[Export] private Units Target;
	[Export] private String CardName;
	[Export] private String CardEffect;
	[Export] private bool CardSelected;
	[Export] private bool CardPlayed;
	[Export] private bool CardUsed;
	
	public Units CardOwner {
		get => CardOwner;
		set => CardOwner = value;
	}
	
	public int Damage {
		get => Damage;
		set => Damage = value;
	}
	
	public Units Target {
		get => Target;
		set => Target = value;
	}
	
	public String CardName {
		get => CardName;
		set => CardName = value;
	}
	
	public String CardEffect {
		get => CardEffect;
		set => CardEffect = value;
	}
	
	public bool CardSelected {
		get => CardSelected;
		set => CardSelected = value;
	}
	
	public bool CardPlayed {
		get => CardPlayed;
		set => CardPlayed = value;
	}
	
	public bool CardUsed {
		get => CardUsed;
		set => CardUsed = value;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
