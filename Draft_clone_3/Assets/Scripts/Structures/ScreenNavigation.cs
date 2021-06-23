using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScreenNavigation
{
    public EMenuScreen CurrentScreen;
    public EMenuScreen PreviousScreen;
    public List<EMenuScreen> NextScreens;
}
