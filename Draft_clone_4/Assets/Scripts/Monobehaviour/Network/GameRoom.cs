using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoom : NetworkBehaviour
{
    //public string GameID { get; private set; }
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
            m_PlayerStates.Add(player, new PlayerGameState(m_Deck.CreateStartField(), m_Deck.GetShopCards(1)));
            //Debug.Log("end start");
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
        List<CardSlot> shopCards = m_PlayerStates[player].GetShopState();
        player.DestroyShopCards();
        foreach (var card in shopCards)
        {
            player.AddCardToShop(card.GenerateFinalCard());
            card.GenerateFinalCard().PrintAttribute();
        }
        player.ArrangeShopCards();
    }
}
