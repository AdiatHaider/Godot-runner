using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Gravity= 1000.0f;
	public const float JumpVelocity = -500.0f;
	private AnimatedSprite2D knight;
	private CollisionShape2D RunColl;
	Node2d main;
	AudioStreamPlayer jumpsfx,diesfx,rollsfx;
	// public bool GameOn;


	private void OnAnimationFinished()
	{
		if(knight.Animation=="Roll")
		{
			RunColl.Disabled=false;
			knight.Play("Run");
		}
	}

	public override void _Ready()
	{
		main=GetParent<Node2d>();
		knight=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		RunColl=GetNode<CollisionShape2D>("RunCol");
		knight.Play("Run");
		jumpsfx=GetNode<AudioStreamPlayer>("Jump");
		diesfx=GetNode<AudioStreamPlayer>("Die");
		rollsfx=GetNode<AudioStreamPlayer>("Roll");
		knight.AnimationFinished+=OnAnimationFinished;
		// GameOn=true;
	}

	public void GameOver()
	{
		main.GameOn=false;
		knight.Play("Die");
		diesfx.Play();
	}
	public override void _PhysicsProcess(double delta)
	{
		if(main.GameOn==false)
		{
			Velocity+=new Vector2(0,(float)(delta*Gravity));
			MoveAndSlide();
			return;
		}
		Vector2 velocity= Velocity;
		Vector2 direction=new Vector2(0,0);
		if(knight.Animation!="Roll")
		{
			if(IsOnFloor())
			{
				velocity.Y=0;
				if(Input.IsActionPressed("Jump"))
				{
					velocity.Y=JumpVelocity;
					knight.Play("Jump");
					jumpsfx.Play();
				}
				else if(Input.IsActionPressed("Roll") )
				{
					RunColl.Disabled=true;
					knight.Play("Roll");
					rollsfx.Play();
				}
				else knight.Play("Run");
			}
			else
			{
				knight.Play("Jump");
				velocity.Y+=(float)(delta*Gravity);
			}
		}
		
		// velocity.X=direction.X*Speed;
		// velocity.X=200;
		Velocity = velocity;
		// Velocity.X=200;
		MoveAndSlide();
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			KinematicCollision2D collision = GetSlideCollision(i);

			Node collider = collision.GetCollider() as Node;

			if (collider is CharacterBody2D)
			{
				// GD.Print("Hit a CharacterBody2D!");
				GameOver();
			}
		}
	}
}
