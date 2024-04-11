using Godot;
using System;

public partial class PlayerIdleState : PlayerState

{
    
    public override void _PhysicsProcess(double delta)
    {
        if(player.direction != Vector2.Zero) {
            player.stateMachineNode.SwitchState<PlayerMoveState>();
        }
    }


    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH)) {
            player.stateMachineNode.SwitchState<PlayerDashState>();        }
    }

    protected override void EnterState() {
        base.EnterState();
        player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}
