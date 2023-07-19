using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCull : MonoBehaviour
{

    [SerializeField]PlayerController playerController;
    [Header("Art Layers")]
    bool isVisibleTopLayer = true;
    [SerializeField] GameObject topLayer;
    bool isVisibleFirstLayer = true;
    [SerializeField]GameObject firstLayer;
    bool isVisibleSecondLayer = true;
    [SerializeField]GameObject secondLayer;
    bool isVisibleThirdLayer = true;
    [SerializeField]GameObject thirdLayer;
    bool isVisibleFourthLayer = true;
    [SerializeField]GameObject fourthLayer;
    [Header("cull value")]
    public float layerTop;
    public float layerFirst;
    public float layerSecond;
    public float layerThird;
    public float layerFourth;

   

    // Update is called once per frame
    void Update()
    {
        LayerActive();
        topLayer.SetActive(isVisibleTopLayer);
        firstLayer.SetActive(isVisibleFirstLayer);
        secondLayer.SetActive(isVisibleSecondLayer);
        thirdLayer.SetActive(isVisibleThirdLayer);
        fourthLayer.SetActive(isVisibleFourthLayer);
    }
    private void LayerActive()
    {

        if (playerController.currentDepth > layerFourth)
        {
            isVisibleFirstLayer = false;
            isVisibleTopLayer = false;
            isVisibleSecondLayer = false;
            isVisibleThirdLayer = true;
            isVisibleFourthLayer = true;
        }
        else if (playerController.currentDepth > layerThird) 
        {
            isVisibleFirstLayer = false;
            isVisibleTopLayer = false;
            isVisibleSecondLayer = true;
            isVisibleThirdLayer = true;
            isVisibleFourthLayer = true;
        }
        else if (playerController.currentDepth > layerSecond)
        {
            isVisibleFirstLayer = true;
            isVisibleTopLayer = false;
            isVisibleSecondLayer = true;
            isVisibleThirdLayer = true;
            isVisibleFourthLayer = false;
        }
        else if (playerController.currentDepth > layerFirst)
        {
            isVisibleFirstLayer = true;
            isVisibleTopLayer = false;
            isVisibleSecondLayer = true;
            isVisibleThirdLayer = false;
            isVisibleFourthLayer = false;
        }
        else if (playerController.currentDepth > layerTop)
        {
            isVisibleFirstLayer = true;
            isVisibleTopLayer = true;
            isVisibleSecondLayer = false;
            isVisibleThirdLayer = false;
            isVisibleFourthLayer = false;
        }
    }

}
