using Godot;
using System;

public partial class Stage : Node2D, IStage
{
	[Export] private bool stageCompleted = false;
	
	public bool StageCompleted
	{
		get => stageCompleted;
		set
		{
			stageCompleted = value;
			
			//if(stageCompleted && NextStage != null)
			//{
				//NextStage.Visible = true;
			//}
		}
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
