using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("enter exit trigger");
        if (other.gameObject.CompareTag("Fish")) 
        {
            Debug.Log("stuff");
            other.gameObject.SetActive(false);
        }
    }
}
