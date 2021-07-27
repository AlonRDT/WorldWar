using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Hand : CardPile
{
    [SerializeField] private SpriteRenderer m_Background;
    public new void Start()
    {
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 2f / 22f;
        m_PileWidthScreenFraction = 1f;
        m_PileHeightScreenFraction = 4f / 22f;

        base.Start();
    }

    

    public override void ReturnCardToPlace(Button_Card cardToReturn)
    {
        cardToReturn.gameObject.transform.position = Settings.GetScreenLocation(m_PileLocationXScreenFraction, m_PileLocationYScreenFraction, (int)EZLocation.Card);
    }

    public override void AcceptNewCardToPile(Button_Card card)
    {
        card.HoldingPileType = PileType;
        
        ReturnCardToPlace(card);
    }

    public override void RemoveCardFromPile(Button_Card card)
    {
        
    }
}
