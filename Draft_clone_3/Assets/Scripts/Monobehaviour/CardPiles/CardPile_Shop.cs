using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Shop : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 18f / 22f;
        m_PileHeightScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 1f;
        base.Start();
    }

    public override void ReturnCardToPlace(Button_Card cardToReturn)
    {
        
    }

    public override void AcceptNewCardToPile(Button_Card card)
    {
        Destroy(card.gameObject);
    }

    public override void RemoveCardFromPile(Button_Card card)
    {
        
    }
}
