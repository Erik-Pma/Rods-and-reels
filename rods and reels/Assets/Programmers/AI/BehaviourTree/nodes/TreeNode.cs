using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode : ActionNode
{
    public BehaviourTree tree;
    protected override void OnStart()
    {
        
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        tree.Update();
        return State.Success;
    }
}
