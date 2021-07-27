using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Field : CardPile
{
    [SerializeField] private SpriteRenderer m_Background;
    // Start is called before the first frame update
    public new void Start()
    {
        m_IsInitializePlaceholders = true;
        m_ArrayRowSize = Settings.FieldCardsRows;
        m_ArrayColumnSize = Settings.FieldCardsColumns;
        m_PileLocationXScreenFraction = 0.4f;
        m_PileLocationYScreenFraction = 9f / 22f;
        m_PileWidthScreenFraction = 0.8f;
        m_PileHeightScreenFraction = 8f / 22f;

        base.Start();
    }

    public override void ReturnCardToPlace(Button_Card cardToAdd)
    {
        cardToAdd.gameObject.transform.position = Settings.GetScreenLocation(m_PileLocationXScreenFraction, m_PileLocationYScreenFraction, (int)EZLocation.Card);
    }

    public override void AcceptNewCardToPile(Button_Card card)
    {
        
    }

    public override void RemoveCardFromPile(Button_Card card)
    {
        
    }
}
