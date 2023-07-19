using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject stuff;
    public void CreditsOn() 
    {
        stuff.SetActive(false);
        credits.SetActive(true);
    }

    public void CreditsOff()
    {
        stuff.SetActive(true);
        credits.SetActive(false);
    }
}
