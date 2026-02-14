using Godot;
using System;

public partial class CharacterBody2d : CharacterBody2D
{
	public const float Gravity= 1000.0f;
	public const float JumpVelocity = -500.0f;
	private AnimatedSprite2D knight;
	private CollisionShape2D RunColl;
	public override void _Ready()
	{
		knight=GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		RunColl=GetNode<CollisionShape2D>("RunCol");
		knight.Play("Run");
	}
	private void OnAnimationFinished()
	{
		if(knight.Animation=="Roll")
		{
			RunColl.Disabled=false;
			knight.Play("Run");
		}
	}
	public override void _PhysicsProcess(double delta)
	{
		knight.AnimationFinished+=OnAnimationFinished;
		Vector2 velocity= Velocity;
		Vector2 direction=new Vector2(0,0);
		if(knight.Animation!="Roll")
		{
			if(IsOnFloor())
			{
				velocity.Y=0;
				if(Input.IsActionJustPressed("Jump"))
				{
					velocity.Y=JumpVelocity;
					knight.Play("Jump");
				}
				else if(Input.IsActionJustPressed("Roll") )
				{
					RunColl.Disabled=true;
					knight.Play("Roll");
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
	}
}
