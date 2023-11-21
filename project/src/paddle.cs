using Godot;

public partial class paddle : Area2D
{

    [Signal]
    public delegate void HitEventHandler();

    private void OnBodyEntered(Node2D body)
    {
        EmitSignal(SignalName.Hit);
        GetNode<CollisionShape2D>("CollisionShape2D").SetDeferred(CollisionShape2D.PropertyName.Disabled, true);

    }


}
