using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// repeats the node given to it
/// </summary>
public class RepeatNode : DecoratorNode
{
    public bool indefinate = false;

    public int numberOfTimes = 1;

    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
       
    }

    protected override State OnUpdate()
    {
        
        if (indefinate == true)
        {
            child.Update();
            return State.Running;
        }
        else 
        {
            
            for (int i = 0; i < numberOfTimes; i++) 
            {
                
                child.Update();
                return State.Running;
            }

        }
        return State.Success;
    }
}
