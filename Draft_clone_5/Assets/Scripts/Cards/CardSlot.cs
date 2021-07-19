using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot
{
    private List<CardRepresentation> m_Cards;

    public CardSlot(CardRepresentation newCard)
    {
        m_Cards = new List<CardRepresentation>();
        m_Cards.Add(newCard);
    }

    public List<CardRepresentation> GetCardsAndReset()
    {
        List<CardRepresentation> output = m_Cards;
        m_Cards = null;
        return output;
    }

    public bool CanAddSlot()
    {
        return true;
    }

    public CardFinalData GenerateFinalCard()
    {
        CardFinalData output;

        output = new CardFinalData(m_Cards[0], getAttack(), getHealth(), getDiplomacyPoints(), getIncome(), getAbility(), getCardLevel());

        return output;
    }

    private int getHealth()
    {
        return m_Cards[0].Health * ((m_Cards.Count / Settings.RequiredCardsToUpdrade) + 1);
    }

    private int getAttack()
    {
        return m_Cards[0].Attack * ((m_Cards.Count / Settings.RequiredCardsToUpdrade) + 1);
    }

    private int getIncome()
    {
        return m_Cards[0].Income * ((m_Cards.Count / Settings.RequiredCardsToUpdrade) + 1);
    }

    private int getDiplomacyPoints()
    {
        return m_Cards[0].DiplomacyPoints * ((m_Cards.Count / Settings.RequiredCardsToUpdrade) + 1);
    }

    private ECardAbility getAbility()
    {
        return m_Cards[0].Ability;
    }

    private ECardLevel getCardLevel()
    {
        ECardLevel output = ECardLevel.Bronze;

        if(m_Cards.Count == 2)
        {
            output = ECardLevel.Silver;
        }
        else if (m_Cards.Count == 4)
        {
            output = ECardLevel.Gold;
        }

        return output;
    }
}
