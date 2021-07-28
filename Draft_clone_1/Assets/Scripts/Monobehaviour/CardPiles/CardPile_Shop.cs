using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Shop : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_IsInitializePlaceholders = false;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = 1;
        m_ArrayColumnSize = Settings.MaxCardsInShop;
        m_PileLocationXScreenFraction = 0.6f;
        m_PileLocationYScreenFraction = 18f / 22f;
        m_PileHeightScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 0.8f;
        base.Start();
    }

    public void ArrangePlaceholders(int amountNeeded)
    {
        for (int i = 0; i < m_CardPlaceholders.Length; i++)
        {
            if(i < amountNeeded)
            {
                placeCardPlaceholder(i, 1, amountNeeded);
            }
            else
            {
                m_CardPlaceholders[i].transform.position = Vector3.zero;
                m_CardPlaceholders[i].SetLocation(0, 0);
            }
        }
    }
}
