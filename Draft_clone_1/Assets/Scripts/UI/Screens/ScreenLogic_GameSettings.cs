using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLogic_GameSettings : ScreenLogic
{
    public override void TurnScreenOff()
    {
        gameObject.SetActive(false);
    }

    public override void TurnScreenOn()
    {
        gameObject.SetActive(true);
    }
}
