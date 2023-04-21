using Godot;
using System;

public class PlasticTrashCan : Area2D
{

    bool colliding = false;
    public void _on_PlasticCan_body_entered(Node body)
    {
        colliding = true;
        GD.Print("Enter plastic!");
    }

    public void _on_PlasticCan_body_exited(Node body)
    {
        colliding = false;
        GD.Print("Exit! plastic ");
    }

    public override void _PhysicsProcess(float delta)
    {
        TrashGameGlobal g = GetNode<TrashGameGlobal>("/root/TrashGameGlobal");

        if (!g.plastic)
        {
            return;
        }
        if (!colliding)
        {
            return;
        }
        if (!Input.IsActionJustPressed("interact"))

        {
            return;
        }
        g.picked = false;
        g.plastic = false;
        g.score++;
        g.dropped = true;
    }
}