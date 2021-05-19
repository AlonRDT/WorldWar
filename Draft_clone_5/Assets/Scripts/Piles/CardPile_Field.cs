using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Field : CardPile
{
    // Start is called before the first frame update
    public new void Start()
    {
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 9f / 22f;
        m_PileHeightScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 1f;
        base.Start();
    }

    protected override void addNewCardToPile(Button_Card cardToAdd)
    {
        throw new System.NotImplementedException();
    }

    public override void ReturnCardToPlace(Button_Card cardToAdd)
    {
        throw new System.NotImplementedException();
    }

    protected override bool canCardEnter(Button_Card leavingCard)
    {
        throw new System.NotImplementedException();
    }

    protected override bool canCardLeave(Button_Card leavingCard)
    {
        throw new System.NotImplementedException();
    }
}
