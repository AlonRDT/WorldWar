using ParrelSync;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private NetworkManagerDraft m_NetworkManager;

    // Start is called before the first frame update
    void Start()
    {
        m_NetworkManager = NetworkManager.singleton as NetworkManagerDraft;
        if (ClonesManager.GetArgument() == "Server")
        {
            m_NetworkManager.StartServer();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
