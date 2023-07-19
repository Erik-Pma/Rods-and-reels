using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipTide : MonoBehaviour
{
    public float riptideForce = 1;
    [SerializeField]LevelDepth depth;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (depth.level >= DepthLevel.LevelTwo)
        {
            rb.AddForce(new Vector3(Random.Range(-riptideForce, riptideForce), 0, 0), ForceMode.Force);
            Debug.Log("push");
        } else if (depth.level >= DepthLevel.LevelThree) 
        {
            rb.AddForce(new Vector3(Random.Range(-riptideForce, riptideForce), 0, 0), ForceMode.Force);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
}
