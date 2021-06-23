using Mirror;
using UnityEngine;

public class ScreenBackgroundLogic : MonoBehaviour
{
    NetworkManagerDraft m_NetworkManager;

    private void Start()
    {
        m_NetworkManager = NetworkManager.singleton as NetworkManagerDraft;
    }

    public void StartGameSearch()
    {
        m_NetworkManager.StartClient();
    }
}
