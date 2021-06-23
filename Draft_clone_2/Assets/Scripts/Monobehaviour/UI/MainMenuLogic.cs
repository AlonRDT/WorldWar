using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainMenuLogic : MonoBehaviour
{
    private List<ScreenLogic> M_Screens;
    private EMenuScreen m_CurrentScreen;
    private List<MenuScreenTransition> m_ScreenTransitions;
    
    void Start()
    {
        m_CurrentScreen = EMenuScreen.BackgroundScreen;
        m_ScreenTransitions = Resources.LoadAll<MenuScreenTransition>("MenuTransitions").ToList();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuLevelDown();
        }
    }

    public void MenuLevelDown()
    {
        if(m_CurrentScreen == EMenuScreen.BackgroundScreen)
        {
            Application.Quit();
        }
        else
        {
            MenuScreenTransition targetTransition = m_ScreenTransitions.Find(a => a.m_CurrentScreen == m_CurrentScreen);
            getScreen(m_CurrentScreen).TurnScreenOff();
            getScreen(targetTransition.m_PreviousScreen).EnableScreen();
            m_CurrentScreen = targetTransition.m_PreviousScreen;
        }
    }

    public void MenuLevelUp(int nextLevelIndex)
    {
        MenuScreenTransition targetTransition = m_ScreenTransitions.Find(a => a.m_CurrentScreen == m_CurrentScreen);
        getScreen(m_CurrentScreen).DisableScreen();
        getScreen(targetTransition.m_NextScreen[nextLevelIndex]).TurnScreenOn();
        m_CurrentScreen = targetTransition.m_NextScreen[nextLevelIndex];
    }

    private ScreenLogic getScreen(EMenuScreen targetScreen)
    {
        return M_Screens.Find(a => a.ScreenType == targetScreen);
    }

    public void AddScreen(ScreenLogic newScreen)
    {
        if(M_Screens == null)
        {
            M_Screens = new List<ScreenLogic>();
        }

        M_Screens.Add(newScreen);
    }
}
