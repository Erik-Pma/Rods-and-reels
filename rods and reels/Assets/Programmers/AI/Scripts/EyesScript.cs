using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesScript : MonoBehaviour
{
    public AnimalAgent agent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")) 
        {
            agent.startpos = agent.transform.position;
            Debug.Log("i can see");
            agent.canSee = true;
        }
    }
}
