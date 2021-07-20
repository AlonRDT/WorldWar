using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerGameState
{
    public int DiplomacyLevel { get; private set; }
    private int m_HealthPoints;
    private int m_Money;
    private List<CardSlot> m_Shop;
    private CardSlot[] m_Field;
    private CardSlot[] m_Hand;



    public PlayerGameState()
    {

    }

    public PlayerGameState(CardSlot[] startField)
    {
        m_Hand = new CardSlot[Settings.MaxCardsInHand];
        m_Field = startField;
        m_Shop = new List<CardSlot>();

        DiplomacyLevel = 1;
        m_HealthPoints = Settings.StartHealth;
        m_Money = Settings.StartCardAmount;
    }

    public List<CardRepresentation> ReplaceShopCards(List<CardRepresentation> newShopCards)
    {
        List<CardRepresentation> output = new List<CardRepresentation>();
        foreach (var card in m_Shop)
        {
            output = output.Concat(card.GetCardsAndReset()).ToList();
        }
        m_Shop.Clear();
        //m_Shop = new List<CardSlot>();
        //Debug.Log("4");
        //Debug.Log(newShopCards.Count);
        foreach (var card in newShopCards)
        {
            m_Shop.Add(new CardSlot(card));
        }

        return output;
    }

    public List<CardSlot> GetShopState()
    {
        return m_Shop;
    }
}
