using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Hand : CardPile
{
    private List<Button_Card> m_HeldCards;

    public new void Start()
    {
        m_HeldCards = new List<Button_Card>();
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 2f / 22f;
        m_PileHeightScreenFraction = 4f / 22f;
        m_PileWidthScreenFraction = 1f;
        base.Start();
    }

    protected override void addNewCardToPile(Button_Card cardToAdd)
    {
        
    }

    public override void ReturnCardToPlace(Button_Card cardToAdd)
    {
        
    }

    protected override bool canCardEnter(Button_Card leavingCard)
    {
        return true;
    }

    protected override bool canCardLeave(Button_Card leavingCard)
    {
        return true;
    }
}
