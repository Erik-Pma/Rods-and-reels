using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeNode : ActionNode
{
    private GameObject player;
    
    protected override void OnStart()
    {
        player = agent.player;
    }

    protected override void OnStop()
    {
        if (!agent.MoveRight)
        {
            
            agent.Flip();
            agent.MoveRight = true;
        }
    }

    protected override State OnUpdate()
    {
        agent.Flee();
        return State.Success;
    }
}
