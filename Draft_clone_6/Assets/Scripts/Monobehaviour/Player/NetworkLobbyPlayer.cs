using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class NetworkLobbyPlayer : NetworkBehaviour
{
    public static NetworkLobbyPlayer LocalPlayer;
    [SyncVar] public string MatchID;
    NetworkManagerDraft m_NetworkManager;


    private NetworkMatchChecker m_NetworkMatchChecker;

    private void Awake()
    {
        if (isLocalPlayer)
        {
            LocalPlayer = this;
        }
        m_NetworkMatchChecker = GetComponent<NetworkMatchChecker>();
        m_NetworkManager = NetworkManager.singleton as NetworkManagerDraft;
    }

    public void HostGame()
    {
        string matchID = MatchMaker.GetRandomMatchID();
        CmdHostGame(matchID);
    }

    [Command]
    private void CmdHostGame(string matchID)
    {
        MatchID = matchID;
        if(MatchMaker.Instance.HostGame(matchID, gameObject))
        {
            Debug.Log($"<color = green>Game hosted success</color>");
            m_NetworkMatchChecker.matchId = matchID.ToGuid();
        }
        else
        {
            Debug.Log($"<color = red>Game hosted failed</color>");
        }
    }

    public void ChangeSearchingPlayersText(int waitingPlayers)
    {
        ScreenFindMatchLogic.ChangePlayersInLobbyText(waitingPlayers);
    }

    public void StartSearchingGame()
    {
        m_NetworkManager.StartClient();
    }

    public void OnChangeStartMatchAnyway(bool newValue)
    {

    }
}
