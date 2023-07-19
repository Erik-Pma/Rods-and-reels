using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider))]
public class Movement : MonoBehaviour
{
    [Header("Movement Variables")]
    public float horizontalSpeed;
    public float verticalSpeed;
    public Vector3 startPos;

    [HideInInspector]
    public Vector3 direction = Vector3.zero;
    [HideInInspector]
    public Vector3 downVec = Vector3.down;
    //[HideInInspector]
    public bool canMove = true;
    [HideInInspector]
    public Vector3 nextPosition;
    //[HideInInspector]
    public bool sendBack = false;

    public float xBounds = 0;

    
    
    private void OnMove(InputValue value)
    {
        direction.x = value.Get<Vector2>().x;
    }

    public void SwitchDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void SwitchDirection(float x, float y, float z)
    {
        if (!sendBack)
        {
            direction = new Vector3(x, y, z);
            direction.y = 0;
            downVec.y = y;
        }
        else
        {
            direction = new Vector3(x, 1, z);
            direction.y = 0;
            downVec.y = y;
        }
    }
}
