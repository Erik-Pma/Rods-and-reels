using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveXNode : ActionNode
{
    public float maxSpeed = 5;

    public float acceleration = 10;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        if (agent.speed < maxSpeed)
        {
            agent.speed += acceleration;
        }
    }

    protected override State OnUpdate()
    {

        //Debug.Log("your pos is " + agent.transform.position);
        this.agent.Move();
        //blackboard.moveToPosition = agent.animalPositition;


        return State.Success;
    }
}
