using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Text m_PlayerNameText;
    // Start is called before the first frame update
    void Start()
    {
        m_PlayerNameText.text = PlayerNetwork.LocalPlayer.Nickname;
    }

    public void RefreshShop()
    {
        PlayerNetwork.LocalPlayer.RefreshShop();
    }
}
