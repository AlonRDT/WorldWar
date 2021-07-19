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
    [SerializeField] private GameObject m_PlayerPrefab = null;
    private List<PlayerNetwork> m_PlayerQueue = new List<PlayerNetwork>();


    [Header("Game")]
    [Scene] [SerializeField] private string m_GameScene = string.Empty;
    private List<Match> m_ActiveGames;

    [SerializeField] private GameObject m_GameRoomPrefab;
    private List<GameRoom> m_Games = new List<GameRoom>();

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
        PlayerNetwork roomPlayerInstance = Instantiate(m_PlayerPrefab).GetComponent<PlayerNetwork>();

        m_PlayerQueue.Add(roomPlayerInstance);

        NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);

        UpdateSearchingPlayersText();
    }



    public override void OnServerDisconnect(NetworkConnection conn)
    {
        foreach (var player in conn.clientOwnedObjects)
        {
            PlayerNetwork disconnectedPlayer = player.gameObject.GetComponent<PlayerNetwork>();
            if (disconnectedPlayer != null)
            {
                m_PlayerQueue.Remove(disconnectedPlayer);
            }
        }

        UpdateSearchingPlayersText();

        base.OnServerDisconnect(conn);
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

    public void CheckStartAnyway()
    {
        int numberOfStartAnywayPlayers = 0;
        foreach (var player in m_PlayerQueue)
        {
            if (player.StartAnyway == true)
            {
                numberOfStartAnywayPlayers++;
            }
        }

        //Debug.Log(numberOfStartAnywayPlayers);
        if (numberOfStartAnywayPlayers == m_PlayerQueue.Count)// && numberOfStartAnywayPlayers > 1)
        {
            StartGameForQueue();
        }
    }

    private void StartGameForQueue()
    {
        GameRoom newRoom = Instantiate(m_GameRoomPrefab, Vector3.zero, Quaternion.identity).GetComponent<GameRoom>();
        //DontDestroyOnLoad(newRoom);
        NetworkServer.Spawn(newRoom.gameObject);
        m_Games.Add(newRoom);
        newRoom.StartGame(m_PlayerQueue);
        m_PlayerQueue.Clear();
        //Debug.Log("start game");
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);
    }
}
