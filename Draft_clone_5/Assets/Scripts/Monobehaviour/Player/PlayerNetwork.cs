using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.SceneManagement;

public class PlayerNetwork : NetworkBehaviour
{
    public static PlayerNetwork LocalPlayer;
    [SyncVar] public string MatchID;
    public bool StartAnyway;
    [SyncVar] public string Nickname;
    private NetworkManagerDraft m_NetworkManager;
    public PlayerGameState State { get; set; }

    private void Awake()
    {
        m_NetworkManager = NetworkManager.singleton as NetworkManagerDraft;
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        LocalPlayer = this;
        if (ScreenMatchSettingsLogic.DisplayName == "")
        {
            CmdSetDisplayName("Player");
        }
        else
        {
            CmdSetDisplayName(ScreenMatchSettingsLogic.DisplayName);
        }
    }

    [TargetRpc]
    public void ChangeSearchingPlayersText(int waitingPlayers)
    {
        ScreenFindMatchLogic.ChangePlayersInLobbyText(waitingPlayers);
    }

    [Command]
    public void OnChangeStartMatchAnyway(bool newValue)
    {
        StartAnyway = newValue;
        m_NetworkManager.CheckStartAnyway();
    }

    [TargetRpc]
    public void ClientStartGame(PlayerGameState startState)
    {
        SceneManager.LoadScene("Game");
    }

    [Command]
    public void ServerStartGame()
    {
        State = new PlayerGameState();
    }

    [Command]
    private void CmdSetDisplayName(string displayName)
    {
        Nickname = displayName;
    }
}
