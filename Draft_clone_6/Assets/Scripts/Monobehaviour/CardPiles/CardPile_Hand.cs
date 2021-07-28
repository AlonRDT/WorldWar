using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Hand : CardPile
{
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = 1;
        m_ArrayColumnSize = Settings.MaxCardsInHand;
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 2f / 22f;
        m_PileWidthScreenFraction = 1f;
        m_PileHeightScreenFraction = 4f / 22f;

        base.Start();
    }
}
