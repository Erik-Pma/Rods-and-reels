using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movewith : MonoBehaviour
{
    [SerializeField] GameObject bound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bound.transform.position = new Vector3(0, PlayerController.instance.transform.position.y, PlayerController.instance.transform.position.z);
    }
}
