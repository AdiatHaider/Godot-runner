using Godot;
using System;

public partial class Hud : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Node2d main;
	Label ScoreLabel;
	Label GameOverLabel;
	Button RestartButton;
	private bool GameOn;
	public bool Restart;
	public override void _Ready()
	{
		main=GetParent<Node2d>();
		ScoreLabel= GetNode<Label>("Score");
		RestartButton=GetNode<Button>("Restart");
		GameOverLabel=GetNode<Label>("GameOver");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		GameOn=main.GameOn;
		if(GameOn)
		{
			RestartButton.Hide();
			GameOverLabel.Hide();
		}
		else
		{
			RestartButton.Show();
			GameOverLabel.Show();
		}
		Restart=RestartButton.ButtonPressed;
		ScoreLabel.Text="Score: "+main.score.ToString();
	}
}
