using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : ActionNode
{
    public float dist =5;
    protected override void OnStart()
    {
        
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        if (Mathf.Abs(Vector3.Distance(agent.startpos,agent.transform.position)) < dist)
        {
            agent.MoveToTarget();
            return State.Running;
        }
        agent.Move();
        return State.Success;
           
    }
}
