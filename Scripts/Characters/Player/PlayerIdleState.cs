using Godot;
using System;

public partial class PlayerIdleState : PlayerState

{
    
    public override void _PhysicsProcess(double delta)
    {
        if(player.direction != Vector2.Zero) {
            player.StateMachineNode.SwitchState<PlayerMoveState>();
        }
    }


    public override void _Input(InputEvent @event)
    {
        if(Input.IsActionJustPressed(GameConstants.INPUT_DASH)) {
            player.StateMachineNode.SwitchState<PlayerDashState>();        }
    }

    protected override void EnterState() {
        base.EnterState();
        player.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
    }

}
