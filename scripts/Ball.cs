using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	public const float Speed = 100.0f;
	public const float Gravity=300;
	public const float JumpVelocity = -100.0f;
	public override void _Ready()
	{
		AnimatedSprite2D knight = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
		knight.Play("Run");
	}
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity= Velocity;
		Vector2 direction=new Vector2(0,0);
		if(Input.IsActionPressed("MoveRight"))
		{
			direction.X+=1;
		}
		if(Input.IsActionPressed("MoveLeft"))
		{
			direction.X-=1;
		}
		if(IsOnFloor())
		{
			velocity.Y=0;
		}
		else
		{
			velocity.Y+=(float)(delta*Gravity);
		}
		if(Input.IsActionJustPressed("Jump"))
		{
			velocity.Y=JumpVelocity;
		}
		velocity.X=direction.X*Speed;
		Velocity = velocity;
		// sprtie.play("Run");
		MoveAndSlide();
	}
}
