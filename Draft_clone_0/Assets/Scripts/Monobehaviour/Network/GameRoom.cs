using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoom : NetworkBehaviour, IGameManager
{
    //public string GameID { get; private set; }
    [SyncVar] public string MatchID;
    private GameDataManager m_GameDataManager;

    private float m_StartDelay;
    private float m_AcummulatedTime;
    private float m_CombatAttackInterval;
    private int m_ShopPhaseDuration;
    private bool m_IsCombat;

    public void StartGame(List<PlayerNetwork> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].PlayerGameIndex = i;
            players[i].ClientStartGame();
        }

        m_IsCombat = false;
        m_StartDelay = 1;
        m_AcummulatedTime = 0;
        m_CombatAttackInterval = 3;
        m_ShopPhaseDuration = 40;

        m_GameDataManager = new GameDataManager(players);

        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(m_StartDelay);
        m_GameDataManager.StartShopPhase(m_ShopPhaseDuration);
        enabled = true;
    }

    private void Update()
    {
        m_AcummulatedTime += Time.deltaTime;
        if(m_IsCombat == true)
        {
            if(m_AcummulatedTime >= m_CombatAttackInterval)
            {
                m_AcummulatedTime -= m_CombatAttackInterval;
                m_IsCombat = m_GameDataManager.CombatStep();
                if(m_IsCombat == false)
                {
                    m_ShopPhaseDuration += Settings.ShopPhaseDurationIncrement;
                    m_GameDataManager.StartShopPhase(m_ShopPhaseDuration);
                    m_AcummulatedTime = 0;
                }
            }
        }
        else
        {
            if(m_AcummulatedTime >= m_ShopPhaseDuration)
            {
                m_GameDataManager.StartCombatPhase();
                m_AcummulatedTime = 0;
                m_IsCombat = true;
            }
        }
    }

    public void RequestRefreshShop(PlayerNetwork player)
    {
        m_GameDataManager.RequestRefreshShop(player.PlayerGameIndex);
    }

    public void RequestMoveCard(PlayerNetwork player, EPileType oldPile, int oldIndex,  EPileType newPile, int newIndex)
    {
        m_GameDataManager.RequestMoveCard(player.PlayerGameIndex, oldPile, oldIndex, newPile, newIndex);
    }
}
