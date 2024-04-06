using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer ainmPlayerNode;
    [Export] private Sprite3D sprite3D;

    private Vector2 direction = new(); // default (0, 0)

    public override void _Ready()
    {
        GD.Print(ainmPlayerNode.Name);
        GD.Print(sprite3D.Name);
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(direction.X, 0, direction.Y);
        Velocity *= 5;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event) 
    {
        direction = Input.GetVector(
            "MoveLeft", "MoveRight", "MoveForward", "MoveBackward"
        );

    }
}
