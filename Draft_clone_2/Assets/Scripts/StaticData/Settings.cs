using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static readonly int MaxCardsInHand = 7;
    public static readonly int MinPlayersToPlay = 2;
    public static readonly int MaxPlayersToPlay = 8;
    public static readonly int FieldCardsRows = 2;
    public static readonly int FieldCardsColumns = 4;
    public static readonly int DiplomacyLevels = 5;
    public static readonly int MaxCardsInShop = 7;
    public static readonly int StartHealth = 30;
    public static readonly int RequiredCardsToUpdrade = 4;
    public static readonly int StartCardAmount = 4;
    public static readonly int CardSellPrice = 1;
    public static readonly int CardBuyPrice = 2;
    public static readonly int CardRefreshPrice = 2;
    public static readonly int ShopPhaseDurationIncrement = 2;
    public static readonly int AmountOfPiles = Enum.GetNames(typeof(EPileType)).Length;
    public static volatile float ScreenSizeX = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
    public static volatile float ScreenSizeY = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

    public static Vector3 GetScreenLocation(float xScreenFraction, float yScreenFraction, int sortingOrder)
    {
        Vector3 output = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * xScreenFraction, Screen.height * yScreenFraction, 10 - sortingOrder)); ;

        return output;
    }

    public static Vector2 GetColliderSize(float widthFraction, float heightFraction)
    {
        Vector2 output = new Vector2(ScreenSizeX * 2 * widthFraction, ScreenSizeY * 2 * heightFraction);

        return output;
    }
}