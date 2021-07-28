using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileData_Transition : CardPileData
{
    public CardPileData_Transition(StateData state, EPileType type) : base(state, type, 1)
    {

    }

    public override bool CanCardEnter(int newIndex)
    {
        bool output = false;

        if(m_HeldCards[newIndex] != null)
        {
            output = true;
        }

        return output;
    }

    public override bool CanCardLeave()
    {
        return true;
    }

    public override void RelocateCard(int oldIndex, int newIndex)
    {
        
    }

    public override void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex)
    {
        moveCard(leavingPile, oldIndex, this, newIndex);
    }
}
