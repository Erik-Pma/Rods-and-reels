using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSightNode : CompositeNode
{
    GameObject eyes;
    int current;
    protected override void OnStart()
    {
        //eyes = agent.eyes;
        current = 0;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (!agent.canSee)
        {

            current = 0;
            return children[current].Update();
        }

        current = 1;
        return children[current].Update();
    }
}
