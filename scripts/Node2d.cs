using Godot;
using System;

public partial class Node2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Node2D knight=GetNode<Node2D>("Knight");
		Camera2D cam=GetNode<Camera2D>("Camera2D");
		Vector2 p=new Vector2(10,0);
		knight.Position+=p;
		cam.Position+=p;
	}
}
