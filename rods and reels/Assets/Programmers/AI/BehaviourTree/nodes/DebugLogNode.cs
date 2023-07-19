using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// this node is to debug the tree
/// </summary>
public class DebugLogNode : ActionNode
{
    /// <summary>
    /// the messag that willbe said
    /// </summary>
    public string message;
    /// <summary>
    /// add displays the message and what phase its in
    /// </summary>
    protected override void OnStart()
    {
        Debug.Log($"OnStart {message}");
    }
    /// <summary>
    /// add displays the message and what phase its in
    /// </summary>
    protected override void OnStop()
    {
        Debug.Log($"log {message}");
    }
    /// <summary>
    /// add displays the message and what phase its in
    /// </summary>
    protected override State OnUpdate()
    {
        Debug.Log($"OnUpdate {message}");

        //Debug.Log($"Blackboard:{blackboard.moveToPosition}");

        
        return State.Success;
    }
}
