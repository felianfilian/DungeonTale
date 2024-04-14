using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0, 20, 0.1")] private float speed = 5;
    public override void _PhysicsProcess(double delta)
    {
        if(player.direction == Vector2.Zero) {
            player.stateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new(player.direction.X, 0, player.direction.Y);
        player.Velocity *= 5;

        player.MoveAndSlide();

        player.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH)) {
            player.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState() {
        base.EnterState();
        player.animPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
