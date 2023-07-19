using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AnimalAgent : MonoBehaviour
{
    public bool hasFlipped = false;

    public GameObject eyes;

    [HideInInspector] public bool canSee = false;

    [HideInInspector]public bool hooked = false;
    
    public bool MoveRight = true;

    public float speed = 1;

    public GameObject fish;

    public float StartPosX;

    public Vector3 startpos;
    /// <summary>
    /// the animals curretn position
    /// </summary>
    public Transform animalPositition;
    /// <summary>
    /// the hitbox for the attack
    /// </summary>
    //public GameObject attack;

    //public ChangeForm form;
    /// <summary>
    /// the ai tree it is running
    /// </summary>
    [SerializeField] BehaviourTreeRunner AiLogic;
    
    //public AiSensor onTheGroundEyes;

    public BehaviourTreeRunner AILogic
    {
        get { return AiLogic; }
    }
    //public AiSensor vision;
    /// <summary>
    /// the posision it will move to
    /// </summary>
    
    /// <summary>
    /// timer between moves
    /// </summary>
    public float moneyValue;
    public GameObject player;
    //public static Animator animator;
    /// <summary>
    /// collider that can be called by other scripts
    /// </summary>
    


    //IDamagable damage;
    // Start is called before the first frame update
    void Start()
    {
        //fish = GetComponentInParent<GameObject>();
        player = PlayerController.instance.gameObject;
        animalPositition = GetComponentInParent<Transform>();
        StartPosX = transform.position.x;
        if (StartPosX > 0) 
        {
            MoveRight = false;
            Flip();
        }
    }

    private void Update()
    {
        if (transform.position.y > 1.5f)
            this.gameObject.SetActive(false);
        if (speed > 0 && hasFlipped) 
        {
            hasFlipped = !hasFlipped;
            Flip();
        }
    }
    /// <summary>
    /// Moves the object to the vecotr 3 position
    /// </summary>
    /// <param name="Position"> the vector3 that hold the current Position to be moved to </param>
    public void Move()
    {
        if (!hooked)
        {
            if (MoveRight)
            {
                fish.transform.Translate(speed * Time.deltaTime / 10, 0, 0);
                if (transform.localScale.x < 0) 
                {
                    Vector3 charScale = transform.localScale;
                    charScale.x *= -1;
                    transform.localScale = charScale;
                    
                }
            }
            else
            {
                fish.transform.Translate(-speed * Time.deltaTime / 10, 0, 0);
            }
        }
    }
    /// <summary>
    /// gets a random positon
    /// </summary>

    public void MoveToTarget() 
    {
        if (!hooked)
        {
            
            //Vector3 pos = player.transform.position.normalized - transform.position.normalized;

            //this.gameObject.transform.Translate(pos.x *speed * Time.deltaTime, pos.y * speed * Time.deltaTime, 0);
            
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime / 2.5f);
        }
    }

    public void Flee() 
    {
        if (!hooked)
        {
            if (player.transform.position.x - transform.position.x > 0)
            {
                if (!hasFlipped)
                {
                    Flip();
                    hasFlipped = true;
                    speed *= -1;
                }
            }
            
            fish.transform.Translate(speed * Time.deltaTime / 2.5f, 0, 0);

        }
        //this.transform.position = Vector3.MoveTowards(player.transform.position,this.transform.position, speed * Time.deltaTime / 10);
    }
    /// <summary>
    /// turns on the hit box
    /// </summary>
    public void ActiveBox() 
    {
        Debug.Log("BOX IS ONLINE");
        transform.LookAt(player.transform, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        //attack.SetActive(true);
    }
    /// <summary>
    /// turns off the box
    /// </summary>
    public void UnactiveBox()
    {
        Debug.Log("BOX IS NO LONGER ONLINE");
        //attack.SetActive(false);
    }
    public void Flip() 
    {
  
            Vector3 charScale = fish.transform.localScale;
            charScale.x *= -1;
            fish.transform.localScale = charScale;

    }
}
