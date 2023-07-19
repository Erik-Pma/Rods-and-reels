using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public 
    //[SerializeField] AnimalAgent agent;
    float startTime;
    public float duration =3;

    private void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > duration)
        {
            ObjectPool.instance.SpawnObject(new Vector3(offsetX, this.transform.position.y - Random.Range(1,offsetY), this.gameObject.transform.position.z), 0);
            startTime = Time.time;
        }
    }
}
