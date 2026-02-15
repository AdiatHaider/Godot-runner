using Godot;
using System;

public partial class Hud : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Node2d main;
	Label ScoreLabel;
	public override void _Ready()
	{
		main=GetParent<Node2d>();
		ScoreLabel= GetNode<Label>("Score");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ScoreLabel.Text="Score: "+main.score.ToString();
	}
}
