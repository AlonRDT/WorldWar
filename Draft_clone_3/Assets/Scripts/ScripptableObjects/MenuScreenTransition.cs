using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MenuTransition")]
public class MenuScreenTransition : ScriptableObject
{
    public EMenuScreen m_CurrentScreen;
    public EMenuScreen m_PreviousScreen;
    public EMenuScreen[] m_NextScreen;
}
