using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    [SerializeField]
    protected GameObject thisObject;
    public abstract void Click();
}
