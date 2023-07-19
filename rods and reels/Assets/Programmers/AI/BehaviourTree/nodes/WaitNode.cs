using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// waits for a time then updates
/// </summary>
public class WaitNode : ActionNode {
    /// <summary>
    /// the duration the time is
    /// </summary>
    public float duration = 1;
    /// <summary>
    /// hold the tiem it started at
    /// </summary>
    float startTime;
protected override void OnStart()
    {
        startTime = Time.time;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {
        if (Time.time - startTime > duration) 
        {
            return State.Success;
        }
        return State.Running;
    }
}
