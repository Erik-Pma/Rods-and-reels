using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPositionNode : ActionNode
{
    Vector3 pos = Vector3.zero;

    public float value = 5;
    protected override void OnStart()    
    {
        //blackboard.moveToPosition = agent.transform.position;
        pos = new Vector3(Random.Range(-value, value), 0, Random.Range(-value, value)); ;
    }

    protected override void OnStop()
    {
        
        //blackboard.moveToPosition += pos;
       // Debug.Log("pos" + blackboard.moveToPosition);
    }

    protected override State OnUpdate()
    {

        return State.Success;
    }
}


