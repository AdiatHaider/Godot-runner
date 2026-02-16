using Godot;
using System;

public partial class Hud : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	Node2d main;
	Label ScoreLabel;
	Label GameOverLabel;
	Label StartLabel;
	Button RestartButton;
	public bool ShowStartScreen;
	public bool GameOn;
	public bool Restart;
	public override void _Ready()
	{
		main=GetParent<Node2d>();
		ScoreLabel= GetNode<Label>("Score");
		RestartButton=GetNode<Button>("Restart");
		GameOverLabel=GetNode<Label>("GameOver");
		StartLabel=GetNode<Label>("Start");
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ShowStartScreen=main.ShowStartScreen;
		GameOn=main.GameOn;
		if(GameOn)
		{
			StartLabel.Hide();
			RestartButton.Hide();
			GameOverLabel.Hide();
		}
		else if(ShowStartScreen)
		{
			StartLabel.Show();
			RestartButton.Hide();
			GameOverLabel.Hide();
		}
		else
		{
			StartLabel.Hide();
			RestartButton.Show();
			GameOverLabel.Show();
		}
		Restart=RestartButton.ButtonPressed;
		ScoreLabel.Text="Score: "+main.score.ToString();
	}
}
