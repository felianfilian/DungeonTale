using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player player;

    public override void _Ready()
    {
        player = GetOwner<Player>();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);

        if(what == 5001) {
            player.animPlayerNode.Play(GameConstants.ANIM_DASH);
        } else if (what == 5002) {

        }
    }
}
