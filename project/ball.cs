using Godot;

public partial class ball : CharacterBody2D 
{
    private Vector2 _velocity = new Vector2(-250, 250);
    // This is just to test. Will need to change with who scores.

    public override void _PhysicsProcess(double delta)
    {
        var collisionInfo = MoveAndCollide(_velocity * (float)delta);
        if (collisionInfo != null)
            _velocity = _velocity.Bounce(collisionInfo.GetNormal());
    }

    private void OnVisibilityNotifier2DScreenExited()
    {
        // Deletes the ball when it exits the screen. Hopefully this only applies to the two sides of the screen behind the paddle. 
        QueueFree();
    }
}
    




 

