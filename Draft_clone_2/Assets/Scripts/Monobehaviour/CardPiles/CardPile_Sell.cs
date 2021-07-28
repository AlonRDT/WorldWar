using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Sell : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = 1;
        m_ArrayColumnSize = 1;
        m_PileLocationXScreenFraction = 0.1f;
        m_PileLocationYScreenFraction = 18f / 22f;
        m_PileHeightScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 0.2f;
        base.Start();
    }
}
