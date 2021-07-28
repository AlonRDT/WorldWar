using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Static_Refresh : Button_Static
{
    public static Button_Static_Refresh Instance;
    public override void Click()
    {
        PlayerNetwork.LocalPlayer.RequestRefreshShop();
    }

    public override void StartMouseHover()
    {

    }

    public override void StopMouseHover()
    {

    }

    protected new void Start()
    {
        Instance = this;

        m_PileLocationXScreenFraction = 0.9f;
        m_PileLocationYScreenFraction = 8f / 22f;
        m_PileWidthScreenFraction = 0.1f;
        m_PileHeightScreenFraction = 4f / 22f;

        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
