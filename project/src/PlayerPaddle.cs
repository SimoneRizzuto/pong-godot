using Godot;
using Ponggodot.shared;
public partial class PlayerPaddle : CharacterBody2D
{
    [Export] public int Speed { get; set; } = 400;
    
    private Sprite2D sprite;
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
        var collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null)
        {
            return;
        }
        
        var velocity = SetVelocity();
        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }
        
        Position += velocity * (float)delta;
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
}