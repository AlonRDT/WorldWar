using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticipantData
{
    PlayerNetwork m_Player = null;
    private Deck m_Deck;
    public int DiplomacyLevel { get; private set; }
    private int m_DiplomacyPoints;
    private int m_Money;
    private CardSlot[] m_Shop;
    private CardSlot[] m_Field;
    private CardSlot[] m_Hand;
    private List<CardSlot> m_HandExtra;
    private int[] m_MatchHistoryBucket;
    public string Nickname { get; private set; }
    public int HealthPoints { get; private set; }
    public bool IsProcessingRequest { get; private set; }

    public ParticipantData(Deck deck, PlayerNetwork player)
    {
        m_Player = player;
        initialize(deck, m_Player.Nickname);
    }

    public ParticipantData(Deck deck, string computerName)
    {
        m_Player = null;
        initialize(deck, computerName);
    }

    private void initialize(Deck deck, string nickname)
    {
        m_Deck = deck;
        Nickname = nickname;
        m_Hand = new CardSlot[Settings.MaxCardsInHand];
        m_HandExtra = new List<CardSlot>();
        m_Field = deck.CreateStartField();
        m_Shop = new CardSlot[Settings.MaxCardsInShop];

        DiplomacyLevel = 1;
        m_DiplomacyPoints = 0;
        HealthPoints = Settings.StartHealth;
        m_Money = Settings.StartCardAmount;
        m_MatchHistoryBucket = new int[Settings.MaxPlayersToPlay];
        for (int i = 0; i < m_MatchHistoryBucket.Length; i++)
        {
            m_MatchHistoryBucket[i] = 0;
        }
    }

    public int GetDiplomacyPointsNeededToLevelUp()
    {
        if (DiplomacyLevel >= 5)
        {
            return 0;
        }
        return (DiplomacyLevel + 1) * (DiplomacyLevel + 1);
    }

    public void StartShopPhase(int shopPhaseDuration)
    {
        refreshShop();

        if (m_Player != null)
        {
            m_Player.DestroyAllCards();
            loadShopForPlayer();
            loadFieldForPlayer();
            loadHandForPlayer();
            m_Player.StartShopPhase(m_Money, m_DiplomacyPoints, GetDiplomacyPointsNeededToLevelUp(), shopPhaseDuration);
        }
    }

    private void loadShopForPlayer()
    {
        for (int i = 0; i < m_Shop.Length; i++)
        {
            m_Player.GenerateAndAddCardToCardPile(m_Shop[i].GenerateFinalCard(), EPileType.Shop, i);
        }
    }

    private void loadFieldForPlayer()
    {
        for (int i = 0; i < m_Field.Length; i++)
        {
            if (m_Field[i] != null)
            {
                m_Player.GenerateAndAddCardToCardPile(m_Field[i].GenerateFinalCard(), EPileType.Field, i);
            }
        }
    }

    private void loadHandForPlayer()
    {
        for (int i = 0; i < m_Hand.Length; i++)
        {
            if (m_Hand[i] != null)
            {
                m_Player.GenerateAndAddCardToCardPile(m_Hand[i].GenerateFinalCard(), EPileType.Hand, i);
            }
        }
    }

    private void loadBattleForPlayer(PlayerNetwork player1, PlayerNetwork player2)
    {

    }

    public List<CardRepresentation> ReplaceShopCards(List<CardRepresentation> newShopCards)
    {
        List<CardRepresentation> output = new List<CardRepresentation>();
        for (int i = 0; i < m_Shop.Length; i++)
        {
            if (m_Shop[i] != null)
            {
                output = output.Concat(m_Shop[i].GetCardsAndReset()).ToList();
                m_Shop[i] = null;
            }

            if(i < newShopCards.Count)
            {
                m_Shop[i] = new CardSlot(newShopCards[i]);
            }
        }

        return output;
    }

    private void refreshShop()
    {
        m_Deck.ReturnCardsToDeck(ReplaceShopCards(m_Deck.GetShopCards(DiplomacyLevel)));
    }

    public void RequestRefereshShop()
    {
        IsProcessingRequest = true;

        if (m_Money >= Settings.CardRefreshPrice)
        {
            m_Money -= Settings.CardRefreshPrice;
            refreshShop();
            if (m_Player != null)
            {
                m_Player.DestroyShopCards();
                loadShopForPlayer();
                m_Player.RefreshShopPhaseStats(m_Money, m_DiplomacyPoints, GetDiplomacyPointsNeededToLevelUp());
            }
        }

        IsProcessingRequest = false;
    }


    internal void RequestMoveCard(EPileType oldPile, int oldIndex, EPileType newPile, int newIndex)
    {
        throw new NotImplementedException();
    }
}
