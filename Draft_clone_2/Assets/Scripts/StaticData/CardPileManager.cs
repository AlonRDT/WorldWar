using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardPileManager
{
    private static CardPile[] m_Piles = new CardPile[Settings.AmountOfPiles];

    public static CardPile GetCardPile(EPileType type)
    {
        return m_Piles[(int)type];
    }

    public static void RegisterPile(CardPile pile, EPileType index)
    {
        m_Piles[(int)index] = pile;
    }

    public static void DestroyAllButtons()
    {
        foreach (var pile in m_Piles)
        {
            pile.DestroyAllCards();
        }
    }
}
