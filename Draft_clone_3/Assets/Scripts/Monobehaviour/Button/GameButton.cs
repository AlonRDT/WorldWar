using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameButton : MonoBehaviour
{
    public abstract void StartMouseHover();
    public abstract void StopMouseHover();
    public abstract void Click();
}
