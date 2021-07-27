using ParrelSync;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkRoleManager : MonoBehaviour
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
        else
        {
            SceneManager.LoadScene("Lobby");
        }
    }
}
