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
    private float m_TimeLeft;
    public int PlayerGameIndex { get; set; }

    public IGameManager GameManager { get; set; }

    private void Update()
    {
        m_TimeLeft -= Time.deltaTime;
        if (StatText_Timer.Instance != null)
        {
            StatText_Timer.Instance.SetText(Mathf.Ceil(Mathf.Max(m_TimeLeft, 0)).ToString());
        }
    }

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
    public void GenerateAndAddCardToCardPile(CardFinalData newCard, EPileType pileType, int index)
    {
        CardPileManager.GetCardPile(pileType).PlaceCard(Factory.Instance.GenerateCard(newCard), index);
    }

    [TargetRpc]
    public void DestroyShopCards()
    {
        CardPileManager.GetCardPile(EPileType.Shop).DestroyAllCards();
    }

    [TargetRpc]
    public void DestroyAllCards()
    {
        CardPileManager.DestroyAllButtons();
    }

    [TargetRpc]
    public void DestroyTargetCard(EPileType pile, int index)
    {
        CardPileManager.GetCardPile(pile).DestroyTargetCard(index);
    }

    [Command]
    public void RequestRefreshShop()
    {
        GameManager.RequestRefreshShop(this);
    }

    [Command]
    public void RequestMoveCard(EPileType oldPile, int oldIndex, EPileType newPile, int newIndex)
    {
        GameManager.RequestMoveCard(this, oldPile, oldIndex, newPile, newIndex);
    }

    [TargetRpc]
    public void MoveCard(EPileType oldPile, int oldIndex, EPileType newPile, int newIndex)
    {
        Button_Card transfer = CardPileManager.GetCardPile(oldPile).RemoveCard(oldIndex);
        CardPileManager.GetCardPile(newPile).PlaceCard(transfer, newIndex);
    }

    [TargetRpc]
    public void ArrangeShopPlaceholders(int amountNeeded)
    {
        CardPile_Shop shop = CardPileManager.GetCardPile(EPileType.Shop) as CardPile_Shop;
        shop.ArrangePlaceholders(amountNeeded);
    }

    [TargetRpc]
    public void RefreshShopPhaseStats(int money, int diplomacyPoints, int diplomacyPointsNeeded)
    {
        StatText_PlayerMoney.Instance.SetText(money.ToString());
        string diplomacy = diplomacyPoints.ToString() + "/" + diplomacyPointsNeeded.ToString();
        StatText_PlayerDiplomacy.Instance.SetText(diplomacy);
    }

    [TargetRpc]
    public void StartShopPhase(int money, int diplomacyPoints, int diplomacyPointsNeeded, int timeToCombat)
    {
        Button_Static_Refresh.Instance.ShowButton();
        m_TimeLeft = timeToCombat;
        StatText_Timer.Instance.ShowText();
        StatText_PlayerHealth.Instance.HideText();
        StatText_EnemyHealth.Instance.HideText();
        StatText_PlayerMoney.Instance.ShowText();
        StatText_PlayerDiplomacy.Instance.ShowText();
        StatText_PlayerMoney.Instance.SetText(money.ToString());
        string diplomacy = diplomacyPoints.ToString() + "/" + diplomacyPointsNeeded.ToString();
        StatText_PlayerDiplomacy.Instance.SetText(diplomacy);
    }

    [TargetRpc]
    public void StartCombatPhase(int playerHealth, int enemyHealth)
    {
        Button_Static_Refresh.Instance.HideButton();
        StatText_Timer.Instance.HideText();
        StatText_PlayerHealth.Instance.ShowText();
        StatText_EnemyHealth.Instance.ShowText();
        StatText_PlayerMoney.Instance.HideText();
        StatText_PlayerDiplomacy.Instance.HideText();
        StatText_PlayerHealth.Instance.SetText(playerHealth.ToString());
        StatText_EnemyHealth.Instance.SetText(enemyHealth.ToString());
    }

    [TargetRpc]
    public void RefreshCombatPhaseStats(int money, int diplomacyPoints, int diplomacyPointsNeeded)
    {

    }
}
