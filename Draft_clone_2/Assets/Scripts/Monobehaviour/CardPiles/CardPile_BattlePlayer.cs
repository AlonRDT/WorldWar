using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_BattlePlayer : CardPile
{
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_IsInitializePlaceholdersFromTop = true;
        m_ArrayRowSize = Settings.FieldCardsRows;
        m_ArrayColumnSize = Settings.FieldCardsColumns;
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 0.5f;
        m_PileHeightScreenFraction = 0f;
        m_PileWidthScreenFraction = 0f;
        base.Start();
    }
}
