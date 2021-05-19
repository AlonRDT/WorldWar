using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLogic_FindMatch : ScreenLogic
{
    private float timePassed = 0;
    private int currentTextIndex = 0;
    [SerializeField] private int numOfTextStates = 4;
    [SerializeField] private float timeToChangeTextInSeconds = 0.3f;
    [SerializeField] private Text searchingText;
    public override void TurnScreenOff()
    {
        gameObject.SetActive(false);
    }

    public override void TurnScreenOn()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > timeToChangeTextInSeconds)
        {
            timePassed = 0;
            changeText();
        }
    }

    private void changeText()
    {
        currentTextIndex = (currentTextIndex + 1) % numOfTextStates;
        switch (currentTextIndex)
        {
            case 0:
                searchingText.text = "Searching Game";
                break;
            case 1:
                searchingText.text = "Searching Game.";
                break;
            case 2:
                searchingText.text = "Searching Game..";
                break;
            case 3:
                searchingText.text = "Searching Game...";
                break;
            default:
                break;
        }
    }
}
