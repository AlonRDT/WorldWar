using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileData_Sell : CardPileData
{
    public CardPileData_Sell(StateData state, EPileType type) : base(state, type, 0)
    {

    }

    public override bool CanCardEnter(int newIndex)
    {
        return true;
    }

    public override bool CanCardLeave()
    {
        return false;
    }

    public override void RelocateCard(int oldIndex, int newIndex)
    {
        
    }

    public override void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex)
    {
        m_State.PlayerMoney += Settings.CardSellPrice;

        if(m_State.Player != null)
        {
            m_State.Player.DestroyTargetCard(PileType, oldIndex);
        }
    }
}
