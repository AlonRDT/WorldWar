using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoom : NetworkBehaviour, IGameManager
{
    //public string GameID { get; private set; }
    [SyncVar] public string MatchID;
    private Dictionary<PlayerNetwork, PlayerGameState> m_PlayerStates;
    private Deck m_Deck;
    private float m_AcummulatedTime;
    private float m_WaitToShopPhase;

    public void StartGame(List<PlayerNetwork> players)
    {
        m_PlayerStates = new Dictionary<PlayerNetwork, PlayerGameState>();
        m_Deck = new Deck();
        foreach (var player in players)
        {
            m_PlayerStates.Add(player, new PlayerGameState(m_Deck.CreateStartField()));
            //Debug.Log(player.Nickname);
            player.ClientStartGame();
        }
        m_AcummulatedTime = 0;
        m_WaitToShopPhase = 1;
    }

    private void Update()
    {
        m_AcummulatedTime += Time.deltaTime;
        if(m_WaitToShopPhase != 0 && m_AcummulatedTime > m_WaitToShopPhase)
        {
            startShopPhase();
            m_WaitToShopPhase = 0;
        }
    }

    private void startShopPhase()
    {
        foreach (KeyValuePair<PlayerNetwork, PlayerGameState> player in m_PlayerStates)
        {
            RefreshShop(player.Key);
        }
    }

    public void RefreshShop(PlayerNetwork player)
    {
        //Debug.Log("7");
        PlayerGameState state = m_PlayerStates[player];
        //Debug.Log("deck " + m_Deck.GetCardAmount(1));
        m_Deck.ReturnCardsToDeck(state.ReplaceShopCards(m_Deck.GetShopCards(state.DiplomacyLevel)));
        //Debug.Log("shop amount " + state.GetShopState().Count);
        //Debug.Log("deck " + m_Deck.GetCardAmount(1));
        List<CardSlot> shopCards = state.GetShopState();
        player.DestroyShopCards();
        foreach (var card in shopCards)
        {
            player.AddCardToShop(card.GenerateFinalCard());
        }
        player.ArrangeShopCards();
    }
}
