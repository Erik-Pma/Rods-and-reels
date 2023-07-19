using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedDespawn : MonoBehaviour
{
    PlayerController Player;
    BehaviourTreeRunner bas;
    public float distance = 20;
    private void Start()
    {
        Player =PlayerController.instance;
    }
    private void FixedUpdate()
    {
        if (Vector3.Distance(Player.gameObject.transform.position,transform.position) > distance) 
        {
            AnimalAgent agent = GetComponent<AnimalAgent>();
            agent.canSee = false;
            
            //agent.Flip();
            
            bas = GetComponentInParent<BehaviourTreeRunner>();
            bas.TurnOff();
        }
    }
}
