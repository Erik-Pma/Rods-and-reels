using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosNode : ActionNode
{
    /// <summary>
    /// the duration the time is
    /// </summary>
    //public float duration = 3;
    /// <summary>
    /// hold the tiem it started at
    /// </summary>
    float startTime;

    protected override void OnStart()
    {
        //startTime = Time.time;
    }

    protected override void OnStop()
    {

        //agent.enemyAnime.SetBool("Moving", false);
        //Debug.Log("finished move");
    }

    protected override State OnUpdate()
    {
        
        
        

            Debug.Log("your pos is " + agent.transform.position);
            this.agent.Move();
            //blackboard.moveToPosition = agent.animalPositition;
     
        
            return State.Success;
        }
}
