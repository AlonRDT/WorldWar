using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck
{
    private List<CardRepresentation>[] m_Cards = new List<CardRepresentation>[Settings.DiplomacyLevels];

    public Deck()
    {
        for (int i = 0; i < m_Cards.Length; i++)
        {
            m_Cards[i] = new List<CardRepresentation>();
        }
        CardData[] templates = Resources.LoadAll<CardData>("");

        foreach (var data in templates)
        {
            for (int i = 0; i < decideCardAmount(data.DiplomacyLevel); i++)
            {
                addCard(new CardRepresentation(data));
            }
        }
    }

    private int decideCardAmount(int diplomacyLevel)
    {
        int output = 8;
        output -= (diplomacyLevel - 1) * 2;
        if(output == 0)
        {
            output++;
        }
        return output * 4;
    }

    private void addCard(CardRepresentation card)
    {
        if (card.DiplomacyLevel > 0)
        {
            m_Cards[card.DiplomacyLevel].Add(card);
        }
    }

    public List<CardRepresentation> GetShopCards(int playerDiplomacyLevel)
    {
        int amount = 3 + playerDiplomacyLevel / 2;
        List<CardRepresentation> pool = new List<CardRepresentation>();

        for (int i = 0; i < playerDiplomacyLevel; i++)
        {
            pool.Concat(m_Cards[i]);
        }

        return getRandomCards(pool, amount);
    }

    private List<CardRepresentation> getRandomCards(List<CardRepresentation> pool, int amount)
    {
        List<CardRepresentation> output = new List<CardRepresentation>();
        CardRepresentation card;

        for (int i = 0; i < amount; i++)
        {
            card = pool[UnityEngine.Random.Range(0, pool.Count)];
            pool.Remove(card);
            m_Cards[card.DiplomacyLevel - 1].Remove(card);
            output.Add(card);
        }

        return output;
    }
}
