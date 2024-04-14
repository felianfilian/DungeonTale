using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer dashTimer;
    [Export(PropertyHint.Range, "0, 20, 0.1")] private float speed = 10;

    public override void _Ready()
    {
        base._Ready();
        dashTimer.Timeout += HandleDashTimeout;
    }

    protected override void EnterState()
    {
        base.EnterState();
        
        player.AnimPlayerNode.Play(GameConstants.ANIM_DASH);
        player.Velocity = new(player.direction.X, 0, player.direction.Y);

        if(player.Velocity == Vector3.Zero) {
            player.Velocity = player.SpriteNode.FlipH ? Vector3.Left : Vector3.Right;
        }

        player.Velocity *= speed;
        dashTimer.Start();
    }

    public override void _PhysicsProcess(double delta)
    {
        player.MoveAndSlide();
        player.Flip();
    }

    private void HandleDashTimeout() {
        player.Velocity = Vector3.Zero;
        player.StateMachineNode.SwitchState<PlayerIdleState>();
    }
}
