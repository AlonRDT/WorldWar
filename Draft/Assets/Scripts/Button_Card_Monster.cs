using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Card_Monster : Button_Card
{
    public override void Click()
    {
        thisObject.GetComponent<Renderer>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
