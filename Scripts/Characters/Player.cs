using Godot;
using System;

public partial class Player : CharacterBody3D
{
    public override void _PhysicsProcess(double delta)
    {
        GD.Print("Hello World");
    }
}
