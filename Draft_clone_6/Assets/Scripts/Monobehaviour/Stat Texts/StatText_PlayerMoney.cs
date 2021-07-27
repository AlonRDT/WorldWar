using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatText_PlayerMoney : StatText
{
    public static StatText Instance;

    protected new void Start()
    {
        Instance = this;

        m_PileLocationXScreenFraction = 0.95f;
        m_PileLocationYScreenFraction = 10f / 22f;
        m_TextColor = Color.yellow;

        base.Start();
    }
}
