using Godot;

public partial class paddle_test : RigidBody2D
{

    [Export]
    public int Speed { get; set; } = 400; // How fast the player will move (pixels/sec).

    public Vector2 ScreenSize; // Size of the game window.

    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    [Signal]
    public delegate void HitEventHandler();

    private void OnBodyEntered(Node2D body)
    {
        EmitSignal(SignalName.Hit);
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector. 

        //+ & - is swapped if witness the 2D coord system. 
        if (Input.IsActionPressed("move_up"))
        {
            velocity.Y -= 1;
        }

        if (Input.IsActionPressed("move_down"))
        {
            velocity.Y += 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * Speed;
        }

        Position += velocity * (float)delta;
        Position = new Vector2(
            x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
            y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
        );


    }


}
