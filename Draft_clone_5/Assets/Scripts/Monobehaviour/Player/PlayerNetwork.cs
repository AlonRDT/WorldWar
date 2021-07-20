using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.SceneManagement;

public class PlayerNetwork : NetworkBehaviour
{
    [SyncVar] public string MatchID;
    [SyncVar] public string Nickname;
    public bool StartAnyway;
    public static PlayerNetwork LocalPlayer;
    private NetworkManagerDraft m_NetworkManager;
    public IGameManager GameManager { get; set; }

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
    public void ClientStartGame()
    {
        DontDestroyOnLoad(this);
        //GameManager.DontDestroyGameManagerOnLoad();
       // Debug.Log("client start");
        SceneManager.LoadScene("Game");
    }

    [Command]
    private void CmdSetDisplayName(string displayName)
    {
        //Debug.Log(displayName);
        Nickname = displayName;
    }

    [TargetRpc]
    public void AddCardToShop(CardFinalData newCard)
    {
        CardPile_Shop.Instance.CreateNewCard(newCard);
    }

    [TargetRpc]
    public void ArrangeShopCards()
    {
        CardPile_Shop.Instance.ArrangeCards();
    }

    [TargetRpc]
    public void DestroyShopCards()
    {
        CardPile_Shop.Instance.DestroyCards();
    }

    [Command]
    public void RefreshShop()
    {
        GameManager.RefreshShop(this);
    }
}
