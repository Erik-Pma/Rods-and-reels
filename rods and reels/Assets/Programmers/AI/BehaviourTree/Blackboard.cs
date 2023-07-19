using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Blackboard {
    public Vector3 startPos;
    public GameObject Player;
    public bool attackMode = false;
    //public AIStats Stats;
    public bool isGrounded;
}
