using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLogic : MonoBehaviour
{
    private MainMenuLogic m_MainMenu;
    private Selectable[] m_Interactables;
    [SerializeField] private EMenuScreen m_ScreenType;

    public EMenuScreen ScreenType { get { return m_ScreenType; } }

    protected void Start()
    {
        m_Interactables = GetComponentsInChildren<Selectable>();
        m_MainMenu = transform.parent.GetComponent<MainMenuLogic>();
        m_MainMenu.AddScreen(this);
        if (m_ScreenType != EMenuScreen.BackgroundScreen)
        {
            TurnScreenOff();
        }
    }

    public void GoALevelDown()
    {
        m_MainMenu.MenuLevelDown();
    }

    public void GoALevelUp(int newLevelIndex)
    {
        m_MainMenu.MenuLevelUp(newLevelIndex);
    }

    public void TurnScreenOff()
    {
        gameObject.SetActive(false);
    }
    public void TurnScreenOn()
    {
        gameObject.SetActive(true);
    }
    public void DisableScreen()
    {
        foreach (Selectable selectable in m_Interactables)
        {
            selectable.interactable = false;
        }
    }
    public void EnableScreen()
    {
        foreach (Selectable selectable in m_Interactables)
        {
            selectable.interactable = true;
        }
    }
}
