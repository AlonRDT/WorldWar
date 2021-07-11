using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameRoom : MonoBehaviour
{
    //public string GameID { get; private set; }
    private List<PlayerNetwork> m_Players;
    private Deck m_Deck;

    public void StartGame(List<PlayerNetwork> players)
    {
        m_Players = players;
        m_Deck = new Deck();
        foreach (var player in m_Players)
        {
            player.ServerStartGame();
            player.ClientStartGame(player.State);
        }
    }
}
