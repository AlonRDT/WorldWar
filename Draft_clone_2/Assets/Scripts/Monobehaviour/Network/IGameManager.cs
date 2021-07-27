using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void RequestRefreshShop(PlayerNetwork player);
    void RequestMoveCard(PlayerNetwork player, EPileType oldPile, int oldIndex, EPileType newPile, int newIndex);
}
