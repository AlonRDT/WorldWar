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
        string matchID = getVerifiedMatchID();
        GameRoom newRoom = Instantiate(m_GameRoomPrefab, Vector3.zero, Quaternion.identity).GetComponent<GameRoom>();
        newRoom.MatchID = matchID;
        foreach (var player in m_PlayerQueue)
        {
            player.MatchID = matchID;
            player.GameManager = newRoom;
        }


        //DontDestroyOnLoad(newRoom);
        m_Games.Add(newRoom);
        //NetworkServer.Spawn(newRoom.gameObject);
        newRoom.StartGame(m_PlayerQueue);
        //Debug.Log("game room spawned");
        m_PlayerQueue.Clear();
        //Debug.Log("start game");
    }

    private string getRandomMatchID()
    {
        string id = string.Empty;

        for (int i = 0; i < 5; i++)
        {
            int random = UnityEngine.Random.Range(0, 36);
            if (random < 26)
            {
                id += (char)(random + 65);
            }
            else
            {
                id += (random - 26).ToString();
            }
        }

        return id;
    }

    private string getVerifiedMatchID()
    {
        string output = getRandomMatchID();

        while(!isMathIDAvailable(output))
        {
            output = getRandomMatchID();
        }

        return output;
    }

    private bool isMathIDAvailable(string input)
    {
        bool output = true;

        foreach (var room in m_Games)
        {
            if(room.MatchID == input)
            {
                output = false;
                break;
            }
        }

        return output;
    }
}
