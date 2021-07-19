using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour
{
    public void ShowStorePhase(PlayerGameState currentState)
    {
        Debug.Log(currentState.GetShopState() == null);
        CardPile_Shop.Instance.ReplaceCards(currentState.GetShopState());
    }

    public void AddCardToShop(CardFinalData newCard)
    {
        CardPile_Shop.Instance.CreateNewCard(newCard);
    }

    public void ArrangeShopCards()
    {
        CardPile_Shop.Instance.ArrangeCards();
    }

    public void DestroyShopCards()
    {
        CardPile_Shop.Instance.DestroyCards();
    }

    public void ShowCombatPhase(PlayerGameState currentState)
    {

    }
}
