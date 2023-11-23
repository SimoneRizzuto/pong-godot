using System;
using System.Linq;
using Godot;
using Ponggodot.shared;
public partial class PlayerPaddle : Area2D
{
    [Export] public int Speed { get; set; } = 400;

    private bool collidingWithWall;
    
    private Sprite2D sprite;
    private Vector2 screenSize;
    public override void _Ready()
    {
        // Fetching type of child - unneeded code for this project, but it might be useful in the future, keeping it here.
        for (var i = 0; i < GetChildCount(); i++)
        {
            var child = GetChild(i);
            if (child.GetClass() == nameof(Sprite2D))
            {
                var node = GetChild<Sprite2D>(i);
                sprite = node;
                break;
            }
        }
    }
    public override void _Process(double delta)
    {
        if (collidingWithWall) return;
        
        screenSize = GetViewportRect().Size;
        
        var velocity = SetVelocity();
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }
        
        Position += velocity * (float)delta;
        
        
        //Position = new Vector2(Position.X, Mathf.Clamp(Position.Y, 0 - sprite.Scale.Y, screenSize.Y - sprite.Scale.Y));
        
        
    }

    private Vector2 SetVelocity()
    {
        var velocity = Vector2.Zero;
        if (Input.IsActionPressed(ActionPress.MoveUp))
        {
            velocity.Y -= 1;
        }
        if (Input.IsActionPressed(ActionPress.MoveDown))
        {
            velocity.Y += 1;
        }
        return velocity;
    }

    private void OnBodyEntered(Node2D body)
    {
        collidingWithWall = true;
    }
}