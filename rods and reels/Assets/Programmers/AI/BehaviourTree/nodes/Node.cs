using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  a node for the tree
/// </summary>
public abstract class Node : ScriptableObject 
{/// <summary>
/// the 3 states the notes can be
/// 
/// </summary>
    public enum State 
    {
        Running,
        Failure,
        Success
    }
    /// <summary>
    /// the state tne node is
    /// </summary>
    [HideInInspector] public State state = State.Running;
    [HideInInspector] public bool started = false;
    [HideInInspector] public string guid;
    [HideInInspector] public Vector2 position;
    [HideInInspector] public Blackboard blackboard; 
    [HideInInspector] public AnimalAgent agent;
    [TextArea] public string description;


    /// <summary>
    /// updates the state
    /// </summary>
    /// <returns>return the current node state</returns>
    public State Update() 
    {
        if (!started) 
        {
            OnStart();
            started = true;
        }

        state = OnUpdate();

        if (state == State.Failure || state == State.Success) 
        {
            OnStop();
            started = false;
        }
        /*
        if (agent.Stats.IsStunned) 
        {
            Abort();
            state = State.Success;
        }
        */
        return state;
    }
    public void Abort()
    {
        BehaviourTree.Traverse(this, (node) => {
            node.started = false;
            node.state = State.Running;
            node.OnStop();
        });
    }
    public virtual Node Clone() 
    {
        return Instantiate(this);
    }
    /// <summary>
    /// plays on start
    /// </summary>
    protected abstract void OnStart();
    /// <summary>
    /// plays on stop
    /// </summary>
    protected abstract void OnStop();
    /// <summary>
    /// playes on update
    /// </summary>
    /// <returns></returns>
    protected abstract State OnUpdate();
}
    

