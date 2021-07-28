using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileData_Field : CardPileData
{
    CardPileData_Hand m_Hand;
    CardPileData_Transition m_Transition;

    public CardPileData_Field(StateData state, EPileType type, CardPileData_Hand hand, CardPileData_Transition transition) : base(state, type, 0)
    {
        m_Hand = hand;
        m_Transition = transition;
        m_HeldCards = m_State.Deck.CreateStartField();
    }

    public override bool CanCardEnter(int newIndex)
    {
        bool output = false;

        if(m_HeldCards[newIndex] == null)
        {
            output = true;
        }
        else
        {
            output = m_Hand.CanCardEnter(0);
        }

        return output;
    }

    public override bool CanCardLeave()
    {
        return true;
    }

    public override void RelocateCard(int oldIndex, int newIndex)
    {
        if(m_HeldCards[newIndex] == null)
        {
            moveCard(this, oldIndex, this, newIndex);
        }
        else
        {
            moveCard(this, newIndex, m_Transition, 0);
            moveCard(this, oldIndex, this, newIndex);
            moveCard(m_Transition, 0, this, oldIndex);
        }
    }

    public override void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex)
    {
        if(m_HeldCards[newIndex] == null)
        {
            moveCard(leavingPile, oldIndex, this, newIndex);
        }
        else
        {
            moveCard(this, newIndex, m_Transition, 0);
            moveCard(leavingPile, oldIndex, this, newIndex);
            moveCard(m_Transition, 0, m_Hand, m_Hand.GetFirstAvailableIndex());
        }
    }
}
