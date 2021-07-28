using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPileData_Hand : CardPileData
{
    private List<CardSlot> m_ExtraCards;

    public CardPileData_Hand(StateData state, EPileType type) : base(state, type, Settings.MaxCardsInHand)
    {
        m_ExtraCards = new List<CardSlot>();
    }

    public override bool CanCardEnter(int newIndex)
    {
        bool output = false;

        for (int i = 0; i < m_HeldCards.Length; i++)
        {
            if (m_HeldCards[i] == null)
            {
                output = true;
                break;
            }
        }

        return output;
    }

    public override bool CanCardLeave()
    {
        return true;
    }

    public override void RelocateCard(int oldIndex, int newIndex)
    {
        if (m_HeldCards[newIndex] != null)
        {
            CardSlot movingCard = removeCard(oldIndex);
            if (m_State.Player != null)
            {
                m_State.Player.MoveCard(PileType, oldIndex, EPileType.Transition, 0);
            }

            clearIndex(newIndex);
            m_HeldCards[newIndex] = movingCard;
            if (m_State.Player != null)
            {
                m_State.Player.MoveCard(EPileType.Transition, 0, PileType, newIndex);
            }
        }
        else
        {
            moveCard(this, oldIndex, this, newIndex);
        }

    }

    public override void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex)
    {
        if (m_HeldCards[newIndex] != null)
        {
            clearIndex(newIndex);
        }
        moveCard(leavingPile, oldIndex, this, newIndex);
    }

    private void clearIndex(int newIndex)
    {
        int emptyIndex = -1;
        for (int i = 0; i < m_HeldCards.Length; i++)
        {
            if (m_HeldCards[i] == null)
            {
                emptyIndex = i;
                if (i > newIndex)
                {
                    break;
                }
            }
        }

        while (newIndex != emptyIndex)
        {
            if (newIndex > emptyIndex)
            {
                moveCard(this, emptyIndex + 1, this, emptyIndex);
                emptyIndex++;
            }
            else
            {
                moveCard(this, emptyIndex - 1, this, emptyIndex);
                emptyIndex--;
            }
        }
    }

    public void StuffExtraCards()
    {
        if (m_ExtraCards.Count > 0)
        {
            for (int i = 0; i < m_HeldCards.Length; i++)
            {
                if (m_HeldCards[i] == null)
                {
                    m_HeldCards[i] = m_ExtraCards[0];
                    m_ExtraCards.RemoveAt(0);

                    if (m_State.Player != null)
                    {
                        m_State.Player.GenerateAndAddCardToCardPile(m_HeldCards[i].GenerateFinalCard(), PileType, i);
                    }

                    if (m_ExtraCards.Count < 1)
                    {
                        break;
                    }
                }
            }

        }
    }

    public int GetFirstAvailableIndex()
    {
        int output = 0;

        for (int i = 0; i < m_HeldCards.Length; i++)
        {
            if (m_HeldCards[i] == null)
            {
                output = i;
                break;
            }
        }

        return output;
    }
}
