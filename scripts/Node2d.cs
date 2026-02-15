using Godot;
using System;
using System.Collections.Generic;
using  static System.Random;

public partial class Node2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public const float Speed=400.0f;
	public bool GameOn=true;
	public int score=0;
	public List<PackedScene> Obstacles;
	public List<CharacterBody2D> ObstaclesMap;
	private Random rand= new Random();
	PackedScene slime=GD.Load<PackedScene>("res://scenes/slime.tscn"),shroom=GD.Load<PackedScene>("res://scenes/shroom.tscn"),land=GD.Load<PackedScene>("res://scenes/floating land.tscn");
	Node2D knight;
	Camera2D cam;
	TileMapLayer ground;
	Area2D hit;


	public override void _Ready()
	{
		knight=GetNode<CharacterBody2D>("Knight");
		cam=GetNode<Camera2D>("Camera2D");
		ground=GetNode<TileMapLayer>("TileMapLayer");
		Obstacles = new List<PackedScene>();
		ObstaclesMap = new List<CharacterBody2D> ();
		Obstacles.Add(slime);
		Obstacles.Add(shroom);
		Obstacles.Add(land);
		GameOn=true;
	}
	
	private void SpawnObstacles()
	{
		if(ObstaclesMap.Count==0 || ObstaclesMap[ObstaclesMap.Count -1].Position.X<knight.Position.X)
		{
			PackedScene obs=Obstacles[(int)rand.Next(0, Obstacles.Count)];
			CharacterBody2D ObsInst=obs.Instantiate<CharacterBody2D>();
			AddChild(ObsInst);
			Vector2 position=new Vector2(knight.Position.X+(int)rand.Next(300, 1800), 0);
			ObsInst.Position=position;
			ObstaclesMap.Add(ObsInst);	
			if(obs==slime)
			{
				AnimatedSprite2D s=ObsInst.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
				s.Play("default");
			}
		}
	}
	
	
	public override void _Process(double delta)
	{
		score=((int)knight.Position.X)/10;
		if(GameOn==false)
		{
			return;
		}
		Vector2 p=new Vector2(0,0);
		p.X=(float)(delta*Speed);
		knight.Position+=p;
		cam.Position+=p;
		if(cam.Position.X>=ground.Position.X+1120)
		{
			p=new Vector2(1120,0);
			ground.Position+=p;
		}
		SpawnObstacles();
	}
}
