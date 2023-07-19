using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// does sequence of nodes then does somthing based of of it fails or succseds
/// </summary>
public class SequencerNode : CompositeNode
{ /// <summary>
/// the curretn node you are checkings
/// </summary>
    int current;

    protected override void OnStart()
    {
        current = 0;

    }

    protected override void OnStop()
    {
        
    }
    /// <summary>
    /// sees if it cna go through he sequence
    /// </summary>
    /// <returns></returns>
    protected override State OnUpdate()
    {
        var child = children[current];
        switch (child.Update())
        {
            case State.Running:
                return State.Running;
            case State.Failure:
                return State.Failure;
            case State.Success:
                current++;
                break;
        }
        return current == children.Count ? State.Success: State.Running;
    }
}
   
