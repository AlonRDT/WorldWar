using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticipantData
{
    private StateData m_State;
    private CardPileData_Shop m_PileShop;
    private CardPileData_Field m_PileField;
    private CardPileData_Hand m_PileHand;
    private CardPileData_Sell m_PileSell;
    private CardPileData_Transition m_PileTransition;

    public bool IsProcessingRequest { get; private set; }

    public ParticipantData(Deck deck, PlayerNetwork player)
    {
        m_State = new StateData(player, deck, player.Nickname);
        initializeCardPiles();
    }

    public ParticipantData(Deck deck, string computerName)
    {
        m_State = new StateData(null, deck, computerName);
        initializeCardPiles();
    }

    private void initializeCardPiles()
    {

        m_PileTransition = new CardPileData_Transition(m_State, EPileType.Transition);
        m_PileHand = new CardPileData_Hand(m_State, EPileType.Hand);
        m_PileField = new CardPileData_Field(m_State, EPileType.Field, m_PileHand, m_PileTransition);
        m_PileShop = new CardPileData_Shop(m_State, EPileType.Shop);
        m_PileSell = new CardPileData_Sell(m_State, EPileType.Sell);
    }

    private CardPileData getPileByType(EPileType type)
    {
        CardPileData output = null;

        switch (type)
        {
            case EPileType.Field:
                output = m_PileField;
                break;
            case EPileType.Sell:
                output = m_PileSell;
                break;
            case EPileType.Shop:
                output = m_PileShop;
                break;
            case EPileType.Hand:
                output = m_PileHand;
                break;
            case EPileType.Transition:
                output = m_PileTransition;
                break;
            case EPileType.BattlePlayer:
                break;
            case EPileType.BattleEnemy:
                break;
            default:
                break;
        }

        return output;
    }


    public void StartShopPhase(int shopPhaseDuration)
    {
        m_PileShop.RefreshShop();
        m_State.StartShopPhase(shopPhaseDuration);
        m_PileShop.LoadCardsToPlayerUI();
        m_PileField.LoadCardsToPlayerUI();
        m_PileHand.LoadCardsToPlayerUI();
    }

    public void RequestRefereshShop()
    {
        IsProcessingRequest = true;

        m_PileShop.RequestRefereshShop();

        IsProcessingRequest = false;
    }


    internal void RequestMoveCard(EPileType oldPile, int oldIndex, EPileType newPile, int newIndex)
    {
        IsProcessingRequest = true;

        CardPileData leavingPile = getPileByType(oldPile), enteringPile = getPileByType(newPile);
        if (leavingPile.DoesCardExists(oldIndex) == true)
        {
            if (oldPile == newPile)
            {
                leavingPile.RelocateCard(oldIndex, newIndex);
            }
            else if (leavingPile.CanCardLeave() == true && enteringPile.CanCardEnter(newIndex) == true)
            {
                enteringPile.TransferCard(newIndex, leavingPile, oldIndex);
            }

            m_PileHand.StuffExtraCards();
        }

        IsProcessingRequest = false;
    }
}
