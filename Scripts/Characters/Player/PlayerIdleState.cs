using Godot;
using System;

public partial class PlayerIdleState : Node
{
    private Player player;
    
    public override void _Ready() {
        player = GetOwner<Player>();
    }

    public override void _PhysicsProcess(double delta)
    {
        if(player.direction != Vector2.Zero) {
            
        }
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if(what == 5001) {
            
            player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
        }
    }


}
