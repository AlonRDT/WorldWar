using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateData
{
    public PlayerNetwork Player { get; private set; }
    public Deck Deck { get; private set; }
    public string Nickname { get; set; }
    public int ShopLevel { get; set; }
    public int ShopXP { get; set; }
    public int PlayerHealth { get; set; }
    public int PlayerMoney { get; set; }

    private int[] m_MatchHistoryBucket;

    public StateData(PlayerNetwork player, Deck deck, string nickname)
    {
        Player = player;
        Deck = deck;
        Nickname = nickname;

        ShopLevel = 1;
        ShopXP = 0;
        PlayerHealth = Settings.StartHealth;
        PlayerMoney = Settings.StartCardAmount;
        m_MatchHistoryBucket = new int[Settings.MaxPlayersToPlay];
        for (int i = 0; i < m_MatchHistoryBucket.Length; i++)
        {
            m_MatchHistoryBucket[i] = 0;
        }
    }

    public void StartShopPhase(int shopPhaseDuration)
    {
        if(Player != null)
        {
            Player.DestroyAllCards();
            Player.StartShopPhase(PlayerMoney, ShopXP, GetXPNeededToShopLevelUp(), shopPhaseDuration);
        }
    }

    public void UpdateShopPhaseStats()
    {
        Player.RefreshShopPhaseStats(PlayerMoney, ShopXP, GetXPNeededToShopLevelUp());
    }

    public int GetXPNeededToShopLevelUp()
    {
        if (ShopLevel >= 5)
        {
            return 0;
        }
        return Mathf.ClosestPowerOfTwo(ShopLevel + 1);
    }
}
