using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player player;
    [Export] private Timer dashTimer;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        dashTimer.Timeout += HandleDashTimeout;
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if(what == 5001) {
            player.animPlayerNode.Play(GameConstants.ANIM_DASH);
            dashTimer.Start();
        } else if (what == 5002) {

        }
    }

    private void HandleDashTimeout() {
        player.stateMachineNode.SwitchState<PlayerIdleState>();
    }
}
