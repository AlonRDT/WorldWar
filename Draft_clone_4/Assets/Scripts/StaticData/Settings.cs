using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    public static readonly int MaxCardsInHand = 7;
    public static readonly int MinPlayersToPlay = 2;
    public static readonly int MaxPlayersToPlay = 8;
    public static volatile float ScreenSizeX = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f;
    public static volatile float ScreenSizeY = Vector2.Distance(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)), Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;
}
