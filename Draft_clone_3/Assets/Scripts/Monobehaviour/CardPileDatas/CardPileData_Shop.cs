using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPileData_Shop : CardPileData
{
    public CardPileData_Shop(StateData state, EPileType type) : base(state, type, Settings.MaxCardsInShop)
    {

    }

    public List<CardRepresentation> ReplaceShopCards(List<CardRepresentation> newShopCards)
    {
        List<CardRepresentation> output = new List<CardRepresentation>();
        for (int i = 0; i < m_HeldCards.Length; i++)
        {
            if (m_HeldCards[i] != null)
            {
                output = output.Concat(m_HeldCards[i].GetCardsAndReset()).ToList();
                m_HeldCards[i] = null;
            }

            if (i < newShopCards.Count)
            {
                m_HeldCards[i] = new CardSlot(newShopCards[i]);
            }
        }

        return output;
    }

    public void RefreshShop()
    {
        List<CardRepresentation> newShopCards = m_State.Deck.GetShopCards(m_State.ShopLevel);
        int amountNeeded = newShopCards.Count;
        m_State.Deck.ReturnCardsToDeck(ReplaceShopCards(newShopCards));

        if (m_State.Player != null)
        {
            m_State.Player.ArrangeShopPlaceholders(amountNeeded);
        }
    }

    public void RequestRefereshShop()
    {
        if (m_State.PlayerMoney >= Settings.CardRefreshPrice)
        {
            m_State.PlayerMoney -= Settings.CardRefreshPrice;
            RefreshShop();
            if (m_State.Player != null)
            {
                m_State.Player.DestroyShopCards();
                LoadCardsToPlayerUI();
                m_State.UpdateShopPhaseStats();
            }
        }
    }

    public override void RelocateCard(int oldIndex, int newIndex)
    {
        
    }

    public override bool CanCardLeave()
    {
        return m_State.PlayerMoney >= Settings.CardBuyPrice;
    }

    public override bool CanCardEnter(int newIndex)
    {
        return false;
    }

    public override void TransferCard(int newIndex, CardPileData leavingPile, int oldIndex)
    {
        
    }

    protected override CardSlot removeCard(int oldIndex)
    {
        m_State.PlayerMoney -= Settings.CardBuyPrice;
        return base.removeCard(oldIndex);
    }
}
