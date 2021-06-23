using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPile_Test : CardPile
{

    // Start is called before the first frame update
    public new void Start()
    {
        m_PileLocationXScreenFraction = 0.5f;
        m_PileLocationYScreenFraction = 0.875f;
        m_PileHeightScreenFraction = 0.25f;
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
