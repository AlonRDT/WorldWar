using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFindMatchLogic : MonoBehaviour
{
    private float timePassed = 0;
    private int currentTextIndex = 0;
    [SerializeField] private int m_NumOfTextStates = 4;
    [SerializeField] private float m_TimeToChangeTextInSeconds = 0.3f;
    [SerializeField] private Text m_SearchingText;
    [SerializeField] private Text m_PlayersInLobbyText;
    private static Text PlayersInLobbyText;


    private void Start()
    {
        PlayersInLobbyText = m_PlayersInLobbyText;
    }

    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > m_TimeToChangeTextInSeconds)
        {
            timePassed = 0;
            changeSearchText();
        }
    }

    public static void ChangePlayersInLobbyText(int waitingPlayers)
    {
        PlayersInLobbyText.text = waitingPlayers.ToString() + "/" + Settings.MaxPlayersToPlay.ToString();
    }

    private void changeSearchText()
    {
        currentTextIndex = (currentTextIndex + 1) % m_NumOfTextStates;
        switch (currentTextIndex)
        {
            case 0:
                m_SearchingText.text = "Searching Game";
                break;
            case 1:
                m_SearchingText.text = "Searching Game.";
                break;
            case 2:
                m_SearchingText.text = "Searching Game..";
                break;
            case 3:
                m_SearchingText.text = "Searching Game...";
                break;
            default:
                break;
        }
    }

    public void ToggleStartAnyway(bool newValue)
    {
        NetworkLobbyPlayer.LocalPlayer.OnChangeStartMatchAnyway(newValue);
    }
}
