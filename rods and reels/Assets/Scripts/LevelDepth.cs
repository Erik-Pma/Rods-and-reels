using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDepth : MonoBehaviour
{
    public static LevelDepth instance;

    public Image levelOneIndicator;
    public Image levelTwoIndicator;
    public Image levelThreeIndicator;
    public Image levelFourIndicator;
    public Sprite empty;
    public Sprite full;

    public DepthLevel level;
    public float startingDepth; //starting Y pos
    public float currentDepth; //current Y pos
    public float calculatedDepth; //difference between starting and current to get actual depth submerged

    private void Start()
    {
        instance = this;
        startingDepth = transform.position.y;
    }

    private void Update()
    {
        currentDepth = transform.position.y;

        calculatedDepth = Mathf.Abs(currentDepth - startingDepth);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "TriggerOne")
        {
            level = DepthLevel.LevelOne;
            levelOneIndicator.sprite = full;
            levelTwoIndicator.sprite = empty;
            levelThreeIndicator.sprite = empty;
            levelFourIndicator.sprite = empty;
        }

        if (other.tag == "TriggerTwo")
        {
            level = DepthLevel.LevelTwo;
            levelTwoIndicator.sprite = full;
            levelThreeIndicator.sprite = empty;
            levelFourIndicator.sprite = empty;
            levelOneIndicator.sprite = empty;
        }

        if (other.tag == "TriggerThree")
        {
            level = DepthLevel.LevelThree;
            levelThreeIndicator.sprite = full;
            levelTwoIndicator.sprite = empty;
            levelFourIndicator.sprite = empty;
            levelOneIndicator.sprite = empty;
        }

        if (other.tag == "TriggerFour")
        {
            level = DepthLevel.LevelFour;
            levelFourIndicator.sprite = full;
            levelTwoIndicator.sprite = empty;
            levelThreeIndicator.sprite = empty;
            levelOneIndicator.sprite = empty;
        }
    }
}

public enum DepthLevel
{
    LevelOne,
    LevelTwo,
    LevelThree,
    LevelFour
}