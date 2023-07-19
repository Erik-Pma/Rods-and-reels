using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public GameObject shopUI;

    public bool unlockFirstAtStart = true;

    [Header("First Rod Values")]
    public bool firstRodUnlocked;
    public float firstMaxDepth;
    public float firstBuyAmount;
    [SerializeField] TMP_Text rodOneValue;

    [Header("Second Rod Values")]
    public bool secondRodUnlocked;
    public float secondMaxDepth;
    public float secondBuyAmount;
    [SerializeField] TMP_Text rodTwoValue;

    [Header("Third Rod Values")]
    public bool thirdRodUnlocked;
    public float thirdMaxDepth;
    public float thirdBuyAmount;
    [SerializeField] TMP_Text rodThreeValue;

    [Header("Fourth Rod Values")]
    public bool fourthRodUnlocked;
    public float fourthMaxDepth;
    public float fourthBuyAmount;
    [SerializeField] TMP_Text rodFourValue;
    private void Start()
    {
        instance = this;

        rodOneValue.text = firstBuyAmount.ToString();
        rodTwoValue.text = secondBuyAmount.ToString();
        rodThreeValue.text = thirdBuyAmount.ToString();
        rodFourValue.text = fourthBuyAmount.ToString();
        firstRodUnlocked = false;
        secondRodUnlocked = false;
        thirdRodUnlocked = false;
        fourthRodUnlocked = false;

        if (unlockFirstAtStart)
        {
            UnlockFirstRod();
        }
    }

    public void EnableShopUI(bool enable)
    {
        shopUI.SetActive(enable);
    }

    public void CheckAndUnlockFirstRod()
    {
        if (CheckPrice(0) && !AlreadyUnlocked(0))
        {
            PlayerController.instance.points -= firstBuyAmount;
            PlayerController.instance.UpdateUI();
            UnlockFirstRod();
        }
    }
    public void CheckAndUnlockSecondRod()
    {
        if (CheckPrice(1) && !AlreadyUnlocked(1))
        {
            PlayerController.instance.points -= secondBuyAmount;
            PlayerController.instance.UpdateUI();
            UnlockSecondRod();
        }
    }
    public void CheckAndUnlockThirdRod()
    {
        if (CheckPrice(2) && !AlreadyUnlocked(2))
        {
            PlayerController.instance.points -= thirdBuyAmount;
            PlayerController.instance.UpdateUI();
            UnlockThirdRod();
        }
    }
    public void CheckAndUnlockFourthRod()
    {
        if (CheckPrice(3) && !AlreadyUnlocked(3))
        {
            PlayerController.instance.points -= fourthBuyAmount;
            PlayerController.instance.UpdateUI();
            UnlockFourthRod();
        }
    }

    public bool CheckPrice(int rodIndex)
    {
        switch (rodIndex)
        {
            case 0:
                if (PlayerController.instance.points >= firstBuyAmount)
                    return true;
                else
                    return false;
            case 1:
                if (PlayerController.instance.points >= secondBuyAmount)
                    return true;
                else
                    return false;
            case 2:
                if (PlayerController.instance.points >= thirdBuyAmount)
                    return true;
                else
                    return false;
            case 3:
                if (PlayerController.instance.points >= fourthBuyAmount)
                    return true;
                else
                    return false;
        }

        return false;
    }
    public bool AlreadyUnlocked(int rodIndex)
    {
        switch (rodIndex)
        {
            case 0:
                if (!firstRodUnlocked && !secondRodUnlocked && !thirdRodUnlocked && !fourthRodUnlocked)
                    return false;
                else
                    return true;
            case 1:
                if (!secondRodUnlocked && !thirdRodUnlocked && !fourthRodUnlocked)
                    return false;
                else
                    return true;
            case 2:
                if (!thirdRodUnlocked && !fourthRodUnlocked)
                    return false;
                else
                    return true;
            case 3:
                return fourthRodUnlocked;
        }

        Debug.LogError("ERROR: reached code that was meant to be unreachable!");
        return false;
    }

    public void UnlockFirstRod()
    {
        if(secondRodUnlocked || thirdRodUnlocked || fourthRodUnlocked)
        {
            return;
        }
        PlayerController.instance.maxDepth = firstMaxDepth;
        PlayerController.instance.obtainableDepth = DepthLevel.LevelOne;
        firstRodUnlocked = true;
    }
    public void UnlockSecondRod()
    {
        if(thirdRodUnlocked || fourthRodUnlocked)
        {
            return;
        }
        PlayerController.instance.maxDepth = secondMaxDepth;
        PlayerController.instance.obtainableDepth = DepthLevel.LevelTwo;
        secondRodUnlocked = true;
    }
    public void UnlockThirdRod()
    {
        if (fourthRodUnlocked)
        {
            return;
        }
        PlayerController.instance.maxDepth = thirdMaxDepth;
        PlayerController.instance.obtainableDepth = DepthLevel.LevelThree;
        thirdRodUnlocked = true;
    }
    public void UnlockFourthRod()
    {
        PlayerController.instance.maxDepth = fourthMaxDepth;
        PlayerController.instance.obtainableDepth = DepthLevel.LevelFour;
        fourthRodUnlocked = true;
    }
}

