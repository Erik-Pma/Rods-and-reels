using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// runs the tree
/// </summary>
public class BehaviourTreeRunner : MonoBehaviour
{
    public BehaviourTree tree;
    // Start is called before the first frame update
    void Start()
    {
        tree = tree.Clone();
        tree.Bind(GetComponentInChildren<AnimalAgent>());//GetComponent<AnimalAgent>());
    }

    // Update is called once per frame
    void Update()
    {
        
        tree.Update();
    }
    public void TurnOff() 
    {
        gameObject.SetActive(false);
    }
}
