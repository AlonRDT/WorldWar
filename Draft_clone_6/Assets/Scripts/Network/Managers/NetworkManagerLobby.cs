using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManagerLobby : NetworkManager
{
    [SerializeField] private int minPlayerAmount = 2;
    public int MinPlayerAmount { get { return minPlayerAmount; } set { minPlayerAmount = value; } }

    [Scene] [SerializeField] private string menuScene = string.Empty;

    public void test()
    {
        
    }
}
