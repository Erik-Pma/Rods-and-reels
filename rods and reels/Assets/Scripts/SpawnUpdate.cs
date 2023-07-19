using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUpdate : MonoBehaviour
{
    public BoxCollider side;
    public float duration = 1;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time - startTime > duration) 
        {
            Vector3 spawnPoint = new Vector3(side.bounds.min.x, Random.Range(side.bounds.min.y, side.bounds.max.y), -4.8f );
            
            ObjectPool.instance.SpawnObject(spawnPoint,Random.Range(0,2));
            startTime = Time.time;
        }
    }
}
