using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button_Card : Button
{
    protected override void targetStart()
    {
        thisObject.transform.localScale = new Vector3(12, 12, 12);
    }

    protected override void targetEnd()
    {
        thisObject.transform.localScale = new Vector3(10, 10, 10);
    }

    protected override void disengaged()
    {
        throw new System.NotImplementedException();
    }

    protected override void updateWhileDisengaged()
    {
        Debug.Log("Update");
    }

    protected override void updateWhileEngaged()
    {
        
    }
}
