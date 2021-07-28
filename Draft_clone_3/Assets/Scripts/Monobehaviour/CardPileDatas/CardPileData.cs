using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardPileData
{
    protected CardSlot[] m_HeldCards;
    protected StateData m_State;
    public EPileType PileType { get; private set; }

    public CardPileData(StateData state, EPileType type, int arraySize)
    {
        m_State = state;
        PileType = type;
        if(arraySize > 0)
        {
            m_HeldCards = new CardSlot[arraySize];
        }
    }

    public void LoadCardsToPlayerUI()
    {
        if(m_State.Player != null)
        {
            for (int i = 0; i < m_HeldCards.Length; i++)
            {
                if(m_HeldCards[i] != null)
                {
                    m_State.Player.GenerateAndAddCardToCardPile(m_HeldCards[i].GenerateFinalCard(), PileType, i);
                }
            }
        }
    }

    public abstract void RelocateCard(int oldIndex, int newIndex);

    public abstract bool CanCardLeave();

    public abstract bool CanCardEnter(int newIndex);

    public abstract void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex);

    protected void moveCard(CardPileData leavingPile, int oldIndex, CardPileData enteringPile, int newIndex)
    {
        enteringPile.m_HeldCards[newIndex] = leavingPile.removeCard(oldIndex);

        if (m_State.Player != null)
        {
            m_State.Player.MoveCard(leavingPile.PileType, oldIndex, enteringPile.PileType, newIndex);
        }
    }



    public bool DoesCardExists(int index)
    {
        bool output = false;

        if(index >= 0 && index < m_HeldCards.Length)
        {
            if(m_HeldCards[index] != null)
            {
                output = true;
            }
        }

        return output;
    }

    protected virtual CardSlot removeCard(int oldIndex)
    {
        CardSlot output = m_HeldCards[oldIndex];
        m_HeldCards[oldIndex] = null;
        return output;
    }
}
