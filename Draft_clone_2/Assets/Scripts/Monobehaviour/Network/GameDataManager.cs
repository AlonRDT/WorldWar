using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private ParticipantData[] m_Participants;

    public GameDataManager(List<PlayerNetwork> players)
    {
        Deck deck = new Deck();
        m_Participants = new ParticipantData[Settings.MaxPlayersToPlay];

        int computerCounter = 1;
        for (int i = 0; i < m_Participants.Length; i++)
        {
            if (i < players.Count)
            {
                m_Participants[i] = new ParticipantData(deck, players[i]);
            }
            else
            {
                m_Participants[i] = new ParticipantData(deck, "Computer" + computerCounter.ToString());
                computerCounter++;
            }
        }
    }

    internal void StartShopPhase(int shopPhaseDuration)
    {
        foreach (var participant in m_Participants)
        {
            participant.StartShopPhase(shopPhaseDuration);
        }
    }

    internal bool CombatStep()
    {
        throw new NotImplementedException();
    }

    internal void StartCombatPhase()
    {
        throw new NotImplementedException();
    }

    internal void RequestRefreshShop(int playerIndex)
    {
        if (m_Participants[playerIndex].IsProcessingRequest == false)
        {
            m_Participants[playerIndex].RequestRefereshShop();
        }
    }

    internal void RequestMoveCard(int playerIndex, EPileType oldPile, int oldIndex, EPileType newPile, int newIndex)
    {
        if (m_Participants[playerIndex].IsProcessingRequest == false)
        {
            m_Participants[playerIndex].RequestMoveCard(oldPile, oldIndex, newPile, newIndex);
        }
    }
}
