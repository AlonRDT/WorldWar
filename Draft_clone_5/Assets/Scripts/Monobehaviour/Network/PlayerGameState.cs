using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState
{
    private int m_DiplomacyLevel;
    private int m_HealthPoints;
    private int m_Money;
    private CardRepresentation[] m_Shop;
    private CardRepresentation[] m_Field;
    private CardRepresentation[] m_Hand;

    public PlayerGameState()
    {
        m_Shop = new CardRepresentation[Settings.MaxCardsInShop];
        m_Field = new CardRepresentation[Settings.MaxCardsInField];
        m_Hand = new CardRepresentation[Settings.MaxCardsInHand];
        for (int i = 0; i < 4; i++)
        {
            m_Field[i] = new CardRepresentation();
        }
        m_DiplomacyLevel = 1;
        m_HealthPoints = Settings.StartHealth;
        m_Money = 0;
    }
}
