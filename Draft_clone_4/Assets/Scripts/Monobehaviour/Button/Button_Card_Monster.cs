using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Card_Monster : Button_Card
{
    protected override void longClick()
    {
        Debug.Log("Long Click");
    }

    protected override void shortClick()
    {
        Debug.Log("Short Click");
    }
}
