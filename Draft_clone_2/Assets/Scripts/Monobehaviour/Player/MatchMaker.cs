using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Text;
using System.Security.Cryptography;

[System.Serializable]
public class Match
{
    public string MatchID;
    public SyncListGameObject Players = new SyncListGameObject();

    public Match(string matchID, GameObject firstPlayer)
    {
        this.MatchID = matchID;
        Players.Add(firstPlayer);
    }

    public Match()
    {

    }
}

[System.Serializable]
public class SyncListGameObject : SyncList<GameObject>
{

}

[System.Serializable]
public class SyncListMatch : SyncList<Match>
{

}

public class MatchMaker : NetworkBehaviour
{
    public static MatchMaker Instance;

    public SyncListMatch Matches = new SyncListMatch();

    public SyncList<string> MatchIDs = new SyncList<string>();

    private void Start()
    {
        Instance = this;
    }

    public bool HostGame(string matchID, GameObject firstPlayer)
    {
        bool output = true;
        if (!MatchIDs.Contains(matchID))
        {
            MatchIDs.Add(matchID);
            Matches.Add(new Match(matchID, firstPlayer));
            Debug.Log("Match generated");
        }
        else
        {
            Debug.Log("Match ID exists");
            output = false;
        }

        return output;
    }

    public static string GetRandomMatchID()
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

}

public static class MatchExtensions
{
    public static Guid ToGuid(this string id)
    {
        MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();
        byte[] inputBytes = Encoding.Default.GetBytes(id);
        byte[] hashBytes = provider.ComputeHash(inputBytes);

        return new Guid(hashBytes);
    }
}
