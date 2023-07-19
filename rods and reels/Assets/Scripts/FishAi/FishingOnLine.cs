using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingOnLine : MonoBehaviour
{
    [Header("Fishing area")]
    [SerializeField] Transform TopBounds;
    [SerializeField] Transform BotBounds;

    [Header("FishSetting")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 3f;
    [SerializeField] float fishTimeRandomizer = 3f;
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    [Header("Hook Setting")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;
    float hookPosition;
    float hookPullVelocity;
    // Start is called before the first frame update

    [Header("Progress Bar Setting")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    float catchProgress;

    private void Start()
    {
        catchProgress = .03f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFish();
    }
    void CheckProgress() 
    {
        Vector3 progressBarScale = progressBarContainer.localScale;
    }
    void MoveHook() 
    {
        if (Input.GetMouseButton(0)) 
        {
            hookPullVelocity += hookSpeed * Time.deltaTime;
        }
        hookPullVelocity -= hookGravity * Time.deltaTime;

        hookPosition += hookPullVelocity;
        if (hookPosition - hookSize / 2 <= 0 && hookPullVelocity < 0) 
        {
            hookPullVelocity = 0;
        }
        if (hookPosition + hookSize / 2 >= 1 && hookPullVelocity > 0)
        {
            hookPullVelocity = 0;
            
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize/2);
        hook.position = Vector3.Lerp(BotBounds.position, TopBounds.position, hookPosition);
    }
    void MoveFish() 
    {
    }
}
