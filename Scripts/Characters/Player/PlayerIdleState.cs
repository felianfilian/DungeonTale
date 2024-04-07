using Godot;
using System;

public partial class PlayerIdleState : Node
{
    
    public override void _Ready() {
        Player player = GetOwner<Player>();
        player.animPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
    
}
