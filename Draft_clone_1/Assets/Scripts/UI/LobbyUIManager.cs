using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private List<ScreenLogic> screens;
    private LobbyUIScreens currentScreen;
    
    void Start()
    {
        turnDownScreens();
        turnScreenOn(LobbyUIScreens.MainMenu);
        currentScreen = LobbyUIScreens.MainMenu;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }

    public void OpenScreen(LobbyUIScreens targetScreen)
    {
        turnScreenOff(currentScreen);
        currentScreen = targetScreen;
        turnScreenOn(currentScreen);
    }

    public void OpenScreen(int targetScreenIndex)
    {
        LobbyUIScreens targetScreen = (LobbyUIScreens)targetScreenIndex;
        turnScreenOff(currentScreen);
        currentScreen = targetScreen;
        turnScreenOn(currentScreen);
    }

    private void turnScreenOff(LobbyUIScreens targetScreen)
    {
        getScreen(targetScreen).TurnScreenOff();
    }

    private ScreenLogic getScreen(LobbyUIScreens targetScreen)
    {
        return screens.Find(a => a.ScreenType == targetScreen);
    }

    private void turnDownScreens()
    {
        foreach (ScreenLogic screen in screens)
        {
            screen.TurnScreenOff();
        }
    }

    private void turnScreenOn(LobbyUIScreens targetScreen)
    {
        getScreen(targetScreen).TurnScreenOn();
    }

    public void Exit()
    {
        switch (currentScreen)
        {
            case LobbyUIScreens.MainMenu:
                Application.Quit();
                break;
            default:
                OpenScreen(LobbyUIScreens.MainMenu);
                break;
        }
    }
}
