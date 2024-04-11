using Godot;

public partial class PlayerState : Node
{
    protected Player player;
    
    public override void _Ready() {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

     public override void _Notification(int what)
    {
        base._Notification(what);

        if(what == 5001) {
            EnterState();
            SetPhysicsProcess(true);
            SetProcessInput(true);
        } else if (what == 5002) {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }

    protected virtual void EnterState() {

    }
}
