using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck
{
    private List<CardRepresentation>[] m_Cards = new List<CardRepresentation>[Settings.DiplomacyLevels];
    private CardData m_StartCardData;

    public Deck()
    {
        for (int i = 0; i < m_Cards.Length; i++)
        {
            m_Cards[i] = new List<CardRepresentation>();
        }
        CardData[] templates = Resources.LoadAll<CardData>("");
        foreach (var data in templates)
        {
            if (data.DiplomacyLevel == 0)
            {
                m_StartCardData = data;
                //Debug.Log("Dip 0");
            }
            else
            {
                for (int i = 0; i < decideCardAmount(data.DiplomacyLevel); i++)
                {
                    addCard(new CardRepresentation(data));
                }
            }
        }
    }

    private int decideCardAmount(int diplomacyLevel)
    {
        int output = 6 - diplomacyLevel;

        return output * Settings.RequiredCardsToUpdrade;
    }

    private void addCard(CardRepresentation card)
    {
        if (card.DiplomacyLevel > 0)
        {
            m_Cards[card.DiplomacyLevel - 1].Add(card);
        }
    }

    public List<CardRepresentation> GetShopCards(int playerDiplomacyLevel)
    {
        int amount = Settings.MaxCardsInShop - 2 + playerDiplomacyLevel / 2;
        List<CardRepresentation> pool = new List<CardRepresentation>();

        for (int i = 0; i < playerDiplomacyLevel; i++)
        {
            //Debug.Log("card per level" + m_Cards[i].Count);
            pool = pool.Concat(m_Cards[i]).ToList();
            //Debug.Log("pool size" + pool.Count);
        }

        return getRandomCards(pool, amount);
    }

    private List<CardRepresentation> getRandomCards(List<CardRepresentation> pool, int amount)
    {
        List<CardRepresentation> output = new List<CardRepresentation>();
        CardRepresentation card;

        //Debug.Log("amount " + amount);
        for (int i = 0; i < amount; i++)
        {
            card = pool[UnityEngine.Random.Range(0, pool.Count)];
            //Debug.Log("index " + index);
            pool.Remove(card);
            m_Cards[card.DiplomacyLevel - 1].Remove(card);
            output.Add(card);
        }
        return output;
    }

    public CardSlot[] CreateStartField()
    {
        CardSlot[] output = new CardSlot[Settings.FieldCardsRows * Settings.FieldCardsColumns];
        for (int i = 0; i < Settings.StartCardAmount; i++)
        {
            output[i] = new CardSlot(new CardRepresentation(m_StartCardData));
        }
        return output;
    }

    public void ReturnCardsToDeck(List<CardRepresentation> returningCards)
    {
        //Debug.Log("returning cards " + returningCards.Count);
        foreach (var card in returningCards)
        {
            if (card.DiplomacyLevel > 0)
            {
                m_Cards[card.DiplomacyLevel - 1].Add(card);
            }
        }
    }

    public int GetCardAmount(int tier)
    {
        return m_Cards[tier - 1].Count;
    }
}
