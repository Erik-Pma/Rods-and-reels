using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerController : Movement
{
    public static PlayerController instance;

    GameObject hookedObj;
    [Header("Fish Hook")]
    public MeshRenderer hook;
    public Vector3 hookedObjOffset = Vector3.zero;
    public float currentDepth = 0f;

    [Header("Fishing Line")]
    public LineRenderer fishingLine;
    public Transform poleMuzzle;

    [Header("Points System")]
    public float points;
    public TextMeshProUGUI pointsText;

    [Header("Fish Rod")]
    public DepthLevel obtainableDepth;
    public float maxDepth;

    public bool canHook = true;
    public bool inShop = false;
    public Quaternion quat;
    private Pause pause;

    // Start is called before the first frame update
    void Start()
    {
        pause = GetComponent<Pause>();
        instance = this;

        hook = GetComponent<MeshRenderer>();

        direction.y = 0;

        canHook = false;
        canMove = false;
        sendBack = false;

        transform.position = startPos;

        pointsText.text = points.ToString();
    }

    float tpX;
    float tpY;
    Vector3 dirToStart = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        CalculateDepth();

        
            if (transform.position.y > startPos.y) 
            {
                sendBack = true;
                canHook = false;
                canMove = false;

                if (HookedObject())
                {
                    DetatchFish();
                }
                else
                {
                    SwitchDirection(direction.x, 1, 0);
                }
            }
        

        tpX = transform.position.x;
        tpY = transform.position.y;

        // && transform.position.y !> startPos.y
        if (canMove)
        {
            if(!(tpX > xBounds) && !(tpX < -xBounds))
            {
                transform.Translate((direction.normalized * (horizontalSpeed / 100)) + (downVec.normalized * (verticalSpeed / 100)));
            }
            else
            {
                if (tpX > xBounds && direction.x == -1)
                {
                    transform.Translate((direction.normalized * (horizontalSpeed / 100)) + (downVec.normalized * (verticalSpeed / 100)));
                }
                else if(tpX < -xBounds && direction.x == 1)
                {
                    transform.Translate((direction.normalized * (horizontalSpeed / 100)) + (downVec.normalized * (verticalSpeed / 100)));
                }
                else
                {
                    transform.Translate(downVec.normalized * verticalSpeed / 100);
                }
            }
        }
        else if (sendBack)
        {
            if (hook.enabled)
            {
                hook.enabled = false;
            }

            dirToStart = (startPos - transform.position).normalized;

            transform.Translate(dirToStart.normalized * verticalSpeed / 100);

            if(Vector3.Distance(transform.position, startPos) < 1)
            {
                hook.enabled = true;
                sendBack = false;
                Destroy(hookedObj);
                hookedObj = null;
                canHook = true;
                canMove = false;
            }
        }
        fishingLine.SetPosition(0, poleMuzzle.position);
        fishingLine.SetPosition(1, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hit");

        if (other.transform.CompareTag("Fish") && canHook)
        {
            //if there isnt a hooked object, attatch le fish
            if (!HookedObject())
            {
                AttatchFish(other.gameObject);
            }
            //if there is, replace fish with new fish :)
            else
            {
                DetatchFish();
                AttatchFish(other.gameObject);
            }
            
        }

        //if hitting a obstacle, destroy the fish
        if (other.transform.CompareTag("Rock"))
        {
            sendBack = true;

            if (HookedObject())
            {
                DetatchFish();
            }
            else
            {
                SwitchDirection(direction.x, 1, 0);
            }
        }

        if (other.transform.CompareTag("Cut"))
        {
            sendBack = true;
            canHook = false;
            canMove = false;

            if (HookedObject())
            {
                DetatchFish();
            }
            else
            {
                SwitchDirection(direction.x, 1, 0);
            }
        }

        if (other.transform.CompareTag("Surface") && downVec.y > 0)
        {
            StartCoroutine(ReturnToHook());
        }
    }

    private void OnSpace()
    {
        if (!pause.isPaused)
        {
            if (!canMove && !sendBack && !inShop)
            {
                canHook = true;
                canMove = true;
                sendBack = false;

                SwitchDirection(direction.x, -1, 0);

            }
        }

        Shop.instance.EnableShopUI(false);
    }

    private void OnShop()
    {
        if(!canMove && !canHook && !sendBack)
        {
            inShop = !Shop.instance.shopUI.activeSelf;
            Shop.instance.EnableShopUI(inShop);

        }
    }

    //attatches fish to hook
    public void AttatchFish(GameObject fish)
    {
        //fish.transform.rotation = new Quaternion(270, 0, 0, 0);
        hookedObj = fish;
        
        hookedObj.transform.parent = transform;
        hookedObj.transform.localPosition = Vector3.zero;
        hookedObj.transform.rotation = quat;
        hookedObj.transform.localPosition = hookedObjOffset;

        if (HookedObject())
        {
            SwitchDirection(direction.x, 1, 0);
        }

        AnimalAgent agent = fish.GetComponent<AnimalAgent>();
        if(agent != null)
        {
            agent.hooked = true;
            agent.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        hookedObj.SetActive(true);
    }

    //detatches fish from hoom
    public void DetatchFish()
    {
        AnimalAgent agent = hookedObj.GetComponent<AnimalAgent>();
        Debug.Log("enter detatch");
        hookedObj.transform.parent = null;

        if (agent)
        {
            agent.hooked = false;
            agent.canSee = false;
        }
        
        //explode the fish
        hookedObj.SetActive(false);
        hookedObj = null;

        if (!HookedObject())
        {
            SwitchDirection(direction.x, -1, 0);
        }
    }

    //checks if there is a object hooked
    public bool HookedObject()
    {
        if(hookedObj != null)
            return true;

        return false;
    }

    Vector3 pos = Vector3.zero;
    Vector3 posStart = Vector3.zero;
    //calculates and (eventually) updates ui for depth
    public void CalculateDepth()
    {
        //currentDepth = Mathf.Abs(transform.position.y - startPos.y);

        //pos = new Vector3(0, transform.position.y, 0);
        //posStart = new Vector3(0, startPos.y, 0);

        //currentDepth = Vector3.Distance(pos, posStart);

        currentDepth = Mathf.Abs(LevelDepth.instance.currentDepth);
        if (currentDepth > maxDepth || !DepthCheck() )
        {
            Debug.Log("THIS SHOULD BE WORKIN");
            sendBack = true;
            SwitchDirection(direction.x, 1, 0);
        }

    }

    //returns true if the depth is unlocked
    public bool DepthCheck()
    {
        //Debug.Log("enter depth check");
        switch (obtainableDepth)
        {
            case DepthLevel.LevelOne:
                if(LevelDepth.instance.level == DepthLevel.LevelTwo ||
                    LevelDepth.instance.level == DepthLevel.LevelThree ||
                    LevelDepth.instance.level == DepthLevel.LevelFour)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                break;
            case DepthLevel.LevelTwo:
                if (LevelDepth.instance.level == DepthLevel.LevelThree ||
                    LevelDepth.instance.level == DepthLevel.LevelFour)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                break;
            case DepthLevel.LevelThree:
                if (LevelDepth.instance.level == DepthLevel.LevelFour)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                break;
            case DepthLevel.LevelFour:
                return true;
                break;
        }

        Debug.LogError("ERROR: reached code that is meant to be unreachable!");
        return false;
    }

    public void UpdateUI()
    {
        //update points ui object here
        if (pointsText)
        {
            pointsText.text = points.ToString();
        }
    }

    IEnumerator ReturnToHook()
    {
        print("enter coroutine");

        canMove = false;
        canHook = false;
        sendBack = false;

        float timer = 0;
        float timeToReel = 1;

        Vector3 currentPos = transform.position;

        while (timer < timeToReel)
        {
            transform.position = Vector3.Lerp(currentPos, startPos, (timer / timeToReel));
            timer += Time.deltaTime;

            yield return null;
        }
        
        transform.position = startPos;
        //put points or fish interaction here
        //disable fish
        GameObject fishHold = hookedObj;

        //handle points here
        Points fishPoints;
        if(fishHold.TryGetComponent(out fishPoints))
        {
            points += fishPoints.points;
        }
        else
        {
            Debug.LogError("ERROR: no points component found on: " + fishHold.name);
        }
        UpdateUI();
        
        DetatchFish();
        
        fishHold.SetActive(false);
        canMove = false;
        canHook = false;
        sendBack = false;
        yield return null;
    }

    public GameObject HookedOBJ
    {
        get
        {
            return hookedObj;
        }
    }

}
