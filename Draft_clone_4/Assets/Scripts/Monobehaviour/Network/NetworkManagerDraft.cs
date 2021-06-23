using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManagerDraft : NetworkManager
{
    [Header("Lobby")]
    [Scene] [SerializeField] private string m_MenuScene = string.Empty;
    [SerializeField] private GameObject m_LobbyPlayerPrefab = null;
    private List<NetworkLobbyPlayer> m_PlayerQueue = new List<NetworkLobbyPlayer>();


    [Header("Game")]
    [Scene] [SerializeField] private string m_GameScene = string.Empty;
    [SerializeField] private GameObject m_GamePlayerPrefab = null;
    private List<NetworkGameRoom> m_ActiveGames;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

        OnClientDisconnected?.Invoke();
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if (SceneManager.GetActiveScene().name == Path.GetFileNameWithoutExtension(m_MenuScene))
        {
            NetworkLobbyPlayer roomPlayerInstance = Instantiate(m_LobbyPlayerPrefab).GetComponent<NetworkLobbyPlayer>();

            m_PlayerQueue.Add(roomPlayerInstance);

            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);

            roomPlayerInstance.StartSearchingGame();

        }
    }

    public int GetPlayersInQeueAmount()
    {
        return m_PlayerQueue.Count;
    }

    public void UpdateSearchingPlayersText()
    {
        foreach (var player in m_PlayerQueue)
        {
            player.ChangeSearchingPlayersText(m_PlayerQueue.Count);
        }
    }
}
