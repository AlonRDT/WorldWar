using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Transition : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = 1;
        m_ArrayColumnSize = 1;
        m_PileLocationXScreenFraction = 0;
        m_PileLocationYScreenFraction = 0;
        m_PileHeightScreenFraction = 0f;
        m_PileWidthScreenFraction = 0;
        base.Start();
    }
}
