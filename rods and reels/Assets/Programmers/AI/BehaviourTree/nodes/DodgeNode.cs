using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeNode : ActionNode
{
    //public Animator animator;
    float animationTime = 2.5f;
    public AnimationClip attackClip;
    protected override void OnStart()
    {
        //animator = AnimalAgent.animator;
        //animator.speed /= animationTime;
    }

    protected override void OnStop()
    {
        //animator.SetBool("attack", false);
        ///animator.speed = 1;
    }

    protected override State OnUpdate()
    {
        //animator.SetBool("attack", true);
        return State.Success;
    }
}
