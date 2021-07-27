using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_BattleEnemy : CardPile
{
    public override void ReturnCardToPlace(Button_Card card)
    {
        throw new System.NotImplementedException();
    }

    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_ArrayRowSize = Settings.FieldCardsRows;
        m_ArrayColumnSize = Settings.FieldCardsColumns;
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 0.5f;
        m_PileHeightScreenFraction = 0f;
        m_PileWidthScreenFraction = 0f;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void AcceptNewCardToPile(Button_Card card)
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveCardFromPile(Button_Card card)
    {
        throw new System.NotImplementedException();
    }
}
