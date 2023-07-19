using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    [SerializeField]GameObject pause;
    PlayerController playermovement;

    private float playerVerticalSpeed;
    private float playerHorizontalSpeed;

    private void Start()
    {
        playermovement = GetComponent<PlayerController>();

        playerVerticalSpeed = playermovement.verticalSpeed;
        Debug.Log(playerVerticalSpeed);
        playerHorizontalSpeed = playermovement.horizontalSpeed;
        Debug.Log(playerHorizontalSpeed);
    }

    private void OnPause() 
    {
        Debug.Log("paused");
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            pause.SetActive(true);
            playermovement.verticalSpeed = 0;
            playermovement.horizontalSpeed = 0;
        }
        else 
        {
            isPaused = false;
            Time.timeScale = 1;
            pause.SetActive(false);
            playermovement.verticalSpeed = playerVerticalSpeed;
            playermovement.horizontalSpeed = playerHorizontalSpeed;
        }
    }

}
