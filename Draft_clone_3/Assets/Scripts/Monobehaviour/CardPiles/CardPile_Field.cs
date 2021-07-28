using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Field : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = Settings.FieldCardsRows;
        m_ArrayColumnSize = Settings.FieldCardsColumns;
        m_PileLocationXScreenFraction = 0.4f;
        m_PileLocationYScreenFraction = 9f / 22f;
        m_PileWidthScreenFraction = 0.8f;
        m_PileHeightScreenFraction = 8f / 22f;

        base.Start();
    }
}
