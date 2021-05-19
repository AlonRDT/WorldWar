using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ScreenLogic : MonoBehaviour
{
    [SerializeField] private LobbyUIScreens screenType;
 
    public LobbyUIScreens ScreenType { get { return screenType; } }
    void Start()
    {
        screenType = (LobbyUIScreens)Enum.Parse(typeof(LobbyUIScreens) ,gameObject.name.Replace("Screen", ""));
    }

    public abstract void TurnScreenOff();
    public abstract void TurnScreenOn();
}
