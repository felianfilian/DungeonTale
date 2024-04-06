using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animPlayerNode;
    [Export] private Sprite3D sprite3D;

    private Vector2 direction = new(); // default (0, 0)

    public override void _Ready()
    {
        animPlayerNode.Play(GameConstants.ANIM_IDLE);
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

        if(direction == Vector2.Zero) {
            animPlayerNode.Play(GameConstants.ANIM_IDLE);
        } else {
            animPlayerNode.Play(GameConstants.ANIM_MOVE);
        }
    }
}
